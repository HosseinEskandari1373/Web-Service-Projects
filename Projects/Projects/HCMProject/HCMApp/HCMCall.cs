using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Tooling.Connector;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.ServiceModel;
using FormModel;
using SecurityLayer;
using System.Security;
using Microsoft.Xrm.Sdk.Discovery;
using System.Text;
using System.IO;
using System.ServiceProcess;
using System.Threading;

namespace HCMApp
{
    public class HCMCall : ServiceBase
    {
        System.Timers.Timer tmrDelay = new System.Timers.Timer(10000);//10000
        private static IOrganizationService _orgService;
        private static int appMaxId;

        public HCMCall()
        {
        }

        protected override void OnStart(string[] args)
        {
            base.OnStart(args);
            Logger.WriteLine("OnStart Function:");
            tmrDelay.Elapsed += TmrDelay_Elapsed;
            tmrDelay.Start();
        }

        private void TmrDelay_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            Logger.WriteLine("TmrDelay_Elapsed");
            tmrDelay.Stop();
            StartProcessing();
        }

        internal static void StartProcessing()
        {
            Logger.WriteLine("Staring Process Function:");
            System.Threading.Thread.Sleep(1000 * 5);//1000

            do
            {
                _orgService = ConnectHCM();
                try
                {
                    //connection to HCM
                    HCMCall app = new HCMCall();

                    //getting opportunity
                    EntityCollection opp = app.RetriveAllOpportunity();
                    //setting changes on opportunity
                    bool insertDB = app.RunProcedure(opp);

                    //read max application id in HCM
                    appMaxId = app.RetriveApplicationId();
                    List<tblPerson> leadEmployees = formDb.tblPersons.Where(x => x.Id > appMaxId).ToList();

                    List<Guid> contactIds = app.CreateContact(leadEmployees);

                    List<Guid> appGuids = app.InsertIntoHCMApplication(leadEmployees, contactIds);
                    List<Guid> eduGuid = app.AddEducationalInfoes(contactIds, appGuids, leadEmployees);
                    List<Guid> workGuid = app.AddWorkInfoes(contactIds, appGuids, leadEmployees);
                    List<Guid> attGuid = app.UploadAttachment(leadEmployees, contactIds, appGuids);


                    //for (int i = 0; i < leadEmployees.Count; i++)
                    //{
                    //    foreach (var item in leadEmployees[i].tblJobOpportunities)
                    //    {

                    //    }
                    //}
                }


                catch (FaultException<Microsoft.Xrm.Sdk.OrganizationServiceFault> ex)
                {
                    Logger.WriteLine("The application terminated with an error.");
                    Logger.WriteLine("Timestamp: {0}", ex.Detail.Timestamp);
                    Logger.WriteLine("Code: {0}", ex.Detail.ErrorCode);
                    Logger.WriteLine("Message: {0}", ex.Detail.Message);
                    Logger.WriteLine("Trace: {0}", ex.Detail.TraceText);
                    Logger.WriteLine("Inner Fault: {0}",
                        null == ex.Detail.InnerFault ? "No Inner Fault" : "Has Inner Fault");
                }
                catch (System.TimeoutException ex)
                {
                    Logger.WriteLine("The application terminated with an error.");
                    Logger.WriteLine("Message: {0}", ex.Message);
                    Logger.WriteLine("Stack Trace: {0}", ex.StackTrace);
                    Logger.WriteLine("Inner Fault: {0}",
                        null == ex.InnerException.Message ? "No Inner Fault" : ex.InnerException.Message);
                }
                catch (System.Exception ex)
                {
                    Logger.WriteLine("The application terminated with an error.");
                    Logger.WriteLine(ex.Message);

                    // Display the details of the inner exception.
                    if (ex.InnerException != null)
                    {
                        Logger.WriteLine(ex.InnerException.Message);

                        FaultException<Microsoft.Xrm.Sdk.OrganizationServiceFault> fe = ex.InnerException
                            as FaultException<Microsoft.Xrm.Sdk.OrganizationServiceFault>;
                        if (fe != null)
                        {
                            Logger.WriteLine("Timestamp: {0}", fe.Detail.Timestamp);
                            Logger.WriteLine("Code: {0}", fe.Detail.ErrorCode);
                            Logger.WriteLine("Message: {0}", fe.Detail.Message);
                            Logger.WriteLine("Trace: {0}", fe.Detail.TraceText);
                            Logger.WriteLine("Inner Fault: {0}",
                                null == fe.Detail.InnerFault ? "No Inner Fault" : "Has Inner Fault");
                        }
                    }
                }
                finally
                {
                    Logger.WriteLine($"Sleeping For {AppInfo.SleepTime} Minute(s).");
                    Thread.Sleep(AppInfo.SleepTime * 1000 * 60);
                }

            } while (true);


            // Additional exceptions to catch: SecurityTokenValidationException, ExpiredSecurityTokenException,
            // SecurityAccessDeniedException, MessageSecurityException, and SecurityNegotiationException.

            //finally
            //{
            //    Logger.WriteLine("Press <Enter> to exit.");
            //    Console.ReadLine();
            //}

        }

        // private String connectionString = GetServiceConfiguration();

        internal static FormModel.FrmDbContext formDb = new FormModel.FrmDbContext();

        #region Methods

        internal static IOrganizationService ConnectHCM()
        {
            var user = SecurityAgent.DecryptString("2i97j4Pp+WIXCKHa5I5nFw==");
            var pass = SecurityAgent.DecryptString("bG3+/ha1jzSv0F06Xw1Beg==");
            var cn = $"AuthType=AD;Url=http://192.168.100.54/HCM; Domain=SDP; Username={user}; Password={pass}";

            CrmServiceClient conn = new CrmServiceClient(cn);
            return (IOrganizationService)conn.OrganizationWebProxyClient != null ? (IOrganizationService)conn.OrganizationWebProxyClient : (IOrganizationService)conn.OrganizationServiceProxy;
        }

        internal int RetriveApplicationId()
        {
            int max = 0;
            int cur = 0;
            try
            {
                QueryExpression query = new QueryExpression
                {
                    EntityName = hcm_application.EntityLogicalName,
                    ColumnSet = new ColumnSet("hcm_appformid")
                };

                EntityCollection ec = _orgService.RetrieveMultiple(query);
                for (int i = 0; i < ec.Entities.Count; i++)
                {
                    cur = ec[i].GetAttributeValue<int>("hcm_appformid");
                    if (max < cur)
                        max = cur;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLine(ex.Message);
            }
            return max;
        }

        internal EntityCollection RetriveAllOpportunity()
        {
            QueryExpression query = new QueryExpression
            {
                EntityName = hcm_vacancy.EntityLogicalName,
                ColumnSet = new ColumnSet(true),
                Criteria = new FilterExpression
                {
                    Conditions =
                            {
                               // new ConditionExpression  {  AttributeName = "hcm_requestedondate",Operator = ConditionOperator.GreaterEqual,Values = { DateTime.Now }},
                                new ConditionExpression {AttributeName="statecode",Operator = ConditionOperator.Equal, Values= { "Active"} },
                            }
                }
            };
            EntityCollection ec = _orgService.RetrieveMultiple(query);
            return ec;
        }

        internal bool RunProcedure(EntityCollection opp)
        {
            try
            {
                int success = 0;
                foreach (var item in opp.Entities)
                {
                    var vacs = (hcm_vacancy)item;
                    if (vacs.hcm_expirationdate.HasValue && vacs.hcm_requestconfirmcode != null &&
                       vacs.hcm_publishdate.HasValue)
                    {
                        if (vacs.statecode == hcm_vacancyState.Active && vacs.hcm_expirationdate >= DateTime.Now &&
                            vacs.hcm_lastState_code.Value == 801140003 && vacs.hcm_publishdate <= DateTime.Now)
                        {
                            PersianDate pd = new HCMApp.PersianDate(vacs.hcm_expirationdate.Value);
                            var vacsguid = vacs.Id;
                            var jobTitle = vacs.hcm_name;
                            var jobProfile = vacs.hcm_jobProfile.Name;
                            var jobProfileId = vacs.hcm_jobProfile.Id;//D2D2A394-1388-E811-8159-00505694449C
                            var department = vacs.hcm_departmentId == null ? vacs.hcm_departmentId.Name : "";
                            var departmentId = vacs.hcm_departmentId.Id;//.Id!=Guid.Empty?vacs.hcm_departmentId.Id:Guid.Empty;
                            var dateNeeded = pd.To8DigitString();
                            //var requester = vacs.hcm_requestby_userId.Name;
                            // var requesterUserId = vacs.hcm_requestby_userId.Id;
                            var amount = vacs.hcm_quantity.Value;
                            var max_salary = vacs.hcm_salary_max.Value;
                            var min_salary = vacs.hcm_salary_min.Value;
                            var desc = vacs.hcm_description;
                            var avg_salary = Math.Round((max_salary + min_salary) / 2);
                            var condition = $"به تعداد {amount} نفر جهت {jobTitle} نیاز داریم. / {desc}";

                            using (SPForm spfrm = new FormModel.SPForm())
                            {
                                success = spfrm.SP_JobOpportunity_Ins(vacsguid, jobTitle, condition, department, dateNeeded);
                            }
                        }

                        else
                        {
                            using (SPForm spfrm = new FormModel.SPForm())
                            {
                                success = spfrm.SP_JobOpportunity_Del(vacs.Id);
                            }
                        }
                    }
                }
                if (success > 0)
                    return true;
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLine(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Create Contact from form information 
        /// the information mades from person model
        /// and for each person create a contact with information provided
        /// </summary>
        /// <param name="leadEmployees">list of form's information</param>
        /// <returns>list of guids contact that newly added</returns>
        internal List<Guid> CreateContact(List<tblPerson> leadEmployees)
        {
            List<Guid> guids = new List<Guid>();
            try
            {
                foreach (var item in leadEmployees)
                {
                    Guid? ifContactExistsGuid = GetEntityRecordId("contact", new[] { "hcm_nationalid", "contactid" },
                       "hcm_nationalid", item.NationalId.ToString(), "contactid");
                    if (ifContactExistsGuid.Value == default(Guid))
                    {
                        string[] colSet = { "new_cityid", "new_name" };
                        string entName = "new_city";
                        string atrName = "new_name";
                        string atrId = "new_cityid";

                        Guid cityBirthGuid = GetEntityRecordId(entName, colSet, atrName, item.BirthPlace, atrId);
                        Guid cityCertGuid = GetEntityRecordId(entName, colSet, atrName, item.CertificatePlace, atrId);
                        Guid cityHome = GetEntityRecordId(entName, colSet, atrName, item.City, atrId);
                        Guid provinceHome = GetEntityRecordId("new_province", new string[] { "new_provinceid", "new_name" }, atrName, item.Province, "new_provinceid");
                        

                        PersianDate pd = new HCMApp.PersianDate(item.BirthDate);
                        int sexCode = item.GenderId == 1 ? 801140001 : 801140000;

                        int eduId = item.tblEducationInfoes.OrderByDescending(x => x.EducationDegreeId).FirstOrDefault().EducationDegreeId;
                        var lastLevelEdu = formDb.tblEducationDegrees.Where(x => x.Id == eduId).SingleOrDefault().HCMId;

                        var jobTitle = item.tblWorkInfoes.Count > 0 ? item.tblWorkInfoes.LastOrDefault(x => x.PersonId == item.Id).Post : "";

                        Contact cnt = new Contact()
                        {
                            //اطلاعات شناسنامه ای
                            FirstName = item.FirstName,
                            LastName = item.LastName,
                            hcm_fatherName = item.FatherName,
                            hcm_NationalId = item.NationalId.ToString(),
                            hcm_idNumber = item.CertificateNo,
                            BirthDate = pd,
                            // hcm_religiousCode = new OptionSetValue(item.Religion.HCMId),
                            // hcm_citizenship_countryid = item.Nationality,
                            hcm_placeodIdCard = item.CertificatePlace,
                            hcm_birthcityid = new EntityReference("new_city", cityBirthGuid),
                            Description = $"دین: {item.Religion} - مذهب: {item.SubReligion} - ملیت: {item.Nationality}",
                            hcm_marital_status_code = new OptionSetValue(item.MaritalStatus.HCMId),
                            hcm_sexcode = new OptionSetValue(sexCode),
                            hcm_military_state_code = item.GenderId == 1 ? new OptionSetValue(item.MilitaryStatus.HCMId) : null,

                            //اطلاعات تماس
                            Telephone2 = item.PhoneNo,
                            MobilePhone = item.MobileNo,
                            EMailAddress1 = item.Email,
                            hcm_provinceId = new EntityReference("new_province", provinceHome),
                            hcm_cityId = new EntityReference("new_city", cityHome),
                            Address1_PostalCode = item.PostalCode,
                            Address1_Line1 = item.Address,
                            
                            //آخرین شغل و مدرک تحصیلی
                            JobTitle = jobTitle,
                            hcm_education_grade_code = new OptionSetValue(lastLevelEdu),
                        };

                        var newContactId = _orgService.Create(cnt);
                        guids.Add(newContactId);
                    }

                    else
                    {
                        guids.Add(ifContactExistsGuid.Value);
                    }
                }
            }

            catch (Exception ex)
            {
                Logger.WriteLine(ex.Message);
            }
            return guids;
        }

        internal List<Guid> InsertIntoHCMApplication(List<tblPerson> leadEmployees, List<Guid> contactId)
        {
            var sysuserId = CurrentUserInfo().Id;
            List<Guid> appguids = new List<Guid>();
            try
            {
                for (int i = 0; i < contactId.Count; i++)
                {
                    tblPerson p = leadEmployees[i];
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("آشنایی با زبان:" + p.LanguageDesc);
                    sb.AppendLine("مهارت ها:" + p.Skill);
                    sb.AppendLine("نرم افزارهای تخصصی:" + p.ComputerInfo);
                    sb.AppendLine("نحوه آشنایی:" + p.tblConnectionLink.Name);
                    sb.AppendLine($"نام معرف:{p.RecommenderFirstName} {p.RecommenderLastName}/شغل: {p.RecommenderJob} / تماس: {p.RecommenderPhone}" +
                        $" / نسبت: {p.RecommenderRelationship} / آدرس: {p.RecommenderAddress}");
                    var contact = _orgService.Retrieve("contact", contactId[i], new ColumnSet(true));
                    var pid = formDb.tblPersons.Where(x => x.Id == p.Id).FirstOrDefault().Id;

                    PersianDate pd = new HCMApp.PersianDate(p.BirthDate);
                    var jobTitle = p.tblWorkInfoes.Count > 0 ? p.tblWorkInfoes.LastOrDefault(x => x.PersonId == p.Id).Post : "";

                    int eduId = p.tblEducationInfoes.OrderByDescending(x => x.EducationDegreeId).FirstOrDefault().EducationDegreeId;
                    var lastLevelEdu = formDb.tblEducationDegrees.Where(x => x.Id == eduId).SingleOrDefault().HCMId;
                    byte[] img = null;
                    if (p.tblPersonImages.Any())
                        img = p.tblPersonImages.FirstOrDefault().Image;
                    if (p.tblJobOpportunities.Count > 0)
                    {
                        foreach (var opportunity in p.tblJobOpportunities)
                        {
                            string title = $"{p.FirstName} {p.LastName} :: متقاضی {opportunity.Title}";

                            hcm_application app = new hcm_application()
                            {
                                hcm_applicantId = new EntityReference("contact", contactId[i]),
                                OwnerId = new EntityReference("systemuser", sysuserId),
                                hcm_received_on_date = DateTime.Now,//.AddDays(-1),
                                hcm_name = title,
                                hcm_appformid = pid,
                                hcm_description = sb.ToString(),
                                hcm_vacancyId = p.tblJobOpportunities.Count > 0 ? new EntityReference("hcm_vacancy", opportunity.HCMId) : null,
                                hcm_recruitingChannelId = new EntityReference("hcm_recruitingchannel", Guid.Parse("B4B8097D-8374-E811-8155-00505694449C")),
                                hcm_unsolicited_application = p.tblJobOpportunities.Count == 0,
                                hcm_expected_alary_min = new Money(p.ExpectedSalary),
                                hcm_address = p.Address,
                                hcm_EMailAddress = p.Email,
                                hcm_MobilePhone=p.MobileNo,
                                hcm_birthdate=pd,
                                hcm_JobTitle=jobTitle,
                                hcm_sexcode= new OptionSetValue(p.GenderId == 1 ? 801140001 : 801140000),
                                hcm_fatherName=p.FatherName,
                                hcm_idNumber=p.NationalId.ToString(),
                                hcm_placeodIdCard= p.CertificatePlace,
                                hcm_birthcityid= new EntityReference("new_city", GetEntityRecordId("new_city", new string[] { "new_cityid", "new_name" }, "new_name", p.BirthPlace, "new_cityid")),
                                hcm_telephone=p.PhoneNo,
                                hcm_education_grade_code = new OptionSetValue(lastLevelEdu),
                                hcm_military_state_code= p.GenderId == 1 ? new OptionSetValue(p.MilitaryStatus.HCMId) : null,
                                hcm_marital_status_code = new OptionSetValue(p.MaritalStatus.HCMId),
                                EntityImage=img,
                                hcm_cityId = new EntityReference("new_city", GetEntityRecordId("new_city", new string[] { "new_cityid", "new_name" }, "new_name", p.City, "new_cityid"))
                            };
                            var appGuid = _orgService.Create(app);
                            appguids.Add(appGuid);
                        }
                    }
                    else
                    {
                        string title = $"{p.FirstName} {p.LastName} :: متقاضی {p.SuggestedJob}";

                        hcm_application app = new hcm_application()
                        {
                            hcm_applicantId = new EntityReference("contact", contactId[i]),
                            OwnerId = new EntityReference("systemuser", sysuserId),
                            hcm_received_on_date = DateTime.Now,//.AddDays(-1),
                            hcm_name = title,
                            hcm_appformid = pid,
                            hcm_description = sb.ToString(),
                            hcm_recruitingChannelId = new EntityReference("hcm_recruitingchannel", Guid.Parse("B4B8097D-8374-E811-8155-00505694449C")),
                            hcm_unsolicited_application = p.tblJobOpportunities.Count == 0,
                            hcm_expected_alary_min = new Money(p.ExpectedSalary),
                            hcm_address = p.Address,
                            hcm_EMailAddress = p.Email,
                            hcm_MobilePhone = p.MobileNo,
                            hcm_birthdate = pd,
                            hcm_JobTitle = jobTitle,
                            hcm_sexcode = new OptionSetValue(p.GenderId == 1 ? 801140001 : 801140000),
                            hcm_fatherName = p.FatherName,
                            hcm_idNumber = p.NationalId.ToString(),
                            hcm_placeodIdCard = p.CertificatePlace,
                            hcm_birthcityid = new EntityReference("new_city", GetEntityRecordId("new_city", new string[] { "new_cityid", "new_name" }, "new_name", p.BirthPlace, "new_cityid")),
                            hcm_education_grade_code = new OptionSetValue(lastLevelEdu),
                            hcm_military_state_code = p.GenderId == 1 ? new OptionSetValue(p.MilitaryStatus.HCMId) : null,
                            hcm_marital_status_code = new OptionSetValue(p.MaritalStatus.HCMId),
                            hcm_telephone=p.PhoneNo,
                            EntityImage = img,
                            hcm_cityId = new EntityReference("new_city", GetEntityRecordId("new_city", new string[] { "new_cityid", "new_name" }, "new_name", p.City, "new_cityid"))
                        };
                        var appGuid = _orgService.Create(app);
                        appguids.Add(appGuid);
                    }
                }
            }


            catch (Exception ex)
            {
                Logger.WriteLine(ex.Message);
            }
            return appguids;
        }

        internal List<Guid> AddEducationalInfoes(List<Guid> contactIds, List<Guid> appGuids, List<tblPerson> people)
        {
            List<Guid> guids = new List<Guid>();

            try
            {
                for (int i = 0; i < contactIds.Count; i++)
                {
                    var edus = people[i].tblEducationInfoes.ToList();

                    List<Guid> apps = GetEntityRecordsId("hcm_application", true, "hcm_applicantid", contactIds[i], "hcm_applicationid");
                    foreach (var app in apps)
                    {
                        foreach (var item in edus)
                        {
                            if (item.EducationDegreeId != 1 && item.EducationDegreeId != 6 && item.EducationDegreeId != 7)
                            {
                                PersianDate pd = null;// DateTime.Now.AddYears(-50);
                                float? gpa = null;
                                if (item.EndYear.HasValue)
                                {
                                    if (item.EndYear < 100)
                                        item.EndYear += 1300;
                                    pd = new HCMApp.PersianDate(item.EndYear.Value, 1, 1);
                                }
                                if (item.GPA.HasValue)
                                {
                                    if (item.GPA <= 20)
                                        gpa = item.GPA;
                                    else
                                    {
                                        if (item.GPA / 100 <= 20)
                                            gpa = item.GPA / 100;
                                    }
                                }

                                int levelName = formDb.tblEducationDegrees.Where(x => x.Id == item.EducationDegreeId).FirstOrDefault().HCMId;
                                int isfinished = item.IsFinished == true ? 801140000 : 801140001;
                                var universityType = formDb.tblInstituteTypes.Where(x => x.Id == item.InstituteTypeId).FirstOrDefault();

                                //var applicant = GetObjectByGettingGuid("contact", contactIds[i], new[] { "lastname" });

                                hcm_education edu = new hcm_education()
                                {
                                    //hcm_contactId = new EntityReference("contact", contactIds[i]),
                                    hcm_name = $" سابقه تحصیلی",
                                    hcm_applicationId = new EntityReference("hcm_application", app),
                                    hcm_edu_level_code = new OptionSetValue(levelName),
                                    hcm_fieldname = item.Field,
                                    hcm_universityname = item.Institute,
                                    hcm_AreaofInterest = item.SubField,
                                    hcm_toDate = pd,
                                    hcm_score = gpa == null ? default(decimal) : Convert.ToDecimal(gpa),
                                    hcm_lastState = new OptionSetValue(isfinished),
                                    hcm_UniversityTypeCode = universityType != null ? new OptionSetValue(universityType.HCMId) : null
                                };

                                var newEductionalId = _orgService.Create(edu);
                                guids.Add(newEductionalId);
                            }
                            else
                            {
                                int levelName = formDb.tblEducationDegrees.Where(x => x.Id == item.EducationDegreeId).FirstOrDefault().HCMId;

                                hcm_education edu = new hcm_education()
                                {
                                    //hcm_contactId = new EntityReference("contact", contactIds[i]),
                                    hcm_name = $" سابقه تحصیلی",
                                    hcm_applicationId = new EntityReference("hcm_application", app),
                                    hcm_edu_level_code = new OptionSetValue(levelName)
                                };
                                var newEductionalId = _orgService.Create(edu);
                                guids.Add(newEductionalId);
                            }
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                Logger.WriteLine(ex.Message);
            }
            return guids;
        }

        internal List<Guid> AddWorkInfoes(List<Guid> contactIds, List<Guid> appGuids, List<tblPerson> people)
        {
            List<Guid> guids = new List<Guid>();
            try
            {
                for (int i = 0; i < contactIds.Count; i++)
                {
                    var works = people[i].tblWorkInfoes.ToList();

                    List<Guid> jobGuidHistories = null;

                    QueryExpression query = new QueryExpression
                    {
                        EntityName = "hcm_jobhistory",
                        ColumnSet = new ColumnSet(true),
                        Criteria = new FilterExpression
                        {
                            Conditions = { new ConditionExpression { AttributeName = "hcm_contactid", Operator = ConditionOperator.Equal, Values = { contactIds[i] } } }
                        }
                    };

                    QueryExpression queryApp = new QueryExpression
                    {
                        EntityName = "hcm_application",
                        ColumnSet = new ColumnSet(true),
                        Criteria = new FilterExpression
                        {
                            Conditions = { new ConditionExpression { AttributeName = "hcm_applicantid", Operator = ConditionOperator.Equal, Values = { contactIds[i] } } }
                        }
                    };

                    EntityCollection jobRecords = _orgService.RetrieveMultiple(query);
                    EntityCollection appRecords = _orgService.RetrieveMultiple(queryApp);

                    //for (int j = 0; j < records.Entities.Count; j++)
                    //{
                    //    jobGuidHistories.Add(new Guid(records.Entities[j].Attributes["hcm_jobhistoryid"].ToString()));
                    //}

                    var jobRec = new hcm_jobHistory();

                    Guid? employeeExist = GetEntityRecordId("hcm_employee", true, "hcm_related_contactid", contactIds[i], "hcm_employeeid");
                    if (employeeExist == default(Guid))
                    {
                        for (int k = 0; k < jobRecords.Entities.Count; k++)
                        {
                            jobRec.Id = (Guid)jobRecords.Entities[k]["hcm_jobhistoryid"];
                            jobRec.statecode = hcm_jobHistoryState.Inactive;
                            _orgService.Update(jobRec);
                        }
                    }

                    if (works.Count > 0)
                    {
                        foreach (var app in appRecords.Entities)
                        {
                            foreach (var item in works)
                            {
                                PersianDate pds = new HCMApp.PersianDate(item.StartDate);
                                PersianDate pde = new HCMApp.PersianDate(item.EndDate);
                                StringBuilder sb = new StringBuilder();
                                sb.AppendLine($" شرح وظایف: {item.Duties} " +
                                    $" علت ترک: {item.LeaveReason} " +
                                    $"آخرین حقوق ماهیانه به ریال: {item.LastSalary} " +
                                    $" تلفن تماس: {item.PhoneNo}");
                                hcm_jobHistory job = new hcm_jobHistory()
                                {
                                    hcm_ifEmployerSelection = false,
                                    hcm_applicationId = new EntityReference("hcm_application", app.Id),
                                    hcm_other_empolyer = item.CompanyName,
                                    hcm_description = sb.ToString(),
                                    hcm_startDate = pds,
                                    hcm_endDate = pde,
                                    hcm_name = item.Post
                                };

                                var newjobId = _orgService.Create(job);
                            }
                        }
                        foreach (var item in works)
                        {
                            PersianDate pds = new HCMApp.PersianDate(item.StartDate);
                            PersianDate pde = new HCMApp.PersianDate(item.EndDate);
                            StringBuilder sb = new StringBuilder();
                            sb.AppendLine($" شرح وظایف: {item.Duties} " +
                                $" علت ترک: {item.LeaveReason} " +
                                $"آخرین حقوق ماهیانه به ریال: {item.LastSalary} " +
                                $" تلفن تماس: {item.PhoneNo}");
                            hcm_jobHistory job = new hcm_jobHistory()
                            {
                                hcm_ifEmployerSelection = false,
                                hcm_contactId = new EntityReference("contact", contactIds[i]),
                                hcm_other_empolyer = item.CompanyName,
                                hcm_description = sb.ToString(),
                                hcm_startDate = pds,
                                hcm_endDate = pde,
                                hcm_name = item.Post
                            };

                            var newjobId = _orgService.Create(job);
                            guids.Add(newjobId);
                        }
                    }

                }

            }


            catch (Exception ex)
            {
                Logger.WriteLine(ex.Message);
            }
            return guids;

        }

        internal List<Guid> UploadAttachment(List<tblPerson> leadEmployees, List<Guid> contactIds, List<Guid> appIds)
        {
            List<Guid> guids = new List<Guid>();
            try
            {
                for (int i = 0; i < leadEmployees.Count; i++)
                {
                    List<Guid> apps = GetEntityRecordsId("hcm_application", true, "hcm_applicantid", contactIds[i], "hcm_applicationid");
                    foreach (var app in apps)
                    {

                        var isAttachment = leadEmployees[i].tblPersonAttachments.Count;
                        string filename = null;
                        if (isAttachment > 0)
                        {
                            filename = appMaxId + "-" + leadEmployees[i].tblPersonAttachments.First().FileName;
                        }

                        using (FileStream fs = new FileStream(Path.GetTempPath() + filename, FileMode.Create, FileAccess.Write))
                        {
                            byte[] arr = leadEmployees[i].tblPersonAttachments.FirstOrDefault().Attachment;
                            fs.Write(arr, 0, arr.Length);

                            Annotation attachment = new Annotation()
                            {
                                Subject = $"رزومه {leadEmployees[i].FirstName} {leadEmployees[i].LastName}",
                                FileName = filename,
                                DocumentBody = Convert.ToBase64String(arr),
                                ObjectId = new EntityReference(hcm_application.EntityLogicalName, app)
                            };

                            var id = _orgService.Create(attachment);
                            guids.Add(id);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLine(ex.Message);
            }
            return guids;
        }

        internal Guid GetEntityRecordId(string entName, string[] colSet, string atrName, string value, string atrId)
        {
            value = value.Trim();
            Guid guid = default(Guid);
            try
            {
                QueryExpression query = new QueryExpression
                {
                    EntityName = entName,
                    ColumnSet = new ColumnSet(colSet),
                    Criteria = new FilterExpression
                    {
                        Conditions = { new ConditionExpression { AttributeName = atrName,
                            Operator = ConditionOperator.Equal, Values = { value }
                        } }
                    }
                };
                query.Criteria.AddCondition("statecode", ConditionOperator.Equal, "Active");
                EntityCollection firstRecord = _orgService.RetrieveMultiple(query);
                if (firstRecord.Entities.Count > 0)
                {
                    var id = firstRecord.Entities[0].Attributes[atrId];
                    guid = new Guid(id.ToString());
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLine(ex.Message);
            }
            return guid;

        }

        internal Guid GetEntityRecordId(string entName, bool colSet, string atrName, string value, string atrId)
        {
            Guid guid = default(Guid);
            try
            {
                QueryExpression query = new QueryExpression
                {
                    EntityName = entName,
                    ColumnSet = new ColumnSet(colSet),
                    Criteria = new FilterExpression
                    {
                        Conditions = { new ConditionExpression { AttributeName = atrName, Operator = ConditionOperator.Equal, Values = { value } } }
                    }
                };
                EntityCollection firstRecord = _orgService.RetrieveMultiple(query);
                var id = firstRecord.Entities[0].Attributes[atrId];
                guid = new Guid(id.ToString());
            }
            catch (Exception ex)
            {
                Logger.WriteLine(ex.Message);
            }
            return guid;

        }

        internal Guid GetEntityRecordId(string entName, bool colSet, string atrName, Guid value, string atrId)
        {
            Guid guid = default(Guid);
            try
            {
                QueryExpression query = new QueryExpression
                {
                    EntityName = entName,
                    ColumnSet = new ColumnSet(colSet),
                    Criteria = new FilterExpression
                    {
                        Conditions = { new ConditionExpression { AttributeName = atrName, Operator = ConditionOperator.Equal, Values = { value } } }
                    }
                };
                EntityCollection firstRecord = _orgService.RetrieveMultiple(query);
                if (firstRecord.Entities.Count > 0)
                {
                    var id = firstRecord.Entities[0].Attributes[atrId];
                    guid = new Guid(id.ToString());
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLine(ex.Message);
            }
            return guid;

        }

        internal List<Guid> GetEntityRecordsId(string entName, bool colSet, string atrName, Guid value, string atrId)
        {
            List<Guid> guids = new List<Guid>();
            try
            {
                QueryExpression query = new QueryExpression
                {
                    EntityName = entName,
                    ColumnSet = new ColumnSet(colSet),
                    Criteria = new FilterExpression
                    {
                        Conditions = { new ConditionExpression { AttributeName = atrName, Operator = ConditionOperator.Equal, Values = { value } } }
                    }
                };
                EntityCollection records = _orgService.RetrieveMultiple(query);
                for (int i = 0; i < records.Entities.Count; i++)
                {
                    var r = records.Entities[i].Attributes[atrId].ToString();
                    guids.Add(Guid.Parse(records.Entities[i].Attributes[atrId].ToString()));
                }

            }
            catch (Exception ex)
            {
                Logger.WriteLine(ex.Message);
            }
            return guids;

        }

        internal SystemUser CurrentUserInfo()
        {
            Guid userId = ((WhoAmIResponse)_orgService.Execute(new WhoAmIRequest())).UserId;
            var systemUser = (SystemUser)_orgService.Retrieve("systemuser", userId, new ColumnSet(true));

            return systemUser;
        }

        internal Entity GetObjectByGettingGuid(string ent, Guid guid, string[] cols)
        {
            ColumnSet columnSet = new ColumnSet(cols);

            return _orgService.Retrieve(ent, guid, columnSet);
        }

        internal Entity GetObjectByGettingGuid(string ent, Guid guid, bool cols)
        {
            ColumnSet columnSet = new ColumnSet(cols);

            return _orgService.Retrieve(ent, guid, columnSet);
        }

        //  internal List<Entity> GetMultipleObjectByGetting
        #endregion Methods
    }
}
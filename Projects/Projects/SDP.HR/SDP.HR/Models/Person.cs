using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;

using DataAccessLayer;
using SDP.HR.Classes;
namespace SDP.HR.Models
{
    public class Person
    {
        #region Properties
        #region Id
        private int _Id;
        public int Id
        {
            get
            {
                return _Id;
            }
            set
            {
                _Id = value;
            }
        }
        #endregion
        #region FirstName
        private string _FirstName;
        public string FirstName
        {
            get
            {
                return _FirstName;
            }
            set
            {
                _FirstName = value;
            }
        }
        #endregion
        #region LastName
        private string _LastName;
        public string LastName
        {
            get
            {
                return _LastName;
            }
            set
            {
                _LastName = value;
            }
        }
        #endregion
        #region FatherName
        private string _FatherName;
        public string FatherName
        {
            get
            {
                return _FatherName;
            }
            set
            {
                _FatherName = value;
            }
        }
        #endregion
        #region CertificateNo
        private string _CertificateNo;
        public string CertificateNo
        {
            get
            {
                return _CertificateNo;
            }
            set
            {
                _CertificateNo = value;
            }
        }
        #endregion
        #region NationalId
        private long _NationalId;
        public long NationalId
        {
            get
            {
                return _NationalId;
            }
            set
            {
                _NationalId = value;
            }
        }
        #endregion
        #region BirthDate
        private string _BirthDate = string.Empty;
        public string BirthDate
        {
            get
            {
                return _BirthDate;
            }
            set
            {
                try
                {
                    PersianDate pd = new PersianDate(value, "/");
                    _BirthDate = pd.To8DigitString();
                }
                catch
                {
                }
            }
        }
        #endregion
        #region BirthPlace 
        private string _BirthPlace;
        public string BirthPlace
        {
            get
            {
                return _BirthPlace;
            }
            set
            {
                _BirthPlace = value;
            }
        }
        #endregion
        #region CertificatePlace
        private string _CertificatePlace;
        public string CertificatePlace
        {
            get
            {
                return _CertificatePlace;
            }
            set
            {
                _CertificatePlace = value;
            }
        }
        #endregion
        #region Religion
        private string _Religion;
        public string Religion
        {
            get
            {
                return _Religion;
            }
            set
            {
                _Religion = value;
            }
        }
        #endregion
        #region SubReligion
        private string _SubReligion;
        public string SubReligion
        {
            get
            {
                return _SubReligion;
            }
            set
            {
                _SubReligion = value;
            }
        }
        #endregion
        #region Nationality
        private string _Nationality;
        public string Nationality
        {
            get
            {
                return _Nationality;
            }
            set
            {
                _Nationality = value;
            }
        }
        #endregion
        #region GenderId
        private byte _GenderId;
        public byte GenderId
        {
            get
            {
                return _GenderId;
            }
            set
            {
                _GenderId = value;
            }
        }
        #endregion
        #region Gender
        private Gender _GenderObj = null;
        public Gender Gender
        {
            get
            {
                if (_GenderObj == null)
                    _GenderObj = Gender.Select(GenderId);
                return _GenderObj;
            }
        }
        #endregion
        #region MilitaryStatusId
        private byte? _MilitaryStatusId;
        public byte? MilitaryStatusId
        {
            get
            {
                return _MilitaryStatusId;
            }
            set
            {
                _MilitaryStatusId = value;
            }
        }
        #endregion
        #region MilitaryStatus
        private MilitaryStatus _MilitaryStatus;
        public MilitaryStatus MilitaryStatus
        {
            get
            {
                if (_MilitaryStatus == null)
                    _MilitaryStatus = MilitaryStatus.Select(MilitaryStatusId);
                return _MilitaryStatus;
            }
        }
        #endregion
        #region MaritalStatusId
        private byte _MaritalStatusId;
        public byte MaritalStatusId
        {
            get
            {
                return _MaritalStatusId;
            }
            set
            {
                _MaritalStatusId = value;
            }
        }
        #endregion
        #region MaritalStatus
        private MaritalStatus _MaritalStatus;
        public MaritalStatus MaritalStatus
        {
            get
            {
                if (_MaritalStatus == null)
                    _MaritalStatus = MaritalStatus.Select(MaritalStatusId);
                return _MaritalStatus;
            }
        }
        #endregion
        #region PhoneNo
        private string _PhoneNo;
        public string PhoneNo
        {
            get
            {
                return _PhoneNo;
            }
            set
            {
                _PhoneNo = value;
            }
        }
        #endregion
        #region MobileNo
        private string _MobileNo;
        public string MobileNo
        {
            get
            {
                return _MobileNo;
            }
            set
            {
                _MobileNo = value;
            }
        }
        #endregion
        #region Email
        private string _Email;
        public string Email
        {
            get
            {
                return _Email;
            }
            set
            {
                _Email = value;
            }
        }
        #endregion
        #region PostalCode
        private string _PostalCode;
        public string PostalCode
        {
            get
            {
                return _PostalCode;
            }
            set
            {
                _PostalCode = value;
            }
        }
        #endregion
        #region Address
        private string _Address;
        public string Address
        {
            get
            {
                return _Address;
            }
            set
            {
                _Address = value;
            }
        }
        #endregion
        #region WorkInfoList
        private List<WorkInfo> _WorkInfoList = new List<WorkInfo>();
        public List<WorkInfo> WorkInfoList
        {
            get
            {
                return _WorkInfoList;
            }
        }
        #endregion
        #region EducationInfoList
        private List<EducationInfo> _EducationInfoList = new List<EducationInfo>();
        public List<EducationInfo> EducationInfoList
        {
            get
            {
                return _EducationInfoList;
            }
        }
        #endregion
        #region LanguageInfoList
        private List<LanguageInfo> _LanguageInfoList = new List<LanguageInfo>();
        public List<LanguageInfo> LanguageInfoList
        {
            get
            {
                return _LanguageInfoList;
            }
        }
        #endregion
        #region JobOpportunityList
        private List<int> _JobOpportunityList = new List<int>();
        public List<int> JobOpportunityList
        {
            get
            {
                return _JobOpportunityList;
            }
            set
            {
                _JobOpportunityList = value;
            }
        }
        #endregion
        #region Attachment
        private byte[] _Attachment = new byte[0];
        public byte[] Attachment
        {
            get
            {
                return _Attachment;
            }
            set
            {
                _Attachment = value;
            }
        }
        #endregion
        #region FileType
        private string _FileType;
        public string FileType
        {
            get
            {
                return _FileType;
            }
            set
            {
                _FileType = value;
            }
        }
        #endregion
        #region FileName
        private string _FileName;
        public string FileName
        {
            get
            {
                return _FileName;
            }
            set
            {
                _FileName = value;
            }
        }
        #endregion
        #region SuggestedJob
        private string _SuggestedJob = string.Empty;
        public string SuggestedJob
        {
            get
            {
                return _SuggestedJob;
            }
            set
            {
                _SuggestedJob = value;
            }
        }
        #endregion
        #region ConnectionLinkId
        private byte _ConnectionLinkId;
        public byte ConnectionLinkId
        {
            get
            {
                return _ConnectionLinkId;
            }
            set
            {
                _ConnectionLinkId = value;
            }
        }
        #endregion
        #region ConnectionLink
        private ConnectionLink _ConnectionLinkObj = null;
        public ConnectionLink ConnectionLink
        {
            get
            {
                if (_ConnectionLinkObj == null)
                    _ConnectionLinkObj = ConnectionLink.Select(ConnectionLinkId);
                return _ConnectionLinkObj;
            }
        }
        #endregion
        #region ExpectedSalary
        private int _ExpectedSalary;
        public int ExpectedSalary
        {
            get
            {
                return _ExpectedSalary;
            }
            set
            {
                _ExpectedSalary = value;
            }
        }
        #endregion
        #region RecommenderFirstName
        private string _RecommenderFirstName;
        public string RecommenderFirstName
        {
            get
            {
                return _RecommenderFirstName;
            }
            set
            {
                _RecommenderFirstName = value;
            }
        }
        #endregion
        #region RecommenderLastName
        private string _RecommenderLastName;
        public string RecommenderLastName
        {
            get
            {
                return _RecommenderLastName;
            }
            set
            {
                _RecommenderLastName = value;
            }
        }
        #endregion
        #region RecommenderRelationship
        private string _RecommenderRelationship;
        public string RecommenderRelationship
        {
            get
            {
                return _RecommenderRelationship;
            }
            set
            {
                _RecommenderRelationship = value;
            }
        }
        #endregion
        #region RecommenderJob
        private string _RecommenderJob;
        public string RecommenderJob
        {
            get
            {
                return _RecommenderJob;
            }
            set
            {
                _RecommenderJob = value;
            }
        }
        #endregion
        #region RecommenderPhone
        private string _RecommenderPhone;
        public string RecommenderPhone
        {
            get
            {
                return _RecommenderPhone;
            }
            set
            {
                _RecommenderPhone = value;
            }
        }
        #endregion
        #region RecommenderAddress
        private string _RecommenderAddress;
        public string RecommenderAddress
        {
            get
            {
                return _RecommenderAddress;
            }
            set
            {
                _RecommenderAddress = value;
            }
        }
        #endregion
        #region Skill
        private string _Skill;
        public string Skill
        {
            get
            {
                return _Skill;
            }
            set
            {
                _Skill = value;
            }
        }
        #endregion
        #region ComputerInfo
        private string _ComputerInfo;
        public string ComputerInfo
        {
            get
            {
                return _ComputerInfo;
            }
            set
            {
                _ComputerInfo = value;
            }
        }
        #endregion
        #region ProvinceId
        private int _ProvinceId;
        public int ProvinceId
        {
            get
            {
                return _ProvinceId;
            }
            set
            {
                _ProvinceId = value;
            }
        }
        #endregion
        #region Province
        private string _Province = string.Empty;
        public string Province
        {
            get
            {
                if (_Province == string.Empty)
                {
                    try
                    {
                        _Province = BaseInfo.ProvinceList.Where(p => p.Id == ProvinceId).First().Name;
                    }
                    catch
                    {
                    }
                }
                return _Province;
            }
            set
            {
                _Province = value;
            }
        }
        #endregion
        #region City
        private string _City;
        public string City
        {
            get
            {
                return _City;
            }
            set
            {
                _City = value;
            }
        }
        #endregion
        #region Image
        private byte[] _Image = new byte[0];
        public byte[] Image
        {
            get
            {
                return _Image;
            }
            set
            {
                _Image = value;
            }
        }
        #endregion
        #region ImageFileType
        private string _ImageFileType;
        public string ImageFileType
        {
            get
            {
                return _ImageFileType;
            }
            set
            {
                _ImageFileType = value;
            }
        }
        #endregion
        #region ImageFileName
        private string _ImageFileName;
        public string ImageFileName
        {
            get
            {
                return _ImageFileName;
            }
            set
            {
                _ImageFileName = value;
            }
        }
        #endregion
        #region FamiliarEmployeeId
        private byte _FamiliarEmployeeId;
        public byte FamiliarEmployeeId
        {
            get
            {
                return _FamiliarEmployeeId;
            }
            set
            {
                _FamiliarEmployeeId = value;
            }
        }
        #endregion
        #region FamiliarEmployee
        public bool FamiliarEmployee
        {
            get
            {
                return _FamiliarEmployeeId==1;
            }
        }
        #endregion
        #endregion
        #region Events
        #endregion
        #region Methods
        public static Person FromForm(NameValueCollection frm)
        {
            Person result = new Person();
            result = (Person)result.GetObjectFromForm(frm);
            result.EducationInfoList.AddRange(frm, "Education");
            result.WorkInfoList.AddRange(frm, "Work");
            result.LanguageInfoList.AddRange(frm, "Lang");
            string[] arr = frm.AllKeys.Where(q => q.StartsWith("Job_Id_")).ToArray();
            foreach (string str in arr)
            {
                int id = int.Parse(str.Replace("Job_Id_", string.Empty));
                result.JobOpportunityList.Add(id);
            }

            return result;
        }
        public void Insert()
        {
            string procedureName = "SP_Person_Ins";
            List<DALParameter> parameters = new List<DALParameter>();
            parameters = DALAgent.GetParameters(procedureName);
            if (parameters != null)
            {
                object obj;
                string fieldName = "";
                for (int i = 1; i < parameters.Count; i++)
                {
                    try
                    {
                        fieldName = parameters[i].Name;
                        obj = this.GetType().GetProperty(fieldName.Substring(1)).GetValue(this, null);
                        parameters[i].Value = obj;
                    }
                    catch { }
                }
            }
            DataTable dt = null;
            dt = EducationInfoList.ToDataTable();
            parameters.Where(p => p.Name == "@EducationInfoList").First().Value = dt;
            dt = WorkInfoList.ToDataTable();
            parameters.Where(p => p.Name == "@WorkInfoList").First().Value = dt;
            dt = LanguageInfoList.ToDataTable();
            dt.Columns.Remove("ForeignLanguage");
            dt.Columns.Remove("ReadingSkillLevel");
            dt.Columns.Remove("WritingSkillLevel");
            dt.Columns.Remove("SpeakingSkillLevel");
            parameters.Where(p => p.Name == "@LanguageInfoList").First().Value = dt;
            dt = new DataTable("JobOpprtunityList");
            dt.Columns.Add("Value");
            for (int i = 0; i < JobOpportunityList.Count; i++)
                dt.Rows.Add(JobOpportunityList[i]);
            parameters.Where(p => p.Name == "@JobOpprtunityList").First().Value = dt;
            if (Attachment != null && Attachment.Length > 0)
            {
                parameters.Where(p => p.Name == "@Attachment").First().Value = Attachment;
            }
            if (Image != null && Image.Length > 0)
            {
                parameters.Where(p => p.Name == "@Image").First().Value = Image;
            }
            DALOutput dalo = DALAgent.ExecuteProcedure(procedureName, DALAgent.enDBMethodOutput.Nothing, parameters);
        }
        public static Person Select(int id)
        {
            List<DALParameter> parameters = new List<DALParameter>();
            parameters.Add(new DALParameter("@Id", id));
            DALOutput dalo = DALAgent.ExecuteProcedure("SP_Person_Sel", DALAgent.enDBMethodOutput.MultipleValue, parameters);
            Person result = null;
            if (dalo.Value != null)
            {
                DataTable dt = (DataTable)dalo.Value;
                DataRow dr = dt.Rows[0];
                result = (Person)dr;
                result.EducationInfoList.AddRange(EducationInfo.SelectList(id));
                result.WorkInfoList.AddRange(WorkInfo.SelectList(id));
                result.LanguageInfoList.AddRange(LanguageInfo.SelectList(id));
            }
            return result;
        }
        public static explicit operator Person(DataRow dr)
        {
            Person obj = new Person();
            System.Reflection.PropertyInfo[] propList = obj.GetType().GetProperties().Where(p => p.CanWrite).ToArray();
            foreach (DataColumn item in dr.Table.Columns)
            {
                if (propList.Where(pi => pi.Name == item.ColumnName).Count() == 0)
                    continue;
                try
                {
                    typeof(Person).GetProperty(item.ColumnName).SetValue(obj, dr[item.ColumnName], null);
                }
                catch
                {
                }
            }
            return obj;
        }

        #endregion

    }
}
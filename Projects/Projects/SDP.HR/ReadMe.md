    <div dir="rtl">

<div style = "font-size:20px; font-weight:bold; margin-bottom:10px; direction:ltr; text-align:right;" dir="rtl"> Publish </div>

<p style="direction:rtl; text-align:right; " dir="rtl">

> پروژه SDP.HR  به منظور ثبت نام و استخدام اشخاص متناسب با نیاز سازمان تعریف شده است. بدین منظور از معماری MVC استفاده می شود. بنابراین طراحی فرم در قسمت View با کد HTM, CSS و JS انجام شده و ساختار مدل و دیتابیس آن نیز در قسمت Model انجام خواهد شد. حال کاربر فقط با Controller برنامه از طریق متد Get از درخواست های HTTP در تماس می باشد.

> این پروژه پس از نهایی سازی و تکمیل فرآیند توسعه بر روی ماشین مجازی (192.168.100.37) Publish شده است:

</p>

</div>

<div style="border: 1px solid #f1d5b1; widtd: 98%; height: 52px; padding-top: 13.5px; margin-bottom: 12px;">

<span style="font-weight:bold; background-color:Green; color:white; text-align:left; direction:ltr; width:30px; height: 35px; padding: 8px 26px; margin: 60px 0px 0 10px; position:absulate; "> GET </span>
<span style="margin-left:20px;"> https://jobs.index-holding.com/ </span>

</div>

<div style="direction:rtl; text-align:right;" dir="rtl">
<p>هنگام اجرای URL بالا، یک درخواست به Verb Get در Controller برنامه ارسال می شود و سپس یک Action اجرا شده که منجر به پردازش های لازم و اجرای View مربوط به این درخواست می شود.</p>
</div>

<div style="direction:ltr; text-align:left;" dir="ltr">

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

</div>

---

<div dir="rtl">

<div style = "font-size:20px; font-weight:bold; margin-bottom:10px; direction:ltr; text-align:right;" dir="rtl"> Introduction </div>

<div style = "font-size:15px; font-weight:bold; margin-bottom:10px; direction:ltr; text-align:right;" dir="rtl"> SDP.HR </div>

<p style="direction:rtl; text-align:justify;" dir="rtl">

> هدف از انجام این پروژه طراحی یک فرم برای استخدام افراد می باشد. برای این منظور از تکنولوژی ASP.NET Framework و معماری MVC استفاده شده است. متناسب با نیاز سازمان فرصت های شغلی مورد نیاز در سامانه HCM ثبت شده و سپس این اطلاعات از طریق برنامه HCMApllication به دیتابیس پروژه SDP منتقل شده تا هنگام لود فرم از دیتابیس خوانده شود.

> جهت دریافت جزئیات درخصوص ساختار این پروژه و سناریو آن به <a style="font-weight:bold;" href="https://alm.index-holding.com/IndexCollection/SoftDept/_wiki/wikis/SoftDept.wiki/63/SDP.HR"> Wiki </a> این پروژه مراجعه نمایید.


</p>

</div>

---

<div style = "font-size:20px; font-weight:bold; margin-bottom:10px; direction:ltr; text-align:left;" dir="rtl"> Technologies </div>

* ASP.NET Framework 4.6.1 (MVC)

* Bootstrap

* jQuery

* Microsoft.AspNet.Razor

* Microsoft.AspNet.WebApi

* Microsoft.AspNet.WebApi.Client

* Microsoft.AspNet.WebApi.Core

* Microsoft.AspNet.WebApi.WebHost

* Microsoft.AspNet.WebPages

* Microsoft.CodeDom.Providers.DotNetCompilerPlatform

* Microsoft.Net.Compilers

* Microsoft.Web.Infrastructure

* Newtonsoft.Json

* popper.js

</div>

---

<div style = "font-size:20px; font-weight:bold;"> محتویات فایل ReadMe.md </div>

<div dir = "ltr">

[[_TOC_]]

</div>

---

<div dir="rtl">

#ساختار
##نیازمندی های پروژه

<p style="direction:rtl; text-align:right;" dir="rtl">

* 1-  Frame Work های زیر را به پروژه اضافه نمایید:

</p>

<div dir="ltr">

    * DataAccessLayer

    * System.Net.Http

    * Newtonsoft.Json

    * System.Net.Http.Formatting

    * System.Web.Http.WebHost

    * System.Web.Http

    * System.Data.SqlClient

</div>

* 2-  NameSpace های زیر را در File Class اضافه نمایید.

<div dir="ltr">

    * using System.Collections.Generic;

    * using System.Data;

    * using System.Data.SqlClient;

    * using Newtonsoft.Json;

    * using System.Net.Http;

    * using System.Linq;

    * using System.Reflection;

    * using System.Collections.Specialized;

    * using DataAccessLayer;

</div>

---

<div dir="rtl">

## نحوه نصب پکیج ها مثل Entity Framework در پروژه

* جهت نصب پکیج ها می توانید به یکی از روش های زیر این عمل را انجام دهید:

1- Tools > NuGet Package Manager > Package Manager Console

2- Command زیر را در PowerShell بنویسید:

<div style = "direction:ltr; text-align:left;" dir="ltr">

    * Install-Package Newtonsoft.Json

</div>

3- همچنین می توانید روی پروژه کلیک راست کرده و گزینه Manage NuGet Packages را انتخاب نمایید.

</div>

---

## نحوه ایجاد DataBase
* ابتدا Database را براساس نمودار <a href="https://alm.index-holding.com/IndexCollection/SoftDept/_wiki/wikis/SoftDept.wiki/63/SDP.HR?anchor=erd-diagram">ERD</a> ترسیم شده ایجاد کرده و سپس کلاس مدل را براساس ساختار Database در برنامه ایجاد نمایید تا بتوانید اطلاعات مورد نیاز را هنگام لود فرم از دیتابیس بخوانید و سپس اطلاعات وارد شده توسط کاربر را نیز جهت ذخیره شدن در دیتابیس به Object تبدیل نمایید..

<div dir="ltr">

    1- Install-Package System.Data.SqlClient

</div>

---

# Run the app
<div dir="rtl">

* برای اجرای این پروژه نیاز است تا درخواستی از سمت کاربر به Controller برنامه ارسال شود. بنابراین پروژه پس از نهایی شدن روی سرور 192.168.100.37 و با آدرس <a href="https://jobs.index-holding.com/">Jobs</a> پابلیش گردید. برای دریافت توضیحات تکمیلی درخصوص ساختار و سناریو این پروژه به <a href="https://alm.index-holding.com/IndexCollection/SoftDept/_wiki/wikis/SoftDept.wiki/63/SDP.HR">WIKI</a> آن مراجعه نمایید.

</div>

---

<div dir="rtl">

# Code Snippet

## ساختار MVC

### نحوه دریافت پارامتر از Web.Config

<div dir="rtl">

> در ابتدایی ترین مرحله پس از Publish پروژه روی سرور 192.168.100.37، با ارسال اولین Request از سمت کاربر این پروژه اجرا می شود (<a href="https://jobs.index-holding.com/">Jobs</a>). با اجرای پروژه ابتدا فایل Global.asax اجرا می شود:

<div dir="ltr">

        public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            DALAgent.SetDatabaseName(AppInfo.DatabaseName);
            DALAgent.SetInstanceName(AppInfo.InstanceName);
            DALAgent.SetLoginMode(DALAgent.enDBLoginMode.DatabaseAuthentication);
            DALAgent.SetLoginId("******");
            DALAgent.SetLoginPassword("******");
        }
    }

</div>

> بنابراین تنظیمات مربوط به Route و اتصال به دیتابیس را در این قسمت قرار می دهیم. خط کد زیر را در نظر بگیرید:

<div dir="ltr">

    RouteConfig.RegisterRoutes(RouteTable.Routes); 
</div>

> با اجرای خط کد بالا فایل RouteConfig در پوشه App_Start اجرا می شود:

<div dir="ltr">

        public class RouteConfig
        {
            public static void RegisterRoutes(RouteCollection routes)
            {
                routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

                routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "HR", action = "Index", id = UrlParameter.Optional }
            );
        }
    }

</div>

> در کد بالا می توانید تنظیمات مربوط به Route پروژه را تغییر دهید. حال خط کد زیر را در نظر بگیرید:

<div dir="ltr">

    DALAgent.SetDatabaseName(AppInfo.DatabaseName);
</div>

> با اجرای کد بالا فایل AppInfo در پوشه Classes اجرا می شود:

<div dir="ltr">

    public class AppInfo
    {
        #region Properties
        #region DatabaseName
        private static string _DatabaseName=string.Empty;
        public static string DatabaseName
        {
            get
            {
                if (_DatabaseName == string.Empty)
                    _DatabaseName = GetAppSetting("DatabaseName");
                return _DatabaseName;
            }
        }
        
        #endregion
        #endregion
        #region Methods
        private static string GetAppSetting(string str)
        {
            try
            {
                return ConfigurationManager.AppSettings[str];
            }
            catch
            {
                return string.Empty;
            }
        } 
        #endregion
    }
</div>

> پس از اجرای این قسمت مقدار AppInfo.DatabaseName از Web.Config گرفته می شود:

<div dir="ltr">

    <add key="DatabaseName" value="******" />
</div>

> سپس فایل DALAgent در پروژه DataAccessLayer اجرا می شود. این پروژه از نوع Class Library بوده و به منظور تنظیم دسترسی داده ها ایجاد گردیده است.

<div dir="ltr">

    public static void SetDatabaseName(string dataBaseName)
    {
        SQLAgent.DatabaseName = dataBaseName;
    }
</div>

> با اجرای کد بالا پارامتر دریافتی از Web.Config  به فایل SQLAgent منتقل می شود:

<div dir="ltr">

    #endregion InstanceName

    #region DatabaseName

    private static string _DatabaseName;

    internal static string DatabaseName
    {
        get
        {
            return _DatabaseName;
        }
        set
        {
            _DatabaseName = value;
        }
    }
</div>

> درنهایت مقدار دریافتی از DALAgent در پارامتر _DatabaseName قرار می گیرد (Set).شایان به ذکر است که سایر پارامترها نیز به همین صورت تنظیم می گردد:

**ساختار Web.Config**

<div dir="ltr">

    <configuration>
        <appSettings>
            <add key="webpages:Version" value="3.0.0.0" />
            <add key="webpages:Enabled" value="false" />
            <add key="PreserveLoginUrl" value="true" />
            <add key="ClientValidationEnabled" value="true" />
            <add key="UnobtrusiveJavaScriptEnabled" value="true" />
            <add key="DatabaseName" value="dbSDP.HR" />
            <!--<add key="InstanceName" value=".\SQL2017"/>-->
            <add key="InstanceName" value="DEVELOP\MSSQLSERVER2017" />
            <add key="MaxCVSize_MB" value="15" />
            <add key="MaxImageSize_MB" value="3" />
            <add key="LogPath" value="C:\SDP.HR\Log" />
        </appSettings>
    </configuration>
   
</div>

**ساختار Global.asax**

<div dir="ltr">

    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            DALAgent.SetDatabaseName(AppInfo.DatabaseName);
            DALAgent.SetInstanceName(AppInfo.InstanceName);
            DALAgent.SetLoginMode(DALAgent.enDBLoginMode.DatabaseAuthentication);
            DALAgent.SetLoginId("******");
            DALAgent.SetLoginPassword("******");
        }
    }
   
</div>   
</div>

### ارسال درخواست به Action مربوطه در Controller
> پس از اجرای فایل Global.asax، اجرای برنامه به  Controller منتقل می شود و Action ها را اجرا می نماید:

<div dir="ltr">

    [HttpGet]
    public ActionResult Index()
    {
        return View();
    }
   
</div> 

> به متدهای بالا یک Action گفته می شود که یک View را به عنوان خروجی بر می گرداند و از آن جایی که نام View مشخص نشده است، Viewیی که همنام این متد است را اجرا می کند.(Index):

> View براساس قاعده Razor عمل می کند، بنابراین برای نوشتن کد #C بایستی از @ استفاده کنید. در این فایل ابتدا پارامترهای مورد نیاز را بخوانید(از Web.config یا سایر متدهای تعریف شده در برنامه):

<div dir="ltr">

    <script>
        var GetCitiesURL = "@Url.Action(actionName: "GetCities", controllerName: "HR")";
        var PostBackURL = "@Url.Action(actionName: "Index", controllerName: "HR")";
        var ShowCaptchaImageURL = "@Url.Action(actionName: "ShowCaptchaImage", controllerName: "HR")";
        var CVUploaderURL = "@Url.Action(actionName: "UploadCVFile", controllerName: "Uploader")";
        var ImageUploaderURL = "@Url.Action(actionName: "UploadImageFile", controllerName: "Uploader")";
        var MaxCVSize_MB = @(AppInfo.MaxCVSize_MB);
        var MaxImageSize_MB = @(AppInfo.MaxImageSize_MB);
        var CaptchaExpireDate = 0;
        var CaptchaTime_Second = 240;
    </script>
   
</div> 

## خواندن داده از Database
> در ادامه براساس کدهای Html و Css ساختار فرم را پیاده سازی کنید و با استفاده از JavaScript پویایی لازم مثل اعتبارسنجی فرمت ایمیل، ایجاد تقویم و ... را برای فرم مهیا فرمایید. پس از پیاده سازی بدنه فرم، برای دریافت داده از دیتابیس به صورت زیر عمل کنید:

### دریافت فرصت های شغلی از دیتابیس
> کد زیر برای پیاده سازی بدنه فرم قسمت فرصت های شغلی نوشته شده است:

<div dir="ltr">

                <div id="pnlJobOpportunity" class="panel panel-default">
                <div class="panel-heading">فرصت های موجود</div>
                <div class="panel-body">
                    <div id="lng_collapse" class="text-center">
                        <div class="table-responsive">
                            <div class="table">
                                <table id="jobTable" class="table table-bordered table-striped">
                                    <thead>
                                        <tr class="info">
                                            <th>
                                                انتخاب
                                            </th>
                                            <th>
                                                عنوان
                                            </th>
                                            <th>
                                                شرایط
                                            </th>
                                            <th>
                                                محل خدمت
                                            </th>
                                            <th>
                                                تاریخ اعتبار
                                            </th>
                                        </tr>
                                    </thead>
                                    <tbody id="job_body">
                                        @foreach (JobOpportunity jo in BaseInfo.JobOpportunityList)
                                        {
                                            <tr id="tr_job_Id_@(jo.Id) " class="job-tr">
                                                <td>
                                                    <input id="chbx_job_Id_@(jo.Id)" name="Job_Id_@(jo.Id)" type="checkbox" value="" class="job-Checkbox">
                                                </td>
                                                <td>
                                                    @jo.Title
                                                </td>
                                                <td>
                                                    @jo.Condition
                                                </td>
                                                <td>
                                                    @jo.Place
                                                </td>
                                                <td>
                                                    @(new PersianDate(jo.ExpireDate).ToDateString("/"))
                                                </td>
                                            </tr>
                                        }
                                    </tbody>
                                </table>
                            </div>

                        </div>
                    </div>
                </div>
            </div>
   
</div> 

> قطعه کد زیر را در نظر بگیرید:

<div dir="ltr">

    @foreach (JobOpportunity jo in BaseInfo.JobOpportunityList)

</div>

> با اجرای قطعه کد بالا ابتدا متد JobOpportunityList در کلاس BaseInfo اجرا می شود:

<div dir="ltr">

    #endregion
    #region JobOpportunityList
    private static DateTime _JobOpportunityList_LastUpdate = DateTime.Now;
    private static List<JobOpportunity> _JobOpportunityList = new List<JobOpportunity>();
    public static List<JobOpportunity> JobOpportunityList
    {
        get
        {
            if (_JobOpportunityList.Count == 0 || _JobOpportunityList_LastUpdate <DateTime.Now.AddMinutes(-10))
            {
                _JobOpportunityList = JobOpportunity.SelectAll();
                _JobOpportunityList_LastUpdate = DateTime.Now;
            }

            return _JobOpportunityList;
        }
        set
        {
            _JobOpportunityList = value;
        }
    }

</div>

> سپس متد SelectAll در کلاس JobOpportunity اجرا خواهد شد:

<div dir="ltr">

    #endregion
    #endregion
    #region Methods
    public static List<JobOpportunity> SelectAll()
    {
        List<JobOpportunity> result = new List<JobOpportunity>();
        List<DALParameter> parameters = new List<DALParameter>();
        parameters.Add(new DALParameter("@ExpireDate", PersianDate.Now.To8DigitString()));
        DALOutput dalo = DALAgent.ExecuteProcedure("SP_JobOpportunity_SelAll",DALAgent.enDBMethodOutput.MultipleValue, parameters);
        DataTable dt = dalo.Value == null ? new DataTable() : (DataTable)daloValue;
        result = dt.ToList<JobOpportunity>();
        return result;
    }
    #endregion
    
</div>

> سپس برای تبدیل تاریخ میلادی به شمسی کدهای زیر به ترتیب اجرا می شوند:

<div dir="ltr">

    1- public static readonly PersianDate MaxValue = DateTime.MinValue;
    
    2- public static implicit operator PersianDate(DateTime dt)
        {
            return new PersianDate(dt);
        }

    3- private PersianCalendar pc = new PersianCalendar();

    4- public PersianDate(DateTime dt)
        {
            currentDateTime = dt;
        }

    5- public static readonly PersianDate MinValue = DateTime.MaxValue;

    6- public static implicit operator PersianDate(DateTime dt)
        {
            return new PersianDate(dt);
        }

    7- private PersianCalendar pc = new PersianCalendar();

    8- public PersianDate(DateTime dt)
        {
            currentDateTime = dt;
        }

    9- public static string[] MonthArray = { "فروردین", "اردیبهشت", "خرداد", "تیر", "مرداد", "شهریور", "مهر", "آبان", "آذر", "دی", "بهمن", "اسفند" };

    10- private static string _ConnectionString = string.Empty;

</div>

> در ادامه برای دریافت ExpireDate متدهای Now و To8DigitString در کلاس PersianDate اجرا خواهد شد. بنابراین ابتدا متد Now اجرا می شود:

<div dir="ltr">

    public static PersianDate Now
        {
            get
            {
                PersianDate result = null;
                if (ConnectionString.Length > 0)
                {
                    SqlConnection SqlConnection = new SqlConnection(ConnectionString);
                    if (SqlConnection.State != ConnectionState.Open)
                    {
                        try
                        {
                            SqlConnection.Open();
                        }
                        catch { }
                    }
                    try
                    {
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = SqlConnection;
                        cmd.CommandText = "Select GetDate();";
                        DateTime dt = (DateTime)cmd.ExecuteScalar();
                        result = dt;
                    }
                    catch
                    {
                    }
                }
                if (PersianDate.Equals(result, null)) // در مرحله قبل مقدار نگرفته
                {
                    DateTime dt = DateTime.Now;
                    result = dt;
                }
                return result;
            }
        }
    
</div>

> بنابراین درصورتی که مقدار ConnectionString.Length از صفر کوچک تر باشد، کد زیر اجرا می شود:

<div dir="ltr">

    if (PersianDate.Equals(result, null)) // در مرحله قبل مقدار نگرفته
    {
        DateTime dt = DateTime.Now;
        result = dt;
    }

</div>

> پس از اجرا شدن کد بالا، کدهای زیر به ترتیب  اجرا خواهد شد:

<div dir="ltr">

    1- public static implicit operator PersianDate(DateTime dt)
    {
        return new PersianDate(dt);
    }

    2- private PersianCalendar pc = new PersianCalendar();

    3- public PersianDate(DateTime dt)
        {
            currentDateTime = dt;
        }

    4- public static implicit operator PersianDate(DateTime dt)
        {
            return new PersianDate(dt);
        }

    5- if (PersianDate.Equals(result, null)) // در مرحله قبل مقدار نگرفته
        {
            DateTime dt = DateTime.Now;
            result = dt;
        }
        return result; 
</div>

> در نهایت مقدار Result برابر تاریخ شمسی می باشد. در ادامه متد To8DigitString در کلاس PersianDate اجرا شده و مقدار تاریخ را به string تبدیل می نماید:

<div dir="ltr">

    1- public string To8DigitString()
        {
            string result = ToDateString();
            return result;
        }

    2- public string ToDateString(string delim = "")
        {
            string result = Year.ToString("00") + delim + Month.ToString("00") + delim + Day.ToString("00");
            return result;
        }

    3- public int Year
        {
            get
            {
                return pc.GetYear(currentDateTime);
            }
        }

    4- public int Month
        {
            get
            {
                return pc.GetMonth(currentDateTime);
            }
        }

    5- public int Day
        {
            get
            {
                return pc.GetDayOfMonth(currentDateTime);
            }
        }

</div>

> درنهایت Constructore مربوطه در کلاس DALParameter اجرا شده و پارامترهای به دست آمده به آن ارسال می گردد:

<div dir="ltr">

    public DALParameter(string name, object value, bool isDataTable = false)
        {
            Name = name;
            Value = value;
            IsDataTable = isDataTable;
        }

</div>

> در ادامه خط کد زیر در کلاس JobOpportunity اجرا می شود:

<div dir="ltr">

    DALOutput dalo = DALAgent.ExecuteProcedure("SP_JobOpportunity_SelAll", DALAgent.enDBMethodOutput.MultipleValue, parameters);

</div>

> با اجرا شدن خط کد بالا متد ExecuteProcedure در کلاس DALAgent اجرا می شود:

<div dir="ltr">

        public static DALOutput ExecuteProcedure(string procedureName, DALAgent.enDBMethodOutput methodOutput, List<DALParameter> lstParameters = null)
        {
            DALOutput result = SQLAgent.Execute(enDBMethodType.StoredProcedure, methodOutput, procedureName, lstParameters);
            return result;
        }

</div>

> سپس متد Execute در کلاس SQLAgent اجرا می شود و سپس کدهای زیر به ترتیب اجرا خواهند شد:

<div dir="ltr">

        1- public static DALOutput Execute(DALAgent.enDBMethodType methodType, DALAgent.enDBMethodOutput methodOutput, string commandText, List<DALParameter> lstParametes)
        {
            SqlConnection con = new SqlConnection(ConnectionString);

        2- public static string ConnectionString
        {
            get
            {
                return string.Format(@"Data Source={0};Initial Catalog={1};Connect Timeout={2};{3}", 
                InstanceName, DatabaseName, TimeOut, (LoginMode == DALAgent.enDBLoginMode.DatabaseAuthentication ? 
                string.Format(@"User ID={0};Password={1}", LoginId, LoginPassword) : "Integrated Security=True"));
            }
        }

        3- internal static string InstanceName
        {
            get
            {
                return _InstanceName;
            }
        }

        4- internal static string DatabaseName
        {
            get
            {
                return _DatabaseName;
            }
        }

        5- internal static int TimeOut
        {
            get
            {
                return _TimeOut;
            }
        }

        6- internal static DALAgent.enDBLoginMode LoginMode
        {
            get
            {
                return _LoginMode;
            }
        }

        7- internal static string LoginId
        {
            get
            {
                return _LoginId;
            } 
        }

        8- internal static string LoginPassword
        {
            get
            {
                return _LoginPassword;
            }
        }

</div>

> پس از برقراری رشته اتصال به Database ( SQL Sonnection )، کوئری های زیر ( Command ) اجرا خواهد شد (در کلاس SQLAgent):

<div dir="ltr">

    SqlConnection con = new SqlConnection(ConnectionString);
            if (con.State == ConnectionState.Broken || con.State == ConnectionState.Closed)
                con.Open();
            DALOutput result = new DALOutput();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = commandText;
            cmd.CommandType = methodType == DALAgent.enDBMethodType.StoredProcedure ? CommandType.StoredProcedure : CommandType.Text;
            cmd.Connection = con;
            if (lstParametes != null)
                foreach (DALParameter dalp in lstParametes)
                {
                    cmd.Parameters.Add(dalp);
                }
</div>

> با اجرای foreach بالا، متد System.Data.SqlClient.SqlParameter در کلاس DALParameter اجرا می شود:

<div dir="ltr">

    public static implicit operator System.Data.SqlClient.SqlParameter(DALParameter dalp)
        {
            System.Data.SqlClient.SqlParameter result = new System.Data.SqlClient.SqlParameter();
            result.ParameterName = dalp.Name;
            result.Value = dalp.Value;
            result.Direction = dalp.Direction;
            result.DbType = dalp.DBType;
            if (dalp.IsDataTable)
            {
                result.SqlDbType = SqlDbType.Structured;
            }
            if (dalp.IsNative)
            {
                result.SqlDbType = SqlDbType.NVarChar;
            }
            return result;
        }

</div>

> در ادامه متد Execute در کلاس SQLAgent اجرا خواهد شد:

<div dir="ltr">

    switch (methodOutput)
            {
                case DALAgent.enDBMethodOutput.MultipleValue:
                    cmd.CommandTimeout = 60;
                    SqlDataReader sdr = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(sdr);
                    result.Value = dt.Columns.Count == 0 ? null : dt;
                    break;

                case DALAgent.enDBMethodOutput.SingleValue:
                    result.Value = cmd.ExecuteScalar();
                    break;

                case DALAgent.enDBMethodOutput.Nothing:
                    cmd.ExecuteNonQuery();
                    break;

                default:
                    break;
            }
            con.Close();
            return result;

</div>

>حال نتیجه متد Execute به متد ExecuteProcedure در کلاس DALAgent بازگردانده می شود:

<div dir="ltr">

    DALOutput result = SQLAgent.Execute(enDBMethodType.StoredProcedure, methodOutput, procedureName, lstParameters);
            return result;

</div>

> پس از آن کدهای زیر در کلاس JobOpportunity اجرا می شود:
<div dir="ltr">

    DataTable dt = dalo.Value == null ? new DataTable() : (DataTable)dalo.Value;
    result = dt.ToList<JobOpportunity>();

</div>

> درنهایت متد ToList برای لیست کردن اطلاعات در کلاس ExtenstionMethods اجرا می شود و با استفاده از متد BindValueToObject در کلاس ExtenstionMethods اطلاعات دریافت شده درون لیست Bind می شود:
<div dir="ltr">

    1- public static List<T> ToList<T>(this DataTable dt)
        {
            List<T> result = new List<T>();
            List<PropertyInfo> lstPropertyInfo = typeof(T).GetProperties().ToList();
            foreach (DataRow dr in dt.Rows)
            {
                object obj = (T)Activator.CreateInstance(typeof(T));
                foreach (PropertyInfo pi in lstPropertyInfo)
                {
                    BindValueToObject(pi, obj, dr[pi.Name]);

                }
                result.Add((T)obj);
            }
            return result;
        }

    2- private static void BindValueToObject(PropertyInfo pi, object obj, object value)
        {

            try
            {
                string pt = pi.PropertyType.Name.ToLower();
                switch (pt)
                {
                    case "boolean":
                        if (value is null)
                            obj.GetType().GetProperty(pi.Name).SetValue(obj, false);
                        else if (value.ToString() == "on"  || value.ToString() == "true")
                            obj.GetType().GetProperty(pi.Name).SetValue(obj, true);
                        else
                            obj.GetType().GetProperty(pi.Name).SetValue(obj, false);
                        break;
                    case "int64":
                        obj.GetType().GetProperty(pi.Name).SetValue(obj, long.Parse(value.ToString().Replace(",", string.Empty)));
                        break;
                    case "int32":
                        obj.GetType().GetProperty(pi.Name).SetValue(obj, int.Parse(value.ToString().Replace(",",string.Empty)));
                        break;
                    case "int16":
                        obj.GetType().GetProperty(pi.Name).SetValue(obj, short.Parse(value.ToString().Replace(",", string.Empty)));
                        break;
                    case "byte":
                        obj.GetType().GetProperty(pi.Name).SetValue(obj, byte.Parse(value.ToString().Replace(",", string.Empty)));
                        break;
                    case "single":
                        obj.GetType().GetProperty(pi.Name).SetValue(obj, float.Parse(value.ToString().Replace(",", string.Empty)));
                        break;
                    case "string":
                        obj.GetType().GetProperty(pi.Name).SetValue(obj, value.ToString());
                        break;
                    case "nullable`1":
                        string type = obj.GetType().GetProperty(pi.Name).ToString().Replace("System.Nullable`1[", string.Empty).Replace("]", string.Empty).Replace(pi.Name, string.Empty).Trim().ToLower();
                        switch (type)
                        {
                            case "system.boolean":
                                if (value is null)
                                    obj.GetType().GetProperty(pi.Name).SetValue(obj, false);
                                else if (value.ToString() == "on" || value.ToString() == "true")
                                    obj.GetType().GetProperty(pi.Name).SetValue(obj, true);
                                else
                                    obj.GetType().GetProperty(pi.Name).SetValue(obj, false);
                                break;

                            case "system.byte":
                                obj.GetType().GetProperty(pi.Name).SetValue(obj, byte.Parse(value.ToString().Replace(",", string.Empty)));
                                break;
                            case "system.int16":
                                obj.GetType().GetProperty(pi.Name).SetValue(obj, short.Parse(value.ToString().Replace(",", string.Empty)));
                                break;
                            case "system.int32":
                                obj.GetType().GetProperty(pi.Name).SetValue(obj, int.Parse(value.ToString().Replace(",", string.Empty)));
                                break;
                            case "system.int64":
                                obj.GetType().GetProperty(pi.Name).SetValue(obj, long.Parse(value.ToString().Replace(",", string.Empty)));
                                break;
                            case "system.single":
                                obj.GetType().GetProperty(pi.Name).SetValue(obj, float.Parse(value.ToString().Replace(",", string.Empty)));
                                break;
                            default:
                                break;
                        }
                        break;
                    default:
                        break;
                }

            }
            catch 
            {

            }
        }

</div>

> با استفاده از دو متد بالا کلیه اطلاعات از دیتابیس خوانده شده و درون لیست ذخیره می گردد تا در View قرار گرفته و هنگام لود فرم فرصت های شغلی به کاربر نمایش داده شود.

> سپس به منظور دریافت تاریخ اعتبار هر فرصت شغلی از Database نیز کدهای زیر اجرا می شود (در کلاس PersianDate):

<div dir="ltr">

    public PersianDate(string str, string delim = " ")
        {
            if (delim!=string.Empty)
            {
                try
                {
                    string[] arr = str.Split(delim.ToCharArray());
                    str = string.Empty;
                    str += arr[0].PadLeft(4,'0');
                    str += arr[1].PadLeft(2,'0');
                    str += arr[2].PadLeft(2, '0');
                }
                catch 
                {
                }
            }
            str = str.Replace(delim, string.Empty);
            int year = 0, month = 0, day = 0, hour = 0, minute = 0, second = 0;
            try
            {
                year = int.Parse(str.Substring(0, 4));
            }
            catch
            {
            }
            try
            {
                month = int.Parse(str.Substring(4, 2));
            }
            catch
            {
            }
            try
            {
                day = int.Parse(str.Substring(6, 2));
            }
            catch
            {
            }
            try
            {
                hour = int.Parse(str.Substring(8, 2));
            }
            catch
            {
            }
            try
            {
                minute = int.Parse(str.Substring(10, 2));
            }
            catch
            {
            }
            try
            {
                second = int.Parse(str.Substring(12, 2));
            }
            catch
            {
            }
            currentDateTime = pc.ToDateTime(year, month, day, hour, minute, second, 0);
        }

</div>

> در نهایت کلیه رکوردهای خوانده شده از Database در View در جدولی قرار می گیرد( به منظور نمایش به کاربر):

<div dir="ltr">

    <tbody id="job_body">
        @foreach (JobOpportunity jo in BaseInfo.JobOpportunityList)
        {
            <tr id="tr_job_Id_@(jo.Id) " class="job-tr">
            <td>
                <input id="chbx_job_Id_@(jo.Id)" name="Job_Id_@(jo.Id)" type="checkbox" value="" class="job-Checkbox">
            </td>
            <td>
                @jo.Title
            </td>
            <td>
                @jo.Condition
            </td>
            <td>
                @jo.Place
            </td>
            <td>
                @(new PersianDate(jo.ExpToDateString("/"))
            </td>
        </tr>
        }
    </tbody>

</div>

**نکته:**

> برای سایر موارد همچون جنسیت، وضعیت تأهل و ... نیز همین روال طی می شود تا اطلاعات مورد نیاز از Database خوانده شده و درون View قرار گیرد تا به کاربر نمایش داده شود.

## دریافت اطلاعات وارد شده توسط کاربر و ذخیره در دیتابیس 
> کاربر پس از پر کردن فرم روی ارسال اطلاعات کلیک می نماید، با این کار رویداد SendData در فایل MainScript.js اجرا می شود:

<div dir="ltr">

    function SendData() {
    $('.errorComponent').prop('title', '');
    $('.errorComponent').removeClass('errorComponent');
    if (CheckValidation() === false) {
        return;
    }
    if ((($("#txtUploadCVFile"))[0].files.length > 0) && ($('#btnUploadCV').css('display') != "none")) {
        if (confirm('فایل انتخابی شما هنوز آپلود نشده، آیا میخواهید بدون آپلود رزومه اطلاعات را ارسال کنید؟')) {
            // Continue;
        } else {
            return;
        }
    }
    var checkedJO = $('input[id^="chbx_job_Id_"]:checked').length;
    var formObject = $('form').serialize();
    $('#btnSubmit').prop('disabled', true);
    $.ajax({
        url: PostBackURL,
        type: 'POST',
        data: formObject,
        success: function (response) {
            var successPost = response.success;
            if (successPost == true) {
                $('.errorComponent').prop('title', '');
                $('.errorComponent').removeClass('errorComponent');
                setTimeout(function () { window.location = "http://index-holding.com"; }, 5000);
                $('#myModal').modal('show');
            }
            else {
                var message = response.message;
                if (message.length > 0) {
                    alert(message);
                }
                ShowErrorList(response.errors);
            }
        }
    })
        //.fail(function () {
        //    alert("error");
        .fail(function (jqXHR, textStatus) {
            alert("error: " + textStatus);
        })
        .always(function () {
            $('#btnSubmit').prop('disabled', false);
        });
    }

</div>

> سایر رویدادهای تعریف شده در OnClick در View در فایل MainScript.js تعریف شده اند. به مثال زیر توجه کنید:
<div dir="ltr">

    <img class="captchControl" id="imgCaptcha" src="@Url.Action("ShowCaptchaImage", "HR",PersianDate.Now.To14DigitString())" alt="Captcha" onclick="CaptchaReferesh();">

    function CaptchaReferesh() {
    $('#imgCaptcha').attr("src", ShowCaptchaImageURL + '/' + new Date().getTime());
    CaptchaExpireDate = Date.now() + CaptchaTime_Second * 1000;
    $('#txtCaptchCode').val("")
    }

</div>

## مدیریت ایمیل و کد ملی توسط جاوااسکریپت
### صحت سنجی کد ملی (MainScript.js)

<div dir="ltr">

        <input class="form-control txt-req" id="txtNationalId" name="NationalId" placeholder="کدملی" type="number" value="">


        $nId = $("#txtNationalId");
        var nationalId = $nId.val();
        var check = parseInt(nationalId[9]);
        var sum = 0;
        var i;
        for (i = 0; i < 9; ++i) {
            sum += parseInt(nationalId[i]) * (10 - i);
        }   
        var mod = sum % 11;
        var invalid = true;

        if ((mod < 2 && check == mod) || (mod >= 2 && check + mod == 11)) {
            invalid = false;
            }
        if ((!/^\d{10}$/.test(nationalId)) || invalid) {
            $nId.addClass('invalidComponent');
            $nId.prop('title', 'کد ملی وارد شده معتبر نمی باشد!');
            }
        }

</div>

### صحت سنجی تاریخ (MainScript.js)

<div dir="ltr">

    <input type="text" id="txtBirthDate" name="BirthDate" placeholder="تاریخ تولد" class="form-control txt-req PersianDatePicker" />

    /////////////////////////////////   Check PersianDate Field   /////////////////////////////////
    $('.PersianDatePicker').each(function () {
        var persianDate = $(this).val();
        if (!IsValidDate(persianDate, 1300, new Date().getFullYear() - 622 + 1)) {
            var ph = $(this).attr('placeholder');
            str = ph + ' معتبر نمی باشد!';
            $(this).addClass('invalidComponent');
            $(this).prop('title', str);
        }
    });
    persianDate = $('#txtBirthDate').val();
    if (!IsValidDate(persianDate, 1300, new Date().getFullYear() - 622 - 17)) {
        var ph = $('#txtBirthDate').attr('placeholder');
        str = ph + ' معتبر نمی باشد!';
        $('#txtBirthDate').addClass('invalidComponent');
        $('#txtBirthDate').prop('title', str);

    }

</div>

> سایر موارد نیز به همین صورت انجام شده است. شایان به ذکر است استایل مربوط به فرم نیز از طریق Bootstrap و فایل MainStyle.css اعمال گردیده است.


## مدیریت خطا در Controller
> پس از آن که کاربر روی ارسال اطلاعات کلیک کرد کلیه اطلاعات وی از طریق رویداد OnClick توسط Ajax ذخیره شده و به Controller جهت بررسی شرط های اعمال شده ارسال می گردد. این شرط ها درون Action تعریف شده در Controller از نوع متد HTTP POST تعریف شده است.

> مثلا بررسی می شود که فیلدهای اجباری حتما توسط کاربر پر شده باشند، در غیر این صورت پیام خطایی به کاربر نمایش داده شود یا با قرمز کردن قسمت های خالی ضروری بودن پر کردن اطلاعات در این قسمت ها را به کاربر نشان دهید.

<div dir="ltr">

    [HttpPost]
        public ActionResult Index(string str)
        {
            PostResponse response = new PostResponse();
            response.success = true;
            List<ControlError> lstError = new List<ControlError>();
            Person p = Person.FromForm(Request.Form);

            try
            {
                PersianDate bd = new PersianDate(p.BirthDate);
                if (bd.Year>DateTime.Now.Year-18 || bd.Year<1300)
                    lstError.Add(new ControlError { ControlId = "txtBirthDate", ErrorText = "تاریخ تولد معتبر نمی‌باشد!" });
            }
            catch {
                    lstError.Add(new ControlError { ControlId = "txtBirthDate", ErrorText = "تاریخ تولد معتبر نمی‌باشد!" });
            }
            try
            {
                if (p.CertificatePlace.Length<=0)
                    lstError.Add(new ControlError { ControlId = "txtCertificatePlace", ErrorText = "محل صدور شناسنامه معتبر نمی‌باشد!" });
            }
            catch
            {
            }
            try
            {
                if (p.BirthPlace.Length <= 0)
                    lstError.Add(new ControlError { ControlId = "cmbxBirthCity", ErrorText = "محل تولد معتبر نمی‌باشد!" });
            }
            catch
            {
            }
            try
            {
                if (p.City.Length <= 0)
                    lstError.Add(new ControlError { ControlId = "cmbxCity", ErrorText = "شهر معتبر نمی‌باشد!" });
            }
            catch
            {
            }
            try
            {
                p.Attachment = (byte[])(Session["CV"]);
                p.FileType = Session["CVFileType"].ToString();
                p.FileName= Session["CVFileName"].ToString();
            }
            catch { }
            try
            {
                p.Image = (byte[])(Session["Image"]);
                p.ImageFileType = Session["ImageFileType"].ToString();
                p.ImageFileName = Session["ImageFileName"].ToString();
            }
            catch { }
            bool OKCaptcha = false;
            #region Check Captcha
            try
            {
                int captchaCode = int.Parse(Request.Form["CaptchaCode"]);
                if ((int)Session["CaptchaCode"] == captchaCode)
                {
                    OKCaptcha = true;
                }
            }
            catch
            {

            }
            if (!OKCaptcha)
                lstError.Add(new ControlError { ControlId = "txtCaptchCode", ErrorText = "کد امنیتی وارد شده صحیح نمی باشد!" });
            #endregion

            #region Insert Person
            if (lstError.Count == 0)
            {
                try
                {
                    p.Insert();
                }
                catch(Exception exp)
                {
                    Logger.WriteError("Error In Inserting Person",exp);
                    //System.IO.File.WriteAllText($@"C:\WebLog\{DateTime.Now.Date}.txt", 
                    //    $"+++{DateTime.Now}+++\r\n Message:{exp.Message}---InnerExecption:{exp.InnerException}-----Source:{exp.Source}---Data:{exp.Data}");
                    string msg = exp.Message;
                    response.success = false;
                    response.message = "خطا در درج اطلاعات، لطفا لحظاتی دیگر مجددا تلاش کنید.";
                }
            } 
            #endregion

            response.errors = lstError.ToArray();
            if (lstError.Count > 0)
            {
                response.success = false;
                if (response.message.Length == 0)
                    response.message = "لطفا خطاهای مشخص شده را بر طرف کنید.";
            }
            return Json(response);
        }
        public ActionResult ShowCaptchaImage()
        {
            bool noisy = true;
            var rand = new Random((int)DateTime.Now.Ticks);
            int a = rand.Next(1000, 9999);
            //int b = rand.Next(0, 9);
            var captcha = string.Format("{0}", a);
            Session["CaptchaCode"] = a;
            FileContentResult img = null;
            using (var mem = new MemoryStream())
            using (var bmp = new Bitmap(50, 30))
            using (var gfx = Graphics.FromImage((Image)bmp))
            {
                gfx.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
                gfx.SmoothingMode = SmoothingMode.AntiAlias;
                gfx.FillRectangle(Brushes.White, new Rectangle(0, 0, bmp.Width, bmp.Height));
                if (noisy)
                {
                    int i, r, x, y;
                    var pen = new Pen(Color.Yellow);
                    for (i = 1; i < 5; i++)
                    {
                        pen.Color = Color.FromArgb(
                        (rand.Next(0, 255)),
                        (rand.Next(0, 255)),
                        (rand.Next(0, 255)));

                        r = rand.Next(0, (130 / 3));
                        x = rand.Next(0, 130);
                        y = rand.Next(0, 30);

                        gfx.DrawEllipse(pen, x - r, y - r, r, r);
                    }
                }
                gfx.DrawString(captcha, new Font("Tahoma", 15), Brushes.Gray, 2, 3);
                bmp.Save(mem, System.Drawing.Imaging.ImageFormat.Jpeg);
                img = this.File(mem.GetBuffer(), "image/Jpeg");
            }
            return img;
        }
        [HttpGet]
        public JsonResult GetCities(short id)
        {
            try
            {
                return Json(City.SelectByProvinceId(id), JsonRequestBehavior.AllowGet);
            }
            catch 
            {
                return null;
            }
        }
</div>
</div>

<hr />

# Sources
<div style="text-align:left; direction:ltr;" dir="ltr">
<p>

* https://jobs.index-holding.com/

* https://toplearn.com/courses/4464/%D8%A2%D9%85%D9%88%D8%B2%D8%B4-asp-netmvc-%D8%A8%D9%87-%D9%87%D9%85%D8%B1%D8%A7%D9%87-%D9%BE%D8%B1%D9%88%DA%98%D9%87-%D8%B9%D9%85%D9%84%DB%8C-%D9%85%D8%AE%D8%B5%D9%88%D8%B5-%D9%86%D8%A7%D8%B4%D9%86%D9%88%D8%A7%DB%8C%D8%A7%D9%86

* http://babakhani.github.io/PersianWebToolkit/doc/datepicker/example/

* https://www.youtube.com/watch?v=uW6inNunRd4&list=PLwaRIh0Jkkle0TVV9iHR4SKiJlW43bB6P

* https://www.youtube.com/watch?v=E7Voso411Vs

* https://www.youtube.com/results?search_query=%D8%A2%D9%85%D9%88%D8%B2%D8%B4+asp.net+framework+mvc

* https://www.w3schools.com/asp/asp_ref_server.asp

* https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Date/getFullYear

* https://developer.mozilla.org/de/docs/Web/JavaScript/Reference/Global_Objects/Date/getYear

</p>
</div>
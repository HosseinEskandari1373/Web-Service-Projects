<div dir="rtl">

<div style = "font-size:20px; font-weight:bold; margin-bottom:10px; direction:ltr; text-align:right;" dir="rtl"> Publish </div>

<p style="direction:rtl; text-align:right;" dir="rtl">

> پروژه SanaAPI_DatabaseFirst به عنوان یک رابط (API) جهت خواندن نرخ ارز از API و انتقال آن ها به یک دیتابیس واسط جهت ذخیره در سامانه XRM ایجاد گردیده است. 

> این پروژه پس از نهایی سازی و تکمیل فرآیند توسعه بر روی ماشین مجازی SOE(192.168.102.24:65002) پابلیش شده است.(از آنجایی که جهت خواندن نرخ ارز از API به اینترنت نیاز می باشد روی ماشین مجازی SOE پابلیش شده است.)

</p>

</div>

<div style="border: 1px solid #f1d5b1; widtd: 98%; height: 50px; padding-top: 13.5px; margin-bottom: 12px;">

<span style="font-weight:bold; background-color:#fca130; color:white; text-align:left; direction:ltr; width:30px; height: 35px; padding: 8px 26px; margin: 60px 0px 0 10px; position:absulate; "> POST </span>
<span style="margin-left:20px;"> /api/CreateSanaAPI/sanaapi/CreateCurrency (http://192.168.102.24:65002/api/CreateSanaAPI/sanaapi/CreateCurrency)</span>

</div>

<div style="direction:rtl; text-align:right;" dir="rtl">
<p>به عنوان مثال متناسب با Request بالا پارامتر زیر به Verb POST در پروژه ConnectXRM ارسال می گردد:</p>
</div>

<div style="direction:ltr; text-align:left;" dir="ltr">

      [{ 
        //  مقداری ندارد و فقط نرخ ارز را درصورت ناموجود بودن در دیتابیس به روز می نماید Verb این      
      }]

</div>

---

<div dir="rtl">

<div style = "font-size:20px; font-weight:bold; margin-bottom:10px; direction:ltr; text-align:right;" dir="rtl"> Introduction </div>

<div style = "font-size:15px; font-weight:bold; margin-bottom:10px; direction:ltr; text-align:right;" dir="rtl"> SanaAPI_DatabaseFirst </div>

<p style="direction:rtl; text-align:justify;" dir="rtl">

> هدف از انجام این پروژه واکشی مقادیر ارز از API سایت <a href="https://www.tgju.org/api"> TGJU </a> و ذخیره در یک Database واسط می باشد.  بنابراین مقادیر ارز را از API این سایت خوانده و سپس در دیتابیس ذخیره می نماید. برای این منظور یک پروژه از نوع Asp.Net 5 Web API ایجاد کنید.

> جهت دریافت جزئیات درخصوص ساختار این پروژه و سناریو آن به <a style="font-weight:bold;" href="https://alm.index-holding.com/IndexCollection/SoftDept/_wiki/wikis/SoftDept.wiki/58/SanaAPI_DatabaseFirst"> Wiki </a> این پروژه مراجعه نمایید.


</p>

</div>

---

<div style = "font-size:20px; font-weight:bold; margin-bottom:10px; direction:ltr; text-align:left;" dir="rtl"> Technologies </div>

* ASP.NET 5 Web API

* Microsoft.EntityFrameworkCore.SqlServer

* Microsoft.EntityFrameworkCore.Tools

* Newtonsoft.Json

* NETCore.MailKit

* MimeKit

* Serilog.AspNetCore

* Serilog.Settings.Configuration

* Serilog.Sinks.MSSqlServer

</div>

---

<div style = "font-size:20px; font-weight:bold;"> محتویات فایل ReadMe.md </div>

<div dir = "ltr">

[[_TOC_]]

</div>

---

<div dir="rtl">

#Structure

<p style="direction:rtl; text-align:right;" dir="rtl">

# نیازمندی های پروژه
* 1-  Frame Work های زیر را به پروژه اضافه نمایید:

</p>

<div dir="ltr">

    * Microsoft.EntityFrameworkCore.SqlServer

    * Microsoft.EntityFrameworkCore.Tools

    * Newtonsoft.Json

    * NETCore.MailKit

    * MimeKit

    * Serilog.AspNetCore

    * Serilog.Settings.Configuration

    * Serilog.Sinks.MSSqlServer

</div>

* 2-  NameSpace های زیر را در File Class اضافه نمایید.

<div dir="ltr">

    * using Microsoft.EntityFrameworkCore;

    * using Newtonsoft.Json;

    * using System.Net.Http;

    * using MailKit.Net.Smtp;

    * using MailKit.Security;

    * using MimeKit;

    * using Microsoft.Extensions.Logging;

</div>

---

<div dir="rtl">

# نحوه نصب پکیج ها مثل Entity Framework در پروژه

* جهت نصب EF در پروژه می توانید به روش های زیر عمل نمایید:

1- Tools > NuGet Package Manager > Package Manager Console

2- Command زیر را در PowerShell بنویسید:

<div style = "direction:ltr; text-align:left;" dir="ltr">

    * Install-Package Microsoft.EntityFrameworkCore.SqlServer

</div>

3- همچنین می توانید روی پروژه کلیک راست کرده و گزینه Manage NuGet Packages را انتخاب نمایید.

</div>

---

# نحوه ایجاد DataBase
* ابتدا Database را براساس نمودار <a href="https://alm.index-holding.com/IndexCollection/SoftDept/_wiki/wikis/SoftDept.wiki/58/SanaAPI_DatabaseFirst?anchor=erd-diagram">ERD</a> ترسیم شده ایجاد کرده و سپس کلاس مدل را براساس ساختار Database در برنامه ایجاد نمایید تا بتوانید مقادیر ارز خوانده از وب سرویس را جهت Add نمودن در Database به Object تبدیل نمایید.

<div dir="ltr">

    1- Install-Package Microsoft.EntityFrameworkCore.Tools

</div>

---

# Run the app
<div dir="ltr">

* Visual Studio uses an inconsistent working directory when running .NET Core console apps. (see dotnet/project-system#3619) This results in an exception being thrown: no such table: Blogs. To update the working directory

    * Right-click on the project and select Edit Project File

    * Just below the TargetFramework property, add the following
        `<StartWorkingDirectory>$(MSBuildProjectDirectory)</StartWorkingDirectory>`
    
    *  Save the file

Now you can run the app:

    * Debug > Start Without Debugging

</div>

---

<div dir="rtl">

#Code Snippet

### Read API Console Code

> ابتدا باید API را بخوانید و سپس با استفاده از کتابخانه Newtonsoft .Json آن را به Object تبدیل کنید. برای تعریف مدل API می توانید از json2csharp.com استفاده کنید. (در پوشه ReadData فایل ReadData.cs تعریف گردیده است)

</div>

<div dir="ltr">

        public static Root GetAPI()
        {
            var Url = configuration.GetSection("AppSettings").GetSection("ApiUrl").Value;
            var Token = configuration.GetSection("AppSettings").GetSection("Token").Value;

            HttpClient Client = new HttpClient();
            Client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Token);

            //Convert Json(API) to Object
            string result = Client.GetStringAsync(Url).Result;

            SanaAPI currency = JsonConvert.DeserializeObject<SanaAPI>(result);
        }

</div>

> همانطور که در کد بالا مشاهده می نمایید Url و Token مربوط به وب سرویس در appsetting.json به صورت زیر تعریف شده و سپس در برنامه از آن ها استفاده می شود:

<div dir="ltr">

    "ConnectionStrings": {
    "ConnectStringSanaAPI": "..."
  },
  "AppSettings": {
    "ApiUrl": "https://gateway.accessban.com/public/web-service/list/price?format=json&limit=1000&page=1",
    "Token": "..."
</div>

> حال به منظور استفاده از مقادیر تعریف شده در appsetting.json لازم است تا در constructor برنامه کد زیر را بنویسید:

<div dir="ltr">

    private IConfiguration configuration;

        public ReadAPI()
        {
            configuration = GetConfiguration();
        }
        public IConfigurationRoot GetConfiguration()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            return builder.Build();
        }
</div>

> در ادامه لازم است تا فقط مقادیر مورد نظر از API خوانده شود، بنابراین ID نرخ های مورد نظر را در یک لیست اضافه کرده و سپس فقط همان ID ها را به Object تبدیل نمایید:

<div dir="ltr">

    List<int> Ids = new List<int>
    {
        137292, 137308, 523799, 523764, 137253,
        137291, 137307, 523801, 523800, 137252,
        137298, 137314, 523813, 523812, 137276,
        137302, 137318, 523821, 523820, 137262,
        137305, 137321, 523827, 523826, 137270,
        137293, 137309, 523803, 523802
    };

    List<ReadData> readCurrency = currency.data.Where(i => Ids.Contains(i.id))
        .Select(res => new ReadData()
            {
                Price = Convert.ToDecimal(res.p),
                SiteDate = DateTime.Parse(res.updated_at),
                CurrencyName = res.title,
                CurrencyType = res.slug,
                PriceType = res.slug
            }).ToList();
</div>
        
### Create the model
> یک Context Class و Entity Class را به عنوان کلاس های مدل تعریف نمایید: (در پوشه Models فایل CurrencyRate.cs تعریف گردیده است)

<div dir="ltr">

        using System.Collections.Generic;
        using Microsoft.EntityFrameworkCore;
        
        public class Currency
        {
            public int CurrencyId { get; set; }
            public string CurrencyName { get; set; }
            public string CurrencyCode { get; set; }
        }
        
        public class CurrencyRate
        {
            public DateTime SiteDate { get; set; }
            public DateTime DateSubmitted { get; set; }
            public int Price { get; set; }

            //Specify the foreign key
            [ForeignKey("Currency")]
            public int CurrencyId { get; set; }
            public virtual Currency Currency { get; set; }

            [ForeignKey("CurrencyType")]
            public int TypeId { get; set; }
            public virtual CurrencyType CurrencyType { get; set; }
        }
        
        public class CurrencyType
        {
            public int TypeId { get; set; }
            public string TypeCurrency { get; set; }
            public string PriceType { get; set; }
        }

</div>

### Create a database structure
> ساختار پایگاه داده را بر اساس نمودار ERD مشخص کنید. برای این منظور از کتابخانه FF Core استفاده کنید: (در پوشه Data فایل CurrencyContext.cs تعریف گردیده است)

<div dir="ltr">

        public class CurrencyContext : DbContext
        {
            public DbSet<Currency> Currencies { get; set; }
            public DbSet<CurrencyRate> CurrencyRates { get; set; }
            public DbSet<CurrencyType> CurrencyTypes { get; set; }
        }

</div>

###Use for database
> با استفاده از قطعه کد زیر ConnectionString مربوط به اتصال به Database را بخوانید:
<div dir="ltr">

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Create a SQL Server DataBase and specify the DataBase name
            optionsBuilder.UseSqlServer(configuration.
                GetSection("ConnectionStrings").GetSection("ConnectStringSanaAPI").Value);
        }

</div>

###specify the master key
> برای تعیین کلید اصلی دو روش وجود دارد: <br />
<span style="font-weight:bold; font-size:15px;">
استفاده از روش Annotation Key:
</span>
این روش برای تعریف کلید اصلی به صورت ترکیبی مناسب نیست. مثال زیر نحوه تعریف کلید را به این روش نشان می دهد: (در پوشه Data فایل CurrencyContext.cs تعریف گردیده است)

<div dir="ltr">

       //Specify the foreign key
        [ForeignKey("Currency")]
        public int CurrencyId { get; set; }
        public virtual Curr ency Currency { get; set; }

</div>

###Pk and FK Determenaition by OnModelCreating method
> همچنین می توانید با استفاده از روش OnModelCreating کلید اصلی را به صورت زیر مشخص کنید. این روش برای تعریف کلید ترکیبی استفاده می شود: (در پوشه Data فایل CurrencyContext.cs تعریف گردیده است)

<div dir="ltr">

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Specify the primary key in the entities
            modelBuilder.Entity<Currency>()
                .HasKey(pk => new { pk.CurrencyId });
            modelBuilder.Entity<CurrencyType>()
                .HasKey(pk => new { pk.TypeId });
            modelBuilder.Entity<CurrencyRate>()
               .HasKey(pk => new { pk.CurrencyId, pk.TypeId, pk.SiteDate });
        }

</div>         

###Create
> برای انجام عملیات Create (به روز رسانی دیتابیس) از کد زیر استفاده نمایید: (در پوشه Data فایل CreateCurrency.cs تعریف گردیده است)

<div dir="ltr">

    public object Create()
        {
            string MessageDuplicate = "";
            string MessageSuccess = "";
            int NumDuplicate = 0;
            int NumSuccess = 0;
            string DbError = "";

            //Add values to the database
            try
            {
                //Calling from the array of currencyRate
                CurrencyRate[] currencyRates = new ListCurrencyRate().ListCurrency();

                if (currencyRates != null)
                {
                    try
                    {
                        using (var db = new CurrencyContext())
                        {
                            //Condition for editing non-duplicate records in the database
                            for (int i = 0; i < currencyRates.Length; i++)
                            {
                                //Specify whether or not a record exists in the database (avoid adding duplicate values)
                                // Database شرط موجود بودن یا نبودن مقدار نرخ ارز در 
                                bool exists = db.CurrencyRates.Any(
                                    s => s.SiteDate.Date == currencyRates[i].SiteDate.Date &&
                                    s.CurrencyId == currencyRates[i].CurrencyId &&
                                    s.TypeId == currencyRates[i].TypeId);

                                //Condition to add a record if that record does not exist in the database
                                if (exists == false)
                                {
                                    //Insert a New Record CurrencyRate"
                                    db.CurrencyRates.AddRange(
                                        new CurrencyRate
                                        {
                                            SiteDate = currencyRates[i].SiteDate,
                                            CurrencyId = currencyRates[i].CurrencyId,
                                            TypeId = currencyRates[i].TypeId,
                                            DateSubmitted = currencyRates[i].DateSubmitted,
                                            Price = currencyRates[i].Price
                                        });
                                    //Specify the number of records added to the DataBase
                                    NumSuccess += 1;
                                    MessageSuccess = "Add Successfully = " + NumSuccess;

                                    db.SaveChanges();
                                }
                                else if (exists == true)
                                {
                                    //Specify the number of records in the DataBase(Duplicate)
                                    NumDuplicate += 1;
                                    MessageDuplicate = "Duplicate Case = " + NumDuplicate;
                                }
                            }
                            return (HttpStatusCode.OK + "   " + MessageDuplicate + "   " + MessageSuccess);
                        }
                    }
                    catch (Exception)
                    {
                        DbError = Convert.ToString(new Exception("No Success Connect to Database SanaAPI and Add Data"));
                        return null;
                    }
                }
                else
                {
                    return new Exception("Disconnected Web Service");
                }
            }
            catch (Exception)
            {
                throw new Exception("Web Service Connection Error!");
            }
        }

</div>

###Set Email 
> کلاس EmailConfiguration را داخل پروژه خود اضافه نمایید:

<div dir = "ltr">

    public class EmailConfiguration
    {
        public string From { get; set; }
        public string SmtpServer { get; set; }
        public int Port { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }

</div>

> سپس از فایل appsettings.json برای پر کردن ویژگی های مورد نیاز استفاده نمایید:

<div dir="ltr">

    {
        "Logging": {
            "LogLevel": {
                "Default": "Information",
                "Microsoft": "Warning",
                "Microsoft.Hosting.Lifetime": "Information"
        }
        },
        "EmailConfiguration": {
        "From": "codemazetest@gmail.com",
        "SmtpServer": "smtp.gmail.com",
        "Port": 465,
        "Username": "codemazetest@gmail.com",
        "Password": "our test password"
    },
    "AllowedHosts": "*"
}

</div>

> برای تکمیل فرآیند پیکربندی، متد ConfigureService را در کلاس Startup.cs تغییر دهید:

<div dir="ltr">

        public void ConfigureServices(IServiceCollection services)
        {
            var emailConfig = Configuration
                .GetSection("EmailConfiguration")
                .Get<EmailConfiguration>();
            services.AddSingleton(emailConfig);

            services.AddControllers();
        }

</div>

> برای ایجاد ایمیل در پروژه ابتدا دو کتابخانه زیر را به پروژه اضافه نمایید:

<div dir="ltr">

* NETCore.MailKit

* MimeKit

> The imports we’ll be using are:

    * using MailKit.Net.Smtp;
    * using MimeKit;

</div>

###Send a Test Email
> در ادامه کلاس Message را به پروژه اضافه نمایید:
<div dir="ltr">

    public class Message
    {
            public List<MailboxAddress> To { get; set; }
            public string Subject { get; set; }
            public string Content { get; set; }

        public Message(IEnumerable<string> to, string subject, string content)
        {
            To = new List<MailboxAddress>();

            To.AddRange(to.Select(x => new MailboxAddress(x)));
            Subject = subject;
            Content = content;        
        }
    }
</div>

> از آن جایی که از این کلاس برای تنظیم داد های مربوط به گیرندگان ایمیل، موضوع و محتوای مربوطه استفاده می شود، بنابراین یک رابط جدید ایجاد نمایید:
<div dir="ltr">

    public interface IEmailSender
    {
        void SendEmail(Message message);
    }
    
</div>

> و کلاسی که این رابط را پیاده سازی می کند را نیز تعریف نمایید:
<div dir="ltr">

    public class EmailSender : IEmailSender
    {
        private readonly EmailConfiguration _emailConfig;

        public EmailSender(EmailConfiguration emailConfig)
        {
            _emailConfig = emailConfig;
        }   

        public void SendEmail(Message message)
        {
            var emailMessage = CreateEmailMessage(message);

            Send(emailMessage);
        }
    }
    
</div>

> همانطور که می بینید، پیکربندی ایمیل را به کلاس EmailSender تزریق کنید و سپس دو روش مختلف را برای ایجاد یک پیام ایمیل و ارسال ایمیل به ترتیب فراخوانی کنید:
<div dir="ltr">

    private MimeMessage CreateEmailMessage(Message message)
    {
        var emailMessage = new MimeMessage();
        emailMessage.From.Add(new MailboxAddress(_emailConfig.From));
        emailMessage.To.AddRange(message.To);
        emailMessage.Subject = message.Subject;
        emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Text) { Text = message.Content };

        return emailMessage;
    }

    private void Send(MimeMessage mailMessage)
    {
        using (var client = new SmtpClient())
        {
            try
            {
                client.Connect(_emailConfig.SmtpServer, _emailConfig.Port, true);
                client.AuthenticationMechanisms.Remove("XOAUTH2");
                client.Authenticate(_emailConfig.UserName, _emailConfig.Password);

                client.Send(mailMessage);
            }
            catch
            {
                //log an error message or throw an exception or both.
                throw;
            }
            finally
            {
                client.Disconnect(true);
                client.Dispose();
            }
        }
    }
    
</div>

> از روش اول برای ایجاد یک شی از نوع MimeMessage و پیکربندی ویژگی های مورد نیاز استفاده کنید. سپس، آن شی را به روش دوم منتقل کرده و از کلاس SmtpClient برای اتصال به سرور ایمیل، احراز هویت و ارسال ایمیل استفاده نمایید.

> فقط توجه داشته باشید که کلاس SmtpClient از فضای نام MailKit.Net.Smtp می آید. بنابراین، شما باید از آن به جای System.Net.Mail استفاده کنید.

> اکنون باید این سرویس را در کلاس Startup.cs ثبت کنیم:
<div dir="ltr">

    services.AddScoped<IEmailSender, EmailSender>();
    
</div>

> در نهایت به صورت زیر می توانید در کد خود پیام خطا را ایمیل نمایید:
<div dir="ltr">

    private readonly IEmailSender _emailSender;
        private IConfiguration configuration;
        private readonly ILogger<SanaAPIController> _logger;

        public SanaAPIController(IEmailSender emailSender, ILogger<SanaAPIController> logger)
        {
            _emailSender = emailSender;
            configuration = GetConfiguration();
            _logger = logger;
        }

        public IConfigurationRoot GetConfiguration()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            return builder.Build();
        }

        // POST: api/<SanaAPIController>
        [HttpPost("{CreateCurrency}")]
        [Obsolete]
        public async Task<object> CreateSanaAPIAsync()
        {
            var ToEmail = configuration.GetSection("ContactEmails").GetSection("Eskandari").Value;
            var Cc0Email = configuration.GetSection("ContactEmails").GetSection("Eslami").Value;
            var Cc1Email = configuration.GetSection("ContactEmails").GetSection("Shahpari_Fard").Value;
            var ErrorMessageAPI = new Message(new string[] { ToEmail },
                                      new string[] { Cc0Email, Cc1Email },
                                      "StatusCode: 500(Server error responses)",
                                      "StatusCode(500, Server error responses(Web Service Connection Error!!)");
            var ErrorMessageConnectDB = new Message(new string[] { ToEmail },
                                      new string[] { Cc0Email, Cc1Email },
                                      "StatusCode: 503(Server error responses)",
                                      "StatusCode(503, Server error responses(Database Connection Error!!)");
            try
            {
                object result = new CreateCurrency().Create();

                if (result == null)
                {
                    _logger.LogError("StatusCode(503, Server error responses(Database Connection Error!!))");
                    try
                    {
                        await _emailSender.SendEmailAsync(ErrorMessageConnectDB);
                        return "StatusCode(503, Server error responses(Database Connection Error!!))";
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "Problem sending email for Database Connection Error!!");
                        throw;
                    }
                }
                else
                {
                    return result;
                }
            }
            catch (Exception)
            {
                _logger.LogError("StatusCode(500, Server error responses(Web Service Connection Error!!))");
                try
                {
                    await _emailSender.SendEmailAsync(ErrorMessageAPI);
                    return "StatusCode(500, Server error responses(Web Service Connection Error!!))";
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Problem sending email for Web Service Connection Error!!");
                    throw;
                }
            }
        }
    
</div>

###Using HTML in the Email Body
> بنابراین، تنها کاری که باید انجام دهید این است که متد CreateEmailMessage را اصلاح نمایید:
<div dir="ltr">

    private MimeMessage CreateEmailMessage(Message message)
    {
        var emailMessage = new MimeMessage();
        emailMessage.From.Add(new MailboxAddress(_emailConfig.From));
        emailMessage.To.AddRange(message.To);
        emailMessage.Subject = message.Subject;
        emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = string.Format("<h2 style='color:red;'>{0}</h2>", message.Content) };

        return emailMessage;
    }
    
</div>

###Set Log with Serilog
> در ابتدا باید تنظیمات و ویژگی های لازم را در appsettings.json برنامه به صورت زیر تعریف نمایید:
<div dir="ltr">

        "Serilog": {
        "MinimumLevel": "Warning",
        "WriteTo": [
            {
                "Name": "MSSqlServer",
                "Args": {
                    "ConnectionString": "رشته اتصال",
                    "tableName": "نام جدول ",
                    "autoCreateSqlTable": true
            }
        }
      ]
    }
    
</div>

> سپس کتابخانه های زیر را به برنامه اضافه نمایید:
<div dir="ltr">

    * Serilog.AspNetCore

    * Serilog.Settings.Configuration

    * Serilog.Sinks.MSSqlServer
</div>

> حال به صورت زیر خطای پروژه خود را به صورت Log در دیتابیس ثبت نمایید:
<div dir="ltr">

        private IConfiguration configuration;
        private readonly ILogger<SanaAPIController> _logger;

        public SanaAPIController(IEmailSender emailSender, ILogger<SanaAPIController> logger)
        {
            configuration = GetConfiguration();
            _logger = logger;
        }

        public IConfigurationRoot GetConfiguration()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            return builder.Build();
        }

        _logger.LogError("StatusCode(503, Server error responses(Database Connection Error!!))");
</div>

</div>

---

#Sources

<div style="text-align:left; direction:ltr;" dir="ltr">
<p>

* https://docs.microsoft.com/en-us/ef/core/get-started/overview/first-app?tabs=visual-studio#next-steps

* https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Sqlite/5.0.3

* https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Tools/5.0.3

* https://www.nuget.org/packages/Microsoft.Extensions.Configuration/

* https://github.com/codehaks/BugVue/tree/master/BugVue

* https://github.com/codehaks/WebApp

* https://code-maze.com/aspnetcore-send-email/

* https://www.youtube.com/watch?v=LwgBWk48ywU

</p>

</div>
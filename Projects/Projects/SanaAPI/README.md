<div dir="rtl">

<div style = "font-size:20px; font-weight:bold; margin-bottom:10px; direction:ltr; text-align:right;" dir="rtl"> Publish </div>

<p style="direction:rtl; text-align:right;" dir="rtl">

> پروژه SanaAPI به عنوان یک رابط (API) جهت خواندن نرخ ارز از API و انتقال آن ها به یک دیتابیس واسط جهت ذخیره در سامانه XRM ایجاد گردیده است. 

> این پروژه پس از نهایی سازی و تکمیل فرآیند توسعه بر روی ماشین مجازی SOE(192.168.102.24:65002) پابلیش شده است.(از آنجایی که جهت خواندن نرخ ارز از API به اینترنت نیاز می باشد روی ماشین مجازی SOE پابلیش شده است.)

</p>

</div>

<div style="border: 1px solid #a5d0f2; widtd: 98%; height: 50px; padding-top: 13.5px; margin-bottom: 12px;">

<span style="font-weight:bold; background-color:#61affe; color:white; text-align:left; direction:ltr; width:50px; height: 35px; padding: 8px 31px; margin: 60px 0px 0 10px; position:absulate; "> GET </span>
<span style="margin-left:20px;"> /api/ReadSanaAPI/sanaapi/ReadCurrency (http://192.168.102.24:65002/api/ReadSanaAPI/sanaapi/ReadCurrency)</span>

</div>

<div style="direction:rtl; text-align:right;" dir="rtl">
<p>به عنوان مثال متناسب با Request بالا پارامترهای زیر به Verb GET در پروژه SanaAPI ارسال می گردد:</p>
</div>

<div style="direction:ltr; text-align:left;" dir="ltr">

      http://192.168.102.24:65002/api/ReadSanaAPI/sanaapi/ReadCurrency?
      date= date  // تاریخ ارز برای بررسی موجود بودن یا نبودن در دیتابیس

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

<div style = "font-size:15px; font-weight:bold; margin-bottom:10px; direction:ltr; text-align:right;" dir="rtl"> SanaAPI </div>

<p style="direction:rtl; text-align:justify;" dir="rtl">

> هدف از انجام این پروژه واکشی مقادیر ارز از API سایت <a href="https://api.accessban.com/v1/data/sana/json"> SanaRate </a> و ذخیره در یک Database واسط می باشد.  بنابراین مقادیر ارز را از API خوانده و سپس در دیتابیس Add می نماید. همچنین براساس تاریخ جاری مقادیر ارز را نیز از دیتابیس می خواند تا در صورت ناموجود بودن در XRM، به آن اضافه گردد. برای این منظور یک پروژه از نوع Asp.Net 5 Web API ایجاد کنید.

> جهت دریافت جزئیات درخصوص ساختار این پروژه و سناریو آن به <a style="font-weight:bold;" href="https://alm.index-holding.com/IndexCollection/SoftDept/_wiki/wikis/SoftDept.wiki/41/SanaAPI"> Wiki </a> این پروژه مراجعه نمایید.


</p>

</div>

---

<div style = "font-size:20px; font-weight:bold; margin-bottom:10px; direction:ltr; text-align:left;" dir="rtl"> Technologies </div>

* ASP.NET 5 Web API

* Microsoft.EntityFrameworkCore.SqlServer

* Microsoft.EntityFrameworkCore.Tools

* Newtonsoft.Json

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

</div>

* 2-  NameSpace های زیر را در File Class اضافه نمایید.

<div dir="ltr">

    * using Microsoft.EntityFrameworkCore;

    * using Newtonsoft.Json;

    * using System.Net.Http;

</div>

---

<div dir="rtl">

# نحوه نصب Entity FrameWork در پروژه

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
* مراحل زیر را طی کنید و با استفاده از Migration ها DataBase را ایجاد نمایید. Command های زیر را در  Package Manager Console (PMC) اجرا نمایید:

<div dir="ltr">

    1- Install-Package Microsoft.EntityFrameworkCore.Tools

    2- Add-Migration InitialCreate

    3- Update-Database

* The Add-Migration command scaffolds a migration to create the initial set of tables for the model. The Update-Database command creates the database and applies the new migration to it.
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
            //Read API
            string Url = "https://api.accessban.com/v1/data/sana/json";

            HttpClient Client = new HttpClient();

            //Convert Json(API) to Object
            string result = Client.GetStringAsync(Url).Result;
            Root currency = JsonConvert.DeserializeObject<Root>(result);

            return currency;
        }

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
> با استفاده از قطعه کد زیر پایگاه داده ایجاد کنید: (در پوشه Data فایل CurrencyContext.cs تعریف گردیده است)

<div dir="ltr">

        //Create a SQLITE DataBase and specify the DataBase name
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=SanaAPI.db");

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

###Assign a fixed value while creating a database
> سپس ابتدا باید موجودیت هایی را تنظیم کنید که دارای مقدار ثابت هستند. برای انجام این کار ، موارد زیر را انجام دهید: (در پوشه Data فایل CurrencyContext.cs تعریف گردیده است)

<div dir="ltr">

      protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Value entities that have a fixed value
            modelBuilder.Entity<Currency>().HasData(
                    new { CurrencyId = 1, CurrencyName = "یورو", CurrencyCode = "EUR" },
                    new { CurrencyId = 2, CurrencyName = "درهم امارات متحده عربی", CurrencyCode = "AED" },
                    new { CurrencyId = 3, CurrencyName = "یوان  چین", CurrencyCode = "CNY" },
                    new { CurrencyId = 4, CurrencyName = "روپیه  هند", CurrencyCode = "INR" },
                    new { CurrencyId = 5, CurrencyName = "دلار آمریکا", CurrencyCode = "USD" },
                    new { CurrencyId = 6, CurrencyName = "روبل روسيه", CurrencyCode = "RUB" }
                    );
            modelBuilder.Entity<CurrencyType>().HasData(
                    new { TypeId = 1, TypeCurrency = "اسکناس", PriceType = "خرید" },
                    new { TypeId = 2, TypeCurrency = "اسکناس", PriceType = "فروش" },
                    new { TypeId = 3, TypeCurrency = "حواله ارزی", PriceType = "خرید" },
                    new { TypeId = 4, TypeCurrency = "حواله ارزی", PriceType = "فروش" }
                  );
        } 

</div>           

### Create
> برای انجام عملیات Create (به روز رسانی دیتابیس) از کد زیر استفاده نمایید: (در پوشه Data فایل CreateCurrency.cs تعریف گردیده است)

<div dir="ltr">

       public static void Create()
        {
            Root currency = ReadAPI.GetAPI();

            //Get the date from the system
            DateTime DateSubmitted = DateTime.Now;

            //Add currency value to DataBase
            using (var db = new CurrencyContext())
            {
                // Create
                Console.WriteLine("Inserting a new CurrencyRate");
                db.AddRange(new CurrencyRate[]
                {
                    new CurrencyRate()
                    {
                        SiteDate = DateTime.Parse(currency.sana.data[1].updated_at),
                        CurrencyId = 1,
                        TypeId = 1,
                        DateSubmitted = DateSubmitted,
                        Price = currency.sana.data[1].p
                    },
                    new CurrencyRate()
                    {
                        SiteDate = DateTime.Parse(currency.sana.data[17].updated_at),
                        CurrencyId = 1,
                        TypeId = 2,
                        Price = currency.sana.data[17].p,
                        DateSubmitted = DateSubmitted
                    }
                    });
                db.SaveChanges();
            }

</div>

### READ
> برای انجام عملیات Read از دیتابیس براساس تاریخ نیز از کد زیر استفاده نمایید: (در پوشه Data فایل ReadCurrency.cs تعریف گردیده است)

<div dir="ltr">

        public static object Read(ReadData data)
        {
            try
            {
                using (var db = new CurrencyContext())
                {
                    db.Database.Migrate();

                    //Specify whether or not a record exists in the database (avoid adding duplicate values)
                    bool exists = db.CurrencyRates.Any(d => d.DateSubmitted.Date == data.DateSubmitted.Date);

                    // Read Currency
                    if (exists == true)
                    {
                        var readCurrency = db.CurrencyRates
                            .Where(date => date.DateSubmitted.Date == data.DateSubmitted.Date)
                            .Select(res => new ReadData()
                           { 
                               DateSubmitted = res.DateSubmitted,
                               SiteDate = res.SiteDate,
                               Price = res.Price,
                               CurrencyName = res.Currency.CurrencyName,
                               CurrencyType = res.CurrencyType.TypeCurrency,
                               PriceType = res.CurrencyType.PriceType
                           }).ToList();

                        if (readCurrency.Any())
                        {
                            return readCurrency;
                        }
                    }
                    return (HttpStatusCode.NotFound);
                }
            }
            catch (Exception)
            {
                throw ;
            }
        }

</div>

</div>

</div>

---

# Sources

<div style="text-align:left; direction:ltr;" dir="ltr">
<p>

* https://docs.microsoft.com/en-us/ef/core/get-started/overview/first-app?tabs=visual-studio#next-steps

* https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Sqlite/5.0.3

* https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Tools/5.0.3

* https://www.nuget.org/packages/Microsoft.Extensions.Configuration/

* https://github.com/codehaks/BugVue/tree/master/BugVue

* https://github.com/codehaks/WebApp

</p>

</div>
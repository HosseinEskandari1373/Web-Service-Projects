<div dir="rtl">

<div style = "font-size:20px; font-weight:bold; margin-bottom:10px; direction:ltr; text-align:right;" dir="rtl"> Publish </div>

<p style="direction:rtl; text-align:right;" dir="rtl">

> پروژه SanaClient به منظور ایجاد جاب برای به روزکردن دیتابیس پروژه <a href="https://alm.index-holding.com/IndexCollection/SoftDept/_wiki/wikis/SoftDept.wiki/58/SanaAPI_DatabaseFirst"> SanaAPI_DatabaseFirst </a> تعریف شده است تا نرخ ارز خوانده شده از دیتابیس را در صورت ناموجود بودن در سامانه XRM به آن اضافه نماید.

> این پروژه پس از نهایی سازی و تکمیل فرآیند توسعه بر روی ماشین مجازی BuildW (192.168.100.38:65001) پابلیش شده است.

</p>

</div>

---

<div dir="rtl">

<div style = "font-size:20px; font-weight:bold; margin-bottom:10px; direction:ltr; text-align:right;" dir="rtl"> Introduction </div>

<div style = "font-size:16px; font-weight:bold; margin-bottom:10px;">SanaClient</div>

<p style = "direction:rtl; text-align:right;" dir="rtl">

> برای زمان بندی پروژه های مختلف ( جاب ) نیاز است که یک واسط ( Client ) جاب های مختلف را که قصد زمان بندی آن ها را دارید، روی دیتابیس مشترک با JobSchedulerServer رجیستر نماید، تا توسط پروژه <a href="https://alm.index-holding.com/IndexCollection/SoftDept/_git/JobSchedulerServer"> JobSchedulerServer </a> براساس زمان بندی رجیستر شده در دیتابیس اجرا گردند. بنابراین پروژه SanaClient  به عنوان یک واسط برای رجیستر کردن جاب زیر تعریف می شود: 

<a href="https://alm.index-holding.com/IndexCollection/SoftDept/_git/SanaClient?path=%2FSanaClient%2FJobs%2FSanaAPI_Post_RecurringDaily%2FSanaAPI_Post_RecurringDaily.cs"> * SanaAPI_Post_RecurringDaily </a>

> این جاب وظیفه دارد تا روزی یکبار ( ساعت 16:00)  مقادیر ارز را در دیتابیس پروژه <a href="https://alm.index-holding.com/IndexCollection/SoftDept/_wiki/wikis/SoftDept.wiki/58/SanaAPI_DatabaseFirst"> SanaAPI_DatabaseFirst </a> به روز نماید.



> این پروژه نیز به عنوان Client عمل می نماید و جاب های مختلف را روی دیتابیس رجیستر می کند تا <a href="https://alm.index-holding.com/IndexCollection/SoftDept/_git/JobSchedulerServer"> JobSchedulerServer </a> آن ها را براساس زمان بندی رجیستر شده، اجرا نماید.

> جهت دریافت جزئیات درخصوص ساختار این پروژه و سناریو آن به <a style="font-weight:bold;" href="https://alm.index-holding.com/IndexCollection/SoftDept/_wiki/wikis/SoftDept.wiki/52/SanaClient"> Wiki </a> این پروژه مراجعه نمایید.

</p>

</div>

---

<div style = "font-size:20px; font-weight:bold; margin-bottom:10px; direction:ltr; text-align:left;" dir="rtl"> Technologies </div>

* ASP.NET 5 Web API

* Newtonsoft.Json

* Hangfire.AspNetCore

* Hangfire.Core
    
* Hangfire.SqlServer

---

<div style = "font-size:20px; font-weight:bold;"> محتویات فایل ReadMe.md </div>

<div dir="ltr">

[[_TOC_]]

</div>

---

<div dir="rtl">

#Structure

<p style="direction:rtl; text-align:right;" dir="rtl">

### نیازمندی های پروژه

* 1-  Framework های زیر را به پروژه اضافه نمایید:

<div dir="ltr">

    * Newtonsoft.Json
    * Microsoft.AspNetCore.Mvc.NewtonsoftJson
    * Hangfire.AspNetCore
    * Hangfire.Core
    * Hangfire.SqlServer

</div>

* 2-  NameSpace های زیر را در File Class اضافه نمایید.

<div dir="ltr">

    * using Newtonsoft.Json;
    * using System.Net.Http;
    * using Hangfire;
    * using Hangfire.SqlServer;

</div>

---

<div dir="rtl">

#Code Snippet

##<a href="https://alm.index-holding.com/IndexCollection/SoftDept/_git/SanaClient?path=%2FSanaClient%2FJobs%2FSanaAPI_Post_RecurringDaily%2FSanaAPI_Post_RecurringDaily.cs">SanaAPI_Post_RecurrinhDaily Job</a>
* برای اجرای جاب <a href="https://alm.index-holding.com/IndexCollection/SoftDept/_git/SanaClient?path=%2FSanaClient%2FJobs%2FSanaAPI_Post_RecurringDaily%2FSanaAPI_Post_RecurringDaily.cs"> SanaAPI_Post_RecurringDaily </a>، ابتدا Interface مربوط به آن را ایجاد نمایید:

<div dir="ltr">

      public interface ISanaAPI_Post_Recurring3H
      {
        Task<object> Create();
      }

</div>

* سپس جاب را به صورت زیر تعریف کنید تا متد Post را در پروژه <a href="https://alm.index-holding.com/IndexCollection/SoftDept/_wiki/wikis/SoftDept.wiki/58/SanaAPI_DatabaseFirst"> SanaAPI_DatabaseFirst </a> فراخوانی کرده و SanaAPIDB را به روز نمایید:

<div dir="ltr">

       public async Task<object> Create()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    //API URL
                    client.BaseAddress = new Uri(configuration.GetSection("AppSettings").GetSection("SanaApiUrl").Value);

                    //Send request to API
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));

                    //Send Client information to the API and receive the response
                    HttpResponseMessage response = await client.PostAsJsonAsync(
                        configuration.GetSection("AppSettings").GetSection("CreateUrlSanaAPI").Value, "");

                    //Get operation result from API
                    if (response.IsSuccessStatusCode)
                    {
                        //Get answers from the API
                        var contact = await response.Content.ReadAsStringAsync();
                        object JsonContact = JsonConvert.DeserializeObject(contact);

                        //Send result for Client
                        switch (JsonContact)
                        {
                            case null:
                                return HttpStatusCode.NotFound;
                            default:
                                return (HttpStatusCode.OK, JsonContact);
                        }
                    }
                    return null;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

</div>


###How to schedule a SanaAPI_Post_Recurring3H Job

*  در مرحله اول، می بایست جاب <a href="https://alm.index-holding.com/IndexCollection/SoftDept/_git/SanaClient?path=%2FSanaClient%2FJobs%2FSanaAPI_Post_RecurringDaily%2FSanaAPI_Post_RecurringDaily.cs"> ISanaAPI_Post_RecurringDaily </a> را درون Startup به ConfigureService تزریق نمایید:

<div dir="ltr">

        services.AddSingleton<ISanaAPI_Post_RecurringDaily, SanaAPI_Post_RecurringDaily>();

</div>


* در مرحله دوم ، می بایست روش پیکربندی را به روز نمود تا بتوان دو پارامتر جدید را گرفت. اولین مورد IRecurringJobManager لازم برای ایجاد یک جاب مکرر است، و مورد دوم IServiceProvider است تا نمونه ISanaAPI_Post_Recurring3H را از محفظه تزریق وابستگی دریافت کند.

ثالثاً، بایستی با AddOrUpdate در نمونه IRecurringJobManager تماس گرفت تا برای هر 3 ساعت یک کار تکراری تنظیم کند.

<div dir="ltr">

         //Implement Job management with Cron commands
            recurringJobManager.AddOrUpdate(
                "Run every day at 16 p.m",
                () => serviceProvider.GetService<ISanaAPI_Post_RecurringDaily>().Create(),
                "0 16 * * *",
                TimeZoneInfo.FindSystemTimeZoneById("Iran Standard Time")
                );

</div>

* <p style="font-weight:bold;">نکته: </p> <span style="text-align:justify;">در صورتی که وب سرویس با مشکل مواجه شده باشد، اجرای آن در Retries قرار می گیرد. حال برای زمان بندی آن که در صورت رخ دادن چنین مشکلی که هر نیم ساعت یکبار آن را Enqueued و Processing نماید و چنان چه باز هم در حالت Retries قرار گرفت (Scheduled) این Job را 10 مرتبه هر نیم ساعت یکبار اجرا نماید و در صورتی که باز هم نتوانست وب سرویس را اجرا نماید آن را Failed کند، بایستی کد زیر را در Startup Configuration قبل از Recurring کردن Job بنویسید: </span>

<div dir="ltr">

    GlobalJobFilters.Filters.Add(new AutomaticRetryAttribute { Attempts = 5, DelaysInSeconds = new int[] { 300 } });      

</div>


##نحوه رفع ارور عدم دسترسی Recurring jobs Could not resolve assembly
* علت این ارور عدم دسترسی پروژه <a href="https://alm.index-holding.com/IndexCollection/SoftDept/_git/JobSchedulerServer"> JobSchedulerServer </a> به Dll پروژه SanaClient می باشد، به همین منظور برای رفع آن به صورت زیر عمل نمایید.

###نحوه اضافه کردن Dll پروژه SanaClient به پروژه JobScheduler

> کلیک راست روی پروژه => Add => Project Reference => Browse => انتخاب Dll پروژه SanaClient

* درنهایت Dll پروژه SanaClient به صورت زیر به پروژه اضافه می شود:

<div dir="ltr">

        <ItemGroup>
            <Reference Include="SanaClient">
                <HintPath>..\..\SanaClient\SanaClient\bin\Debug\net5.0\SanaClient.dll</HintPath>
            </Reference>
        </ItemGroup>

</div>

---
<div style="text-align:left; direction:ltr;">

# Sources

<p>

* https://dotnetcorecentral.com/blog/hangfire-in-aspnetcore/

* https://codewithmukesh.com/blog/hangfire-in-aspnet-core-3-1/

* https://docs.hangfire.io/en/latest/

* https://www.youtube.com/watch?v=FIhpte9UVHM

* https://app.pluralsight.com/course-player?clipId=b9fac3da-ed2c-4c2e-8ebc-e40da8f4bc58

* https://discuss.hangfire.io/t/deploy-hangfire-distributed-client-server/1647

* https://discuss.hangfire.io/t/separate-server-hangfire-setup/910

</p>

</div>
    
</div>
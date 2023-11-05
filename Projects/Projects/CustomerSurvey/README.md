<div dir="rtl">

<div style = "font-size:20px; font-weight:bold; margin-bottom:10px; direction:ltr; text-align:right;" dir="rtl"> Publish </div>

<p style="direction:rtl; text-align:right;" dir="rtl">

> پروژه SanaClient به منظور ایجاد دو جاب برای به روزکردن دیتابیس پروژه <a href="https://alm.index-holding.com/IndexCollection/SoftDept/_git/SanaAPI"> SanaAPI </a> و خواندن از آن براساس تاریخ ایجاد گردیده است تا نرخ ارز خوانده شده از دیتابیس را در صورت ناموجود بودن در سامانه XRM به آن اضافه نماید.

> این پروژه پس از نهایی سازی و تکمیل فرآیند توسعه بر روی ماشین مجازی BuildW (192.168.100.38:65001) پابلیش شده است.

</p>

</div>

---

<div dir="rtl">

<div style = "font-size:20px; font-weight:bold; margin-bottom:10px; direction:ltr; text-align:right;" dir="rtl"> Introduction </div>

<div style = "font-size:16px; font-weight:bold; margin-bottom:10px;">SanaClient</div>

<p style = "direction:rtl; text-align:right;" dir="rtl">

> برای زمان بندی پروژه های مختلف ( جاب ) نیاز است که یک واسط ( Client ) جاب های مختلف را که قصد زمان بندی آن ها را دارید، روی دیتابیس مشترک با JobSchedulerServer رجیستر نماید، تا توسط پروژه <a href="https://alm.index-holding.com/IndexCollection/SoftDept/_git/JobSchedulerServer"> JobSchedulerServer </a> براساس زمان بندی رجیستر شده در دیتابیس اجرا گردند. بنابراین پروژه SanaClient  به عنوان یک واسط برای رجیستر کردن دو جاب زیر تعریف می شود: 

<a href="https://alm.index-holding.com/IndexCollection/SoftDept/_git/SanaClient?path=%2FSanaClient%2FJobs%2FSanaAPI_Post_Recurring3H"> 1-	SanaAPI_Post_Recurring3H </a>

> این جاب وظیفه دارد تا هر 3 ساعت یکبار مقادیر ارز را در دیتابیس پروژه <a href="https://alm.index-holding.com/IndexCollection/SoftDept/_git/SanaAPI"> SanaAPI </a> به روز نماید.

<a href="https://alm.index-holding.com/IndexCollection/SoftDept/_git/SanaClient?path=%2FSanaClient%2FJobs%2FConnectXrmAPI_Inset_RecurringDaily"> 2-	ConnectXrmAPI_Insert_RecurrinhDaily </a>

> این جاب نیز به صورت روزانه مقادیر ارز را براساس تاریخ جاری از دیتابیس پروژه SanaAPI می خواند و سپس در صورت ناموجود بودن در XRM، به آن اضافه می نماید.

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

##<a href="https://alm.index-holding.com/IndexCollection/SoftDept/_git/SanaClient?path=%2FSanaClient%2FJobs%2FSanaAPI_Post_Recurring3H">SanaAPI_Post_Recurrinh3H Job</a>
* برای اجرای جاب <a href="https://alm.index-holding.com/IndexCollection/SoftDept/_git/SanaClient?path=%2FSanaClient%2FJobs%2FSanaAPI_Post_Recurring3H"> SanaAPI_Post_Recurring3H </a>، ابتدا Interface مربوط به آن را ایجاد نمایید:

<div dir="ltr">

      public interface ISanaAPI_Post_Recurring3H
      {
        Task<object> Create();
      }

</div>

* سپس جاب را به صورت زیر تعریف کنید تا متد Post را در پروژه <a href="https://alm.index-holding.com/IndexCollection/SoftDept/_git/SanaAPI"> SanaAPI </a> فراخوانی کرده و SanaAPI DB را به روز نمایید:

<div dir="ltr">

       public async Task<object> Create()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    //API URL
                    client.BaseAddress = new Uri("http://localhost:52672/");

                    //Send request to API
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));

                    //Send Client information to the API and receive the response
                    HttpResponseMessage response = await client.PostAsJsonAsync(
                        "api/CreateSanaAPI/sanaapi/CreateCurrency", "");

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

*  در مرحله اول، می بایست جاب <a href="https://alm.index-holding.com/IndexCollection/SoftDept/_git/SanaClient?path=%2FSanaClient%2FJobs%2FSanaAPI_Post_Recurring3H"> ISanaAPI_Post_Recurring3H </a> را درون Startup به ConfigureService تزریق نمایید:

<div dir="ltr">

        services.AddSingleton<ISanaAPI_Post_Recurring3H, SanaAPI_Post_Recurring3H>();

</div>


* در مرحله دوم ، می بایست روش پیکربندی را به روز نمود تا بتوان دو پارامتر جدید را گرفت. اولین مورد IRecurringJobManager لازم برای ایجاد یک جاب مکرر است، و مورد دوم IServiceProvider است تا نمونه ISanaAPI_Post_Recurring3H را از محفظه تزریق وابستگی دریافت کند.

ثالثاً، بایستی با AddOrUpdate در نمونه IRecurringJobManager تماس گرفت تا برای هر 3 ساعت یک کار تکراری تنظیم کند.

<div dir="ltr">

         //Implement Job management with Cron commands
            recurringJobManager.AddOrUpdate(
                "Run every 3 hours",
                () => serviceProvider.GetService<ISanaAPI_Post_Recurring3H>().Create(),
                "0 */3 * * *"
                );

</div>

##<a href="https://alm.index-holding.com/IndexCollection/SoftDept/_git/SanaClient?path=%2FSanaClient%2FJobs%2FConnectXrmAPI_Inset_RecurringDaily">ConnectXrmAPI_Insert_RecurringDaily Job</a>

* برای اجرای جاب <a href="https://alm.index-holding.com/IndexCollection/SoftDept/_git/SanaClient?path=%2FSanaClient%2FJobs%2FConnectXrmAPI_Inset_RecurringDaily"> ConnectXrmAPI_Insert_RecurringDaily </a>، ابتدا Interface مربوط به آن را ایجاد نمایید:

<div dir="ltr">

       public interface IConnectXrmAPI_Inset_RecurringDaily
       {
        Task<object> Insert();
       }

</div>

* سپس جاب را به صورت زیر تعریف کنید تا متد GET در پروژه <a href="https://alm.index-holding.com/IndexCollection/SoftDept/_git/SanaAPI"> SanaAPI </a> فراخوانی شود و پس از دریافت مقادیر ارز بر اساس تاریخ فعلی، آن مقادیر را برای پروژه <a href="https://alm.index-holding.com/IndexCollection/SoftDept/_git/ConnectXrmAPI"> ConnectXrmAPI </a> ارسال کنید:

<div dir="ltr">

        public async Task<object> Insert()
        {
            try
            {
                using (var clientSanaAPI = new HttpClient())
                {
                    //API URL
                    clientSanaAPI.BaseAddress = new Uri("http://192.168.100.38:65002/");

                    //Send request to API
                    clientSanaAPI.DefaultRequestHeaders.Accept.Clear();
                    clientSanaAPI.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));

                    //Get Informations Client and Send to API
                    HttpResponseMessage response = await clientSanaAPI.GetAsync("api/ReadSanaAPI/sanaapi/ReadCurrency?" +
                    "date=" + Utilities.DateSubmitted);

                    //Get operation result from API
                    if (response.IsSuccessStatusCode)
                    {
                        //Get answers from the API
                        string ReadCurrency = await response.Content.ReadAsStringAsync();

                        var JsonCurrency = JsonConvert.DeserializeObject<List<ReadData>>(ReadCurrency);

                        foreach (var item in JsonCurrency)
                        {
                            item.UserName = Utilities.UserName;
                            item.password = Utilities.Password;
                            item.Url = Utilities.Url;
                        }

                        using (var clientConnectXrmAPI = new HttpClient())
                        {
                            //API URL
                            clientConnectXrmAPI.BaseAddress = new Uri("http://localhost:58566/");

                            //Send request to API
                            clientConnectXrmAPI.DefaultRequestHeaders.Accept.Clear();
                            clientConnectXrmAPI.DefaultRequestHeaders.Accept.Add(
                                new MediaTypeWithQualityHeaderValue("application/json"));

                            //Send Client information to the API and receive the response
                            HttpResponseMessage responseConnectXrmAPI = await clientConnectXrmAPI.PostAsJsonAsync(
                                "api/PostCurrency/connectxrmapi/CreateCurrency", JsonCurrency);

                            //Get operation result from API
                            if (responseConnectXrmAPI.IsSuccessStatusCode)
                            {
                                //Get answers from the API
                                string result = await responseConnectXrmAPI.Content.ReadAsStringAsync();
                                object Jsonresult = JsonConvert.DeserializeObject(result);

                                //Send result for Client
                                switch (Jsonresult)
                                {
                                    case null:
                                        return HttpStatusCode.NotFound;
                                    default:
                                        return (HttpStatusCode.OK);
                                }
                            }
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

###How to schedule a ConnectXrmAPI_Insert_RecurringDaily

* در مرحله اول، می بایست جاب <a href="https://alm.index-holding.com/IndexCollection/SoftDept/_git/SanaClient?path=%2FSanaClient%2FJobs%2FConnectXrmAPI_Inset_RecurringDaily"> IConnectXrmAPI_Insert_RecurringDaily </a> را درون Startup به ConfigureService تزریق نمایید:

<div dir="ltr">

        services.AddSingleton<IConnectXrmAPI_Inset_RecurringDaily, ConnectXrmAPI_Inset_RecurringDaily>();

</div>

* در مرحله دوم ، می بایست روش پیکربندی را به روز نمود تا بتوان دو پارامتر جدید را گرفت. اولین مورد IRecurringJobManager لازم برای ایجاد یک جاب مکرر است، و مورد دوم IServiceProvider است تا نمونه IConnectXrmAPI_Insert_RecurringDaily را از محفظه تزریق وابستگی دریافت کند.

ثالثاً، بایستی با AddOrUpdate در نمونه IRecurringJobManager تماس گرفت تا جاب را به صورت روزانه تنظیم نماید.

<div dir="ltr">

       //Implement Job management with Cron commands
            recurringJobManager.AddOrUpdate(
                "Run every Day",
                () => serviceProvider.GetService<IConnectXrmAPI_Inset_RecurringDaily>().Insert(),
                "0 0 * * *"
                );

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
<div dir="rtl">

<div style = "font-size:20px; font-weight:bold; margin-bottom:10px; direction:ltr; text-align:right;" dir="rtl"> Publish </div>

<p style="direction:rtl; text-align:right;" dir="rtl">

> پروژه JobSchedulerServer به منظور اجرای جاب های رجیستر شده روی دیتابیس و ارائه داشبوردی برای کنترل و نظارت بر اجرای جاب ها ایجاد گردیده است.

> این پروژه پس از نهایی سازی و تکمیل فرآیند توسعه بر روی ماشین مجازی BuildW (192.168.100.38:65000) پابلیش شده است.

</p>

</div>

---

<div dir="rtl">

<div style = "font-size:20px; font-weight:bold; margin-bottom:10px; direction:ltr; text-align:right;" dir="rtl"> Introduction </div>

<div style = "font-size:16px; font-weight:bold; margin-bottom:10px;">TaskScheduler</div>
<p style = "direction:rtl; text-align:justify;" dir="rtl">

> ممکن است برخی از درخواست های وب وجود داشته باشد که برای اجرای آنها زمان زیادی لازم است، مانند تهیه گزارش درج موفقیت آمیز یا ارسال ایمیل / پیام کوتاه به عنوان تأیید برای انجام معامله. این درخواست ها می تواند زمان نامعلومی برای اتمام داشته باشد و نگه داشتن کاربر به نشانگر انتظار برای آن زمان انجام درخواست خوب نیست.

> ایده این است که در اسرع وقت صفحه کاربر را برای درخواست هایی که انجام آنها طولانی مدت طول می کشد، انسداد دهید تا کاربر بتواند کارهای دیگر را انجام دهد.

>این جایی است که مشاغل پس زمینه به تصویر می آیند مانند این است که باقیمانده فعالیت ها را در پس زمینه مانند یک موضوع دیگر اجرا کنید تا موضوع اصلی برای کاربر آزاد شود تا فعالیت های دیگر را انجام دهد.

>حال اگر مجبور به ایجاد چارچوبی برای ایجاد و نظارت بر مشاغل پس زمینه باشید. این یک کار پیچیده است که ممکن است به تلاش زیادی نیاز داشته باشد. اینجاست که می توان از Hangfire استفاده کرد. Hangfire استفاده ساده از یک کتابخانه منبع باز است که پیاده سازی کار پس زمینه را در برنامه های NET Core و .NET آسان می کند.

> جهت دریافت جزئیات درخصوص ساختار این پروژه و سناریو آن به <a style="font-weight:bold;" href="https://alm.index-holding.com/IndexCollection/SoftDept/_wiki/wikis/SoftDept.wiki/12/Job-Scheduler"> Wiki </a> این پروژه مراجعه نمایید.

</p>

</div>

---

<div style = "font-size:20px; font-weight:bold; margin-bottom:10px; direction:ltr; text-align:left;" dir="rtl"> Technologies </div>

* ASP.NET core 5 Web API

* Hangfire.Core

* Hangfire.AspNetCore

* Hangfire.SqlServer

* Newtonsoft.Json

---
<div dir="ltr" style = "font-size:17px; font-weight:bold;"> محتویات فایل ReadMe.md </div>

<div  dir="ltr">

[[_TOC_]]

</div>

---

<div dir="rtl">

#Structure

<p style="direction:rtl; text-align:right;" dir="rtl">

### نیازمندی های پروژه

* 1-  Frame Work های زیر را به پروژه اضافه نمایید:

</p>

<div dir="ltr">

    * Hangfire;

    * Hangfire.SqlServer;

    * Microsoft.AspNetCore.Mvc

    * Newtonsoft.Json

</div>

* 2-  NameSpace های زیر را در File Class اضافه نمایید.

<div dir="ltr">

    * using.Hangfire;

    * using.Hangfire.SqlServer;

    * using.Microsoft.AspNetCore.Mvc

    * using.Newtonsoft.Json


</div>

</div>

---

<div dir="rtl">

#Code Snippet

### Configure Hangfire in Startup

<div dir="ltr">

> add calls to the extension method AddHangfire & AddHangfireServer on the IServiceCollection in ConfigureServices method in class Startup:

           /*
             * Add Hangfire services.
             * Configuration SQL Server
             */
            services.AddHangfire(configuration => configuration
                .UseSqlServerStorage(Configuration.GetConnectionString("HangfireConnection"), new SqlServerStorageOptions
                {
                    CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
                    SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
                    QueuePollInterval = TimeSpan.Zero,
                    UseRecommendedIsolationLevel = true,
                    DisableGlobalLocks = true
                }));

            /* 
             * Add the processing server as IHostedService
             */
            services.AddHangfireServer();

</div>

# Adding Hangfire Dashboard UI

<div dir="ltr">

> Now let’s add the Hangfire dashboard UI. We will add a call to the extension method UseHangfireDashboard on the IApplicationBuilder instance:

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            //Adding Hangfire Dashboard UI
            app.UseHangfireDashboard();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

</div>

#Fixed an HTTP 401 error when Publishing a JobScheduler project

<div dir="ltr">

> ASP.NET Core Hangfire released after the formal environment, if accesshttp://10.1.2.31:5000/hangfire/ Then, will be reported401 UnauthorizedUnauthorized error because Hangfire increased default authorization configuration.

<span style="font-weight:bold; font-size:18px;">Solution:</span>

> increaseCustomAuthorizeFilter：

        public class CustomAuthorizeFilter : IDashboardAuthorizationFilter
     {
        public bool Authorize([NotNull] DashboardContext context)
       {
        //var httpcontext = context.GetHttpContext();
        //return httpcontext.User.Identity.IsAuthenticated;
        return true;
        }
     }

ConfigureIncrease the allocation:

       app.UseHangfireDashboard("/hangfire", new DashboardOptions() { 
        Authorization = new[] { new CustomAuthorizeFilter() }
        });

</div>

---

<div dir="ltr">

#Sources

* https://docs.hangfire.io/en/latest/

* https://www.programmersought.com/article/28062407879/

* https://docs.hangfire.io/en/latest/getting-started/aspnet-core-applications.html

* https://docs.hangfire.io/en/latest/background-processing/index.html

* https://dotnetcorecentral.com/blog/hangfire-in-aspnetcore/

</div>
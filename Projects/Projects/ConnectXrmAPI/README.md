<div dir="rtl">

<div style = "font-size:20px; font-weight:bold; margin-bottom:10px; direction:ltr; text-align:right;" dir="rtl"> Publish </div>

<p style="direction:rtl; text-align:right;" dir="rtl">

> پروژه ConnectXrmAPI رابطی (API) جهت دریافت اطلاعات و مقادیر ارز از Client و انتقال آن ها به پروژه ConnectXRM جهت ثبت در سامانه XRM می باشد. 
> این پروژه پس از نهایی سازی و تکمیل فرآیند توسعه بر روی ماشین مجازیBuildW (192.168.100.38:65003) پابلیش شده است.

</p>

</div>

<div style="border: 1px solid #a5d0f2; widtd: 98%; height: 50px; padding-top: 13.5px; margin-bottom: 12px;">

<span style="font-weight:bold; background-color:#61affe; color:white; text-align:left; direction:ltr; width:50px; height: 35px; padding: 8px 31px; margin: 60px 0px 0 10px; position:absulate; "> GET </span>
<span style="margin-left:20px;"> /api/GetCurrency/connectxrmapi/GetCurrency (http://192.168.100.38:65003/api/GetCurrency/connectxrmapi/GetCurrency)</span>

</div>

<div style="direction:rtl; text-align:right;" dir="rtl">
<p>به عنوان مثال متناسب با Request بالا پارامترهای زیر به Verb GET در پروژه  ConnectXrmAPI ارسال می گردد:</p>
</div>

<div style="direction:ltr; text-align:left;" dir="ltr">

      192.168.100.38:65003/api/GetCurrency/connectxrmapi/GetCurrency?
      username=string  // برای اعتبارسنجی
      password=string  // برای اعتبارسنجی
      url=string  //  XRM آدرس سامانه 
      id=Guid  // Guid برای خواندن از سامانه براساس 

</div>

<div style="border: 1px solid #f1d5b1; widtd: 98%; height: 50px; padding-top: 13.5px; margin-bottom: 12px;">

<span style="font-weight:bold; background-color:#fca130; color:white; text-align:left; direction:ltr; width:30px; height: 35px; padding: 8px 26px; margin: 60px 0px 0 10px; position:absulate; "> POST </span>
<span style="margin-left:20px;"> /api/PostCurrency/connectxrmapi/CreateCurrency (http://192.168.100.38:65003/api/PostCurrency/connectxrmapi/CreateCurrency)</span>

</div>

<div style="direction:rtl; text-align:right;" dir="rtl">
<p>به عنوان مثال متناسب با Request بالا پارامترهای زیر به Verb POST در پروژه ConnectXrmAPI ارسال می گردد:</p>
</div>

<div style="direction:ltr; text-align:left;" dir="ltr">

      [{
        "username":"string",  //برای اعتبارسنجی
        "password":"string",  //برای اعتبارسنجی
        "Url"="string",  //  XRM آدرس سامانه 
        "sitedate":"DateTime",  //تاریخ سایت
        "datesubmitted":"DateTime",  // تاریخ ثبت 
        "price":"decimal",  //قیمت ارز
        "currencyname":"string",  // نام ارز
        "currencytype":"string",  // (حواله ارزی و اسکناس) نوع ارز 
        "currencyprice":"string"  //  (خرید و فروش) نوع قیمت ارز      
      }]

</div>

<div style="border: 1px solid #9ae3c2; widtd: 98%; height: 50px; padding-top: 13.5px; margin-bottom: 12px;">

<span style="font-weight:bold; background-color:#49cc90; color:white; text-align:left; direction:ltr; width:30px; height: 35px; padding: 8px 31px; margin: 60px 0px 0 10px; position:absulate; "> PUT </span>
<span style="margin-left:20px;"> /api/PutCurrency/connectxrmapi/UpdateCurrency (http://192.168.100.38:65003/api/PutCurrency/connectxrmapi/UpdateCurrency)</span>

</div>

<div style="direction:rtl; text-align:right;" dir="rtl">
<p>به عنوان مثال متناسب با Request بالا پارامترهای زیر به Verb PUT در پروژه ConnectXrmAPI ارسال می گردد:</p>
</div>

<div style="direction:ltr; text-align:left;" dir="ltr">

      [{
         "username":"string",  //برای اعتبارسنجی
         "password":"string",  //برای اعتبارسنجی
         "Url:"string",  // XRM آدرس سامانه 
         "id":"Guid",  // Guid برای به روز رسانی موجودیت در سامانه براساس
         "sitedate":"DateTime",  //تاریخ سایت
         "datesubmitted":"DateTime",  //تاریخ ثبت
         "price":"decimal"  //قیمت ارز
      }] 

</div>

<div style="border: 1px solid #feebeb; widtd: 98%; height: 50px; padding-top: 13.5px; margin-bottom: 12px;">

<span style="font-weight:bold; background-color:#f93e3e; color:white; text-align:left; direction:ltr; width:30px; height: 35px; padding: 8px 21px; margin: 60px 0px 0 10px; position:absulate; "> DELETE </span>
<span style="margin-left:20px;"> /api/DeleteCurrency/connectxrmapi/DeleteCurrency (http://192.168.100.38:65003/api/DeleteCurrency/connectxrmapi/DeleteCurrency)</span>

</div>

<div style="direction:rtl; text-align:right;" dir="rtl">
<p>به عنوان مثال متناسب با Request بالا پارامترهای زیر به Verb DELETE در پروژه ConnectXrmAPI ارسال می گردد:</p>
</div>

<div style="direction:ltr; text-align:left;" dir="ltr">

      {
        "username":"string",  //برای اعتبارسنجی
        "password":"string",  //برای اعتبارسنجی
        "id":"Guid"  // Guid برای حذف موجودیت از سامانه براساس
      }

</div>

<div dir="rtl">

<div style = "font-size:20px; font-weight:bold; margin-bottom:10px; direction:ltr; text-align:right;" dir="rtl"> Introduction </div>

<div style = "font-size:15px; font-weight:bold; margin-bottom:10px; direction:ltr; text-align:right;" dir="rtl"> ConnectXrmAPI </div>

<div style = "direction:ltr; text-align:right;" dir="rtl">

<p style="direction:rtl; text-align:justify;" dir="rtl">

> هدف از انجام این پروژه گرفتن اطلاعات مورد نیاز از Client و ارسال آن ها به API دیگر می باشد، سپس از طریق آن API دیگر به XRM متصل شده و عملیات CRUD را انجام می دهد. درواقع این پروژه مقادیر ارز را دریافت می کند و جهت اضافه شدن به XRM به <a href="https://alm.index-holding.com/IndexCollection/SoftDept/_git/ConnectXRM?version=GBmaster">ConnectXrmAPI</a> انتقال می دهد.

> از آن جایی که این پروژه به عنوان یک رایط عمل می کند، بنابراین خروجی ای را نمایش نمی دهد و فقط مقادیر را از مشتری دریافت کرده و به <a href="https://alm.index-holding.com/IndexCollection/SoftDept/_git/ConnectXRM?version=GBmaster">ConnectXrmAPI</a> ارسال می نماید.

> جهت دریافت جزئیات درخصوص ساختار این پروژه و سناریو آن به <a style="font-weight:bold;" href="https://alm.index-holding.com/IndexCollection/SoftDept/_wiki/wikis/SoftDept.wiki/55/ConnectXrmAPI"> Wiki </a> این پروژه مراجعه نمایید.

</p>

</div>

</div>

---

<div style = "font-size:20px; font-weight:bold; margin-bottom:10px; direction:ltr; text-align:left;" dir="ltr"> Technologies </div>


* ASP.NET 5 Web API

* Newtonsoft.Json

---

<div style = "font-size:20px; font-weight:bold;">  محتویات فایل ReadMe.md </div>

[[_TOC_]]

---

<div dir="rtl">

<div style = "direction:ltr; text-align:right;" dir="rtl">

#Structure

### نیازمندی های پروژه

<p style="direction:rtl; text-align:justify;" dir="rtl">

* 1-  Framework های زیر را به پروژه اضافه نمایید:

</p>

</div>

<div dir="ltr">

    * Newtonsoft.Json

</div>

<div style = "direction:ltr; text-align:right;" dir="rtl">

<p style="direction:rtl; text-align:justify;" dir="rtl">


* 2-  NameSpace های زیر را در File Class اضافه نمایید.

</p>

</div>

<div dir="ltr">

    * using System.Net.Http.Json;

    * using Newtonsoft.Json;

    * using System.Net.Http;

    * using System.Net;

    * using System.IO;

    * using JsonSerializer = System.Text.Json.JsonSerializer;

</div>

<div style = "direction:ltr; text-align:right;" dir="rtl">

<p style="direction:rtl; text-align:justify;" dir="rtl">

* همچنین جهت استفاده از متد PostAsJsonAsync باید کتابخانه زیر را به پروژه اضافه نمایید:

</p>

</div>

<div dir="ltr">

    * using System.Net.Http.Json;

</div>

</div>

---

<div dir="rtl">

<div style = "direction:ltr; text-align:right;" dir="rtl">

<p style="direction:rtl; text-align:justify;" dir="rtl">

#Code Snippet

### نحوه خواندن API

* برای خواندن یک API به صورت زیر عمل کنید: (در پوشه Services درون فایل CRUD.cs تعریف گردیده است)

</p>

</div>

<div dir="ltr">

       using (var client = new HttpClient())
        {
            //API URL
            client.BaseAddress = new Uri("http://localhost:57849/");

        //Send request to API
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

        GetData credentials = new GetData();

        //Enter UserName by Client
        credentials.UserName = data.UserName;

        //Send Client information to the API and receive the response
        HttpResponseMessage response = client.PostAsJsonAsync(
            "api/connectxrm/CreateContact", credentials).Result;

        //Get operation result from API
        if (response.IsSuccessStatusCode)
        {
            //Get answers from the API
            var contact = await response.Content.ReadAsStringAsync();

            return contact;
        }
        return null;
       }
</div>

<div style = "direction:ltr; text-align:right;" dir="rtl">

<p style="direction:rtl; text-align:justify;" dir="rtl">

* <span style="font-weight:bold; font-size:15px;">نکته</span>:  هنگام Return کردن نتیجه خوانده شده از API مورد نظر، با ارور زیر مواجه خواهید شد:

</p>

</div>

<div dir="ltr">

<p dir="ltr">

        * System.Text.Json.JsonException: A possible object cycle was detected. 
        * This can either be due to a cycle or if the object depth is larger than the maximum allowed depth of 32(asp.net core 5)

</p>

</div>


<div style = "direction:ltr; text-align:right;" dir="rtl">

<p style="direction:rtl; text-align:justify;" dir="rtl">

* برای رفع ارور بالا باید به صورت زیر عمل کنید:

1- ابتدا پکیج زیر را به پروژه اضافه نمایید:

</p>

</div>

<div dir="ltr">
 
        Microsoft.AspNetCore.Mvc.NewtonsoftJson

</div>

<div style = "direction:ltr; text-align:right;" dir="rtl">

<p style="direction:rtl; text-align:justify;" dir="rtl">

2- سپس کد زیر را در Startup برنامه در تابع ConfigureServices بنویسید:

</p>

</div>

<div dir="ltr" style="direction:ltr !important; text-align:left;">

       public void ConfigureServices(IServiceCollection services)
        {
            /*
             * ،ارور زیر را در نظر بگیرید که هنگام برگرداندن نتیجه خوانده شده با آن مواجه می شوید
             * بنویسید Startup بنابراین برای رفع آن باید کد نوشته را در
             * System.Text.Json.JsonException: A possible object cycle was detected. 
             * This can either be due to a cycle or if the object depth is larger than the maximum 
             * allowed depth of 32(asp.net core 5)
             */
            services.AddControllers().AddNewtonsoftJson(options =>
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
        }
</div>
</div>

---

<div dir="ltr">

#Sources

<div dir="ltr">

* https://docs.microsoft.com/en-us/dotnet/api/system.net.webclient.downloadstring?view=net-5.0

* https://www.c-sharpcorner.com/article/calling-web-api-using-httpclient/


* https://www.c-sharpcorner.com/UploadFile/036f9e/httpresponsemessage-in-webapi166/

* <p style="color:green;">https://forums.asp.net/t/2126083.aspx?Post+Data+to+Web+API</p>

* https://stackoverflow.com/questions/59199593/net-core-3-0-possible-object-cycle-was-detected-which-is-not-supported

* https://entityframeworkcore.com/knowledge-base/59199593/-net-core-3-0-possible-object-cycle-was-detected-which-is-not-supported

</div>
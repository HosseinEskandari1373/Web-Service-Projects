<div dir="rtl">

<div style = "font-size:28px; font-weight:bold; margin-bottom:10px;">ConnectXrmAPI</div>
<p style = "direction:rtl; text-align:right;" dir="rtl">

> هدف از انجام این پروژه گرفتن اطلاعات مورد نیاز از Client و ارسال آن ها به API دیگری است. سپس از طریق API دیگر به XRM متصل شده و عملیات CRUD را انجام می دهد.

</p>
<hr>

<div style = "font-size:20px; font-weight:bold; margin-bottom:10px; direction:rtl; text-align:right;" dir="rtl">تکنولوژی ها</div>

<div dir="ltr">

    * .NET 5

    * Newtonsoft.Json

</div>

---

<div style = "font-size:20px; font-weight:bold;"> فهرست مطالب </div>

[[_TOC_]]

---

# نیازمندی های پروژه
* 1-  Frame Work های زیر را به پروژه اضافه نمایید:

<div dir="ltr">

    * Newtonsoft.Json

</div>

* 2-  NameSpace های زیر را در File Class اضافه نمایید.

<div dir="ltr">

    * using System.Net.Http.Json;

    * using Newtonsoft.Json;

    * using System.Net.Http;

    * using System.Net;

    * using System.IO;

    * using JsonSerializer = System.Text.Json.JsonSerializer;

</div>

* همچنین جهت استفاده از متد PostAsJsonAsync باید کتابخانه زیر را به پروژه اضافه نمایید:

<div dir="ltr">

    * using System.Net.Http.Json;

</div>

---

<div dir="rtl">

# نحوه خواندن API

* برای خواندن یک API به صورت زیر عمل کنید:

<div dir="ltr">

    `using (var client = new HttpClient())
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
        HttpResponseMessage response = await client.PostAsJsonAsync(
            "api/connectxrm/CreateContact", credentials);

        //Get operation result from API
        if (response.IsSuccessStatusCode)
        {
            //Get answers from the API
            var contact = await response.Content.ReadAsStringAsync();

            return contact;
        }
        return null;
    } `
</div>

* نکته ای که وجود دارد در API جهت استفاده از متد HttpResponseMessage باید به صورت زیر عمل نمایید:

<div dir="ltr">

     `//Send Client information to the API and receive the response
    HttpResponseMessage response = await client.PostAsJsonAsync("api/connectxrm/CreateContact", credentials);`

</div>

---
#منابع

<div dir="ltr">

* https://docs.microsoft.com/en-us/dotnet/api/system.net.webclient.downloadstring?view=net-5.0

* https://www.c-sharpcorner.com/article/calling-web-api-using-httpclient/


* https://www.c-sharpcorner.com/UploadFile/036f9e/httpresponsemessage-in-webapi166/

</div>
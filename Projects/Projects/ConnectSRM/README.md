<div dir="rtl">

<div style = "font-size:20px; font-weight:bold; margin-bottom:10px; direction:ltr; text-align:right;" dir="rtl"> Publish </div>

<p style="direction:rtl; text-align:right;" dir="rtl">

> پروژه ConnectXRM به عنوان یک رابط (API) جهت تعامل با سامانه های XRM و انجام عملیات CRUD روی موجودیت های موجود در آن ایجاد گردیده است. 
> این پروژه پس از نهایی سازی و تکمیل فرآیند توسعه بر روی ماشین مجازی BuildW (192.168.100.38:65004) پابلیش شده است.

</p>

</div>

<div style="border: 1px solid #a5d0f2; widtd: 98%; height: 50px; padding-top: 13.5px; margin-bottom: 12px;">

<span style="font-weight:bold; background-color:#61affe; color:white; text-align:left; direction:ltr; width:50px; height: 35px; padding: 8px 31px; margin: 60px 0px 0 10px; position:absulate; "> GET </span>
<span style="margin-left:20px;"> /api/connectxrm/GetCurrency (http://192.168.100.38:65004/api/connectxrm/GetCurrency)</span>

</div>

<div style="direction:rtl; text-align:right;" dir="rtl">
<p>به عنوان مثال متناسب با Request بالا پارامترهای زیر به Verb GET در پروژه ConnectXRM ارسال می گردد:</p>
</div>

<div style="direction:ltr; text-align:left;" dir="ltr">

      http://192.168.100.38:65004/api/connectxrm/GetCurrency?
      username=string  // برای اعتبارسنجی
      password=string  // برای اعتبارسنجی
      url=string  //  XRM آدرس سامانه 
      id=Guid  // Guid برای خواندن از سامانه براساس 

</div>

<div style="border: 1px solid #f1d5b1; widtd: 98%; height: 50px; padding-top: 13.5px; margin-bottom: 12px;">

<span style="font-weight:bold; background-color:#fca130; color:white; text-align:left; direction:ltr; width:30px; height: 35px; padding: 8px 26px; margin: 60px 0px 0 10px; position:absulate; "> POST </span>
<span style="margin-left:20px;"> /api/connectxrm/CreateCurrency (http://192.168.100.38:65004/api/connectxrm/CreateCurrency)</span>

</div>

<div style="direction:rtl; text-align:right;" dir="rtl">
<p>به عنوان مثال متناسب با Request بالا پارامترهای زیر به Verb POST در پروژه ConnectXRM ارسال می گردد:</p>
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
<span style="margin-left:20px;"> /api/connectxrm/UpdateCurrency (http://192.168.100.38:65004/api/connectxrm/UpdateCurrency)</span>

</div>

<div style="direction:rtl; text-align:right;" dir="rtl">
<p>به عنوان مثال متناسب با Request بالا پارامترهای زیر به Verb PUT در پروژه ConnectXRM ارسال می گردد:</p>
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
<span style="margin-left:20px;"> /api/connectxrm/DeleteCurrency (http://192.168.100.38:65004/api/connectxrm/DeleteCurrency)</span>

</div>

<div style="direction:rtl; text-align:right;" dir="rtl">
<p>به عنوان مثال متناسب با Request بالا پارامترهای زیر به Verb DELETE در پروژه ConnectXRM ارسال می گردد:</p>
</div>

<div style="direction:ltr; text-align:left;" dir="ltr">

      {
        "username":"string",  //برای اعتبارسنجی
        "password":"string",  //برای اعتبارسنجی
        "id":"Guid"  // Guid برای حذف موجودیت از سامانه براساس
      }

</div>

---

<div dir="rtl">

<div style = "font-size:20px; font-weight:bold; margin-bottom:10px; direction:ltr; text-align:right;" dir="rtl"> Introduction </div>

<div style = "font-size:15px; font-weight:bold; margin-bottom:10px; direction:ltr; text-align:right;" dir="rtl"> Dynamic CRM SDK 8.1 </div>

<p style="direction:rtl; text-align:justify;" dir="rtl">

> CRM SDK روشی پشتیبانی شده / ایمن برای تعامل با پایگاه داده Microsoft Dynamics CRM است. در ادامه با نحوه کار با آن و انجام عملیات CRUD آشنا می شوید.

> هدف از انجام این پروژه به شرح زیر است:

- از آنجا که این پروژه به عنوان یک رابط عمل می کند، بنابراین خروجی را نمایش نمی دهد و فقط مقادیر را از مشتری دریافت می کند و به XRM متصل شده و عملیات CRUD را روی موجودیت های موجود در XRM اعمال می نماید.

> جهت دریافت جزئیات درخصوص ساختار این پروژه و سناریو آن به <a style="font-weight:bold;" href="https://alm.index-holding.com/IndexCollection/SoftDept/_wiki/wikis/SoftDept.wiki/11/ConnectXRM"> Wiki </a> این پروژه مراجعه نمایید.

</div>

---

<div style = "font-size:20px; font-weight:bold; margin-bottom:10px; direction:ltr; text-align:left;" dir="rtl"> Technologies </div>

* Asp.Net Framework Web Aplication Web API
* Microsoft Dynamics CRM SDK 2016
* Microsoft.Crm.Sdk.Proxy
* System.ServiceMode
* XRMTolling
* System.Runtime.Serialization
* System.ServiceMode

<div style = "font-size:20px; font-weight:bold; margin-bottom:10px; direction:ltr; text-align:left;" dir="rtl"> محتویات فایل ReadMe.md </div>

---

[[_TOC_]]

---
<div dir="rtl">

#Structure

<p style="direction:rtl; text-align:right;" dir="rtl">

> جهت اتصال به Dynamics CRM از طریق ASP.NET Framework Web API و افزودن منابع لازم، مراحل زیر را دنبال نمایید: 

</p>

</div>

        * open SDK and goto the path, SDK->Bin for the dlls:

            - Microsoft.Crm.Sdk.Proxy
            -  System.ServiceMode


        * Add the following frameworks to the project:

            - System.Runtime.Serialization
            - System.ServiceMode


        * Add the follwing namespaces to your class file:

            - using Microsoft.Crm.Sdk.Messages;
            - using Microsoft.Xrm.Sdk;
            - using Microsoft.Xrm.Sdk.Client;
            - using System.ServiceModel.Description; 

        * CRM consists of 3 parameters. Use the following method in your project to connect. These 3 parameters are as follows:

            - UserName
            - Password
            - SoapOrgServiceUri : Goto Microsoft Dynamic CRM -> Settings -> Customizations -> Developer Resources
            - EX: http://crm2016.sdp.com/Test/XRMServices/2011/Organization.svc

---

<div dir="rtl">

#Code Snippet

#### Connect Web Application

این کد برای اتصال به CRM با استفاده از Web Application است. ابتدا یک کلاس ایجاد کرده و از کد زیر را برای اتصال به CRM استفاده نمایید
(در پوشه Services درون فایل ConnectServices.cs تعریف گردیده است):

</div> 

        //Authentication and get service organization
        public static IOrganizationService GetOrganizationService(
            Uri url, string username, string password)
        {
            //Validation with ClientCredentials
            ClientCredentials credentials = new ClientCredentials();
            credentials.Windows.ClientCredential.UserName = username;
            credentials.Windows.ClientCredential.Password = password;
            OrganizationServiceProxy service = new OrganizationServiceProxy(url, null, credentials, null);

            //Check Out Service
            if (service == null)
            {
                throw new Exception("Unable to Establish Connection");
            }
            else
            {
                Console.WriteLine("Connection Sussefuly!");
            }

            //.ایجاد شده نوشتن خط زیر لازم است Service برای استفاده از Early-Bound در روش
            service.EnableProxyTypes();
            return service;
        }

<div dir="rtl">


####Create Currency
سرویس Organization مربوطه را دریافت کنید و سپس براساس پارامترهای دریافتی موجودیت Currency تعریف شده در سامانه XRM را مقداردهی نمایید. (در پوشه Services درون فایل CRUD.cs تعریف گردیده است):

<div style="direction:ltr; text-align:left;" dir="ltr">

        public object CreateCurrency(IOrganizationService service, List<ReadData> currency)
        {
            try
            {
                var _currency = new dev1_currency();
                //insert into entity contact
                        _currency.dev1_name = item.CurrencyName;
                        _currency.dev1_SiteDate = item.SiteDate;
                        _currency.dev1_DateSubmitted = item.DateSubmitted;
                        _currency.dev1_Price = item.Price;
            }
        }

</div>

####Read Currency
سرویس Organization مربوطه را دریافت کنید و براساس Guid دریافتی، ارز مربوطه را از موجودیت Currency در سامانه XRM با کد زیر بخوانید. (در پوشه Services درون فایل CRUD.cs تعریف گردیده است):

<div style="direction:ltr; text-align:left;" dir="ltr">

        public dev1_currency ReadCurrency(IOrganizationService service, Guid id)
        {
            //read from entity Currency
            dev1_currency readcurrency = (dev1_currency)service.Retrieve(
                        dev1_currency.EntityLogicalName,
                        id,
                        new ColumnSet("dev1_sitedate", "dev1_datesubmitted", "dev1_price"));

            return readcurrency;
        }

</div>
       
####Update Currency
پس از دریافت سرویس مورد نظر با برقراری شرط، عملیات Update را براساس Guid دریافتی اعمال نمایید.

کد زیر نحوه انجام این کار را نشان می دهد (در پوشه Services درون فایل CRUD.cs تعریف گردیده است):
<div style="direction:ltr; text-align:left;" dir="ltr">

        /* update entity CRM
            * first, dsfine which entity to update
            * update contact with contactid = id;   */
        public string UpdateCurrency(IOrganizationService service, Guid id, GetCurrency currency)
        {
            //read from entity contact
            dev1_currency updatecurrency = (dev1_currency)service.Retrieve(
                        dev1_currency.EntityLogicalName,
                        id,
                        new ColumnSet("dev1_sitedate", "dev1_datesubmitted", "dev1_price"));

            //Select q_updatecontacts that contactid="id"
            if (updatecurrency != null)
            {
                /* Update q_updatecontact that contactid="id" 
                   And are available in EntityCollection */
                updatecurrency.Attributes["dev1_sitedate"] = currency.SiteDate;
                updatecurrency.Attributes["dev1_datesubmitted"] = currency.DateSubmitted;

                service.Update(updatecurrency);

                string success = "Update contact success!";
                return success;
            }
            return null;
        }

</div>
   

####Delete Currency
پس از دریافت سرویس مورد نظر عملیات حذف را براساس Guid دریافتی بر روی موجودیت مربوطه در سامانه اعمال نمایید.

کد زیر نحوه انجام این کار را نشان می دهد (در پوشه Services درون فایل CRUD.cs تعریف گردیده است):

<div style="direction:ltr; text-align:left;" dir="ltr">

        public HttpResponseMessage DeleteCurrency(IOrganizationService service, Guid id)
        {
            //Select q_updatecontacts that contactid="id
            //read from entity contact
            dev1_currency deleteCurrency = (dev1_currency)service.Retrieve(
                        dev1_currency.EntityLogicalName,
                        id,
                        new ColumnSet("dev1_currencyid"));

            if (deleteCurrency != null)
            {
                /* Delete q_deletecontact that contactid="id" 
                   And are available in EntityCollection */
                service.Delete(deleteCurrency.LogicalName, deleteCurrency.Id);

                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            else if (id != deleteCurrency.Id)
            {
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            }
            return null;
        }

</div>

####Apply the condition whether or not a value exists in XRM

شرط زیر را برای بررسی وجود مقدار ارز در XRM اعمال نمایید(در پوشه Services درون فایل CRUD.cs تعریف گردیده است).

<div style="direction:ltr; text-align:left;" dir="ltr">

<details><summary style="direction:rtl; text-align:right;" dir="rtl">برای مشاهده کد مربوطه کلیک نمایید:</summary>
<p>

            public object CreateCurrency(IOrganizationService service, List<ReadData> currency)
        {
            try
            {
                var _currency = new dev1_currency();

                var currencies = service.RetrieveMultiple(new QueryExpression
                {
                    EntityName = "dev1_currency",
                    ColumnSet = new ColumnSet("dev1_sitedate")
                });

                if (currencies.Entities.Count > 0)
                {
                    foreach (ReadData item in currency)
                    {
                        QueryExpression currencyQueries = new QueryExpression();
                        currencyQueries.EntityName = _currency.LogicalName;
                        currencyQueries.ColumnSet = new ColumnSet("dev1_currencyname", "dev1_currencytype",
                            "dev1_sitedate", "dev1_currencyprice");
                        currencyQueries.Criteria.AddCondition("dev1_currencypricename", ConditionOperator.Equal,
                            item.PriceType);
                        currencyQueries.Criteria.AddCondition("dev1_currencynamename", ConditionOperator.Equal,
                            item.CurrencyName);
                        currencyQueries.Criteria.AddCondition("dev1_currencytypename", ConditionOperator.Equal,
                            item.CurrencyType);
                        currencyQueries.Criteria.AddCondition("dev1_sitedate", ConditionOperator.Equal,
                            item.SiteDate);

                        DataCollection<Entity> Collections = service.RetrieveMultiple(currencyQueries).Entities;

                        if (Collections.Count < 1)
                        {
                            //insert into entity contact
                            _currency.dev1_name = item.CurrencyName;
                            _currency.dev1_SiteDate = item.SiteDate;
                            _currency.dev1_DateSubmitted = item.DateSubmitted;
                            _currency.dev1_Price = item.Price;

                            if (item.PriceType == "خرید")
                            {
                                OptionSetValue CurrencyPriceBuy = new OptionSetValue(770760000);
                                _currency.Attributes.Remove("dev1_currencyprice");
                                _currency.Attributes.Add("dev1_currencyprice", CurrencyPriceBuy);
                            }
                            else if (item.PriceType == "فروش")
                            {
                                OptionSetValue CurrencyPriceSell = new OptionSetValue(770760001);
                                _currency.Attributes.Remove("dev1_currencyprice");
                                _currency.Attributes.Add("dev1_currencyprice", CurrencyPriceSell);
                            }
                            else
                            {
                                return new HttpResponseMessage(HttpStatusCode.NotFound);
                            }

                            if (item.CurrencyType == "اسکناس")
                            {
                                OptionSetValue CurrencyTypeEskenas = new OptionSetValue(770760001);
                                _currency.Attributes.Remove("dev1_currencytype");
                                _currency.Attributes.Add("dev1_currencytype", CurrencyTypeEskenas);
                            }
                            else if (item.CurrencyType == "حواله ارزی")
                            {
                                OptionSetValue CurrencyTypeHavaleh = new OptionSetValue(770760000);
                                _currency.Attributes.Remove("dev1_currencytype");
                                _currency.Attributes.Add("dev1_currencytype", CurrencyTypeHavaleh);
                            }
                            else
                            {
                                return new HttpResponseMessage(HttpStatusCode.NotFound);
                            }

                            QueryExpression currencyQuery = new QueryExpression();
                            currencyQuery.EntityName = "transactioncurrency";
                            currencyQuery.ColumnSet = new ColumnSet("currencyname");
                            currencyQuery.Criteria.AddCondition("currencyname", ConditionOperator.Equal, item.CurrencyName);

                            Guid currencyId = Guid.Empty;
                            string currencyName = "";
                            EntityCollection Collection = service.RetrieveMultiple(currencyQuery);

                            foreach (var itemLookUp in Collection.Entities)
                            {
                                currencyId = itemLookUp.Id;
                                currencyName = itemLookUp.GetAttributeValue<string>("currencyname");
                            }

                            var currencyRateId = new EntityReference(_currency.LogicalName, currencyId);
                            _currency.dev1_CurrencyName = currencyRateId;

                            //Create currency using Service methods
                            currencyGUID = service.Create(_currency);
                        }
                    }
                }
                return (new HttpResponseMessage(HttpStatusCode.OK));
            }
            catch (Exception)
            {
                throw;
            }
        }

</p>
</details>

</div>

---

# Sources

<div style="text-align:left; direction:ltr;" dir="ltr">
<p>

* https://dynamics365authority.com/Blog/connect-to-crm-online-or-on-premise-using-c-sdk

* https://docs.microsoft.com/en-us/dynamics365/customerengagement/on-premises/developer/sample-create-retrieve-update-delete-email-attachment

* https://developer.okta.com/blog/2018/07/27/build-crud-app-in-aspnet-framework-webapi-and-angular

* https://docs.microsoft.com/en-us/aspnet/mvc/overview/getting-started/getting-started-with-ef-using-mvc/implementing-basic-crud-functionality-with-the-entity-framework-in-asp-net-mvc-application

* https://www.tutorialsteacher.com/webapi/web-api-routing

* https://www.codeguru.com/csharp/.net/using-custom-action-names-in-asp.net-web-api.htm

* https://www.codeproject.com/Questions/5266236/How-to-change-the-base-url-in-web-api

* https://docs.microsoft.com/en-us/aspnet/web-api/overview/web-api-routing-and-actions/routing-in-aspnet-web-api

* https://community.dynamics.com/crm/f/microsoft-dynamics-crm-forum/305276/crud-operations-using-web-api-in-console-app/880221

* https://www.youtube.com/watch?v=EfgSBiZSXAA

* https://docs.microsoft.com/en-us/aspnet/web-api/

</p>

</div>

---
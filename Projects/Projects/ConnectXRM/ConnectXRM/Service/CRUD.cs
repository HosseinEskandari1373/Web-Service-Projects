using System;
using System.Collections.Generic;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using ConnectXRM.Models;
using ConnectXRM.Services;
using CrmEarlyBound;
using System.Net.Http;
using System.Net;
using System.Linq;

namespace ConnectXRM.Operations
{
    public class CRUD
    {
        public Guid currencyGUID;
        //Determine the type of CRUD operation Entity
        public enum ActionTypes
        {
            Contact = 1,
            Account = 2,
            Currency = 3
        }

        //-------------------Contact-----------------------//
        public object CreateContact(IOrganizationService service, GetContact contact)
        {
            //insert into entity contact
            var _contact = new Contact();
            _contact.FirstName = contact.FirstName;
            _contact.LastName = contact.LastName;
            _contact.EMailAddress1 = contact.Email;

            //Create contacts using Service methods
            Guid contactID = service.Create(_contact);

            return (_contact + "    GUID: " + contactID);
        }

        public Contact ReadContact(IOrganizationService service, Guid id)
        {
            //read from entity contact
            Contact readContact = (Contact)service.Retrieve(
                        Contact.EntityLogicalName,
                        id,
                        new ColumnSet("firstname", "lastname", "emailaddress1"));

            return readContact;
        }

        /*  * update entity CRM
           * first, dsfine which entity to update
           * update contact with contactid = id;   */
        public string UpdateContact(IOrganizationService service, Guid id, GetContact contact)
        {
            //read from entity contact
            Contact updateContact = (Contact)service.Retrieve(
                        Contact.EntityLogicalName,
                        id,
                        new ColumnSet("firstname", "lastname", "emailaddress1"));

            //Select q_updatecontacts that contactid="id"
            if (updateContact != null)
            {
                /* Update q_updatecontact that contactid="id" 
                   And are available in EntityCollection */
                updateContact.Attributes["firstname"] = contact.FirstName;
                updateContact.Attributes["lastname"] = contact.LastName;

                service.Update(updateContact);

                string success = "Update contact success!";
                return success;
            }
            return null;
        }


        public HttpResponseMessage DeleteContact(IOrganizationService service, Guid id)
        {
            //Select q_updatecontacts that contactid="id
            //read from entity contact
            Contact deleteContact = (Contact)service.Retrieve(
                        Contact.EntityLogicalName,
                        id,
                        new ColumnSet("contactid"));

            if (deleteContact != null)
            {
                /* Delete q_deletecontact that contactid="id" 
                   And are available in EntityCollection */
                service.Delete(deleteContact.LogicalName, deleteContact.Id);

                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            else if (id != deleteContact.Id)
            {
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            }
            return null;
        }

        //-------------------Account-----------------------//
        public object CreateAccount(IOrganizationService service, GetAccount account)
        {
            //insert into entity account
            var _account = new Account();
            _account.Name = account.Name;
            _account.Telephone1 = account.Phone;
            _account.Address1_City = account.Address;

            //Create account using Service methods
            Guid accountID = service.Create(_account);

            return (_account + "    GUID: " + accountID);
        }

        public Account ReadAccount(IOrganizationService service, Guid id)
        {
            //read from entity account
            Account readAccount = (Account)service.Retrieve(
                        Account.EntityLogicalName,
                        id,
                        new ColumnSet("name", "telephone1", "address1_city"));

            return readAccount;
        }

        /*  * update entity CRM
            * first, dsfine which entity to update
            * update account with accountid = id;   */
        public string UpdateAccount(IOrganizationService service, Guid id, GetAccount account)
        {
            //read from entity contact
            Account updateAccount = (Account)service.Retrieve(
                        Account.EntityLogicalName,
                        id,
                        new ColumnSet("name", "telephone1", "address1_city"));

            //Select q_updatecontacts that contactid="id"
            if (updateAccount != null)
            {
                /* Update q_updatecontact that contactid="id" 
                   And are available in EntityCollection */
                updateAccount.Attributes["name"] = account.Name;
                updateAccount.Attributes["telephone1"] = account.Phone;

                service.Update(updateAccount);

                string success = "Update contact success!";
                return success;
            }
            return null;
        }

        public HttpResponseMessage DeleteAccount(IOrganizationService service, Guid id)
        {
            //Select q_updatecontacts that contactid="id
            //read from entity contact
            Account deleteAccount = (Account)service.Retrieve(
                        Account.EntityLogicalName,
                        id,
                        new ColumnSet("accountid"));

            if (deleteAccount != null)
            {
                /* Delete q_deletecontact that contactid="id" 
                   And are available in EntityCollection */
                service.Delete(deleteAccount.LogicalName, deleteAccount.Id);

                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            else if (id != deleteAccount.Id)
            {
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            }
            return null;
        }

        //-------------------Currency-----------------------//
        public object CreateCurrency(IOrganizationService service, List<ReadData> currency)
        {
            try
            {
                var _currency = new dev1_currency();

                foreach (ReadData item in currency)
                {
                    //XRM نوشتن شرط برای بررسی موجود بودن یا نبودن مقدار ارز دریافتی در 
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

                    //کوئری نوشته شده Collection خواندن
                    DataCollection<Entity> Collections = service.RetrieveMultiple(currencyQueries).Entities;

                    //XRM شرط برای ناموجود بودن مقدار ارز در 
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
                            //شده است Set حذف مقدار قبلی که
                            _currency.Attributes.Remove("dev1_currencyprice");
                            _currency.Attributes.Add("dev1_currencyprice", CurrencyPriceBuy);
                        }
                        else if (item.PriceType == "فروش")
                        {
                            OptionSetValue CurrencyPriceSell = new OptionSetValue(770760001);
                            //شده است Set حذف مقدار قبلی که
                            _currency.Attributes.Remove("dev1_currencyprice");
                            _currency.Attributes.Add("dev1_currencyprice", CurrencyPriceSell);
                        }
                        else if (item.PriceType == "نرخ دولتی")
                        {
                            OptionSetValue CurrencyPriceArzDolati = new OptionSetValue(770760002);
                            //شده است Set حذف مقدار قبلی که
                            _currency.Attributes.Remove("dev1_currencyprice");
                            _currency.Attributes.Add("dev1_currencyprice", CurrencyPriceArzDolati);
                        }
                        else
                        {
                            return new HttpResponseMessage(HttpStatusCode.NotFound);
                        }

                        if (item.CurrencyType == "اسکناس")
                        {
                            OptionSetValue CurrencyTypeEskenas = new OptionSetValue(770760001);
                            //شده است Set حذف مقدار قبلی که
                            _currency.Attributes.Remove("dev1_currencytype");
                            _currency.Attributes.Add("dev1_currencytype", CurrencyTypeEskenas);
                        }
                        else if (item.CurrencyType == "حواله ارزی")
                        {
                            OptionSetValue CurrencyTypeHavaleh = new OptionSetValue(770760000);
                            //شده است Set حذف مقدار قبلی که
                            _currency.Attributes.Remove("dev1_currencytype");
                            _currency.Attributes.Add("dev1_currencytype", CurrencyTypeHavaleh);
                        }
                        else if (item.CurrencyType == "ارز دولتی")
                        {
                            OptionSetValue CurrencyTypeArzDolati = new OptionSetValue(770760002);
                            //شده است Set حذف مقدار قبلی که
                            _currency.Attributes.Remove("dev1_currencytype");
                            _currency.Attributes.Add("dev1_currencytype", CurrencyTypeArzDolati);
                        }
                        else
                        {
                            return new HttpResponseMessage(HttpStatusCode.NotFound);
                        }

                        //XRM تعریف شده در Currency در موجودیت LookUp کوئری جهت خواندن فیلدهای
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

                return (new HttpResponseMessage(HttpStatusCode.OK), "Add Successfull Currency in XRM");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public dev1_currency ReadCurrency(IOrganizationService service, Guid id)
        {
            //read from entity Currency
            dev1_currency readcurrency = (dev1_currency)service.Retrieve(
                        dev1_currency.EntityLogicalName,
                        id,
                        new ColumnSet("dev1_sitedate", "dev1_datesubmitted", "dev1_price"));

            return readcurrency;
        }

        /*  * update entity CRM
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

    }
}

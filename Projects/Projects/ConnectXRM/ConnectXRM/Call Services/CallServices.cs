using ConnectXRM.Models;
using ConnectXRM.Services;
using CrmEarlyBound;
using System;
using System.Net;
using System.Collections.Generic;
using static ConnectXRM.Operations.CRUD;

namespace ConnectXRM.Operations
{
    public class CallServices
    {
        public object CreateEntities(ActionTypes type,
            List<ReadData> data, GetContact contact, GetAccount account, ReadData otherData)
        {
            switch (type)
            {
                case ActionTypes.Contact:
                    Uri uriContact = new Uri(otherData.Url);

                    var serviceContact = ConnectService.GetOrganizationService(uriContact, otherData.UserName, otherData.Password);
                    //Calling method ReadContact From the CRUD class
                    object createContact = new CRUD().CreateContact(serviceContact, contact);

                    //Send result for Client
                    switch (createContact)
                    {
                        case null:
                            return HttpStatusCode.NotFound;
                        default:
                            return (HttpStatusCode.OK, createContact);
                    }

                case ActionTypes.Account:
                    Uri uriAccount = new Uri(otherData.Url);

                    var serviceAccount = ConnectService.GetOrganizationService(uriAccount, otherData.UserName, otherData.Password);

                    //Calling method ReadContact From the CRUD class
                    object createAccount = new CRUD().CreateAccount(serviceAccount, account);

                    //Send result for Client
                    switch (createAccount)
                    {
                        case null:
                            return HttpStatusCode.NotFound;
                        default:
                            return (HttpStatusCode.OK, createAccount);
                    }

                default:
                    break;
            }

            foreach (var item in data)
            {
                Uri uriCurrency = new Uri(item.Url);

                //Call service to perform CRUD operations
                var serviceCurrency = ConnectService.GetOrganizationService(uriCurrency, item.UserName, item.Password);

                switch (type)
                {
                    case ActionTypes.Currency:
                        //Calling method ReadContact From the CRUD class
                        object createCurrency = new CRUD().CreateCurrency(serviceCurrency, data);

                        //Send result for Client
                        switch (createCurrency)
                        {
                            case null:
                                return HttpStatusCode.NotFound;
                            default:
                                return (HttpStatusCode.OK, createCurrency);
                        }

                    default:
                        break;
                }
            }

            return null;
        }
        public object ReadEntities(ActionTypes type, ReadData data)
        {
            Uri uri = new Uri(data.Url);

            //Call service to perform CRUD operations
            var service = ConnectService.GetOrganizationService(uri, data.UserName, data.Password);

            switch (type)
            {
                case ActionTypes.Contact:
                    //Calling method ReadContact From the CRUD class
                    Contact readContact = new CRUD().ReadContact(service, data.Id);

                    //Send result for Client
                    switch (readContact)
                    {
                        case null:
                            return HttpStatusCode.NotFound;
                        default:
                            return (HttpStatusCode.OK, readContact);
                    }

                case ActionTypes.Account:
                    //Calling method ReadContact From the CRUD class
                    Account readAccount = new CRUD().ReadAccount(service, data.Id);

                    //Send result for Client
                    switch (readAccount)
                    {
                        case null:
                            return HttpStatusCode.NotFound;
                        default:
                            return (HttpStatusCode.OK, readAccount);
                    }

                case ActionTypes.Currency:
                    //Calling method ReadContact From the CRUD class
                    dev1_currency readCurrency = new CRUD().ReadCurrency(service, data.Id);

                    //Send result for Client
                    switch (readCurrency)
                    {
                        case null:
                            return HttpStatusCode.NotFound;
                        default:
                            return (HttpStatusCode.OK, readCurrency);
                    }

                default:
                    break;
            }
            return null;
        }

        public object UpdateEntities(ActionTypes type,
            ReadData data, GetContact contact, GetAccount account, GetCurrency currency)
        {
            Uri uri = new Uri(data.Url);

            //Call service to perform CRUD operations
            var service = ConnectService.GetOrganizationService(uri, data.UserName, data.Password);

            switch (type)
            {
                case ActionTypes.Contact:
                    //Calling method ReadContact From the CRUD class
                    string updateContact = new CRUD().UpdateContact(service, data.Id, contact);

                    //Send result for Client
                    switch (updateContact)
                    {
                        case null:
                            return HttpStatusCode.NotFound;
                        default:
                            return (HttpStatusCode.OK, updateContact);
                    }

                case ActionTypes.Account:
                    //Calling method ReadContact From the CRUD class
                    string updateAccount = new CRUD().UpdateAccount(service, data.Id, account);

                    //Send result for Client
                    switch (updateAccount)
                    {
                        case null:
                            return HttpStatusCode.NotFound;
                        default:
                            return (HttpStatusCode.OK, updateAccount);
                    }

                case ActionTypes.Currency:
                    //Calling method ReadContact From the CRUD class
                    string updateCurrency = new CRUD().UpdateCurrency(service, data.Id, currency);

                    //Send result for Client
                    switch (updateCurrency)
                    {
                        case null:
                            return HttpStatusCode.NotFound;
                        default:
                            return (HttpStatusCode.OK, updateCurrency);
                    }

                default:
                    break;
            }
            return null;
        }

        public string DeleteEntities(ActionTypes type, ReadData data)
        {
            Uri uri = new Uri(data.Url);

            //Call service to perform CRUD operations
            var service = ConnectService.GetOrganizationService(uri, data.UserName, data.Password);

            switch (type)
            {
                case ActionTypes.Contact:
                    //Calling method ReadContact From the CRUD class
                    var DeleteContact = new CRUD().DeleteContact(service, data.Id);
                    string DeleteContactMessage = "Delete Successful!";

                    if (DeleteContact != null)
                    {
                        return DeleteContactMessage;
                    }
                    else
                    {
                        string DeleteContactError = "NotFound!!";
                        return DeleteContactError;
                    }

                case ActionTypes.Account:
                    //Calling method ReadContact From the CRUD class
                    var DeleteAccount = new CRUD().DeleteAccount(service, data.Id);
                    string DeleteAccountMessage = "Delete Successful!";

                    if (DeleteAccount != null)
                    {
                        return DeleteAccountMessage;
                    }
                    else
                    {
                        string DeleteAccountError = "NotFound!!";
                        return DeleteAccountError;
                    }

                case ActionTypes.Currency:
                    //Calling method ReadContact From the CRUD class
                    var DeleteCurrency = new CRUD().DeleteCurrency(service, data.Id);
                    string DeleteCurrencyMessage = "Delete Successful!";

                    if (DeleteCurrency != null)
                    {
                        return DeleteCurrencyMessage;
                    }
                    else
                    {
                        string DeleteCurrencyError = "NotFound!!";
                        return DeleteCurrencyError;
                    }

                default:
                    break;
            }
            return null;
        }
    }
}


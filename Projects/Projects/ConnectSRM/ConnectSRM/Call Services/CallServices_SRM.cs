using CrmEarlyBound;
using System;
using System.Net;
using System.Collections.Generic;
using ConnectSRM.Models;
using static ConnectSRM.Operations.CRUD_SRM;
using ConnectSRM.Services;

namespace ConnectSRM.Operations
{
    public class CallServices_SRM
    {
        public object CreateEntities(ActionTypes type,
            List<ReadData> data, ReadData otherData)
        {
            foreach (var item in data)
            {
                Uri uriCurrency = new Uri(item.Url);

                //Call service to perform CRUD operations
                var serviceCurrency = ConnectServices_SRM.GetOrganizationService(uriCurrency, item.UserName, item.Password);

                switch (type)
                {
                    case ActionTypes.Currency:
                        //Calling method ReadContact From the CRUD class
                        object createCurrency = new CRUD_SRM().CreateCurrency(serviceCurrency, data);

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
            var service = ConnectServices_SRM.GetOrganizationService(uri, data.UserName, data.Password);

            switch (type)
            {
                case ActionTypes.Currency:
                    //Calling method ReadContact From the CRUD class
                    dev1_currency readCurrency = new CRUD_SRM().ReadCurrency(service, data.Id);

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
            ReadData data, GetCurrency currency)
        {
            Uri uri = new Uri(data.Url);

            //Call service to perform CRUD operations
            var service = ConnectServices_SRM.GetOrganizationService(uri, data.UserName, data.Password);

            switch (type)
            {
                
                case ActionTypes.Currency:
                    //Calling method ReadContact From the CRUD class
                    string updateCurrency = new CRUD_SRM().UpdateCurrency(service, data.Id, currency);

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
            var service = ConnectServices_SRM.GetOrganizationService(uri, data.UserName, data.Password);

            switch (type)
            {
                
                case ActionTypes.Currency:
                    //Calling method ReadContact From the CRUD class
                    var DeleteCurrency = new CRUD_SRM().DeleteCurrency(service, data.Id);
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


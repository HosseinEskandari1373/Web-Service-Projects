using ConnectXrmAPI.Models;
using ConnectXrmAPI.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using static ConnectXrmAPI.Services.CRUD;

namespace ConnectXrmAPI.Cal_Services
{
    public class CallServices
    {
        private readonly ILogger<CRUD> _logger;
        public object CreateEntities(ActionTypes type, List<ReadData> data, ReadData otherData)
        {
            switch (type)
            {
                case ActionTypes.Contact:
                    {
                        //Call the CreateContact method
                        Task<object> createContact = new CRUD(_logger).CreateContact(otherData);
                        return createContact;
                    }
                case ActionTypes.Account:
                    {
                        //Call the CreateAccount method
                        object createAccount = new CRUD(_logger).CreateAccount(otherData);
                        return createAccount;
                    }
                case ActionTypes.Currency:
                    {
                        //Call the CreateCurrency method
                        object createCurrency = new CRUD(_logger).CreateCurrency(data);
                        return createCurrency;
                    }

                default:
                    break;
            }
            return null;
        }

        public object ReadEntities(ActionTypes type, ReadData data)
        {
            switch (type)
            {
                case ActionTypes.Contact:
                    {
                        //Call the ReadContact method
                        object createContact = new CRUD(_logger).ReadContact(data);
                        return createContact;
                    }
                case ActionTypes.Account:
                    {
                        //Call the ReadAccount method
                        object createAccount = new CRUD(_logger).ReadAccount(data);
                        return createAccount;
                    }
                case ActionTypes.Currency:
                    {
                        //Call the ReadCurrency method
                        object createCurrency = new CRUD(_logger).ReadCurrency(data);
                        return createCurrency;
                    }

                default:
                    break;
            }
            return null;
        }

        public object UpdateEntities(ActionTypes type, ReadData data)
        {
            switch (type)
            {
                case ActionTypes.Contact:
                    {
                        //Call the UpdateContact method
                        object updateContact = new CRUD(_logger).UpdateContact(data);
                        return updateContact;
                    }
                case ActionTypes.Account:
                    {
                        //Call the UpdateAccount method
                        object updateAccount = new CRUD(_logger).UpdateAccount(data);
                        return updateAccount;
                    }
                case ActionTypes.Currency:
                    {
                        //Call the UpdateCurrency method
                        object updateCurrency = new CRUD(_logger).UpdateCurrency(data);
                        return updateCurrency;
                    }

                default:
                    break;
            }
            return null;
        }

        public object DeleteEntities(ActionTypes type, ReadData data)
        {
            switch (type)
            {
                case ActionTypes.Contact:
                    {
                        //Call the DeleteContact method
                        object deleteContact = new CRUD(_logger).DeleteContact(data);
                        return deleteContact;
                    }
                case ActionTypes.Account:
                    {
                        //Call the DeleteAccount method
                        HttpResponseMessage deleteAccount = new CRUD(_logger).DeleteAccount(data);
                        return deleteAccount;
                    }
                case ActionTypes.Currency:
                    {
                        //Call the DeleteCurrency method
                        HttpResponseMessage deleteCurrency = new CRUD(_logger).DeleteCurrency(data);
                        return deleteCurrency;
                    }

                default:
                    break;
            }
            return null;
        }
    }
}

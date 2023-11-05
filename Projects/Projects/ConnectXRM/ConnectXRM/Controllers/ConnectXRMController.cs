using ConnectXRM.Models;
using ConnectXRM.Operations;
using System;
using System.Collections.Generic;
using System.Web.Http;
using static ConnectXRM.Operations.CRUD;

namespace ConnectXRM.Controllers
{
    public class ConnectXRMController : ApiController
    {
        //-------------------Contact-----------------------//
        /* GET: api/ConnectCRM/GetContact
           Receive Client Informations and then passes them to another method */
        [HttpGet]
        [ActionName("GetContact")]
        public object GetContact(
            string username, string password, string url, Guid id)
        {
            ReadData credentials = new ReadData()
            {
                UserName = username,
                Password = password,
                Url = url,
                Id = id
            };

            /* Call the ReadEntities method from the CallServices class to 
             * get the result of the Read operation */
            object result = new CallServices().ReadEntities(ActionTypes.Contact, credentials);

            return result;
        }

        /* POST: api/ConnectXRM/CreateContact
        Receive Client Informations and then passes them to another method */
        [HttpPost]
        [ActionName("CreateContact")]
        public object PostContact([FromBody] ReadData data)
        {
            GetContact contact = new GetContact()
            {
                FirstName = data.FirstName,
                LastName = data.LastName,
                Email = data.Email
            };

            /* Call the CreateEntities method from the CallServices class to 
             * get the result of the Create operation */
            object result = new CallServices().CreateEntities(
                ActionTypes.Contact, null, contact, null, data);

            return result;
        }

        /* PUT: api/ConnectXRM/UpdateContact
        Receive Client Informations and then passes them to another method */
        [HttpPut]
        [ActionName("UpdateContact")]
        public object PutContact([FromBody] ReadData data)
        {
            GetContact contact = new GetContact()
            {
                FirstName = data.FirstName,
                LastName = data.LastName
            };

            /* Call the UpdateEntities method from the CallServices class to 
             * get the result of the Update operation */
            object result = new CallServices().UpdateEntities(
                ActionTypes.Contact, data, contact , null, null);

            return result;
        }

        /* DELETE: api/ConnectXRM/DeleteContact
        Receive Client Informations and then passes them to another method */
        [HttpDelete]
        [ActionName("DeleteContact")]
        public object DeleteContact([FromBody] ReadData data)
        {
            /* Call the DeleteEntities method from the CallServices class to 
             * get the result of the Delete operation */
            object result = new CallServices().DeleteEntities(ActionTypes.Contact, data);

            return result;
        }

        //-------------------Account-----------------------//
        /* GET: api/ConnectCRM/GetAccount
        Receive Client Informations and then passes them to another method */
        [HttpGet]
        [ActionName("GetAccount")]
        public object GetAccount(
            string username, string password, string url, Guid id)
        {
            ReadData credentials = new ReadData()
            {
                UserName = username,
                Password = password,
                Url = url,
                Id = id
            };

            /* Call the ReadEntities method from the CallServices class to 
             * get the result of the Read operation */
            object result = new CallServices().ReadEntities(ActionTypes.Account, credentials);

            return result;
        }

        /* POST: api/ConnectXRM/CreateAccount
        Receive Client Informations and then passes them to another method */
        [HttpPost]
        [ActionName("CreateAccount")]
        public object PostAccount([FromBody] ReadData data)
        {
            GetAccount account = new GetAccount()
            {
                Name = data.Name,
                Phone = data.Phone,
                Address = data.Address
            };

            /* Call the CreateEntities method from the CallServices class to 
             * get the result of the Create operation */
            object result = new CallServices().CreateEntities(
                ActionTypes.Account, null, null, account, data);

            return result;
        }

        /* PUT: api/ConnectXRM/UpdateAccount
        Receive Client Informations and then passes them to another method */
        [HttpPut]
        [ActionName("UpdateAccount")]
        public object PutAccount([FromBody] ReadData data)
        {
            GetAccount account = new GetAccount()
            {
                Name = data.Name,
                Phone = data.Phone,
                Address = data.Address
            };

            /* Call the UpdateEntities method from the CallServices class to 
             * get the result of the Update operation */
            object result = new CallServices().UpdateEntities(
                ActionTypes.Account, data, null, account, null);

            return result;
        }

        /* DELETE: api/ConnectXRM/DeleteAccount
        Receive Client Informations and then passes them to another method */
        [HttpDelete]
        [ActionName("DeleteAccount")]
        public object DeleteAccount([FromBody] ReadData data)
        {
            /* Call the DeleteEntities method from the CallServices class to 
             * get the result of the Delete operation */
            object result = new CallServices().DeleteEntities(ActionTypes.Account, data);

            return result;
        }

        //-------------------Currency-----------------------//
        /* GET: api/ConnectCRM/GetCurrency
        Receive Client Informations and then passes them to another method */
        [HttpGet]
        [ActionName("GetCurrency")]
        public object GetCurrency(
            string username, string password, string url, Guid id)
        {
            ReadData credentials = new ReadData()
            {
                UserName = username,
                Password = password,
                Url = url,
                Id = id
            };

            /* Call the ReadEntities method from the CallServices class to 
             * get the result of the Read operation */
            object result = new CallServices().ReadEntities(ActionTypes.Currency, credentials);

            return result;
        }

        /* POST: api/ConnectXRM/CreateCurrency
        Receive Client Informations and then passes them to another method */
        [HttpPost]
        [ActionName("CreateCurrency")]
        public object PostCurrency([FromBody] List<ReadData> data)
        {
            /* Call the CreateEntities method from the CallServices class to 
             * get the result of the Create operation */
            object result = new CallServices().CreateEntities(
                ActionTypes.Currency, data, null, null, null);

            return result;
        }

        /* PUT: api/ConnectXRM/UpdateCurrency
        Receive Client Informations and then passes them to another method */
        [HttpPut]
        [ActionName("UpdateCurrency")]
        public object PutCurrency([FromBody] ReadData data)
        {
            GetCurrency currency = new GetCurrency()
            {
                SiteDate = data.SiteDate,
                DateSubmitted = data.DateSubmitted,
                Price = data.Price
            };

            /* Call the UpdateEntities method from the CallServices class to 
             * get the result of the Update operation */
            object result = new CallServices().UpdateEntities(
                ActionTypes.Currency, data, null, null, currency);

            return result;
        }

        /* DELETE: api/ConnectXRM/DeleteCurrency
        Receive Client Informations and then passes them to another method */
        [HttpDelete]
        [ActionName("DeleteCurrency")]
        public object DeleteCurrency([FromBody] ReadData data)
        {
            /* Call the DeleteEntities method from the CallServices class to 
             * get the result of the Delete operation */
            object result = new CallServices().DeleteEntities(ActionTypes.Currency, data);

            return result;
        }
    }
}

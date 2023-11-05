using ConnectXrmAPI.Cal_Services;
using ConnectXrmAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static ConnectXrmAPI.Services.CRUD;

namespace ConnectXrmAPI.Controllers
{
    [Route("api/[action]/{controller}")]
    [ApiController]
    public class ConnectXrmAPI : ControllerBase
    {
        private readonly ILogger<ConnectXrmAPI> _logger;

        public ConnectXrmAPI(ILogger<ConnectXrmAPI> logger)
        {
            _logger = logger;
        }

        ////-------------------Contact-----------------------//
        ///* GET: api/ConnectCRM/GetContact
        //   Receive Client Informations and then passes them to another method */
        [HttpGet("{GetContact}")]
        public object GetContact(
            string username, string password, Guid id)
        {
            ReadData credentials = new ReadData()
            {
                UserName = username,
                Password = password,
                Id = id,
            };

            /* Call the ReadEntities method from the CallServices class to 
             * get the result of the Read operation */
            object result = new CallServices().ReadEntities(ActionTypes.Contact, credentials);

            //Send result for Client
            return result;
        }

        /* POST: api/ConnectXRM/CreateContact
        Receive Client Informations and then passes them to another method */
        [HttpPost("{CreateContact}")]
        public object PostContact([FromBody] ReadData data)
        {
            /* Call the CreateEntities method from the CallServices class to 
             * get the result of the Create operation */
            object result = new CallServices().CreateEntities(
                ActionTypes.Contact, null, data);

            //Send result for Client
            return result;
        }
        /* PUT: api/ConnectXRM/UpdateContact
        Receive Client Informations and then passes them to another method */
        [HttpPut("{UpdateContact}")]
        public object PutContact([FromBody] ReadData data)
        {
            /* Call the UpdateEntities method from the CallServices class to 
             * get the result of the Update operation */
            object result = new CallServices().UpdateEntities(
                ActionTypes.Contact, data);

            //Send result for Client
            return result;
        }

        /* DELETE: api/ConnectXRM/DeleteContact
        Receive Client Informations and then passes them to another method */
        [HttpDelete("{DeleteContact}")]
        public object DeleteContact([FromBody] ReadData data)
        {
            /* Call the DeleteEntities method from the CallServices class to 
             * get the result of the Delete operation */
            object result = new CallServices().DeleteEntities(ActionTypes.Contact, data);

            //Send result for Client
            string DeleteContact = "Delete Contact Successful";
            return (result, DeleteContact);
        }

        //-------------------Account-----------------------//
        /* GET: api/ConnectCRM/GetAccount
        Receive Client Informations and then passes them to another method */
        [HttpGet("{GetAccount}")]
        public object GetAccount(
            string username, string password, Guid id)
        {
            ReadData credentials = new ReadData()
            {
                UserName = username,
                Password = password,
                Id = id
            };

            /* Call the ReadEntities method from the CallServices class to 
             * get the result of the Read operation */
            object result = new CallServices().ReadEntities(ActionTypes.Account, credentials);

            //Send result for Client
            return result;
        }

        /* POST: api/ConnectXRM/CreateAccount
        Receive Client Informations and then passes them to another method */
        [HttpPost("{CreateAccount}")]
        public object PostAccount([FromBody] ReadData data)
        {
            /* Call the CreateEntities method from the CallServices class to 
             * get the result of the Create operation */
            object result = new CallServices().CreateEntities(
                ActionTypes.Account, null, data);

            //Send result for Client
            return result;
        }

        /* PUT: api/ConnectXRM/UpdateAccount
        Receive Client Informations and then passes them to another method */
        [HttpPut("{UpdateAccount}")]
        public object PutAccount([FromBody] ReadData data)
        {
            /* Call the UpdateEntities method from the CallServices class to 
             * get the result of the Update operation */
            object result = new CallServices().UpdateEntities(
                ActionTypes.Account, data);

            //Send result for Client
            return result;
        }

        /* DELETE: api/ConnectXRM/DeleteAccount
        Receive Client Informations and then passes them to another method */
        [HttpDelete("{DeleteAccount}")]
        public object DeleteAccount([FromBody] ReadData data)
        {
            /* Call the DeleteEntities method from the CallServices class to 
             * get the result of the Delete operation */
            object result = new CallServices().DeleteEntities(ActionTypes.Account, data);

            //Send result for Client
            //Send result for Client
            string DeleteAccount = "Delete Contact Successful";
            return (result, DeleteAccount);
        }

        //-------------------Currency-----------------------//
        /* GET: api/ConnectCRM/GetCurrency
        Receive Client Informations and then passes them to another method */
        [HttpGet("{GetCurrency}")]
        public object GetCurrency(
            string username, string password, Guid id)
        {
            ReadData credentials = new ReadData()
            {
                UserName = username,
                Password = password,
                Id = id
            };

            /* Call the ReadEntities method from the CallServices class to 
             * get the result of the Read operation */
            object result = new CallServices().ReadEntities(ActionTypes.Currency, credentials);

            //Send result for Client
            return result;
        }

        /* POST: api/ConnectXRM/CreateCurrency
        Receive Client Informations and then passes them to another method */
        [HttpPost("{CreateCurrency}")]
        public object PostCurrency([FromBody] List<ReadData> data)
        {
            _logger.LogInformation("Start PostCurrency Method in ConnectXrmAPI Controller and" +
                " Get List Currency From SanaClient");

            try
            {
                /* Call the CreateEntities method from the CallServices class to 
             * get the result of the Create operation */
                object result = new CallServices().CreateEntities(
                    ActionTypes.Currency, data, null);

                _logger.LogWarning("Successfull Add Currency in XRM");
                //Send result for Client
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to Add Currency in XRM!!");
            }

            return "Failed to Add Currency in XRM and Failed to Read ConnectXRM Project!!";
        }

        /* PUT: api/ConnectXRM/UpdateCurrency
        Receive Client Informations and then passes them to another method */
        [HttpPut("{UpdateCurrency}")]
        public object PutCurrency([FromBody] ReadData data)
        {
            /* Call the UpdateEntities method from the CallServices class to 
             * get the result of the Update operation */
            object result = new CallServices().UpdateEntities(
                ActionTypes.Currency, data);

            //Send result for Client
            return result;
        }

        /* DELETE: api/ConnectXRM/DeleteCurrency
        Receive Client Informations and then passes them to another method */
        [HttpDelete("{DeleteCurrency}")]
        public object DeleteCurrency([FromBody] ReadData data)
        {
            /* Call the DeleteEntities method from the CallServices class to 
             * get the result of the Delete operation */
            object result = new CallServices().DeleteEntities(ActionTypes.Currency, data);

            //Send result for Client
            string DeleteCurrency = "Delete Contact Successful";
            return (result, DeleteCurrency);
        }
    }
}

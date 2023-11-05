using ConnectSRM.Models;
using ConnectSRM.Operations;
using System;
using System.Collections.Generic;
using System.Web.Http;
using static ConnectSRM.Operations.CRUD_SRM;

namespace ConnectXRM.Controllers
{
    public class ConnectSRMController : ApiController
    {
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
            object result = new CallServices_SRM().ReadEntities(ActionTypes.Currency, credentials);

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
            object result = new CallServices_SRM().CreateEntities(
                ActionTypes.Currency, data, null);

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
            object result = new CallServices_SRM().UpdateEntities(
                ActionTypes.Currency, data, currency);

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
            object result = new CallServices_SRM().DeleteEntities(ActionTypes.Currency, data);

            return result;
        }
    }
}

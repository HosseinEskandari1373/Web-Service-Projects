using CustomerSurvey.Data.Operations;
using CustomerSurvey.Models;
using CustomerSurvey.ReadForms;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CustomerSurvey.Controllers
{
    [Route("api/[action]/{controller}")]
    [ApiController]
    public class CustomerSurveyFormController : ControllerBase
    {
        // POST api/<CustomerSurveyForm>
        [HttpPost("CustomerSurvey")]
        public object GetFormCustomer()
        {
            object result = new AddDataForm().CreateForm();

            return result;
        }
    }
}

using EmailService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Threading.Tasks;

namespace SanaAPI.Controllers
{
    [Route("api/[action]/{controller}")]
    [ApiController]
    public class SanaAPIController : ControllerBase
    {
        private readonly IEmailSender _emailSender;
        private IConfiguration configuration;

        public SanaAPIController(IEmailSender emailSender)
        {
            _emailSender = emailSender;
            configuration = GetConfiguration();
        }

        public IConfigurationRoot GetConfiguration()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            return builder.Build();
        }

        // POST: api/<SanaAPIController>
        [HttpPost("{CreateCurrency}")]
        [Obsolete]
        public async Task<object> CreateSanaAPIAsync()
        {
            var ToEmail = configuration.GetSection("ContactEmails").GetSection("Eskandari").Value;
            var Cc0Email = configuration.GetSection("ContactEmails").GetSection("Eslami").Value;
            var Cc1Email = configuration.GetSection("ContactEmails").GetSection("Shahpari_Fard").Value;
            var ErrorMessageAPI = new Message(new string[] { ToEmail }, 
                                      new string[] { Cc0Email, Cc1Email },
                                      "StatusCode: 500(Server error responses)",
                                      "StatusCode(500, Server error responses(Web Service Connection Error!!)");
            var ErrorMessageConnectDB= new Message(new string[] { ToEmail },
                                      new string[] { Cc0Email, Cc1Email },
                                      "StatusCode: 503(Server error responses)",
                                      "StatusCode(503, Server error responses(Database Connection Error!!)");
            try
            {
                object result = new CreateCurrency().Create();

                if (result == null)
                {
                    await _emailSender.SendEmailAsync(ErrorMessageConnectDB);
                    return StatusCode(503, "Server error responses(Database Connection Error!!)");
                }
                else
                {
                    return result;
                }
            }
            catch (Exception)
            {
                await _emailSender.SendEmailAsync(ErrorMessageAPI);
                return StatusCode(500, "Server error responses(Web Service Connection Error!!)");
            }
        }

        // GET: api/<SanaAPIController>
        [HttpGet("{ReadCurrency}")]
        public object ReadSanaAPI(DateTime date)
        {
            try
            {
                ReadData readData = new ReadData()
                {
                    DateSubmitted = date
                };

                var result = new ReadCurrency().Read(readData);

                if (result != null)
                {
                    return result;
                }
                else
                {
                    return "Failed to Read READ Method && Not Exist Currency in DataBase!!";
                }
            }
            catch (Exception ex)
            {
                 return StatusCode(500, ex.Message);
            }
        }
    }
}

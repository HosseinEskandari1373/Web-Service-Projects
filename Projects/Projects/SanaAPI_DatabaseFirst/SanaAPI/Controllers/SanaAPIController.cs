using EmailService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SanaAPI.Controllers
{
    [Route("api/[action]/{controller}")]
    [ApiController]
    public class SanaAPIController : Controller
    {
        private readonly IEmailSender _emailSender;
        private IConfiguration configuration;
        private readonly ILogger<SanaAPIController> _logger;

        public SanaAPIController(IEmailSender emailSender, ILogger<SanaAPIController> logger)
        {
            _emailSender = emailSender;
            configuration = GetConfiguration();
            _logger = logger;
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
            var ErrorMessageConnectDB = new Message(new string[] { ToEmail },
                                      new string[] { Cc0Email, Cc1Email },
                                      "StatusCode: 503(Server error responses)",
                                      "StatusCode(503, Server error responses(Database Connection Error!!)");
            try
            {
                object result = new CreateCurrency().Create();

                if (result == null)
                {
                    _logger.LogError("StatusCode(503, Server error responses(Database Connection Error!!))");
                    try
                    {
                        await _emailSender.SendEmailAsync(ErrorMessageConnectDB);
                        return "StatusCode(503, Server error responses(Database Connection Error!!))";
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "Problem sending email for Database Connection Error!!");
                        throw;
                    }
                }
                else
                {
                    return result;
                }
            }
            catch (Exception)
            {
                _logger.LogError("StatusCode(500, Server error responses(Web Service Connection Error!!))");
                try
                {
                    await _emailSender.SendEmailAsync(ErrorMessageAPI);
                    return "StatusCode(500, Server error responses(Web Service Connection Error!!))";
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Problem sending email for Web Service Connection Error!!");
                    throw;
                }
            }
        }
    }
}

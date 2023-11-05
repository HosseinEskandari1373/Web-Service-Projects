using CustomerSurvey.Models;
using CustomerSurvey.Models.FormSettings;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace CustomerSurvey.ReadForm
{
    public class GetFormSettings
    {
        private IConfiguration configuration;

        public GetFormSettings()
        {
            configuration = GetConfiguration();
        }

        public IConfigurationRoot GetConfiguration()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            return builder.Build();
        }
        public List<FormSettings> GetFormSettingsAPI()
        {
            try
            {
                var Url = configuration.GetSection("AppSettings").GetSection("PorsLineURL").Value;
                var UrlResponse = configuration.GetSection("AppSettings").GetSection("PorsLineSettingsResponse").Value;
                var Token = configuration.GetSection("AppSettings").GetSection("PorsLineToken").Value;

                List<FormSettings> responseSettings = new List<FormSettings>();

                List<int> FormID = new List<int>
                {
                    301116, 296612, 279391, 280619
                };

                foreach (var item in FormID)
                {
                    WebRequest request = WebRequest.Create(Url + item + UrlResponse);
                    request.Method = "GET";
                    request.ContentType = "application/json";
                    request.Headers.Add("Authorization", "API-Key " + Token);

                    // Send Client information to the API and receive the response
                    var httpResponse = (HttpWebResponse)request.GetResponse();

                    //Get operation result from API
                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        string result = streamReader.ReadToEnd();

                        FormSettings CustomerSurvey = JsonConvert.DeserializeObject<FormSettings>(result);

                        responseSettings.Add(new FormSettings()
                        {
                            survey = CustomerSurvey.survey
                        });
                    }
                }

                return responseSettings;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

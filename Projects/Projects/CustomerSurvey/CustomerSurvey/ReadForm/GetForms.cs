using CustomerSurvey.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Net;
using System.Threading.Tasks;
using System.Text;

namespace CustomerSurvey.ReadForms
{
    public class GetForms
    {
        private IConfiguration configuration;

        public GetForms()
        {
            configuration = GetConfiguration();
        }

        public IConfigurationRoot GetConfiguration()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            return builder.Build();
        }
        public List<Response> GetAPI()
        {
            try
            {
                var Url = configuration.GetSection("AppSettings").GetSection("PorsLineURL").Value;
                var UrlResponse = configuration.GetSection("AppSettings").GetSection("PorsLineResponse").Value;
                var Token = configuration.GetSection("AppSettings").GetSection("PorsLineToken").Value;

                List<Response> response = new List<Response>();

                List<int> FormID = new List<int>
                {
                    301116, 296612, 279391, 280619
                };

                foreach (var item in FormID)
                {
                    WebRequest request = WebRequest.Create(Url + item + UrlResponse);
                    request.Method = "POST";
                    request.ContentType = "application/json";
                    request.Headers.Add("Authorization", "API-Key " + Token);

                    // Send Client information to the API and receive the response
                    var httpResponse = (HttpWebResponse)request.GetResponse();

                    //Get operation result from API
                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        string result = streamReader.ReadToEnd();

                        Response CustomerSurvey = JsonConvert.DeserializeObject<Response>(result);

                        response.Add(new Response()
                        {
                            body = CustomerSurvey.body,
                            header = CustomerSurvey.header,
                            len_responders = CustomerSurvey.len_responders
                        });
                    }
                }

                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

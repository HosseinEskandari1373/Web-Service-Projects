using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace SanaClient.Jobs.SanaAPI_Post_Recurring3H
{
    public class SanaAPI_Post_RecurringDaily:ISanaAPI_Post_RecurringDaily
    {
        private IConfiguration configuration;
        public SanaAPI_Post_RecurringDaily()
        {
            configuration = GetConfiguration();
        }

        public IConfigurationRoot GetConfiguration()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            return builder.Build();
        }
        public async Task<object> Create()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    //API URL
                    client.BaseAddress = new Uri(configuration.GetSection("AppSettings").GetSection("SanaApiUrl").Value);

                    //Send request to API
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));

                    //Send Client information to the API and receive the response
                    HttpResponseMessage response = await client.PostAsJsonAsync(
                        configuration.GetSection("AppSettings").GetSection("CreateUrlSanaAPI").Value, "");

                    //Get operation result from API
                    if (response.IsSuccessStatusCode)
                    {
                        //Get answers from the API
                        var contact = await response.Content.ReadAsStringAsync();
                        object JsonContact = JsonConvert.DeserializeObject(contact);

                        //Send result for Client
                        switch (JsonContact)
                        {
                            case null:
                                return HttpStatusCode.NotFound;
                            default:
                                return (HttpStatusCode.OK, JsonContact);
                        }
                    }
                    return null;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using SanaClient.Security;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace SanaClient.Jobs.ConnectXrmAPI_Inset_RecurringDaily
{
    public class ConnectXrmAPI_Inset_RecurringDaily : IConnectXrmAPI_Inset_RecurringDaily
    {
        private IConfiguration configuration;
        public ConnectXrmAPI_Inset_RecurringDaily()
        {
            configuration = GetConfiguration();
        }

        public IConfigurationRoot GetConfiguration()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            return builder.Build();
        }
        public async Task<object> Insert()
        {
            try
            {
                using (var clientSanaAPI = new HttpClient())
                {
                    //API URL
                    clientSanaAPI.BaseAddress = new Uri(configuration.GetSection("AppSettings").GetSection("SanaApiUrl").Value);

                    //Send request to API
                    clientSanaAPI.DefaultRequestHeaders.Accept.Clear();
                    clientSanaAPI.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));

                    //Get Informations Client and Send to API
                    HttpResponseMessage response = await clientSanaAPI.GetAsync(configuration.GetSection("AppSettings").GetSection("ReadUrlSanaAPI").Value +
                    "date=" + Utilities.DateSubmitted);

                    //Get operation result from API
                    if (response.IsSuccessStatusCode)
                    {
                        //Get answers from the API
                        string ReadCurrency = await response.Content.ReadAsStringAsync();

                        var JsonCurrency = JsonConvert.DeserializeObject<List<ReadData>>(ReadCurrency);

                        //Add Username and Password and Url to JsonCurrency Object
                        foreach (var item in JsonCurrency)
                        {
                            item.UserName = configuration.GetSection("AppSettings").GetSection("UserName").Value;
                            item.password = configuration.GetSection("AppSettings").GetSection("Password").Value;
                            item.Url = configuration.GetSection("AppSettings").GetSection("XRM_URL").Value;
                        }

                        using (var clientConnectXrmAPI = new HttpClient())
                        {
                            //API URL
                            clientConnectXrmAPI.BaseAddress = new Uri(configuration.GetSection("AppSettings").GetSection("ConnectXrmUrl").Value);

                            //Send request to API
                            clientConnectXrmAPI.DefaultRequestHeaders.Accept.Clear();
                            clientConnectXrmAPI.DefaultRequestHeaders.Accept.Add(
                                new MediaTypeWithQualityHeaderValue("application/json"));

                            //Send Client information to the API and receive the response
                            HttpResponseMessage responseConnectXrmAPI = await clientConnectXrmAPI.PostAsJsonAsync(
                                configuration.GetSection("AppSettings").GetSection("PostCurrencyConnectXrmAPI").Value, JsonCurrency);

                            //Get operation result from API
                            if (responseConnectXrmAPI.IsSuccessStatusCode)
                            {
                                //Get answers from the API
                                string result = await responseConnectXrmAPI.Content.ReadAsStringAsync();
                                object Jsonresult = JsonConvert.DeserializeObject(result);

                                //Send result for Client
                                switch (Jsonresult)
                                {
                                    case null:
                                        return HttpStatusCode.NotFound;
                                    default:
                                        return (HttpStatusCode.OK);
                                }
                            }
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

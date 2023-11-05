using ConnectXrmAPI.Dashboard;
using ConnectXrmAPI.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace ConnectXrmAPI.Services
{
    public class CRUD
    {
        public enum ActionTypes
        {
            Contact = 1,
            Account = 2,
            Currency = 3,
        }

        private readonly ILogger<CRUD> _logger;
        private IConfiguration configuration;
        public CRUD(ILogger<CRUD> logger)
        {
            configuration = GetConfiguration();
            _logger = logger;
        }

        public IConfigurationRoot GetConfiguration()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            return builder.Build();
        }

        public async Task<object> CreateContact(ReadData data)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    //API URL
                    client.BaseAddress = new Uri(configuration.
                        GetSection("AppSettings").GetSection("ConnectXRM_Url").Value);

                    //Send request to API
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));

                    ReadData credentials = new ReadData();

                    //Enter UserName by Client
                    credentials.UserName = data.UserName;

                    //Enter Password by Client
                    credentials.Password = data.Password;

                    //Enter FirstName by Client
                    credentials.FirstName = data.FirstName;

                    //Enter LastName by Client
                    credentials.LastName = data.LastName;

                    //Enter Email by Client
                    credentials.Email = data.Password;

                    //Get Url from appsettings
                    credentials.Url = Utilities.ServiceUrl;

                    //Send Client information to the API and receive the response
                    HttpResponseMessage response = await client.PostAsJsonAsync(
                        configuration.GetSection("AppSettings").
                        GetSection("CreateContact").Value, credentials);

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

        public async Task<object> ReadContact(ReadData data)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    //API URL
                    client.BaseAddress = new Uri(configuration.
                        GetSection("AppSettings").GetSection("ConnectXRM_Url").Value);

                    //Send request to API
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));

                    //Get Informations Client and Send to API
                    HttpResponseMessage response = await client.GetAsync(configuration.GetSection("AppSettings").
                        GetSection("ReadContact").Value +
                    "username=" + data.UserName + "&" +
                    "password=" + data.Password + "&" +
                    "url=" + Utilities.ServiceUrl + "&" +
                    "id=" + data.Id);

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


        public async Task<object> UpdateContact(ReadData data)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    //API URL
                    client.BaseAddress = new Uri(configuration.
                        GetSection("AppSettings").GetSection("ConnectXRM_Url").Value);

                    //Send request to API
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));
                    ReadData credentials = new ReadData();

                    //Enter UserName by Client
                    credentials.UserName = data.UserName;

                    //Enter Password by Client
                    credentials.Password = data.Password;

                    //Enter FirstName by Client
                    credentials.FirstName = data.FirstName;

                    //Enter LastName by Client
                    credentials.LastName = data.LastName;

                    //Enter Guid by Client
                    credentials.Id = data.Id;

                    //Get Url from appsettings
                    credentials.Url = Utilities.ServiceUrl;

                    //Send Client information to the API and receive the response
                    HttpResponseMessage response = await client.PutAsJsonAsync(
                        configuration.GetSection("AppSettings").
                        GetSection("UpdateContact").Value, credentials);

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

        public HttpResponseMessage DeleteContact(ReadData data)
        {
            try
            {
                //API URL
                var url = configuration.
                        GetSection("AppSettings").GetSection("DeleteContact").Value;

                //Send request to API
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "DELETE";

                //Send information to API
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    ReadData credentials = new ReadData();

                    //Enter UserName by Client
                    credentials.UserName = data.UserName;

                    //Enter Password by Client
                    credentials.Password = data.Password;

                    //Enter Guid by Client
                    credentials.Id = data.Id;

                    //Get Url from appsettings
                    credentials.Url = Utilities.ServiceUrl;

                    //Convert information to JSON
                    string JsonContact = JsonSerializer.Serialize(credentials);
                    streamWriter.Write(JsonContact);
                }

                //Send Client information to the API and receive the response
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

                //Get operation result from API
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    //Get answers from the API
                    var contact = streamReader.ReadToEnd();

                    //Send result for Client
                    switch (contact)
                    {
                        case null:
                            return new HttpResponseMessage(HttpStatusCode.NotFound);
                        default:
                            return new HttpResponseMessage(HttpStatusCode.OK);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        //-------------------Account-----------------------//
        public async Task<object> CreateAccount(ReadData data)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    //API URL
                    client.BaseAddress = new Uri(configuration.
                        GetSection("AppSettings").GetSection("ConnectXRM_Url").Value);

                    //Send request to API
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));
                    ReadData credentials = new ReadData();

                    //Enter UserName by Client
                    credentials.UserName = data.UserName;

                    //Enter Password by Client
                    credentials.Password = data.Password;

                    //Enter FirstName by Client
                    credentials.Name = data.Name;

                    //Enter LastName by Client
                    credentials.Phone = data.Phone;

                    //Enter Email by Client
                    credentials.Address = data.Address;

                    //Get Url from appsettings
                    credentials.Url = Utilities.ServiceUrl;

                    //Send Client information to the API and receive the response
                    HttpResponseMessage response = await client.PostAsJsonAsync(
                    configuration.GetSection("AppSettings").
                        GetSection("CreateAccount").Value, credentials);

                    //Get operation result from API
                    if (response.IsSuccessStatusCode)
                    {
                        //Get answers from the API
                        var account = await response.Content.ReadAsStringAsync();
                        object JsonAccount = JsonConvert.DeserializeObject(account);

                        //Send result for Client
                        switch (JsonAccount)
                        {
                            case null:
                                return HttpStatusCode.NotFound;
                            default:
                                return (HttpStatusCode.OK, JsonAccount);
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

        public async Task<object> ReadAccount(ReadData data)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    //API URL
                    client.BaseAddress = new Uri(configuration.
                        GetSection("AppSettings").GetSection("ConnectXRM_Url").Value);

                    //Send request to API
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));

                    Console.WriteLine("\n" + "GET" + "\n");

                    //Get Informations Client and Send to API
                    Console.WriteLine("Please enter your username, password and ID:");
                    HttpResponseMessage response = await client.GetAsync(configuration.GetSection("AppSettings").
                        GetSection("ReadAccount").Value +
                        "username=" + data.UserName + "&" +
                        "password=" + data.Password + "&" +
                        "url=" + Utilities.ServiceUrl + "&" +
                        "id=" + data.Id);

                    //Get operation result from API
                    if (response.IsSuccessStatusCode)
                    {
                        //Get answers from the API
                        var account = await response.Content.ReadAsStringAsync();
                        object JsonAccount = JsonConvert.DeserializeObject(account);

                        //Send result for Client
                        switch (JsonAccount)
                        {
                            case null:
                                return HttpStatusCode.NotFound;
                            default:
                                return (HttpStatusCode.OK, JsonAccount);
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

        public async Task<object> UpdateAccount(ReadData data)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    //API URL
                    client.BaseAddress = new Uri(configuration.
                        GetSection("AppSettings").GetSection("ConnectXRM_Url").Value);

                    //Send request to API
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));

                    ReadData credentials = new ReadData();

                    //Enter UserName by Client
                    credentials.UserName = data.UserName;

                    //Enter Password by Client
                    credentials.Password = data.Password;

                    //Enter FirstName by Client
                    credentials.Name = data.Name;

                    //Enter LastName by Client
                    credentials.Phone = data.Phone;

                    //Enter Guid by Client
                    credentials.Id = data.Id;

                    //Get Url from appsettings
                    credentials.Url = Utilities.ServiceUrl;

                    // Send Client information to the API and receive the response 
                    HttpResponseMessage response = await client.PutAsJsonAsync(
                        configuration.GetSection("AppSettings").
                        GetSection("UpdateAccount").Value, credentials);

                    //Get operation result from API
                    if (response.IsSuccessStatusCode)
                    {
                        //Get answers from the API
                        var account = await response.Content.ReadAsStringAsync();
                        object JsonAccount = JsonConvert.DeserializeObject(account);

                        //Send result for Client
                        switch (JsonAccount)
                        {
                            case null:
                                return HttpStatusCode.NotFound;
                            default:
                                return (HttpStatusCode.OK, JsonAccount);
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

        public HttpResponseMessage DeleteAccount(ReadData data)
        {
            try
            {
                //API URL
                var url = configuration.
                        GetSection("AppSettings").GetSection("DeleteAccount").Value;

                //Send request to API
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "DELETE";

                //Send information to API
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    ReadData credentials = new ReadData();

                    //Enter UserName by Client
                    credentials.UserName = data.UserName;

                    //Enter Password by Client
                    credentials.Password = data.Password;

                    //Enter Guid by Client
                    credentials.Id = data.Id;

                    //Get Url from appsettings
                    credentials.Url = Utilities.ServiceUrl;

                    //Convert information to JSON
                    string jsonAccount = JsonSerializer.Serialize(credentials);
                    streamWriter.Write(jsonAccount);
                }

                //Send Client information to the API and receive the response
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

                //Get operation result from API
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    //Get answers from the API
                    string account = streamReader.ReadToEnd();

                    //Send result for Client
                    switch (account)
                    {
                        case null:
                            return new HttpResponseMessage(HttpStatusCode.NotFound);
                        default:
                            return new HttpResponseMessage(HttpStatusCode.OK);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        //-------------------Currency-----------------------//
        public async Task<object> CreateCurrency(List<ReadData> data)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    if (data[0].Url_IS == "Test")
                    {
                        //API URL
                        client.BaseAddress = new Uri(configuration.
                            GetSection("AppSettings").GetSection("ConnectXRMUrl").Value);

                        //Send request to API
                        client.DefaultRequestHeaders.Accept.Clear();
                        client.DefaultRequestHeaders.Accept.Add(
                            new MediaTypeWithQualityHeaderValue("application/json"));

                        //Send Client information to the API and receive the response
                        HttpResponseMessage response = await client.PostAsJsonAsync(
                        configuration.GetSection("AppSettings").
                            GetSection("CreateCurrency").Value, data);

                        //Get operation result from API
                        if (response.IsSuccessStatusCode)
                        {
                            //Get answers from the API
                            var currency = await response.Content.ReadAsStringAsync();
                            object JsonCurrency = JsonConvert.DeserializeObject(currency);

                            //Send result for Client
                            switch (JsonCurrency)
                            {
                                case null:
                                    return (HttpStatusCode.NotFound, "Failed to Add Currency in XRM");
                                default:
                                    return (HttpStatusCode.OK, JsonCurrency);
                            }
                        }
                    }
                    else if (data[0].Url_IS == "SRM")
                    {
                        //API URL
                        client.BaseAddress = new Uri(configuration.
                            GetSection("AppSettings").GetSection("ConnectSRMUrl").Value);

                        //Send request to API
                        client.DefaultRequestHeaders.Accept.Clear();
                        client.DefaultRequestHeaders.Accept.Add(
                            new MediaTypeWithQualityHeaderValue("application/json"));

                        //Send Client information to the API and receive the response
                        HttpResponseMessage response = await client.PostAsJsonAsync(
                        configuration.GetSection("AppSettings").
                            GetSection("CreateCurrencySRM").Value, data);

                        //Get operation result from API
                        if (response.IsSuccessStatusCode)
                        {
                            //Get answers from the API
                            var currency = await response.Content.ReadAsStringAsync();
                            object JsonCurrency = JsonConvert.DeserializeObject(currency);

                            //Send result for Client
                            switch (JsonCurrency)
                            {
                                case null:
                                    return HttpStatusCode.NotFound;
                                default:
                                    return (HttpStatusCode.OK, JsonCurrency);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to Read READ Method From ConnectXRM!!");
            }

            return "Failed to Read READ Method From ConnectXRM!!";
        }

        public async Task<object> ReadCurrency(ReadData data)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    //API URL
                    client.BaseAddress = new Uri(configuration.
                        GetSection("AppSettings").GetSection("ConnectXRM_Url").Value);

                    //Send request to API
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));

                    Console.WriteLine("\n" + "GET" + "\n");

                    //Get Informations Client and Send to API
                    Console.WriteLine("Please enter your username, password and ID:");
                    HttpResponseMessage response = await client.GetAsync(configuration.GetSection("AppSettings").
                        GetSection("ReadCurrency").Value +
                    "username=" + data.UserName + "&" +
                    "password=" + data.Password + "&" +
                    "url=" + Utilities.ServiceUrl + "&" +
                    "id=" + data.Id);

                    //Get operation result from API
                    if (response.IsSuccessStatusCode)
                    {
                        //Get answers from the API
                        var currency = await response.Content.ReadAsStringAsync();
                        object JsonCurrency = JsonConvert.DeserializeObject(currency);

                        //Send result for Client
                        switch (JsonCurrency)
                        {
                            case null:
                                return HttpStatusCode.NotFound;
                            default:
                                return (HttpStatusCode.OK, JsonCurrency);
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

        public async Task<object> UpdateCurrency(ReadData data)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    //API URL
                    client.BaseAddress = new Uri(configuration.
                        GetSection("AppSettings").GetSection("ConnectXRM_Url").Value);

                    //Send request to API
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));

                    ReadData credentials = new ReadData();

                    //Enter UserName by Client
                    credentials.UserName = data.UserName;

                    //Enter Password by Client
                    credentials.Password = data.Password;

                    //Enter DateSubmitted by Client
                    credentials.DateSubmitted = data.DateSubmitted;

                    //Enter SiteDate by Client
                    credentials.SiteDate = data.SiteDate;

                    //Enter Guid by Client
                    credentials.Id = data.Id;

                    //Get Url from appsettings
                    credentials.Url = Utilities.ServiceUrl;

                    // Send Client information to the API and receive the response 
                    HttpResponseMessage response = await client.PutAsJsonAsync(
                        configuration.GetSection("AppSettings").
                        GetSection("UpdateCurrency").Value, credentials);

                    //Get operation result from API
                    if (response.IsSuccessStatusCode)
                    {
                        //Get answers from the API
                        var currency = await response.Content.ReadAsStringAsync();
                        object JsonCurrency = JsonConvert.DeserializeObject(currency);

                        //Send result for Client
                        switch (JsonCurrency)
                        {
                            case null:
                                return HttpStatusCode.NotFound;
                            default:
                                return (HttpStatusCode.OK, JsonCurrency);
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

        public HttpResponseMessage DeleteCurrency(ReadData data)
        {
            try
            {
                //API URL
                var url = configuration.
                        GetSection("AppSettings").GetSection("DeleteCurrency").Value;

                //Send request to API
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "DELETE";

                //Send information to API
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    ReadData credentials = new ReadData();

                    //Enter UserName by Client
                    credentials.UserName = data.UserName;

                    //Enter Password by Client
                    credentials.Password = data.Password;

                    //Enter Guid by Client
                    credentials.Id = data.Id;

                    //Get Url from appsettings
                    credentials.Url = Utilities.ServiceUrl;

                    //Convert information to JSON
                    string JsonCurrency = JsonSerializer.Serialize(credentials);
                    streamWriter.Write(JsonCurrency);
                }

                //Send Client information to the API and receive the response
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

                //Get operation result from API
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    //Get answers from the API
                    string currency = streamReader.ReadToEnd();

                    //Send result for Client
                    switch (currency)
                    {
                        case null:
                            return new HttpResponseMessage(HttpStatusCode.NotFound);
                        default:
                            return new HttpResponseMessage(HttpStatusCode.OK);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

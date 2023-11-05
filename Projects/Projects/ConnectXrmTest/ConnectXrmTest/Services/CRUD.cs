using System;
using System.Net;
using System.Threading.Tasks;
using System.IO;
using JsonSerializer = System.Text.Json.JsonSerializer;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Configuration;

namespace ConnectXRM_Test.Services
{
    public class CRUD
    {
        //-------------------Contact-----------------------//
        public static async Task CreateContact()
        {
            using (var client = new HttpClient())
            {
                //API URL
                client.BaseAddress = new Uri("http://localhost:57849/");

                //Send request to API
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                Console.WriteLine("\n" + "POST" + "\n");

                GetData credentials = new GetData();

                //Enter UserName by Client
                Console.WriteLine("\n" + "Please Enter Your UserName:");
                credentials.UserName = Console.ReadLine();

                //Enter Password by Client
                Console.WriteLine("\n" + "Please Enter Your Password:");
                credentials.Password = Console.ReadLine();

                //Enter FirstName by Client
                Console.WriteLine("\n" + "Please Enter Your FirstName:");
                credentials.FirstName = Console.ReadLine();

                //Enter LastName by Client
                Console.WriteLine("\n" + "Please Enter Your LastName:");
                credentials.LastName = Console.ReadLine();

                //Enter FirstName by Client
                Console.WriteLine("\n" + "Please Enter Your Email:");
                credentials.Email = Console.ReadLine();

                //Get Url from appsettings
                credentials.Url = ConfigurationManager.AppSettings["url"];

                //Send Client information to the API and receive the response
                HttpResponseMessage response = await client.PostAsJsonAsync(
                    "api/connectxrm/CreateContact", credentials);

                //Get operation result from API
                if (response.IsSuccessStatusCode)
                {
                    var contact = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("\n" + contact);
                    Console.ReadKey();
                }
            }
        }

        public static async Task ReadContact()
        {
            using (var client = new HttpClient())
            {
                //API URL
                client.BaseAddress = new Uri("http://localhost:57849/");

                //Send request to API
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                Console.WriteLine("\n" + "GET" + "\n");

                //Get Informations Client and Send to API
                Console.WriteLine("Please enter your username, password and ID:");
                HttpResponseMessage response = await client.GetAsync("api/connectxrm/GetContact?" +
                    "username=" + Console.ReadLine() + "&" +
                    "password=" + Console.ReadLine() + "&" +
                    "url=" + ConfigurationManager.AppSettings["url"] + "&" +
                    "id=" + Console.ReadLine());

                //Get operation result from API
                if (response.IsSuccessStatusCode)
                {
                    var contact = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("\n" + contact);
                    Console.ReadKey();
                }
            }
        }

        public static async Task UpdateContact()
        {
            using (var client = new HttpClient())
            {
                //API URL
                client.BaseAddress = new Uri("http://localhost:57849/");

                //Send request to API
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                Console.WriteLine("\n" + "PUT" + "\n");

                GetData credentials = new GetData();

                //Enter UserName by Client
                Console.WriteLine("\n" + "Please Enter Your UserName:");
                credentials.UserName = Console.ReadLine();

                //Enter Password by Client
                Console.WriteLine("\n" + "Please Enter Your Password:");
                credentials.Password = Console.ReadLine();

                //Enter Guid by Client
                Console.WriteLine("\n" + "Please Enter Your Id:");
                credentials.Id = new Guid(Console.ReadLine());

                //Enter FirstName by Client
                Console.WriteLine("\n" + "Please Enter Your New FirstName:");
                credentials.FirstName = Console.ReadLine();

                //Enter LastName by Client
                Console.WriteLine("\n" + "Please Enter Your New LastName:");
                credentials.LastName = Console.ReadLine();


                //Get Url from appsettings
                credentials.Url = ConfigurationManager.AppSettings["url"];

                //Send Client information to the API and receive the response
                HttpResponseMessage response = await client.PutAsJsonAsync(
                    "api/connectxrm/UpdateContact", credentials);

                //Get operation result from API
                if (response.IsSuccessStatusCode)
                {
                    var contact = await response.Content.ReadAsStringAsync();

                    Console.WriteLine("\n" + contact);
                    Console.ReadKey();
                }
            }
        }

        public static void DeleteContact()
        {
            //API URL
            var url = "http://localhost:57849/api/connectxrm/DeleteContact";

            //Send request to API
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "DELETE";

            Console.WriteLine("\n" + "DELETE" + "\n");

            //Send information to API
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                GetData credentials = new GetData();

                //Enter UserName by Client
                Console.WriteLine("\n" + "Please Enter Your UserName:");
                credentials.UserName = Console.ReadLine();

                //Enter Password by Client
                Console.WriteLine("\n" + "Please Enter Your Password:");
                credentials.Password = Console.ReadLine();

                //Enter Guid by Client
                Console.WriteLine("\n" + "Please Enter Your Id:");
                credentials.Id = new Guid(Console.ReadLine());

                //Get Url from appsettings
                credentials.Url = ConfigurationManager.AppSettings["url"];

                //Convert information to JSON
                string json = JsonSerializer.Serialize(credentials);
                streamWriter.Write(json);
            }

            //Send Client information to the API and receive the response
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

            //Get operation result from API
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var contact = streamReader.ReadToEnd();

                Console.WriteLine("\n" + contact);
                Console.ReadKey();
            }
        }

        //-------------------Account-----------------------//
        public static async Task CreateAccount()
        {
            using (var client = new HttpClient())
            {
                //API URL
                client.BaseAddress = new Uri("http://localhost:57849/");

                //Send request to API
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                Console.WriteLine("\n" + "POST" + "\n");

                GetData credentials = new GetData();

                //Enter UserName by Client
                Console.WriteLine("\n" + "Please Enter Your UserName:");
                credentials.UserName = Console.ReadLine();

                //Enter Password by Client
                Console.WriteLine("\n" + "Please Enter Your Password:");
                credentials.Password = Console.ReadLine();


                //Enter Name by Client
                Console.WriteLine("\n" + "Please Enter Your Name:");
                credentials.Name = Console.ReadLine();

                //Enter Phone by Client
                Console.WriteLine("\n" + "Please Enter Your Phone:");
                credentials.Phone = Console.ReadLine();

                //Enter Address by Client
                Console.WriteLine("\n" + "Please Enter Your Address:");
                credentials.Address = Console.ReadLine();

                //Get Url from appsettings
                credentials.Url = ConfigurationManager.AppSettings["url"];

                //Send Client information to the API and receive the response
                HttpResponseMessage response = await client.PostAsJsonAsync(
                    "api/connectxrm/CreateAccount", credentials);

                //Get operation result from API
                if (response.IsSuccessStatusCode)
                {
                    var account = await response.Content.ReadAsStringAsync();

                    Console.WriteLine("\n" + account);
                    Console.ReadKey();
                }
            }
        }

        public static async Task ReadAccount()
        {
            using (var client = new HttpClient())
            {
                //API URL
                client.BaseAddress = new Uri("http://localhost:57849/");

                //Send request to API
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                Console.WriteLine("\n" + "GET" + "\n");

                //Get Informations Client and Send to API
                Console.WriteLine("Please enter your username, password and ID:");
                HttpResponseMessage response = await client.GetAsync("api/connectxrm/GetAccount?" +
                    "username=" + Console.ReadLine() + "&" +
                    "password=" + Console.ReadLine() + "&" +
                    "url=" + ConfigurationManager.AppSettings["url"] + "&" +
                    "id=" + Console.ReadLine());

                //Get operation result from API
                if (response.IsSuccessStatusCode)
                {
                    var account = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("\n" + account);
                    Console.ReadKey();
                }
            }
        }

        public static async Task UpdateAccount()
        {
            using (var client = new HttpClient())
            {
                //API URL
                client.BaseAddress = new Uri("http://localhost:57849/");

                //Send request to API
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                Console.WriteLine("\n" + "PUT" + "\n");

                GetData credentials = new GetData();

                //Enter UserName by Client
                Console.WriteLine("\n" + "Please Enter Your UserName:");
                credentials.UserName = Console.ReadLine();

                //Enter Password by Client
                Console.WriteLine("\n" + "Please Enter Your Password:");
                credentials.Password = Console.ReadLine();

                //Enter Guid by Client
                Console.WriteLine("\n" + "Please Enter Your Id:");
                credentials.Id = new Guid(Console.ReadLine());

                //Enter Name by Client
                Console.WriteLine("\n" + "Please Enter Your New Name:");
                credentials.Name = Console.ReadLine();

                //Enter Phone by Client
                Console.WriteLine("\n" + "Please Enter Your New Phone:");
                credentials.Phone = Console.ReadLine();

                //Get Url from appsettings
                credentials.Url = ConfigurationManager.AppSettings["url"];

                //Send Client information to the API and receive the response
                HttpResponseMessage response = await client.PutAsJsonAsync(
                    "api/connectxrm/UpdateAccount", credentials);

                //Get operation result from API
                if (response.IsSuccessStatusCode)
                {
                    var contact = await response.Content.ReadAsStringAsync();

                    Console.WriteLine("\n" + contact);
                    Console.ReadKey();
                }
            }
        }

        public static void DeleteAccount()
        {
            //API URL
            var url = "http://localhost:57849/api/connectxrm/DeleteAccount";

            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);

            //Send request to API
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "DELETE";

            Console.WriteLine("\n" + "DELETE" + "\n");

            //Send information to API
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                GetData credentials = new GetData();

                //Enter UserName by Client
                Console.WriteLine("\n" + "Please Enter Your UserName:");
                credentials.UserName = Console.ReadLine();

                //Enter Password by Client
                Console.WriteLine("\n" + "Please Enter Your Password:");
                credentials.Password = Console.ReadLine();

                //Enter Guid by Client
                Console.WriteLine("\n" + "Please Enter Your Id:");
                credentials.Id = new Guid(Console.ReadLine());

                //Get Url from appsettings
                credentials.Url = ConfigurationManager.AppSettings["url"];

                //Convert information to JSON
                string json = JsonSerializer.Serialize(credentials);
                streamWriter.Write(json);
            }

            //Send Client information to the API and receive the response
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

            //Get operation result from API
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var account = streamReader.ReadToEnd();

                Console.WriteLine("\n" + account);
                Console.ReadKey();
            }
        }
    }
}

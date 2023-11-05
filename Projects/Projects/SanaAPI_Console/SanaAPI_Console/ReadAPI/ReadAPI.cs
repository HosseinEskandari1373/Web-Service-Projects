using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SanaAPI
{
    public class ReadAPI
    {
        public static SanaAPI GetAPI()
        {
            //Read API
            string Url = "https://api.accessban.com/v1/data/sana/json";

            HttpClient Client = new HttpClient();

            //Convert Json(API) to Object
            string result = Client.GetStringAsync(Url).Result;
            SanaAPI currency = JsonConvert.DeserializeObject<SanaAPI>(result);

            return currency;
        }
    }
}

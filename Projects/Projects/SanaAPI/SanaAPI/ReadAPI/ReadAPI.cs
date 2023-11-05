using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;

namespace SanaAPI
{
    public class ReadAPI
    {
        private IConfiguration configuration;

        public ReadAPI()
        {
            configuration = GetConfiguration();
        }
        public IConfigurationRoot GetConfiguration()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            return builder.Build();
        }

        public List<ReadData> GetAPI()
        {
            try
            {
                var Url = configuration.GetSection("AppSettings").GetSection("ApiUrl").Value;
                var Token = configuration.GetSection("AppSettings").GetSection("Token").Value;

                HttpClient Client = new HttpClient();
                Client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Token);

                //Convert Json(API) to Object
                string result = Client.GetStringAsync(Url).Result;

                SanaAPI currency = JsonConvert.DeserializeObject<SanaAPI>(result);

                List<int> Ids = new List<int>
            {
                137292, 137308, 523799, 523764, 137253,
                137291, 137307, 523801, 523800, 137252,
                137298, 137314, 523813, 523812, 137276,
                137302, 137318, 523821, 523820, 137262,
                137305, 137321, 523827, 523826, 137270,
                137293, 137309, 523803, 523802
            };

                List<ReadData> readCurrency = currency.data.Where(i => Ids.Contains(i.id))
                    .Select(res => new ReadData()
                    {
                        Price = Convert.ToDecimal(res.p),
                        SiteDate = DateTime.Parse(res.updated_at),
                        CurrencyName = res.title,
                        CurrencyType = res.slug,
                        PriceType = res.slug
                    }).ToList();

                return readCurrency;
            }
            catch (Exception)
            {
                throw new Exception("Web Service Connection Error!");
            }
        }
    }
}

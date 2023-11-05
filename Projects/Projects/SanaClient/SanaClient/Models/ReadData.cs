using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class ReadData
    {
        public DateTime SiteDate { get; set; }
        public DateTime DateSubmitted { get; set; }
        public string CurrencyName { get; set; }
        public string CurrencyType { get; set; }
        public string PriceType { get; set; }
        public decimal Price { get; set; }

        //UserName
        public string UserName { get; set; }
        public string password { get; set; }
        public string Url { get; set; }

        ////Password
        //public string Password = "hh24132413HH";

        ////the URL address for OrganizationService
        //public string Url =
        //    "http://crm2016.sdp.com/Test/XRMServices/2011/Organization.svc";

        public List<ReadData> JsonReadCurrencies { get; set; }
    }
}

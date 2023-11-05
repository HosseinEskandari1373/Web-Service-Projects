using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConnectSRM.Models
{
    public class ReadData
    {
        /*Credentials*/
        public string Url { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public Guid Id { get; set; }

        /*Currency*/
        public DateTime SiteDate { get; set; }
        public DateTime DateSubmitted { get; set; }
        public string CurrencyName { get; set; }
        public string CurrencyType { get; set; }
        public string PriceType { get; set; }
        public decimal Price { get; set; }

        public List<ReadData> readData { get; set; } = new List<ReadData>();
    }
}
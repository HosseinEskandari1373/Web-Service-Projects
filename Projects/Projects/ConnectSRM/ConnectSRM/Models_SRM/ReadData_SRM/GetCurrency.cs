using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConnectSRM.Models
{
    public class GetCurrency
    {
        public DateTime SiteDate { get; set; }
        public DateTime DateSubmitted { get; set; }
        public decimal Price { get; set; }
        public string CurrencyName { get; set; }
        public string CurrencyType { get; set; }
        public string CurrencyPrice { get; set; }

        public List<GetCurrency> readCurrency { get; } = new List<GetCurrency>();

        public GetCurrency getCurrency { get; set; }
    }
}
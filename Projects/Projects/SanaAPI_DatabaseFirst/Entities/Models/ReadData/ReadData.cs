using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SanaAPI
{
    public class ReadData
    {
        public DateTime SiteDate { get; set; }
        public DateTime DateSubmitted { get; set; }
        public string CurrencyName { get; set; }
        public string CurrencyType { get; set; }
        public string PriceType  { get; set; }
        public decimal Price  { get; set; }
    }
}

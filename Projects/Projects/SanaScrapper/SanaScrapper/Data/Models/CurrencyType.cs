using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebScrappingHtmlPage
{
    public class CurrencyType
    {
        public int TypeId { get; set; }
        public string TypeCurrency { get; set; }
        public string PriceType { get; set; }
    }
}

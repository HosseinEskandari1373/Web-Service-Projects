using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SanaAPI
{
    public class CurrencyType
    {
        public int TypeId { get; set; }
        public string TypeCurrency { get; set; }
        public string PriceType { get; set; }
    }
}

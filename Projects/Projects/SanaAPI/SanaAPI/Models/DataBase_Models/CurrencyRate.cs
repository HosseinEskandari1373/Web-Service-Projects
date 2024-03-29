﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SanaAPI
{
    public class CurrencyRate
    {
        [Column(TypeName = "datetime2(0)")]
        public DateTime SiteDate { get; set; }

        [Column(TypeName = "datetime2(0)")]
        public DateTime DateSubmitted { get; set; }

        public decimal Price { get; set; }

        //Specify the foreign key
        [ForeignKey("Currency")]
        public int CurrencyId { get; set; }
        public virtual Currency Currency { get; set; }

        [ForeignKey("CurrencyType")]
        public int TypeId { get; set; }
        public virtual CurrencyType CurrencyType { get; set; }
    }
}

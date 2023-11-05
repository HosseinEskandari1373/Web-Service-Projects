using System;
using System.Collections.Generic;
using System.Text;

namespace SanaAPI
{
    public class SanaAPI
    {
        public int id { get; set; }
        public string title { get; set; }
        public string slug { get; set; }
        public string p { get; set; }
        public string updated_at { get; set; }

        public List<SanaAPI> data { get; set; }
    }
}

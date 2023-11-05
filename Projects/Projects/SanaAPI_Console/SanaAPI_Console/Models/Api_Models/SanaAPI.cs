using System;
using System.Collections.Generic;
using System.Text;

namespace SanaAPI
{
    public class SanaAPI
    {
        public string title { get; set; }
        public string slug { get; set; }
        public int p { get; set; }
        public string updated_at { get; set; }

        public List<SanaAPI> data { get; set; }

        public SanaAPI sana { get; set; }
    }
}

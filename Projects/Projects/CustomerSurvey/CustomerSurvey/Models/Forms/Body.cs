using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerSurvey.Models
{
    public class Body
    {
        public int rid { get; set; }
        public List<string> data { get; set; }
        public string review_link { get; set; }
    }
}

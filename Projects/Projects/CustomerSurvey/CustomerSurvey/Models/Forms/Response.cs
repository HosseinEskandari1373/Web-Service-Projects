using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerSurvey.Models
{
    public class Response
    {
        public List<Header> header { get; set; }
        public List<Body> body { get; set; }
        public int len_responders { get; set; }
    }
}

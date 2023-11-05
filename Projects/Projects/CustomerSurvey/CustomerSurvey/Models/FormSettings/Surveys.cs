using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerSurvey.Models.FormSettings
{
    public class Surveys
    {
        public int id { get; set; }
        public string name { get; set; }
        public bool is_stopped { get; set; }
        public bool is_not_started { get; set; }
        public int language { get; set; }
        public object stop_date_time { get; set; }
        public object start_date_time { get; set; }
    }
}

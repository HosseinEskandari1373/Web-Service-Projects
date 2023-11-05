using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerSurvey.Models
{
    public class Header
    {
        public int id { get; set; }
        public string title { get; set; }
        public int col_type { get; set; }
        public string cell_type { get; set; }
        public object related_group { get; set; }
        public bool show { get; set; }
        public int? qtype { get; set; }
        public int? answer_type { get; set; }
        public object related_group_id { get; set; }
        public object related_group_question_number_is_hidden { get; set; }
        public bool? question_number_is_hidden { get; set; }
    }
}

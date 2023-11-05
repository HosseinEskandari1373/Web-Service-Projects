using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerSurvey.Models.Database
{
    public class Survey
    {
        public int SurveyID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateSubmitted { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Organization { get; set; }
        public bool IsActive { get; set; }
    }
}

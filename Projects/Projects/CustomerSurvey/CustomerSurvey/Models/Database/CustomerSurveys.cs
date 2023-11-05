using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerSurvey.Models.Database
{
    public class CustomerSurveys
    {
        public string UniqueURL { get; set; }
        public bool SurveyNotificationDelivered { get; set; }
        public bool IsSurveyCompleted { get; set; }

        //Specify the foreign key
        [ForeignKey("Customer")]
        public int CustomerID { get; set; }
        public virtual Customer Customer { get; set; }

        //Specify the foreign key
        [ForeignKey("Survey")]
        public int SurveyID { get; set; }
        public virtual Survey Survey { get; set; }
    }
}

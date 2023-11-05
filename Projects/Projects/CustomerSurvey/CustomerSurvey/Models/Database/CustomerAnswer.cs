using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerSurvey.Models.Database
{
    public class CustomerAnswer
    {
        public int CustomerAnswers { get; set; }

        //Specify the foreign key
        [ForeignKey("Customer")]
        public int CustomerID { get; set; }
        public virtual Customer Customer { get; set; }

        //Specify the foreign key
        [ForeignKey("Answer")]
        public int AnswerID { get; set; }
        public virtual Answer Answer { get; set; }

        public string Response { get; set; }
    }
}

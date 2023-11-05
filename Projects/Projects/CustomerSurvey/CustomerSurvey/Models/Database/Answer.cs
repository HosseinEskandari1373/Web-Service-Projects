using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerSurvey.Models.Database
{
    public class Answer
    {
        public int AnswerID { get; set; }

        //Specify the foreign key
        [ForeignKey("Question")]
        public int OuestionID { get; set; }
        public virtual Question Question { get; set; }

        public string Answers { get; set; }
    }
}

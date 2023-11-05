using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerSurvey.Models.Database
{
    public class Question
    {
        public int QuestionID { get; set; }

        //Specify the foreign key
        [ForeignKey("Survey")]
        public int SurveyID { get; set; }
        public virtual Survey Survey { get; set; }

        public string QuestionCategory { get; set; }
        public string QuestionType { get; set; }
        public string QuestionText { get; set; }
    }
}

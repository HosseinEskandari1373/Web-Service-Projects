
using CustomerSurvey.Models;
using CustomerSurvey.Models.FormSettings;
using CustomerSurvey.ReadForm;
using CustomerSurvey.ReadForms;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerSurvey.Data.Operations
{
    public class AddDataForm
    {
        public object CreateForm()
        {
            try
            {
                //Calling from the array of FormData
                List<Response> CreateSurvey = new GetForms().GetAPI();
                List<FormSettings> CreateSurveySettings = new GetFormSettings().GetFormSettingsAPI();

                DateTime DateSubmitted = DateTime.Now;

                using (var db = new CustomeSurveyContext())
                {
                    db.Database.Migrate();

                    for (int i = 0; i < CreateSurvey.Count; i++)
                    {
                        //db.CustomerSurveys.AddRange(
                        //new CustomerSurveys
                        //{
                        //    //CustomerSurveyID = CreateSurvey[i].header[i].id,
                        //    DateSubmitted = DateSubmitted
                        //});

                        //db.SaveChanges();
                    }

                    return CreateSurvey;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

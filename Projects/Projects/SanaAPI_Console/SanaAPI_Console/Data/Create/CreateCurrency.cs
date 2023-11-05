using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanaAPI
{
    public class CreateCurrency
    {
        public static void Create()
        {
            //Calling from the array of currencyRate
            var currencyRates = ListCurrencyRate.ListCurrency();

            //Add values to the database
            try
            {
                using (var db = new CurrencyContext())
                {
                    //Condition for editing non-duplicate records in the database
                    for (int i = 0; i < currencyRates.Length; i++)
                    {
                        //Specify whether or not a record exists in the database (avoid adding duplicate values)
                        bool exists = db.CurrencyRates.Any(
                            s => s.SiteDate == currencyRates[i].SiteDate &&
                            s.CurrencyId == currencyRates[i].CurrencyId &&
                            s.TypeId == currencyRates[i].TypeId);

                        //Condition to add a record if that record does not exist in the database
                        if (exists == false)
                        {
                            Console.WriteLine("Insert a New Record CurrencyRate");
                            db.CurrencyRates.AddRange(
                                new CurrencyRate
                                {
                                    SiteDate = currencyRates[i].SiteDate,
                                    CurrencyId = currencyRates[i].CurrencyId,
                                    TypeId = currencyRates[i].TypeId,
                                    DateSubmitted = currencyRates[i].DateSubmitted,
                                    Price = currencyRates[i].Price
                                });
                            db.SaveChanges();

                            Console.WriteLine("Add Success!!");
                        }
                        else
                        {
                            Console.WriteLine("Duplicate!!!!");
                        }
                    }
                    db.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw new Exception("Duplicate Case");
            }
        }
    }
}

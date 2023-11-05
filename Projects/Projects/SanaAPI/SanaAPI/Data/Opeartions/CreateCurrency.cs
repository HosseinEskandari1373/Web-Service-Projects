using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Net;

namespace SanaAPI
{
    public class CreateCurrency
    {
        public object Create()
        {
            string MessageDuplicate = "";
            string MessageSuccess = "";
            int NumDuplicate = 0;
            int NumSuccess = 0;
            string DbError = "";

            //Add values to the database
            try
            {
                //Calling from the array of currencyRate
                CurrencyRate[] currencyRates = new ListCurrencyRate().ListCurrency();

                if (currencyRates != null)
                {
                    try
                    {
                        using (var db = new CurrencyContext())
                        {
                            db.Database.Migrate();

                            //Condition for editing non-duplicate records in the database
                            for (int i = 0; i < currencyRates.Length; i++)
                            {
                                //Specify whether or not a record exists in the database (avoid adding duplicate values)
                                bool exists = db.CurrencyRates.Any(
                                    s => s.SiteDate.Date == currencyRates[i].SiteDate.Date &&
                                    s.CurrencyId == currencyRates[i].CurrencyId &&
                                    s.TypeId == currencyRates[i].TypeId);

                                //Condition to add a record if that record does not exist in the database
                                if (exists == false)
                                {
                                    //Insert a New Record CurrencyRate"
                                    db.CurrencyRates.AddRange(
                                        new CurrencyRate
                                        {
                                            SiteDate = currencyRates[i].SiteDate,
                                            CurrencyId = currencyRates[i].CurrencyId,
                                            TypeId = currencyRates[i].TypeId,
                                            DateSubmitted = currencyRates[i].DateSubmitted,
                                            Price = currencyRates[i].Price
                                        });
                                    //Specify the number of records added to the DataBase
                                    NumSuccess += 1;
                                    MessageSuccess = "Add Successfully = " + NumSuccess;

                                    db.SaveChanges();
                                }
                                else if (exists == true)
                                {
                                    //Specify the number of records in the DataBase(Duplicate)
                                    NumDuplicate += 1;
                                    MessageDuplicate = "Duplicate Case = " + NumDuplicate;
                                }
                            }
                            return (HttpStatusCode.OK + "   " + MessageDuplicate + "   " + MessageSuccess);
                        }
                    }
                    catch (Exception)
                    {
                        DbError = Convert.ToString(new Exception("No Success Connect to Database SanaAPI and Add Data"));
                        return null;
                    }
                }
                else
                {
                    return new Exception("Disconnected Web Service");
                }
            }
            catch (Exception)
            {
                throw new Exception("Web Service Connection Error!");
            }
        }
    }
}

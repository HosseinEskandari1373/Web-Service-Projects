using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace SanaAPI
{
    public class ReadCurrency
    {
        public object Read(ReadData data)
        {
            try
            {
                using (var db = new CurrencyContext())
                {
                    db.Database.Migrate();

                    // کوئری مربوط به خواندن ارز براساس تاریخ از دیتابیس
                    var readCurrency = db.CurrencyRates
                        .Where(date => date.DateSubmitted.Date == data.DateSubmitted.Date)
                        .Select(res => new ReadData()
                        {
                            DateSubmitted = res.DateSubmitted,
                            SiteDate = res.SiteDate,
                            Price = res.Price,
                            CurrencyName = res.Currency.CurrencyName,
                            CurrencyType = res.CurrencyType.TypeCurrency,
                            PriceType = res.CurrencyType.PriceType
                        }).ToList();

                    if (readCurrency.Any())
                    {
                        return readCurrency;
                    }
                    else
                    {
                        return "Not Exist Currency in DataBase!!";
                    }
                }
            }
            catch (Exception)
            {
                throw new Exception("Web Service Connection Error!");
            }

            //return "Not Exist Currency in DataBase!!";
        }
    }
}

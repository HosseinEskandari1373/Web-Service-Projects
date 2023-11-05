using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace SanaAPI
{
    public class ListCurrencyRate
    {
        public CurrencyRate[] ListCurrency()
        {
            try
            {
                List<ReadData> currncy = new ReadAPI().GetAPI();

                //Get the date from the system
                DateTime DateSubmitted = DateTime.Now;

                //Prepare an array of required currency values
                var currencyRates = new CurrencyRate[] {
                //------------------- (دلار) -------------------//
                new CurrencyRate()
                 {
                     // (USD) تاریخ خرید حواله ارزی دلار
                     SiteDate = currency[12].SiteDate,
                     CurrencyId = 5,
                     TypeId = 3,
                     DateSubmitted = DateSubmitted,
                     // (USD) قیمت خرید حواله ارزی دلار
                     Price = Convert.ToDecimal(currency[12].Price)
                 },
                new CurrencyRate()
                 {
                     // (USD) تاریخ فروش حواله ارزی دلار
                     SiteDate = currency[11].SiteDate,
                     CurrencyId = 5,
                     TypeId = 4,
                     DateSubmitted = DateSubmitted,
                     // (USD) قیمت فروش حواله ارزی دلار
                     Price = Convert.ToDecimal(currency[11].Price)
                 },
                new CurrencyRate()
                 {
                     // (USD) تاریخ خرید ارز سنا دلار
                     SiteDate = currency[9].SiteDate,
                     CurrencyId = 5,
                     TypeId = 1,
                     DateSubmitted = DateSubmitted,
                     // (USD) قیمت خرید ارز سنا دلار
                     Price = Convert.ToDecimal(currency[9].Price)
                 },
                new CurrencyRate()
                 {
                     // (USD) تاریخ فروش ارز سنا دلار
                     SiteDate = currency[10].SiteDate,
                     CurrencyId = 5,
                     TypeId = 2,
                     DateSubmitted = DateSubmitted,
                     // (USD) قیمت فروش ارز سنا دلار
                     Price = Convert.ToDecimal(currency[10].Price)
                 },
                new CurrencyRate()
                 {
                     // (USD) تاریخ ارز دولتی دلار
                     SiteDate = currency[8].SiteDate,
                     CurrencyId = 5,
                     TypeId = 5,
                     DateSubmitted = DateSubmitted,
                     // (USD) تاریخ ارز دولتی دلار
                     Price = Convert.ToDecimal(currency[8].Price)
                 },
                //------------------- (یورو) -------------------//
                new CurrencyRate()
                 {
                     // (EUR) تاریخ خرید حواله ارزی یورو
                     SiteDate = currency[16].SiteDate,
                     CurrencyId = 1,
                     TypeId = 3,
                     DateSubmitted = DateSubmitted,
                     // (EUR) قیمت خرید حواله ارزی یورو
                     Price = Convert.ToDecimal(currency[16].Price)
                 },
                new CurrencyRate()
                 {
                     // (EUR) تاریخ فروش حواله ارزی یورو
                     SiteDate = currency[19].SiteDate,
                     CurrencyId = 1,
                     TypeId = 4,
                     DateSubmitted = DateSubmitted,
                     // (EUR) قیمت فروش حواله ارزی یورو
                     Price = Convert.ToDecimal(currency[19].Price)
                 },
                new CurrencyRate()
                 {
                     // (EUR) تاریخ خرید ارز سنا یورو
                     SiteDate = currency[14].SiteDate,
                     CurrencyId = 1,
                     TypeId = 1,
                     DateSubmitted = DateSubmitted,
                     // (EUR) قیمت خرید ارز سنا یورو
                     Price = Convert.ToDecimal(currency[14].Price)
                 },
                new CurrencyRate()
                 {
                     // (EUR) تاریخ فروش ارز سنا یورو
                     SiteDate = currency[15].SiteDate,
                     CurrencyId = 1,
                     TypeId = 2,
                     DateSubmitted = DateSubmitted,
                     // (EUR) قیمت فروش ارز سنا یورو
                     Price = Convert.ToDecimal(currency[15].Price)
                 },
                new CurrencyRate()
                 {
                     // (EUR) تاریخ ارز دولتی یورو
                     SiteDate = currency[13].SiteDate,
                     CurrencyId = 1,
                     TypeId = 5,
                     DateSubmitted = DateSubmitted,
                     // (EUR) تاریخ ارز دولتی یورو
                     Price = Convert.ToDecimal(currency[13].Price)
                 },
                //------------------- (درهم امارات) -------------------//
                new CurrencyRate()
                 {
                     // (AED) تاریخ خرید حواله ارزی درهم امارات
                     SiteDate = currency[0].SiteDate,
                     CurrencyId = 2,
                     TypeId = 3,
                     DateSubmitted = DateSubmitted,
                     // (AED) قیمت خرید حواله ارزی درهم امارات
                     Price = Convert.ToDecimal(currency[0].Price)
                 },
                new CurrencyRate()
                 {
                     // (AED) تاریخ فروش حواله ارزی درهم امارات
                     SiteDate = currency[1].SiteDate,
                     CurrencyId = 2,
                     TypeId = 4,
                     DateSubmitted = DateSubmitted,
                     // (AED) قیمت فروش حواله ارزی درهم امارات
                     Price = Convert.ToDecimal(currency[1].Price)
                 },
                new CurrencyRate()
                 {
                     // (AED) تاریخ خرید ارز سنا درهم امارات
                     SiteDate = currency[17].SiteDate,
                     CurrencyId = 2,
                     TypeId = 1,
                     DateSubmitted = DateSubmitted,
                     // (AED) قیمت خرید ارز سنا درهم امارات
                     Price = Convert.ToDecimal(currency[17].Price)
                 },
                new CurrencyRate()
                 {
                     // (AED) تاریخ فروش ارز سنا درهم امارات
                     SiteDate = currency[18].SiteDate,
                     CurrencyId = 2,
                     TypeId = 2,
                     DateSubmitted = DateSubmitted,
                     // (AED) قیمت فروش ارز سنا درهم امارات
                     Price = Convert.ToDecimal(currency[18].Price)
                 },
                new CurrencyRate()
                 {
                     // (AED) تاریخ ارز دولتی درهم امارات
                     SiteDate = DateSubmitted,
                     CurrencyId = 2,
                     TypeId = 5,
                     DateSubmitted = DateSubmitted,
                     // (AED) تاریخ ارز دولتی درهم امارات
                     Price = 0000000000
                 },
                //------------------- (یوان چین) -------------------//
                new CurrencyRate()
                 {
                     // (CNY) تاریخ خرید حواله ارزی یوان چین
                     SiteDate = currency[6].SiteDate,
                     CurrencyId = 3,
                     TypeId = 3,
                     DateSubmitted = DateSubmitted,
                     // (CNY) قیمت خرید حواله ارزی یوان چین
                     Price = Convert.ToDecimal(currency[6].Price)
                 },
                new CurrencyRate()
                 {
                     // (CNY) تاریخ فروش حواله ارزی یوان چین
                     SiteDate = currency[7].SiteDate,
                     CurrencyId = 3,
                     TypeId = 4,
                     DateSubmitted = DateSubmitted,
                     // (CNY) قیمت فروش حواله ارزی یوان چین
                     Price = Convert.ToDecimal(currency[7].Price)
                 },
                new CurrencyRate()
                 {
                     // (CNY) تاریخ خرید ارز سنا یوان چین
                     SiteDate = currency[26].SiteDate,
                     CurrencyId = 3,
                     TypeId = 1,
                     DateSubmitted = DateSubmitted,
                     // (CNY) قیمت خرید ارز سنا یوان چین
                     Price = Convert.ToDecimal(currency[26].Price)
                 },
                new CurrencyRate()
                 {
                     // (CNY) تاریخ فروش ارز سنا یوان چین
                     SiteDate = currency[27].SiteDate,
                     CurrencyId = 3,
                     TypeId = 2,
                     DateSubmitted = DateSubmitted,
                     // (CNY) قیمت فروش ارز سنا یوان چین
                     Price = Convert.ToDecimal(currency[27].Price)
                 },
                new CurrencyRate()
                 {
                     // (CNY) تاریخ ارز دولتی یوان چین
                     SiteDate = currency[20].SiteDate,
                     CurrencyId = 3,
                     TypeId = 5,
                     DateSubmitted = DateSubmitted,
                     // (CNY) تاریخ ارز دولتی یوان چین
                     Price = Convert.ToDecimal(currency[20].Price)
                 },
                //------------------- (روبل روسیه) -------------------//
                new CurrencyRate()
                 {
                     // (RUB) تاریخ خرید حواله ارزی روبل روسیه
                     SiteDate = currency[2].SiteDate,
                     CurrencyId = 6,
                     TypeId = 3,
                     DateSubmitted = DateSubmitted,
                     // (RUB) قیمت خرید حواله ارزی روبل روسیه
                     Price = Convert.ToDecimal(currency[2].Price)
                 },
                new CurrencyRate()
                 {
                     // (RUB) تاریخ فروش حواله ارزی روبل روسیه
                     SiteDate = currency[3].SiteDate,
                     CurrencyId = 6,
                     TypeId = 4,
                     DateSubmitted = DateSubmitted,
                     // (RUB) قیمت فروش حواله ارزی روبل روسیه
                     Price = Convert.ToDecimal(currency[3].Price)
                 },
                new CurrencyRate()
                 {
                     // (RUB) تاریخ خرید ارز سنا روبل روسیه
                     SiteDate = currency[24].SiteDate,
                     CurrencyId = 6,
                     TypeId = 1,
                     DateSubmitted = DateSubmitted,
                     // (RUB) قیمت خرید ارز سنا روبل روسیه
                     Price = Convert.ToDecimal(currency[24].Price)
                 },
                new CurrencyRate()
                 {
                     // (RUB) تاریخ فروش ارز سنا روبل روسیه
                     SiteDate = currency[25].SiteDate,
                     CurrencyId = 6,
                     TypeId = 2,
                     DateSubmitted = DateSubmitted,
                     // (RUB) قیمت فروش ارز سنا روبل روسیه
                     Price = Convert.ToDecimal(currency[25].Price)
                 },
                new CurrencyRate()
                 {
                     // (RUB) تاریخ ارز دولتی روبل روسیه
                     SiteDate = currency[23].SiteDate,
                     CurrencyId = 6,
                     TypeId = 5,
                     DateSubmitted = DateSubmitted,
                     // (RUB) تاریخ ارز دولتی روبل روسیه
                     Price = Convert.ToDecimal(currency[23].Price)
                 },
                //------------------- (روپیه هند) -------------------//
                new CurrencyRate()
                 {
                     // (INR) تاریخ خرید حواله ارزی روپیه هند
                     SiteDate = currency[4].SiteDate,
                     CurrencyId = 4,
                     TypeId = 3,
                     DateSubmitted = DateSubmitted,
                     // (INR) قیمت خرید حواله ارزی روپیه هند
                     Price = Convert.ToDecimal(currency[4].Price)
                 },
                new CurrencyRate()
                 {
                     // (INR) تاریخ فروش حواله ارزی روپیه هند
                     SiteDate = currency[5].SiteDate,
                     CurrencyId = 4,
                     TypeId = 4,
                     DateSubmitted = DateSubmitted,
                     // (INR) قیمت فروش حواله ارزی روپیه هند
                     Price = Convert.ToDecimal(currency[5].Price)
                 },
                new CurrencyRate()
                 {
                     // (INR) تاریخ خرید ارز سنا روپیه هند
                     SiteDate = currency[21].SiteDate,
                     CurrencyId = 4,
                     TypeId = 1,
                     DateSubmitted = DateSubmitted,
                     // (INR) قیمت خرید ارز سنا روپیه هند
                     Price = Convert.ToDecimal(currency[21].Price)
                 },
                new CurrencyRate()
                 {
                     // (INR) تاریخ فروش ارز سنا روپیه هند
                     SiteDate = currency[22].SiteDate,
                     CurrencyId = 4,
                     TypeId = 2,
                     DateSubmitted = DateSubmitted,
                     // (INR) قیمت فروش ارز سنا روپیه هند
                     Price = Convert.ToDecimal(currency[22].Price)
                 },
                new CurrencyRate()
                 {
                     // (INR) تاریخ ارز دولتی روپیه هند
                     SiteDate = currency[28].SiteDate,
                     CurrencyId = 4,
                     TypeId = 5,
                     DateSubmitted = DateSubmitted,
                     // (INR) تاریخ ارز دولتی روپیه هند
                     Price = Convert.ToDecimal(currency[28].Price)
                 }
            };

                return currencyRates;
            }
            catch (Exception)
            {
                throw new Exception("Web Service Connection Error!");
            }
        }
    }
}

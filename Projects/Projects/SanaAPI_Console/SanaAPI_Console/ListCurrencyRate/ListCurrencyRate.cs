using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanaAPI
{
    public class ListCurrencyRate
    {
        public static CurrencyRate[] ListCurrency()
        {
            SanaAPI currency = ReadAPI.GetAPI();

            //Get the date from the system
            DateTime DateSubmitted = DateTime.Now;

            // DateTime حذف میلی ثانیه از
            DateSubmitted = new DateTime(
                DateSubmitted.Ticks - (DateSubmitted.Ticks % TimeSpan.TicksPerSecond),
                DateSubmitted.Kind
                );

            //Prepare an array of required currency values
            var currencyRates = new CurrencyRate[] {
                 new CurrencyRate()
                 {
                     // (EUR) تاریخ خرید اسکناس یورو
                     SiteDate = DateTime.Parse(currency.sana.data[1].updated_at),
                     CurrencyId = 1,
                     TypeId = 1,
                     DateSubmitted = DateSubmitted,
                     // (EUR) قیمت خرید اسکناس یورو
                     Price = currency.sana.data[1].p
                 },
                 new CurrencyRate()
                 {
                     // (EUR) تاریخ فروش اسکناس یورو
                     SiteDate = DateTime.Parse(currency.sana.data[17].updated_at),
                     CurrencyId = 1,
                     TypeId = 2,
                     Price = currency.sana.data[17].p,
                     // (EUR) قیمت فروش اسکناس یورو
                     DateSubmitted = DateSubmitted
                 },
                 new CurrencyRate()
                 {
                     // (AED) تاریخ خرید اسکناس درهم امارات متحده عربی
                     SiteDate = DateTime.Parse(currency.sana.data[2].updated_at),
                     CurrencyId = 2,
                     TypeId = 1,
                     Price = currency.sana.data[2].p,
                     // (AED) قیمت خرید اسکناس درهم امارات متحده عربی
                     DateSubmitted = DateSubmitted
                 },
                 new CurrencyRate()
                 {
                     // (AED) تاریخ فروش اسکناس درهم امارات متحده عربی
                     SiteDate = DateTime.Parse(currency.sana.data[18].updated_at),
                     CurrencyId = 2,
                     TypeId = 2,
                     Price = currency.sana.data[18].p,
                     // (AED) قیمت فروش اسکناس درهم امارات متحده عربی
                     DateSubmitted = DateSubmitted
                 },
                 new CurrencyRate()
                 {
                     // (CNY) تاریخ خرید اسکناس یوان چین
                     SiteDate = DateTime.Parse(currency.sana.data[6].updated_at),
                     CurrencyId = 3,
                     TypeId = 1,
                     Price = currency.sana.data[6].p,
                     // (CNY) قیمت خرید اسکناس یوان چین
                     DateSubmitted = DateSubmitted
                 },
                 new CurrencyRate()
                 {
                     // (CNY) تاریخ فروش اسکناس یوان چین
                     SiteDate = DateTime.Parse(currency.sana.data[22].updated_at),
                     CurrencyId = 3,
                     TypeId = 2,
                     Price = currency.sana.data[22].p,
                     // (CNY) قیمت فروش اسکناس یوان چین
                     DateSubmitted = DateSubmitted
                 },
                 new CurrencyRate()
                 {
                     // (INR) تاریخ خرید اسکناس روپیه هند
                     SiteDate = DateTime.Parse(currency.sana.data[3].updated_at),
                     CurrencyId = 4,
                     TypeId = 1,
                     Price = currency.sana.data[3].p,
                     // (INR) قیمت خرید اسکناس روپیه هند
                     DateSubmitted = DateSubmitted
                 },
                 new CurrencyRate()
                 {
                     // (INR) تاریخ فروش اسکناس روپیه هند
                     SiteDate = DateTime.Parse(currency.sana.data[19].updated_at),
                     CurrencyId = 4,
                     TypeId = 2,
                     Price = currency.sana.data[19].p,
                     // (INR) قیمت فروش اسکناس روپیه هند
                     DateSubmitted = DateSubmitted
                 },
                 new CurrencyRate()
                 {
                     // (USD) تاریخ خرید اسکناس دلار آمریکا
                     SiteDate = DateTime.Parse(currency.sana.data[0].updated_at),
                     CurrencyId = 5,
                     TypeId = 1,
                     Price = currency.sana.data[0].p,
                     // (USD) قیمت خرید اسکناس دلار آمریکا
                     DateSubmitted = DateSubmitted
                 },
                 new CurrencyRate()
                 {
                     // (USD) تاریخ فروش اسکناس دلار آمریکا
                     SiteDate = DateTime.Parse(currency.sana.data[16].updated_at),
                     CurrencyId = 5,
                     TypeId = 2,
                     Price = currency.sana.data[16].p,
                     // (USD) قیمت فروش اسکناس دلار آمریکا
                     DateSubmitted = DateSubmitted
                 },
                 new CurrencyRate()
                 {
                     // (RUB) تاریخ خرید اسکناس روبل روسیه
                     SiteDate = DateTime.Parse(currency.sana.data[5].updated_at),
                     CurrencyId = 6,
                     TypeId = 1,
                     Price = currency.sana.data[5].p,
                     // (RUB) قیمت خرید اسکناس روبل روسیه
                     DateSubmitted = DateSubmitted
                 },
                 new CurrencyRate()
                 {
                     // (RUB) تاریخ فروش اسکناس روبل روسیه
                     SiteDate = DateTime.Parse(currency.sana.data[21].updated_at),
                     CurrencyId = 6,
                     TypeId = 2,
                     Price = currency.sana.data[21].p,
                     // (RUB) قیمت فروش اسکناس روبل روسیه
                     DateSubmitted = DateSubmitted
                 }
            };

            return currencyRates;
        }
    }
}

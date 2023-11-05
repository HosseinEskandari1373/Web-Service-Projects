using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace WebScrappingHtmlPage
{
    /*
       1- Banknote = اسکناس
       2- Draft = حواله ارزی
    */
    public class ListCurrencyRate
    {
        public static CurrencyRate[] ListCurrencies()
        {
            DateTime SiteDateBanknote = GetSiteDateEskenas.GetSiteDateBanknote();
            List<decimal> PriceBanknote = GetPriceEskenas.GetPriceBanknote();

            DateTime SiteDateDraft = GetSiteDateHavale.GetSiteDateDraft();
            List<decimal> PriceDraft = GetPriceHavale.GetPriceDraft();

            //Get the date from the system
            DateTime DateSubmitted = DateTime.Now;

            // DateTime حذف میلی ثانیه از
            DateSubmitted = new DateTime(
                DateSubmitted.Ticks - (DateSubmitted.Ticks % TimeSpan.TicksPerSecond),
                DateSubmitted.Kind
                );

            //Prepare an array of required currency values
            var currencyRates = new CurrencyRate[] {
                  /*******Currency Banknote ( اسکناس )********/
                  new CurrencyRate()
                  {
                      SiteDate = SiteDateBanknote,
                      CurrencyId = 1,
                      TypeId = 1,
                      DateSubmitted = DateSubmitted,
                      // خرید EUR (یورو)
                      Price = PriceBanknote[0]
                  },
                  new CurrencyRate()
                  {
                      SiteDate = SiteDateBanknote,
                      CurrencyId = 1,
                      TypeId = 2,
                      DateSubmitted = DateSubmitted,
                      // فروش EUR (یورو)
                      Price = PriceBanknote[1]
                  },
                  new CurrencyRate()
                  {
                      SiteDate = SiteDateBanknote,
                      CurrencyId = 2,
                      TypeId = 1,
                      DateSubmitted = DateSubmitted,
                      // خرید AED (درهم امارات متحده عربی)
                      Price = PriceBanknote[2]
                  },
                  new CurrencyRate()
                  {
                      SiteDate = SiteDateBanknote,
                      CurrencyId = 2,
                      TypeId = 2,
                      DateSubmitted = DateSubmitted,
                      // فروش AED (درهم امارات متحده عربی)
                      Price = PriceBanknote[3]
                  },
                  new CurrencyRate()
                  {
                      SiteDate = SiteDateBanknote,
                      CurrencyId = 3,
                      TypeId = 1,
                      DateSubmitted = DateSubmitted,
                      // خرید CNY (یوان  چین)
                      Price = PriceBanknote[4]
                  },
                  new CurrencyRate()
                  {
                      SiteDate = SiteDateBanknote,
                      CurrencyId = 3,
                      TypeId = 2,
                      DateSubmitted = DateSubmitted,
                      // فروش CNY (یوان  چین)
                      Price = PriceBanknote[5]
                  },
                  new CurrencyRate()
                  {
                      SiteDate = SiteDateBanknote,
                      CurrencyId = 4,
                      TypeId = 1,
                      DateSubmitted = DateSubmitted,
                      // خرید INR (روپیه  هند)
                      Price = PriceBanknote[14]
                  },
                  new CurrencyRate()
                  {
                      SiteDate = SiteDateBanknote,
                      CurrencyId = 4,
                      TypeId = 2,
                      DateSubmitted = DateSubmitted,
                      // فروش INR (روپیه  هند)
                      Price = PriceBanknote[15]
                  },
                  new CurrencyRate()
                  {
                      SiteDate = SiteDateBanknote,
                      CurrencyId = 5,
                      TypeId = 1,
                      DateSubmitted = DateSubmitted,
                      // خرید USD (دلار آمریکا)
                      Price = PriceBanknote[18]
                  },
                  new CurrencyRate()
                  {
                      SiteDate = SiteDateBanknote,
                      CurrencyId = 5,
                      TypeId = 2,
                      DateSubmitted = DateSubmitted,
                      // فروش USD (دلار آمریکا)
                      Price = PriceBanknote[19]
                  },
                  new CurrencyRate()
                  {
                      SiteDate = SiteDateBanknote,
                      CurrencyId = 6,
                      TypeId = 1,
                      DateSubmitted = DateSubmitted,
                      // خرید RUB (روبل روسيه)
                      Price = PriceBanknote[24]
                  },
                  new CurrencyRate()
                  {
                      SiteDate = SiteDateBanknote,
                      CurrencyId = 6,
                      TypeId = 2,
                      DateSubmitted = DateSubmitted,
                      // فروش RUB (روبل روسيه)
                      Price = PriceBanknote[25]
                  },
                  /*******Currency Draft ( حواله ارزی )********/
                  new CurrencyRate()
                  {
                      SiteDate = SiteDateDraft,
                      CurrencyId = 1,
                      TypeId = 3,
                      DateSubmitted = DateSubmitted,
                      // خرید EUR (یورو)
                      Price = PriceDraft[0]
                  },
                  new CurrencyRate()
                  {
                      SiteDate = SiteDateDraft,
                      CurrencyId = 1,
                      TypeId = 4,
                      DateSubmitted = DateSubmitted,
                      // فروش EUR (یورو)
                      Price = PriceDraft[1]
                  },
                  new CurrencyRate()
                  {
                      SiteDate = SiteDateDraft,
                      CurrencyId = 2,
                      TypeId = 3,
                      DateSubmitted = DateSubmitted,
                      // خرید AED (درهم امارات متحده عربی)
                      Price = PriceDraft[2]
                  },
                  new CurrencyRate()
                  {
                      SiteDate = SiteDateDraft,
                      CurrencyId = 2,
                      TypeId = 4,
                      DateSubmitted = DateSubmitted,
                      // فروش AED (درهم امارات متحده عربی)
                      Price = PriceDraft[3]
                  },
                  new CurrencyRate()
                  {
                      SiteDate = SiteDateDraft,
                      CurrencyId = 3,
                      TypeId = 3,
                      DateSubmitted = DateSubmitted,
                      // خرید CNY (یوان  چین)
                      Price = PriceDraft[4]
                  },
                  new CurrencyRate()
                  {
                      SiteDate = SiteDateDraft,
                      CurrencyId = 3,
                      TypeId = 4,
                      DateSubmitted = DateSubmitted,
                      // فروش CNY (یوان  چین)
                      Price = PriceDraft[5]
                  },
                  new CurrencyRate()
                  {
                      SiteDate = SiteDateDraft,
                      CurrencyId = 4,
                      TypeId = 3,
                      DateSubmitted = DateSubmitted,
                      // خرید INR (روپیه  هند)
                      Price = PriceDraft[14]
                  },
                  new CurrencyRate()
                  {
                      SiteDate = SiteDateDraft,
                      CurrencyId = 4,
                      TypeId = 4,
                      DateSubmitted = DateSubmitted,
                      // فروش INR (روپیه  هند)
                      Price = PriceDraft[15]
                  },
                  new CurrencyRate()
                  {
                      SiteDate = SiteDateDraft,
                      CurrencyId = 5,
                      TypeId = 3,
                      DateSubmitted = DateSubmitted,
                      // خرید USD (دلار آمریکا)
                      Price = PriceDraft[18]
                  },
                  new CurrencyRate()
                  {
                      SiteDate = SiteDateDraft,
                      CurrencyId = 5,
                      TypeId = 4,
                      DateSubmitted = DateSubmitted,
                      // فروش USD (دلار آمریکا)
                      Price = PriceDraft[19]
                  },
                  new CurrencyRate()
                  {
                      SiteDate = SiteDateDraft,
                      CurrencyId = 6,
                      TypeId = 3,
                      DateSubmitted = DateSubmitted,
                      // خرید RUB (روبل روسيه)
                      Price = PriceDraft[24]
                  },
                  new CurrencyRate()
                  {
                      SiteDate = SiteDateDraft,
                      CurrencyId = 6,
                      TypeId = 4,
                      DateSubmitted = DateSubmitted,
                      // فروش RUB (روبل روسيه)
                      Price = PriceDraft[25]
                  }
            };
            return currencyRates;
        }
    }
}

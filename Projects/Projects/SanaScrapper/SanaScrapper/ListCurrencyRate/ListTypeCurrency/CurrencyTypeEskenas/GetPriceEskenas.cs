using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebScrappingHtmlPage
{
    /*
       1- Banknote = اسکناس
    */
    public class GetPriceEskenas
    {
        public static List<decimal> GetPriceBanknote()
        {
            //Retrive CleanTextSiteEskenas
            string[] CleanLineBanknote = CleanTextSiteEskenas.CleanTextBanknote();

            /*
                1- از آنجایی که قیمت ارز در سایت گاهی مقدار "--" را به خود اختصاص می دهد، بنابراین
                  . دچار مشکل خواهید شد Decimal در تبدیل رشته قیمت به
                2- برای حل این مشکل لیستی از قیمت ها ایجاد نمایید
                3- . تبدیل نمایید Decimal با نوشتن شرط های لازم درصورتی که قیمت مقدار "--" را نداشت آن را به
            */
            List<decimal> PriceBanknote = new List<decimal>();

            // i = 13 شروع حلقه از سطر دوم جدول یعنی خانه
            for (int i = 13; i <= CleanLineBanknote.Length; i++)
            {
                // حلقه برای گرفتن فقط قیمت خرید و فروش روزکاری قبل 
                for (int j = 0; j < 2; j++)
                {
                    /* 
                     * از آنجایی که قیمت ها معمولا دارای "," هستند، بررسی کنید
                     * . تبدیل کنید Decimal که درصورت وجود "," رشته قیمت را به
                    */
                    bool Result = CleanLineBanknote[i + j].Contains(",");

                    if (Result == true || CleanLineBanknote[i + j].Length > 2)
                    {
                        PriceBanknote.Add(Convert.ToDecimal(decimal.Parse(CleanLineBanknote[i + j])));
                    }
                    else
                    {
                        PriceBanknote.Add(-1);
                    }
                }
                // . شود i += 7 برای دریافت فقط قیمت خرید و فروش روزکاری قبل باید
                i += 7;
            }

            return PriceBanknote;
        }
    }
}

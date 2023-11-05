using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebScrappingHtmlPage
{
    /*
       1- Draft = حواله ارزی
    */
    public class CleanTextSiteHavale
    {
        public static string[] CleanTextDraft()
        {
            /*
               SanaRate سایت Html درون تگ ها با نوشتن کوئری از بین تگ های مورد نیاز از سند Text خواندن 
            */
            IEnumerable<string> innerTextDraft = ReadTextSiteHavale.ReadTextDraft();

            /*
              (از متن خوانده شده از سایت (تمیز کردن متن خوانده شده \n حذف فضاهای خالی و
            */
            string[] lines = innerTextDraft.ToArray()[0].Split('\n');
            string[] cleanLineDraft = lines.Where(lines => !string.IsNullOrWhiteSpace(lines))
                .Select(x => x.Trim()).ToArray();

            return cleanLineDraft;
        }
    }
}

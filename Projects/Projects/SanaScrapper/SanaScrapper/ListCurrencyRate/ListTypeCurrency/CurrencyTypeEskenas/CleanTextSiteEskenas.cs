using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebScrappingHtmlPage;

namespace WebScrappingHtmlPage
{
    /*
       1- Banknote = اسکناس
    */
    public class CleanTextSiteEskenas
    {
        public static string[] CleanTextBanknote()
        {
            /*
               SanaRate سایت Html درون تگ ها با نوشتن کوئری از بین تگ های مورد نیاز از سند Text خواندن 
            */
            IEnumerable<string> innerTextBanknote = ReadTextSiteEskenas.ReadTextBanknote();

            /*
              (از متن خوانده شده از سایت (تمیز کردن متن خوانده شده \n حذف فضاهای خالی و
            */
            string[] lines = innerTextBanknote.ToArray()[0].Split('\n');
            string[] cleanLineBanknote = lines.Where(lines => !string.IsNullOrWhiteSpace(lines))
                .Select(x => x.Trim()).ToArray();

            return cleanLineBanknote;
        }
    }
}

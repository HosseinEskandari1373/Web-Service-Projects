using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebScrappingHtmlPage
{
    /*
       1- Banknote = اسکناس
    */
    public class GetSiteDateEskenas
    {
        public static DateTime GetSiteDateBanknote()
        {
            //Retrive ReadTextSiteEskenas
            IEnumerable<string> innerTextBanknote = ReadTextSiteEskenas.ReadTextBanknote();

            /*
              Retrieve the date from the read text
              Get the house number that starts with parentheses.
              Since the date is defined as (12/25/1399), we take the house number that starts with ( and 
              extract the date from it.
             */
            int foundBanknote = 0;
            string DateBanknote = "";
            foreach (var item in innerTextBanknote)
            {
                foundBanknote = innerTextBanknote.ToArray()[0].IndexOf("(");
                DateBanknote = item.Substring(foundBanknote + 1, 10);
            }

            /*
              String persianDate = "1390/02/07";
              Convert string to Gregorian date
            */
            CultureInfo persianCulture = new CultureInfo("fa-IR");
            DateTime SiteDateBanknote = DateTime.ParseExact(DateBanknote, "yyyy/MM/dd", persianCulture);

            return SiteDateBanknote;
        }
    }
}

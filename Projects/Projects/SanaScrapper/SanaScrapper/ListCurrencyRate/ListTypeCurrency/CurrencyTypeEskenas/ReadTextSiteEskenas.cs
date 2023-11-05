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
    public class ReadTextSiteEskenas
    {
        public static IEnumerable<string> ReadTextBanknote()
        {
            //Calling Document
            HtmlDocument document = ReadHtml.GetHtmlDoc();

            /*
               SanaRate سایت Html درون تگ ها با نوشتن کوئری از بین تگ های مورد نیاز از سند Text خواندن 
            */
            HtmlNodeCollection AverageBanknotes = document.DocumentNode
                .SelectNodes(".//*[@id='MainContent_ViewCashChequeRates_divCash']/div[2]/" +
                "*[@class='table table-hover table-bordered table-blueheader table-responsive']");
            IEnumerable<string> innerTextBanknote = AverageBanknotes.Select(node => node.InnerText);

            return innerTextBanknote;
        }
    }
}

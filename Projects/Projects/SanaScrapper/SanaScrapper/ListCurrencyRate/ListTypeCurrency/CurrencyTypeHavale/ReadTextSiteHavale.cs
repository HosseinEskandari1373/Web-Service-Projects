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
    public class ReadTextSiteHavale
    {
        public static IEnumerable<string> ReadTextDraft()
        {
            //Calling Document
            HtmlDocument document = ReadHtml.GetHtmlDoc();

            /*
               SanaRate سایت Html درون تگ ها با نوشتن کوئری از بین تگ های مورد نیاز از سند Text خواندن 
            */
            HtmlNodeCollection average_remittances = document.DocumentNode
               .SelectNodes(".//*[@id='MainContent_ViewCashChequeRates_divHavale']/div[2]/" +
               "*[@class='table table-hover table-bordered table-blueheader']");
            IEnumerable<string> innerTextDraft = average_remittances.Select(node => node.InnerText);

            return innerTextDraft;
        }
    }
}

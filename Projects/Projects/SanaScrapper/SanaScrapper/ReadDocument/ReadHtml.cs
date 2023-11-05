using HtmlAgilityPack;
using System.Net;

namespace WebScrappingHtmlPage
{
    public class ReadHtml
    {
        public static HtmlDocument GetHtmlDoc()
        {
            //Get Url Site SanaRate
            string url = "https://fxmarketrate.cbi.ir/";

            WebClient Client = new WebClient();
            string html = Client.DownloadString(url);
            
            HtmlDocument document = new HtmlDocument();

            //Load the Html Page in document
            document.LoadHtml(html);
            return document;
        }
    }
}

using HtmlAgilityPack;
using System;
using System.IO;
using System.Linq;
using System.Net;

namespace HangfireScheduling
{
    public class PrintJob : IPrintJob
    {
        //WebScrapper SanaRate
        public void Print()
        {
            var url = "https://fxmarketrate.cbi.ir/";

            var Client = new WebClient();
            var html = Client.DownloadString(url);

            var document = new HtmlDocument();

            //Load the Html Page in document
            document.LoadHtml(html);

            //Gets the root node of the document
            HtmlNodeCollection result = document.DocumentNode.SelectNodes(".//*[@id='MainContent_ViewCashChequeRates_divCash']/div[2]/*[@class='table table-hover table-bordered table-blueheader table-responsive']");

            var innerText = result.Select(node => node.InnerText);
            File.AppendAllLines(@"../Sana_Rate.txt", innerText);
        }
    }
}

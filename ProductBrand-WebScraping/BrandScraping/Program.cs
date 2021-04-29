using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BrandScraping
{
    class Program
    {
        static void Main(string[] args)
        {
            GetHtmlAsync();
            Console.ReadLine();
        }

        private static async void GetHtmlAsync()
        {
            Console.WriteLine("Please enter url: ");
            var url = Console.ReadLine();
            
            var httpClient = new HttpClient();
            var html = await httpClient.GetStringAsync(url);

            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);

            var productBrand = htmlDocument.DocumentNode.SelectSingleNode("//a[@id=\"sellerProfileTriggerId\"]").InnerText.Trim('\n');
            Console.WriteLine("PRODUCT BRAND: " + productBrand + "\n");
        }
    }
}

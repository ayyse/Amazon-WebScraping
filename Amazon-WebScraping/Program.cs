using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Amazon_WebScraping
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
            var url = "https://www.amazon.co.uk/dp/B085ZKNCSQ/";
            var httpClient = new HttpClient();
            var html = await httpClient.GetStringAsync(url);

            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);



            string productName = htmlDocument.DocumentNode.SelectSingleNode("//*[@id=\"productTitle\"]").InnerText.Trim('\n');
            Console.WriteLine("PRODUCT NAME: " +  productName + "\n");

            string productStar = htmlDocument.DocumentNode.SelectSingleNode("//*[@id=\"acrPopover\"]").InnerText.Trim('\n');
            Console.WriteLine("PRODUCT STAR RATE: " + productStar + "\n");

            string productPrice = htmlDocument.DocumentNode.SelectSingleNode("//*[@id=\"priceblock_saleprice\"]").InnerText.Trim('\n');
            Console.WriteLine("PRODUCT PRICE: " + productPrice + "\n");

            string productColorBlack = htmlDocument.DocumentNode.SelectSingleNode("//*[@id=\"color_name_0\"]").InnerText.Trim('\n');
            Console.WriteLine("BLACK PRODUCT PRICE: " + productColorBlack + "\n");

            string productColorBlue = htmlDocument.DocumentNode.SelectSingleNode("//*[@id=\"color_name_1\"]").InnerText.Trim('\n');
            Console.WriteLine("BLUE PRODUCT PRICE: " + productColorBlue + "\n");


            Console.WriteLine();
        }
    }
}
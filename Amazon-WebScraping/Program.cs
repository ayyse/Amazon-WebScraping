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

            var productsHtml = htmlDocument.DocumentNode.Descendants("div")
            .Where(node => node.GetAttributeValue("id", " ")
            .Equals("centerCol")).ToList();

            var productListItems = productsHtml[0].Descendants("div")
                .Where(node => node.GetAttributeValue("class", " ")
                .Equals("celwidget")).ToList();

            foreach (var productListItem in productListItems)
            {
                // id
                Console.WriteLine(productListItem.GetAttributeValue("id", ""));

                // product name
                Console.WriteLine("Product Name: ", productListItem.Descendants("span")
                    .Where(node => node.GetAttributeValue("id", "")
                    .Equals("productTitle")).FirstOrDefault().InnerText
                    );

                // product price
                //Console.WriteLine(productListItem.Descendants("span")
                //    .Where(node => node.GetAttributeValue("id", "")
                //    .Equals("priceblock_saleprice")).FirstOrDefault().InnerText
                //    );
            }

            Console.WriteLine();
        }
    }
}
using HtmlAgilityPack;
using System;
using System.Net.Http;

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

            var country = htmlDocument.DocumentNode.SelectSingleNode("//a[@id=\"nav-logo-sprites\"]").InnerText.Trim('\n');
            Console.WriteLine("PRODUCT COUNTRY: " + country + "\n");


            try
            {
                var productBrand = htmlDocument.DocumentNode.SelectSingleNode("//a[@id=\"sellerProfileTriggerId\"]").InnerText.Trim('\n');
                Console.WriteLine("PRODUCT BRAND: " + productBrand + "\n");
                Console.WriteLine("Selling by  " + productBrand);
            }
            catch (Exception)
            {
                Console.WriteLine("Selling by Amazon");
            }

            try
            {
                var shipping = htmlDocument.DocumentNode.SelectSingleNode("//a[@id=\"SSOFpopoverLink\"]").InnerText.Trim('\n');
                if (shipping != null)
                {
                    Console.WriteLine("Shipping by Amazon");
                }
            }
            catch (Exception)
            {
                try
                {
                    var productBrand = htmlDocument.DocumentNode.SelectSingleNode("//a[@id=\"sellerProfileTriggerId\"]").InnerText.Trim('\n');
                    Console.WriteLine("Shipping by " + productBrand);
                }
                catch (Exception)
                {
                    Console.WriteLine("Shipping by Amazon");
                }
            }


        }
    }
}

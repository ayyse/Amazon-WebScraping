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

            var sellingBrand = htmlDocument.DocumentNode.SelectSingleNode("//span[@id=\"tabular-buybox-truncate-1\"]");
            if (sellingBrand != null)
            {
                var selling = sellingBrand.InnerText.Trim('\n');
                Console.WriteLine("PRODUCT BRAND: " + selling + "\n");
                Console.WriteLine("Selling by " + selling);
            }
            else
            {
                var productBrand = htmlDocument.DocumentNode.SelectSingleNode("//a[@id=\"sellerProfileTriggerId\"]");
                if (productBrand != null)
                {
                    var brand = productBrand.InnerText.Trim('\n');
                    Console.WriteLine("PRODUCT BRAND: " + brand + "\n");
                    Console.WriteLine("Selling by  " + brand);
                }
                else
                    Console.WriteLine("Selling by Amazon");
            }


            var shippingBrand = htmlDocument.DocumentNode.SelectSingleNode("//span[@id=\"tabular-buybox-truncate-0\"]");
            if (shippingBrand != null)
            {
                var shipping = shippingBrand.InnerText.Trim('\n');
                Console.WriteLine("Shipping by " + shipping);
            }
            else
            {
                var shippingBrand2 = htmlDocument.DocumentNode.SelectSingleNode("//a[@id=\"SSOFpopoverLink\"]");
                if (shippingBrand2 != null)
                {
                    var shipping = shippingBrand2.InnerText.Trim('\n');
                    Console.WriteLine("Shipping by Amazon");
                }
                else
                {
                    var productBrand = htmlDocument.DocumentNode.SelectSingleNode("//a[@id=\"sellerProfileTriggerId\"]");
                    if (productBrand != null)
                   s {
                        var brand = productBrand.InnerText.Trim('\n');
                        Console.WriteLine("Shipping by " + brand);
                    }
                    else
                        Console.WriteLine("Shipping by Amazon");
                }
            }
        }
    }
}

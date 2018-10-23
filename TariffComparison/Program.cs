using System;
using TariffComparison.Services;

namespace TariffComparison
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = new ProductService("../../../products.json");
            bool keep = true;
            Console.WriteLine("Tariff Comparsion.");
            while (keep)
            {
                Console.WriteLine("Please, enter a number of statement that what you want to do or any another key to exit and press 'enter': \n1. Create product \n2. See products list");
                string number = Console.ReadLine();
                switch (number)
                {
                    case "1":
                        {
                            service.AddProduct();
                            break;
                        }
                    case "2":
                        {
                            service.OutputProducts();
                            break;
                        }
                    default:
                        {
                            keep = false;
                            break;
                        }
                }
            }

        }

    }
}

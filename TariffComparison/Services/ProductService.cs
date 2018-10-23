using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json.Linq;
using TariffComparison.Models;

namespace TariffComparison.Services
{
    sealed class ProductService
    {
        private static List<Product> productChoices { get; set;} = new List<Product>();
        private static List<CreatedProduct> createdProducts { get; set;} = new List<CreatedProduct>();
        public ProductService()
        {
            string filepath = "../../../products.json";
            string result = string.Empty;
            using (StreamReader r = new StreamReader(filepath))
            {
                var json = r.ReadToEnd();
                var jobj = JObject.Parse(json);       
                foreach (var item in jobj.Property("products").Value) {
                    productChoices.Add(item.ToObject<Product>());          
                }           
            }
            
        }
        public void AddProduct()
        {
            Console.WriteLine("\nWich product do you want to add? (Write a number and press 'enter')");
            for(int i=0; i < productChoices.Count; i++)
            {
                Console.WriteLine($"{i+1}. {productChoices[i].Name}");
            }

            var productNumber = Convert.ToInt16(Console.ReadLine()) - 1;
            Console.WriteLine("\nPlease, write the consumption (kWh/year) and press 'enter'");
            var consumption = Convert.ToDecimal(Console.ReadLine());
            var newProduct = CreateProduct(productNumber, consumption);
            createdProducts.Add(newProduct);
            Console.WriteLine("Your product has annual costs {0}", newProduct.AnnualCosts);
        }

        public void OutputProducts()
        {
            Console.WriteLine(new string('-', 73));
            Console.WriteLine(String.Format("|{0,35}|{1,35}|", "Tariff name", "Annual costs (€/year)"));
            Console.WriteLine(new string('-', 73));
            foreach(var el in createdProducts.OrderBy(product => product.AnnualCosts))
            {
               Console.WriteLine(String.Format("|{0,35}|{1,35}|", el.TariffName, el.AnnualCosts));
            }
            Console.WriteLine(new string('-', 73));
        }

        private CreatedProduct CreateProduct(int productNumber, decimal consumption)
        {
            var newProduct = new CreatedProduct(productChoices[productNumber].Name);
            decimal annualCosts = productChoices[productNumber].BaseCostPerYear;
            foreach(var limit in productChoices[productNumber].Limits)
            {
                if(consumption > limit.KWhPerYear)
                {
                     annualCosts += limit.Addition * (consumption - limit.KWhPerYear);
                }
            }
            newProduct.AnnualCosts = annualCosts;
            return newProduct;
        }
    }
}

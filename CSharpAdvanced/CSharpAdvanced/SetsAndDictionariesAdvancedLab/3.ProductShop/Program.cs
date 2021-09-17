using System;
using System.Collections.Generic;
using System.Linq;

namespace _3.ProductShop
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Dictionary<string, Dictionary<string, double>> shopList = new Dictionary<string, Dictionary<string, double>>();   

            while (input != "Revision")
            {
                var splitted = input.Split(", ", StringSplitOptions.RemoveEmptyEntries);
                var shop = splitted[0];
                var product = splitted[1];
                double price = double.Parse(splitted[2]);

                if (!shopList.ContainsKey(shop))
                {
                    shopList.Add(shop, new Dictionary<string, double>());
                }
                if (!shopList[shop].ContainsKey(product))
                {
                    shopList[shop].Add(product, price);
                }

                input = Console.ReadLine();
            }
            shopList = shopList.OrderBy(s => s.Key).ToDictionary(s => s.Key, v =>v.Value);

            foreach (var shop in shopList)
            {
                Console.WriteLine($"{shop.Key}->");

                foreach (var product in shop.Value)
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
                }
            }
        }
    }
}

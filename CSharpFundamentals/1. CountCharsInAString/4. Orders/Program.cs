using System;
using System.Collections.Generic;
using System.Linq;

namespace _4._Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            Dictionary<string, Product> products = new Dictionary<string, Product>();

            while ((input = Console.ReadLine()) != "buy")
            {
                string[] command = input
                    .Split()
                    .ToArray();

                Product product = new Product(command);

                if (!products.ContainsKey(command[0]))
                {
                    products.Add(command[0], product);
                }
                else
                {
                    products[command[0]].Price = double.Parse(command[1]);
                    products[command[0]].Quantity += int.Parse(command[2]);
                }
            }

            foreach (var item in products)
            {
                Console.WriteLine($"{item.Key} -> {item.Value.Price * item.Value.Quantity:f2}");
            }
        }
        public  class Product
        {
            public string Name { get; set; }
            public double Price { get; set; }
            public int Quantity { get; set; }

            public Product(string[] input)
            {
                this.Name = input[0];
                this.Price = double.Parse(input[1]);
                this.Quantity = int.Parse(input[2]);
            }

            public override string ToString()
            {
                return $"{Name} {Price} {Quantity}";   
            }
        }
    }
}

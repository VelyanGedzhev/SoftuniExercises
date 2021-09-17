using CommandPattern.Interfaces;
using CommandPattern.Models;
using System;

namespace CommandPattern
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var modifyPrice = new ModifyPrice();
            var product = new Product("Smartphone", 500);

            Execute(product, modifyPrice, new ProductCommand(product, Enumerators.PriceAction.Increase, 100));
            Execute(product, modifyPrice, new ProductCommand(product, Enumerators.PriceAction.Increase, 50));
            Execute(product, modifyPrice, new ProductCommand(product, Enumerators.PriceAction.Decrease, 25));

            Console.WriteLine(product);
        }
        public static void Execute(Product product, ModifyPrice modifyPrice, ICommand productCommand)
        {
            modifyPrice.SetCommand(productCommand);
            modifyPrice.Invoke();
        }
    }

    
}

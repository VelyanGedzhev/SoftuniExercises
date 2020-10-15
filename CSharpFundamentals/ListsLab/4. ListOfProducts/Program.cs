using System;
using System.Collections.Generic;

namespace _4._ListOfProducts
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> products = CreatList();
            SortAndPrintList(products);
            
        }
        static List<string> CreatList()
        {
            int count = int.Parse(Console.ReadLine());
            List<string> list = new List<string>();

            for (int i = 0; i < count; i++)
            {
                list.Add(Console.ReadLine());
            }

            return list;
        }
        static void SortAndPrintList(List<string> products)
        {
            products.Sort();

            for (int i = 0; i < products.Count; i++)
            {
                Console.WriteLine($"{i + 1}.{products[i]}");
            }
        }
    }
}

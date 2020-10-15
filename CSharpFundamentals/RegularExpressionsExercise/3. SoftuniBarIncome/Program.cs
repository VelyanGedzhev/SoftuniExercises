using System;
using System.Collections.Concurrent;
using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

namespace _3._SoftuniBarIncome
{
    class Program
    {
        static void Main(string[] args)
        {
            string order = Console.ReadLine();
            string pattern = @"^%(?<name>[A-Z][a-z]+)%[^|$%.]*<(?<product>\w+)>[^|$%.]*\|(?<count>\d+)\|[^|$%.]*?(?<price>[-+]?[0-9]*\.?[0-9]+([eE][-+]?[0-9]+)?)\$";
            double totalIncome = 0;

            while (order != "end of shift")
            {
                MatchCollection orderInfo = Regex.Matches(order, pattern);

                foreach (Match item in orderInfo)
                {
                    double sum = double.Parse(item.Groups["count"].Value) * double.Parse(item.Groups["price"].Value);
                    Console.WriteLine($"{item.Groups["name"].Value}: {item.Groups["product"].Value}" +
                        $" - {sum:f2}");
                    totalIncome += sum;
                }
                order = Console.ReadLine();
            }
            Console.WriteLine($"Total income: {totalIncome:f2}");
        }
    }
}

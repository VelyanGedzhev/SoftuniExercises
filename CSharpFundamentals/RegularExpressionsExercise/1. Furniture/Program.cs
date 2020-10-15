using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace _1._Furniture
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @">>(?<product>[\w]+)<<(?<price>[\d]+[\.]?[\d]+?)\!(?<quantity>[\d]+)";
            StringBuilder sb = new StringBuilder();
            double sum = 0;
            double spendMoney = 0;

            while (input  != "Purchase")
            {
                MatchCollection matches = Regex.Matches(input, pattern);

                foreach (Match match in matches)
                {
                    sb.AppendLine(match.Groups["product"].Value);
                    double quantity = double.Parse(match.Groups["quantity"].Value);
                    double price = double.Parse(match.Groups["price"].Value);
                    sum = price * quantity;
                    spendMoney += sum;
                }
                input = Console.ReadLine();
            }
            Console.WriteLine("Bought furniture:");
            if (spendMoney > 0)
            {
                Console.WriteLine(sb.ToString().Trim());
            }
            Console.WriteLine($"Total money spend: {spendMoney:f2}");
        }
    }
}

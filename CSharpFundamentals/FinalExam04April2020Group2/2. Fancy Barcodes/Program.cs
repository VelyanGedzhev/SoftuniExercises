using System;
using System.Text;
using System.Text.RegularExpressions;

namespace _2._Fancy_Barcodes
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex regex = new Regex(@"@\#+(?<name>[A-Z][A-Za-z0-9]{4,}[A-Z])@\#+");
            int num = int.Parse(Console.ReadLine());

            for (int i = 0; i < num; i++) 
            {
                string bardcodeInput = Console.ReadLine();
                Match match = regex.Match(bardcodeInput);

                if (!match.Success)
                {
                    Console.WriteLine("Invalid barcode");
                    continue;
                }

                string barcode = match.Groups["name"].Value;
                StringBuilder productGroup = new StringBuilder();

                for (int j = 0; j < barcode.Length; j++)
                {
                    if (char.IsDigit(barcode[j]))
                    {
                        productGroup.Append(barcode[j]);
                    }
                }
                if (productGroup.Length == 0)
                {
                    Console.WriteLine("Product group: 00");
                }
                else
                {
                    Console.WriteLine($"Product group: {productGroup.ToString().Trim()}");
                } 
            }
        }
    }
}

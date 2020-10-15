using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace _2._MatchPhoneNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(\+359([ -])2(\2)(\d{3})(\2)(\d{4}))\b";

            string input = Console.ReadLine();

            MatchCollection matchedNumbers = Regex.Matches(input, pattern);
            List<string> result = new List<string>();
            
            foreach (Match number in matchedNumbers)
            {
                result.Add(number.Value);
            }
            Console.WriteLine(string.Join(", ", result));
            
        }
    }
}

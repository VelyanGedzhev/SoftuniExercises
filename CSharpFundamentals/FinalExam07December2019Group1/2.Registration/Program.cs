using System;
using System.Collections.Concurrent;
using System.Text.RegularExpressions;

namespace _2.Registration
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            string pattern = @"U\$(?<username>[A-Z][a-z]{2,})U\$P@\$(?<password>[A-Za-z]{5,}[0-9]{1,})P@\$";
            int successfulCounter = 0;

            for (int i = 1; i <= count; i++)
            {
                string input = Console.ReadLine();
                Match match = Regex.Match(input, pattern);

                if (Regex.IsMatch(input,pattern))
                {
                    Console.WriteLine("Registration was successful");
                    Console.WriteLine($"Username: {match.Groups["username"].Value}" +
                        $", Password: {match.Groups["password"].Value}");
                    successfulCounter++;
                }
                else
                {
                    Console.WriteLine("Invalid username or password");
                }
            }
            Console.WriteLine($"Successful registrations: {successfulCounter}");
        }
    }
}

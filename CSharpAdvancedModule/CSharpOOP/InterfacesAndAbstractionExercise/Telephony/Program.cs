using System;
using System.Linq;
using Telephony.Interfaces;

namespace Telephony
{
    public class Program
    {
        static void Main(string[] args)
        {
            Smartphone telephone = new Smartphone();
            StationaryPhone stationaryPhone = new StationaryPhone();
            
            string[] phoneNumbers = Console.ReadLine()
                .Split();

            string[] websites = Console.ReadLine()
                .Split();

            foreach (var item in phoneNumbers)
            {
                if (item.Length == 10 && !item.Any(char.IsLetter))
                {
                    telephone.Call(item);
                }
                else if (item.Length == 7 && !item.Any(char.IsLetter))
                {
                    stationaryPhone.Call(item);
                }
                else
                {
                    Console.WriteLine("Invalid number!");
                }
            }

            foreach (var item in websites)
            {
                if (!item.Any(char.IsDigit))
                {
                    telephone.Browse(item);
                }
                else
                {
                    Console.WriteLine("Invalid URL!");
                }
            }
        }
    }
}

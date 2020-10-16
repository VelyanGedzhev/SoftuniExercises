using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericBoxOfString
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<double> values = new List<double>();
            
            for (int i = 0; i < n; i++)
            {
                double input = double.Parse(Console.ReadLine());
                //string input = Console.ReadLine();
                values.Add(input);
            }

            //int[] swapInfo = Console.ReadLine()
            //    .Split()
            //    .Select(int.Parse)
            //    .ToArray();
            //int firstIndex = swapInfo[0];
            //int secondIndex = swapInfo[1];
            double comparator = double.Parse(Console.ReadLine());
            Box<double> box = new Box<double>(values);

            Console.WriteLine(box.CountBiggerValues(comparator));
            
            
        }
    }
}

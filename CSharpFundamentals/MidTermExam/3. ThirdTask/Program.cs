using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace _3._ThirdTask
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> sequence = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            double averageValue = sequence.Sum() * 1.0 / sequence.Count;
            

            List<int> result = new List<int>();

            for (int i = 0; i < sequence.Count; i++)
            {

                if (sequence[i] > averageValue)
                {
                    result.Add(sequence[i]);
                }
            }
            List<int> sortedList = new List<int>();
            if (result.Count > 5)
            {
                List<int> ascendingOrder = result.OrderByDescending(x => x).ToList();
                ascendingOrder.RemoveRange(5, ascendingOrder.Count - 5);
                sortedList = ascendingOrder.OrderByDescending(x => x).ToList();
            }
            else
            {
                sortedList = result.OrderByDescending(x => x).ToList();
            }

            if (sortedList.Count > 0)
            {
                Console.WriteLine(String.Join(" ", sortedList));
            }
            else
            {
                Console.WriteLine("No");
            }
           
        }
    }
}

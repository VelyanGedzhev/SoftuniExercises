using System;
using System.Linq;

namespace _3.CustomMinFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Func<int[], int> minNum = GetMin;

            //Func<int[], int> minNum = nums =>
            //{
            //    int min = int.MaxValue;

            //    foreach (var num in numbers)
            //    {
            //        if (num < min)
            //        {
            //            min = num;
            //        }
            //    }
            //    return min;
            //};
            Console.WriteLine(minNum(numbers));
        }
        static int GetMin(int[] numbers)
        {
            int min = int.MaxValue;

            foreach (var num in numbers)
            {
                if (num < min)
                {
                    min = num;
                }
            }
            return min;
        }
    }
}

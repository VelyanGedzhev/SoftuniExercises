using System;
using System.Linq;

namespace _1._Sort_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int maxValue = int.MinValue;
            int middleValue = int.MinValue;
            int minValue = int.MinValue;

            for (int i = 0; i < 3; i++)
            {
                int numberToCheck = int.Parse(Console.ReadLine());
                if (numberToCheck > maxValue)
                {
                    minValue = middleValue;
                    middleValue = maxValue;
                    maxValue = numberToCheck;
                }
                else if (numberToCheck > middleValue)
                {
                    minValue = middleValue;
                    middleValue = numberToCheck;
                }
                else if (numberToCheck > minValue)
                {
                    minValue = numberToCheck;
                }

            }
            Console.WriteLine(maxValue);
            Console.WriteLine(middleValue);
            Console.WriteLine(minValue);


        }
    }
}

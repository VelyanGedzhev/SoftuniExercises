using System;

namespace _9._SpiceMustFlow
{
    class Program
    {
        static void Main(string[] args)
        {
            int startingYield = int.Parse(Console.ReadLine());
            int yieldPerDay = startingYield;
            int totalYield = 0;
            int days = 0;

            while (yieldPerDay >= 100)
            {
                totalYield += yieldPerDay;
                days++;
                yieldPerDay -= 10;
                totalYield -= 26;
            }
            if (totalYield >= 26)
            {
                totalYield -= 26;
            }
            Console.WriteLine(days);
            Console.WriteLine(totalYield);
        }
    }
}

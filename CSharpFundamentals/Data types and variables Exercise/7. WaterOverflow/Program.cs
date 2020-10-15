using System;

namespace _7._WaterOverflow
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            int totalLiters = 0;
            int capacity = 255;

            for (int i = 0; i < count; i++)
            {
                int liters = int.Parse(Console.ReadLine());
                if(capacity >= liters)
                {
                    totalLiters += liters;
                    capacity -= liters;
                }
                else
                {
                    Console.WriteLine("Insufficient capacity!");
                }
            }
            Console.WriteLine(totalLiters);
        }
    }
}

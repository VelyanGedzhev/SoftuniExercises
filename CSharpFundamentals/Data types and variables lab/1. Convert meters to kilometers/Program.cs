using System;

namespace _1._Convert_meters_to_kilometers
{
    class Program
    {
        static void Main(string[] args)
        {
            int meters = int.Parse(Console.ReadLine());

            double kilometers = meters *1.0 / 1000.0;

            Console.WriteLine($"{kilometers:f2}");
        }
    }
}

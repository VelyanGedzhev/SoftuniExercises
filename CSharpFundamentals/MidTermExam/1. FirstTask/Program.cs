using System;

namespace _1._FirstTask
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstEmployee = int.Parse(Console.ReadLine());
            int secondEmployee = int.Parse(Console.ReadLine());
            int thirdtEmployee = int.Parse(Console.ReadLine());
            int studentsCount = int.Parse(Console.ReadLine());

            int fullEfficiency = firstEmployee + secondEmployee + thirdtEmployee;
            int hours = 0;

            while(studentsCount > 0)
            {
                studentsCount -= fullEfficiency;
                hours++;

                if (hours % 4 == 0)
                {
                    hours++;
                }
            }

            Console.WriteLine($"Time needed: {hours}h.");

        }
    }
}

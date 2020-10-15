using System;

namespace _1.NationalCourt
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstEfficiency = int.Parse(Console.ReadLine());
            int secondEfficiency = int.Parse(Console.ReadLine());
            int thirdEfficiency = int.Parse(Console.ReadLine());
            int peopleCount = int.Parse(Console.ReadLine());

            int totalEfficiency = firstEfficiency + secondEfficiency + thirdEfficiency;
            int time = 0;
            

            while (peopleCount > 0)
            {
                time++;
                peopleCount -= totalEfficiency;

                if (time % 4 == 0)
                {
                    time++;
                }
            }
            Console.WriteLine($"Time needed: {time}h.");
        }
    }
}

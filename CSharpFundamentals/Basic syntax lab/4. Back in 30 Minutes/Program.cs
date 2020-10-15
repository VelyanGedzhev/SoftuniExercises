using System;

namespace _4._Back_in_30_Minutes
{
    class Program
    {
        static void Main(string[] args)
        {
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());

            int currentMinutes = minutes + 30;
            if(currentMinutes > 59)
            {
                hours++;
                currentMinutes -= 60;
            }
            if(hours > 23)
            {
                hours -= 24;
            }
            Console.WriteLine($"{hours}:{currentMinutes:d2}");
        }
    }
}

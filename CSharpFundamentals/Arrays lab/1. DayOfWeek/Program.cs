using System;

namespace _1._DayOfWeek
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] days = new string[7] {
                "Monday", 
                "Tuesday",
                "Wednesday",
                "Thursday",
                "Friday",
                "Saturday",
                "Sunday"
            };
            int currentDay = int.Parse(Console.ReadLine());
            if (currentDay < 1 || currentDay > 7)
            {
                Console.WriteLine("Invalid day!");
            }
            else
            {
                Console.WriteLine(days[currentDay-1]);
            }
        }
    }
}

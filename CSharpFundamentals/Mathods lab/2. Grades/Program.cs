using System;

namespace _2._Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            double input = double.Parse(Console.ReadLine());
            Grade(input);
        }
        static void Grade (double number)
        {
            if (number >= 2.0 && number <= 2.99)
            {
                Console.WriteLine("Fail");
            }
            else if (number >= 3.00 && number <= 3.49)
            {
                Console.WriteLine("Poor");
            }
            else if (number >= 3.5 && number <= 4.49)
            {
                Console.WriteLine("Good");
            }
            else if (number >= 4.5 && number <= 5.49)
            {
                Console.WriteLine("Very good");
            }
            else if(number >= 5.5 && number <= 6.0)
            {
                Console.WriteLine("Excellent");
            }
        }
    }
}

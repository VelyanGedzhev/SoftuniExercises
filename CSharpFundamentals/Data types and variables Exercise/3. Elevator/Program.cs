using System;

namespace _3._Elevator
{
    class Program
    {
        static void Main(string[] args)
        {
            int peopleCount = int.Parse(Console.ReadLine());
            int capacity = int.Parse(Console.ReadLine());

            int courses = 0;
            if(peopleCount % capacity == 0)
            {
                courses = peopleCount / capacity;
            }
            else
            {
                courses = peopleCount / capacity + 1;
            }
            Console.WriteLine(courses);
        }
    }
}

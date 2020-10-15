using System;
using System.Linq;

namespace _1._Train
{
    class Program
    {
        static void Main(string[] args)
        {
            int wagonsCount = int.Parse(Console.ReadLine());
            int[] passangers = new int[wagonsCount];
            int sum = 0;

            for (int i = 0; i < wagonsCount; i++)
            {
                passangers[i] = int.Parse(Console.ReadLine());
                sum += passangers[i];
            }
            Console.WriteLine(String.Join(" ", passangers));
            Console.WriteLine(sum);
        }
    }
}

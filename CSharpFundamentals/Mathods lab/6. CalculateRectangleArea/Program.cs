using System;

namespace _6._CalculateRectangleArea
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());

            Console.WriteLine(RectangleArea(a, b));
        }
        static int RectangleArea(int a, int b)
        {
            return a * b;
        }
    }
}

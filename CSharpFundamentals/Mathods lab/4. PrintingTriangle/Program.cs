using System;

namespace _4._PrintingTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            PrintingTriangle(n);
        }
        static void PrintingLine(int start, int end)
        {
            for (int i = start; i <= end; i++)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }
        static void PrintingTriangle(int end)
        {
            for (int i = 1; i <= end; i++)
            {
                PrintingLine(1, i);
            }
            for (int i = end-1; i > 0; i--)
            {
                PrintingLine(1, i);
            }
        }
    }
}


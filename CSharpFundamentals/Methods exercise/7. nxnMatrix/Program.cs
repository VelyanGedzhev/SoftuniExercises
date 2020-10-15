using System;

namespace _7._nxnMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintMatrix(int.Parse(Console.ReadLine()));
        }
        static void PrintMatrix (int count)
        {
            for (int i = 0; i < count; i++)
            {

                for (int j = 0; j < count; j++)
                {
                    Console.Write(count + " ");
                }
                Console.WriteLine();
            }
        }
    }
}

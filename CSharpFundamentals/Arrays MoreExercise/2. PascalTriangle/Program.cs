using System;

namespace _2._PascalTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int number = 1;
            
            for (int i = 0; i < rows; i++)
            {
                
                for (int j = 0; j <= i; j++)
                {
                    if (j == 0 || i == 0)
                    {
                        number = 1;
                    }
                    else
                    {
                        number = number * (i - j + 1) / j;
                    }
                    Console.Write(number + " ");
                }
                Console.WriteLine();
            }

        }
    }
}

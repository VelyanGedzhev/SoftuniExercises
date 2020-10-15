using System;

namespace _7.PascalTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            long[][] jagged = new long[n][];
            int cols = 1;

            for (int row = 0; row < jagged.Length; row++)
            {
                jagged[row] = new long[cols];
                jagged[row][0] = 1;
                jagged[row][jagged[row].Length - 1] = 1;

                if (row > 1)
                {
                    for (int col = 1; col < jagged[row].Length - 1; col++)
                    {
                        long[] previuosRow = jagged[row - 1];
                        long firstNum = previuosRow[col];
                        long secondNum = previuosRow[col - 1];
                        jagged[row][col] = firstNum + secondNum;
                    }
                }
                cols++;
            }

            for (int row = 0; row < jagged.Length; row++)
            {
                for (int col = 0; col < jagged[row].Length; col++)
                {
                    Console.Write(jagged[row][col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}

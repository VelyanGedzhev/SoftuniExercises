using System;
using System.Linq;

namespace _1.DiagonalDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = ReadMatrix(n, n);

            int primarySum = 0;
            int secondarySum = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                primarySum += matrix[i, i];
            }
            int row = 0;
            for (int i = matrix.GetLength(1) - 1; i >= 0; i--)
            {
                secondarySum += matrix[row,i];
                row++;
            }
            int difference = Math.Abs(primarySum - secondarySum);
            Console.WriteLine(difference);
        }
        public static int[,] ReadMatrix(int rows, int cols)
        {
            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            return matrix;
        }
    }
}

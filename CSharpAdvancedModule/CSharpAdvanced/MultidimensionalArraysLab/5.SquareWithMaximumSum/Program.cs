using System;
using System.Linq;

namespace _5.SquareWithMaximumSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine()
               .Split(", ", StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToArray();

            int rows = sizes[0];
            int cols = sizes[1];
            int max = int.MinValue;
            int maxRow = 0;
            int maxCol = 0;

            int[,] matrix = ReadMatrix(rows, cols);

            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    int sum = matrix[row, col] + matrix[row + 1, col]
                        + matrix[row, col + 1] 
                        + matrix[row + 1, col + 1];

                    if (sum > max)
                    {
                        max = sum;
                        maxRow = row;
                        maxCol = col;
                    }
                }
            }
            Console.WriteLine(matrix[maxRow, maxCol] + " " + matrix[maxRow, maxCol + 1]);
            Console.WriteLine(matrix[maxRow + 1, maxCol] + " " + matrix[maxRow + 1, maxCol + 1]);
            Console.WriteLine(max);
        }
        public static int[,] ReadMatrix(int rows, int cols)
        {
            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] rowData = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowData[col];
                }
            }

            return matrix;
        }

    }
}

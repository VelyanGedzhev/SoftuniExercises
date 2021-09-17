using System;
using System.Linq;

namespace _5.SnakeMoves
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

            int rows = input[0];
            int cols = input[1];

            char[,] matrix = new char[rows,cols];
            string snakeName = Console.ReadLine();
            int currentLetter = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                if (row % 2 == 0)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        currentLetter = FillMatrix(matrix, snakeName, currentLetter, row, col);
                    }
                }
                else
                {
                    for (int col = matrix.GetLength(1) - 1; col >= 0; col--)
                    {
                        currentLetter = FillMatrix(matrix, snakeName, currentLetter, row, col);
                    }
                }
                
            }
            PrintMatrix(matrix);
        }

        private static int FillMatrix(char[,] matrix, string snakeName, int currentLetter, int row, int col)
        {
            matrix[row, col] = snakeName[currentLetter];
            currentLetter++;

            if (currentLetter == snakeName.Length)
            {
                currentLetter = 0;
            }

            return currentLetter;
        }

        public static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}

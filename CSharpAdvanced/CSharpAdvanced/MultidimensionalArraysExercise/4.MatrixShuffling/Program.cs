using System;
using System.Linq;

namespace _4.MatrixShuffling
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

            string[,] matrix = ReadMatrix(rows, cols);
            string input2 = string.Empty;
            while ((input2 = Console.ReadLine()) != "END")
            {
                
                string[] command = input2
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (command.Length != 5)
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }
                int row1 = int.Parse(command[1]);
                int col1 = int.Parse(command[2]);
                int row2 = int.Parse(command[3]);
                int col2 = int.Parse(command[4]);

                if (command[0] != "swap" ||
                    (row1 >= rows || row1 < 0) ||
                    (row2 >= rows || row2 < 0) ||
                    (col1 >= cols || col1 < 0) ||
                    (col2 >= cols || col2 < 0))
                {
                    Console.WriteLine("Invalid input!");
                }
                else
                {
                    string firstToSwap = matrix[row1, col1];
                    matrix[row1, col1] = matrix[row2, col2];
                    matrix[row2, col2] = firstToSwap;
                    for (int row = 0; row < matrix.GetLength(0); row++)
                    {
                        for (int col = 0; col < matrix.GetLength(1); col++)
                        {
                            Console.Write(matrix[row,col] + " " );
                        }
                        Console.WriteLine();
                    }
                }
            }

        }
        public static string[,] ReadMatrix(int rows, int cols)
        {
            string[,] matrix = new string[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            return matrix;
        }
    }
}

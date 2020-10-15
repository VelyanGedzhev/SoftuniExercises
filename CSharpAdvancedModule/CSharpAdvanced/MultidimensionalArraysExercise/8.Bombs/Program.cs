using System;
using System.Linq;

namespace _8.Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] bombField = ReadMatrix(n);
            string[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < input.Length; i++)
            {
                int[] bomb = input[i]
                    .Split(',')
                    .Select(int.Parse)
                    .ToArray();
                int bombRow = bomb[0];
                int bombCol = bomb[1];
                int bombPower = bombField[bombRow, bombCol];

                

            }
                
        }
        public static int[,] ReadMatrix(int n)
        {
            int[,] matrix = new int[n, n];
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

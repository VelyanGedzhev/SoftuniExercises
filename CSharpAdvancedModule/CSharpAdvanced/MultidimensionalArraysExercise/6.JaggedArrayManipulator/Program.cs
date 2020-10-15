using System;
using System.Linq;

namespace _6.JaggedArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            double[][] jagged = new double[n][];

            for (int row = 0; row < jagged.GetLength(0); row++)
            {
                double[] input = Console.ReadLine()
                    .Split()
                    .Select(double.Parse)
                    .ToArray();

                jagged[row] = input;
            }
            for (int row = 0; row < jagged.GetLength(0) - 1; row++)
            {
                if (jagged[row].Length == jagged[row + 1].Length)
                {
                    for (int col = 0; col < jagged[row].Length; col++)
                    {
                        jagged[row][col] *= 2;
                        jagged[row + 1][col] *= 2;
                    }
                }
                else
                {
                    for (int col = 0; col < jagged[row].Length; col++)
                    {
                        jagged[row][col] /= 2;
                    }
                    for (int col = 0; col < jagged[row + 1].Length; col++)
                    {
                        jagged[row + 1][col] /= 2;
                    }
                }
            }

            string input2 = string.Empty;
            while ((input2 = Console.ReadLine()) != "End")
            {
                string[] command = input2.Split();
                int row = 0;
                int col = 0;
                int value = 0;
                if (command.Length == 4)
                {
                    row = int.Parse(command[1]);
                    col = int.Parse(command[2]);
                    value = int.Parse(command[3]);
                }
                if (row < jagged.GetLength(0) && row >= 0)
                {
                    if (col < jagged[row].Count() && col >= 0)
                    {
                        if (command[0] == "Add")
                        {
                            jagged[row][col] += value;
                        }
                        else if (command[0] == "Subtract")
                        {
                            jagged[row][col] -= value;
                        }
                    }
                }
            }
            foreach (var item in jagged)
            {
                Console.WriteLine(string.Join(" ", item));
            }
        }
    }
}

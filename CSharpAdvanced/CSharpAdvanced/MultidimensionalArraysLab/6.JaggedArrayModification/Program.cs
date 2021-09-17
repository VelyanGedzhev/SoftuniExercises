using System;
using System.Linq;

namespace _6.JaggedArrayModification
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            int[][] jagged = new int[rows][];

            for (int row = 0; row < jagged.Length; row++)
            {
                int[] rowData = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                jagged[row] = new int[rowData.Length];

                for (int col = 0; col < rowData.Length; col++)
                {
                    jagged[row][col] = rowData[col];
                }
            }

            string command = Console.ReadLine();
            while (command != "END")
            {
                var splitted = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                int row = int.Parse(splitted[1]);
                int col = int.Parse(splitted[2]);
                int value = int.Parse(splitted[3]);
                bool isInvalid = false;

                if (jagged.Length <= row || row < 0)
                {
                    isInvalid = true;
                }
                else if (jagged[row].Length <= col || col < 0)
                {
                    isInvalid = true;
                }
                if (isInvalid)
                {
                    Console.WriteLine($"Invalid coordinates");
                }
                else
                {
                    if (splitted[0] == "Add")
                    {
                        jagged[row][col] += value;
                    }
                    else if (splitted[0] == "Subtract")
                    {
                        jagged[row][col] -= value;
                    }
                }
                
                command = Console.ReadLine();
            }
            foreach (var row in jagged)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }
    }
}

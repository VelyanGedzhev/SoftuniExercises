using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Garder
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int n = input[0];
            int[,] garden = new int[n, n];
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    garden[row, col] = 0;
                }
            }
            List<Flower> flowers = new List<Flower>();
            string command = string.Empty;

            while ((command = Console.ReadLine()) != "Bloom Bloom Plow")
            {
                int[] inputData = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int row = inputData[0];
                int col = inputData[1];

                if (!IsValidIndex(n, row, col))
                {
                    Console.WriteLine("Invalid coordinates.");
                    continue;
                }
                else
                {
                    Flower currentFlower = new Flower(row, col);
                    flowers.Add(currentFlower);
                }
            }
            foreach (Flower flower in flowers)
            {
                garden[flower.Row, flower.Col]++;
                for (int i = 0; i < garden.GetLength(0); i++)
                {
                    if (i == flower.Row)
                    {
                        continue;
                    }
                    garden[i, flower.Col]++;

                }
                for (int j = 0; j < garden.GetLength(1); j++)
                {
                    if (j == flower.Col)
                    {
                        continue;
                    }
                    garden[flower.Row, j]++;
                }
            }
            Console.WriteLine(PrintGarden(garden));
        }
        private static bool IsValidIndex(int n, int row, int col) 
        {
            if (row < 0 || row < 0)
            {
                return false;
            }
            if (row > n - 1 || col > n - 1)
            {
                return false;
            }
            return true;
        }
        private static string PrintGarden(int[,] garden)
        {
            StringBuilder sb = new StringBuilder();
            for (int row = 0; row < garden.GetLength(0); row++)
            {

                for (int col = 0; col < garden.GetLength(1); col++)
                {
                    sb.Append(garden[row, col] + " ");
                }
                sb.AppendLine();
            }
            return sb.ToString().Trim();
        }
    }
    public class Flower
    {
        public Flower(int row, int col)
        {
            Row = row;
            Col = col;
        }

        public int Row { get; set; }
        public int Col { get; set; }
    }
}

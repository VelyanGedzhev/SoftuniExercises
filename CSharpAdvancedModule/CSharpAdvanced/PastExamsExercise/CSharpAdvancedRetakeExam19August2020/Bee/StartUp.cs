using System;

namespace Bee
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int pollinatedFlowers = 0;
            char[,] territory = new char[n, n];
            int beeRow = -1;
            int beeCol = -1;

            for (int row = 0; row < n; row++)
            {
                string rowData = Console.ReadLine();

                for (int col = 0; col < n; col++)
                {
                    territory[row, col] = rowData[col];

                    if (territory[row, col] == 'B')
                    {
                        beeRow = row;
                        beeCol = col;
                    }
                }
            }
            string command = Console.ReadLine();
          
            while (command != "End")
            {
                territory[beeRow, beeCol] = '.';
                if (command == "left")
                {
                    beeCol--;
                }
                if (command == "right")
                {
                    beeCol++;
                }
                if (command == "up")
                {
                    beeRow--;
                }
                if (command == "down")
                {
                    beeRow++;
                }
                if (!IsValid(territory, beeRow, beeCol))
                {
                    Console.WriteLine($"The bee got lost!");

                    break;
                }
                if (territory[beeRow, beeCol] == 'f')
                {
                    pollinatedFlowers++;
                }
                else if (territory[beeRow, beeCol] == 'O')
                {
                    continue;
                }
               
                territory[beeRow, beeCol] = 'B';
               
                command = Console.ReadLine();
            }
            if (pollinatedFlowers >= 5)
            {
                Console.WriteLine($"Great job, the bee managed to pollinate {pollinatedFlowers} flowers!");
            }
            else
            {
                Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {5 -pollinatedFlowers} flowers more");
            }
            PrintTerritory(territory);
        }
        public static bool IsValid(char[,] territory, int beeRow, int beeCol)
        {
            if (beeRow < 0 || beeCol < 0)
            {
                return false;
            }
            if (beeRow >= territory.GetLength(0) || beeCol >= territory.GetLength(1))
            {
                return false;
            }
            return true;
        }
        public static void PrintTerritory(char[,] territory)
        {
            for (int row = 0; row < territory.GetLength(0); row++)
            {

                for (int col = 0; col < territory.GetLength(1); col++)
                {
                    Console.Write(territory[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}

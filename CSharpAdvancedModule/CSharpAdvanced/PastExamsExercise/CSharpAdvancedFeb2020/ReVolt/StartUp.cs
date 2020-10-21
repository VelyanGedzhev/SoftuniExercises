using System;

namespace ReVolt
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int commandsCount = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];
            int playerRow = -1;
            int playerCol = -1;

            for (int row = 0; row < n; row++)
            {
                string rowData = Console.ReadLine();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = rowData[col];
                    if (matrix[row, col] == 'f')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }
            string command = Console.ReadLine();
            int counter = 0;
            matrix[playerRow, playerCol] = '-';
            while (true)
            {
                counter++;
                if (command == "up")
                {
                    playerRow--;
                }
                else if (command == "down")
                {
                    playerRow++;
                }
                else if (command == "left")
                {
                    playerCol--;
                }
                else if (command == "right")
                {
                    playerCol++;
                }
                playerRow = IsValidRow(n, playerRow);
                playerCol = IsValidCol(n, playerCol);

                if (matrix[playerRow, playerCol] == 'B')
                {
                    counter--;
                    continue;
                }
                else if (matrix[playerRow, playerCol] == 'T')
                {
                    command = Trap(command);
                    counter--;
                    continue;
                }
                if (matrix[playerRow, playerCol] == 'F')
                {
                    Console.WriteLine($"Player won!");
                    matrix[playerRow, playerCol] = 'f';
                    break;
                }
                if (counter == commandsCount)
                {
                    Console.WriteLine("Player lost!");
                    matrix[playerRow, playerCol] = 'f';
                    break;
                }
                //Print(matrix);
                command = Console.ReadLine();
            }
            Print(matrix);
        }
        public static string Trap(string command)
        {
            string newCommand = string.Empty;

            if (command == "up")
            {
                newCommand = "down";
            }
            else if (command == "down")
            {
                newCommand = "up";
            }
            else if (command == "left")
            {
                newCommand = "right";
            }
            else if (command == "right")
            {
                newCommand = "left";
            }
            return newCommand;
        }
        public static int IsValidRow(int n, int playerRow)
        {
            if (playerRow == n)
            {
                playerRow -= n;
                
            }
            else if (playerRow < 0)
            {
                playerRow += n;
                
            }
            return playerRow;
            
        }
        public static int IsValidCol(int n, int playerCol)
        {
            if (playerCol == n)
            {
                playerCol -= n;
                
            }
            else if (playerCol < 0)
            {
                playerCol += n;
                
            }
            return playerCol;
        }
        public static void Print(char[,] matrix)
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

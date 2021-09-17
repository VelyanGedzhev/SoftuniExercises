using System;

namespace BookWorm
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string initialString = Console.ReadLine();
            int n = int.Parse(Console.ReadLine());
            string[,] field = new string[n, n];
            int playerRow = -1;
            int playerCol = -1;
            

            for (int row = 0; row < n; row++)
            {
                string rowData = Console.ReadLine();

                for (int col  = 0; col  < n; col ++)
                {
                    field[row, col] = rowData[col].ToString();
                    if (field[row, col] == "P")
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }

            string command = string.Empty;
            field[playerRow, playerCol] = "-";

            while ((command = Console.ReadLine()) != "end")
            {
                int currentRow = playerRow;
                int currentCol = playerCol;

                switch (command)
                {
                    case "up":
                        playerRow--;
                        break;
                    case "down":
                        playerRow++;
                        break;
                    case "left":
                        playerCol--;
                        break;
                    case "right":
                        playerCol++;
                        break;
                    default:
                        break;
                }
                
                if (IsInField(field, playerRow, playerCol))
                {
                    if (field[playerRow, playerCol] != "-")
                    {
                        string stringToConcat = field[playerRow, playerCol];
                        initialString = initialString + stringToConcat;
                        field[playerRow, playerCol] = "-";
                    }
                }
                else
                {
                    if (initialString.Length > 0)
                    {
                        initialString = initialString.Remove(initialString.Length - 1, 1);
                        playerRow = currentRow;
                        playerCol = currentCol;
                    }
                }
                //Console.WriteLine();
                //Print(field);
            }
            field[playerRow, playerCol] = "P";
            Console.WriteLine(initialString);
            Print(field);

        }
        private static bool IsInField(string[,] field, int playerRow, int playerCol)
        {
            if (playerRow < 0 || playerCol < 0)
            {
                return false;
            }
            if (playerRow >= field.GetLength(0) || playerCol >= field.GetLength(1))
            {
                return false;
            }
            return true;
        }
        private static void Print(string[,] field)
        {
            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    Console.Write(field[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}

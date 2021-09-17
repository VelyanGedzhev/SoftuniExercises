using System;
using System.Collections.Generic;
using System.Linq;

namespace TronRacers
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];
            Player firstPlayer = new Player(0, 0, 'f');
            Player secondPlayer = new Player(0, 0, 's');
            List<Player> players = new List<Player>();
            players.Add(firstPlayer);
            players.Add(secondPlayer);

            for (int row = 0; row < n; row++)
            {
                string rowData = Console.ReadLine();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = rowData[col];

                    if (matrix[row, col] == 'f')
                    {
                        firstPlayer.Row = row;
                        firstPlayer.Col = col;
                    }
                    else if (matrix[row, col] == 's')
                    {
                        secondPlayer.Row = row;
                        secondPlayer.Col = col;
                    }
                }
            }

            while (firstPlayer.IsAlive && secondPlayer.IsAlive)
            {
                string[] command = Console.ReadLine().Split();
                string firstPlayerCommand = command[0];
                string secondPlayerCommand = command[1];

                int firstRow = firstPlayer.Row;
                int firstCol = firstPlayer.Col;

                int secondRow = secondPlayer.Row;
                int secondCol = secondPlayer.Col;

                Command(firstPlayerCommand,ref firstRow,ref firstCol, matrix);
                ChechIndexValidity(ref firstRow, ref firstCol, matrix);
                ChechCurrentCell(firstRow, firstCol, ref matrix, firstPlayer.PlayerSign, ref players);

                if (!firstPlayer.IsAlive)
                {
                    break;
                }


                Command(secondPlayerCommand,ref secondRow, ref secondCol, matrix);
                ChechIndexValidity(ref secondRow, ref secondCol, matrix);
                ChechCurrentCell(secondRow, secondCol, ref matrix, secondPlayer.PlayerSign, ref players);
            }
            PrintMatrix(matrix);
        }
        private static void Command(string command, ref int row, ref int col, char[,] matrix)
        {
            if (command == "up")
            {
                row--;
            }
            if (command == "down")
            {
                row++;
            }
            if (command == "left")
            {
                col--;
            }
            if (command == "right")
            {
                col++;
            }
        }
        private static void ChechIndexValidity(ref int row, ref int col, char[,] matrix)
        {
            if (row < 0)
            {
                row = matrix.GetLength(0) - 1;
            }
            if (row >= matrix.GetLength(0))
            {
                row = 0;
            }
            if (col < 0)
            {
                col = matrix.GetLength(1) - 1;
            }
            if (col >= matrix.GetLength(1))
            {
                col = 0;
            }
        }
        private static void ChechCurrentCell (int row, int col, ref char[,] matrix, char playerSing, ref List<Player> players)
        {
            Player player = players.FirstOrDefault(p => p.PlayerSign == playerSing);

            if (matrix[row, col] == '*')
            {
                matrix[row, col] = player.PlayerSign;
                players.FirstOrDefault(p => p.PlayerSign == player.PlayerSign).Row = row;
                players.FirstOrDefault(p => p.PlayerSign == player.PlayerSign).Col = col;
            }
            else if (matrix[row, col] != player.PlayerSign)
            {
                matrix[row, col] = 'x';
                players.FirstOrDefault(p => p.PlayerSign == player.PlayerSign).IsAlive = false;
            }
        }
        private static void PrintMatrix(char[,] matrix)
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
    public class Player
    {
        public Player()
        {
            IsAlive = true;
        }

        public Player(int row, int col, char playerSign) : this()
        {
            Row = row;
            Col = col;
            PlayerSign = playerSign;
        }

        public int Row { get; set; }
        public int Col { get; set; }
        public char PlayerSign { get; set; }
        public bool IsAlive { get; set; }
    }
}
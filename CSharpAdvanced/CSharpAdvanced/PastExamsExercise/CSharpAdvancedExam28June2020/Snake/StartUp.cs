using System;
using System.Collections.Generic;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());
            char[,] territory = new char[n, n];
            int foodQuantity = 0;
            int snakeRow = 0;
            int snakeCol = 0;

            for (int row = 0; row < n; row++)
            {
                char[] rowInfo = Console.ReadLine().ToCharArray();

                for (int col = 0; col < n; col++)
                {
                    territory[row, col] = rowInfo[col];
                    if (territory[row, col] == 'S')
                    {
                        snakeRow = row;
                        snakeCol = col;
                    }
                }
            }
            string command = Console.ReadLine();
            bool isOver = false;

            while (foodQuantity != 10)
            {
                switch (command)
                {
                    case "left":
                        if (snakeCol - 1 >= 0)
                        {
                            if (territory[snakeRow, snakeCol - 1] == '*')
                            {
                                foodQuantity++;
                                territory[snakeRow, snakeCol - 1] = 'S';
                                territory[snakeRow, snakeCol] = '.';
                                snakeCol = snakeCol - 1;
                            }
                            else if (territory[snakeRow, snakeCol - 1] == 'B')
                            {
                                territory[snakeRow, snakeCol - 1] = '.';
                                for (int row = 0; row < n; row++)
                                {
                                    for (int col = 0; col < n; col++)
                                    {
                                        if (territory[row, col] == 'B')
                                        {
                                            territory[row, col] = 'S';
                                            territory[snakeRow, snakeCol] = '.';
                                            snakeRow = row;
                                            snakeCol = col;
                                            break;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                territory[snakeRow, snakeCol - 1] = 'S';
                                territory[snakeRow, snakeCol] = '.';
                                snakeCol = snakeCol - 1;
                            }

                        }
                        else
                        {

                            isOver = true;
                            territory[snakeRow, snakeCol] = '.';
                        }
                        break;

                    case "right":
                        if (snakeCol + 1 < n)
                        {
                            if (territory[snakeRow, snakeCol + 1] == '*')
                            {
                                foodQuantity++;
                                territory[snakeRow, snakeCol + 1] = 'S';
                                territory[snakeRow, snakeCol] = '.';
                                snakeCol = snakeCol + 1;
                            }
                            else if (territory[snakeRow, snakeCol + 1] == 'B')
                            {
                                territory[snakeRow, snakeCol + 1] = '.';
                                for (int row = 0; row < n; row++)
                                {
                                    for (int col = 0; col < n; col++)
                                    {
                                        if (territory[row, col] == 'B')
                                        {
                                            territory[row, col] = 'S';
                                            territory[snakeRow, snakeCol] = '.';
                                            snakeRow = row;
                                            snakeCol = col;
                                            break;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                territory[snakeRow, snakeCol + 1] = 'S';
                                territory[snakeRow, snakeCol] = '.';
                                snakeCol = snakeCol + 1;
                            }
                        }
                        else
                        {
                            isOver = true;
                            territory[snakeRow, snakeCol] = '.';
                        }
                        break;

                    case "up":
                        if (snakeRow - 1 >= 0)
                        {
                            if (territory[snakeRow - 1, snakeCol] == '*')
                            {
                                foodQuantity++;
                                territory[snakeRow - 1, snakeCol] = 'S';
                                territory[snakeRow, snakeCol] = '.';
                                snakeRow = snakeRow - 1;
                            }
                            else if (territory[snakeRow - 1, snakeCol] == 'B')
                            {
                                territory[snakeRow - 1, snakeCol] = '.';
                                for (int row = 0; row < n; row++)
                                {
                                    for (int col = 0; col < n; col++)
                                    {
                                        if (territory[row, col] == 'B')
                                        {
                                            territory[row, col] = 'S';
                                            territory[snakeRow, snakeCol] = '.';
                                            snakeRow = row;
                                            snakeCol = col;
                                            break;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                territory[snakeRow - 1, snakeCol] = 'S';
                                territory[snakeRow, snakeCol] = '.';
                                snakeRow = snakeRow - 1;
                            }

                        }
                        else
                        {
                            isOver = true;
                            territory[snakeRow, snakeCol] = '.';
                        }
                        break;

                    case "down":
                        if (snakeRow + 1 < n)
                        {
                            if (territory[snakeRow + 1, snakeCol] == '*')
                            {
                                foodQuantity++;
                                territory[snakeRow + 1, snakeCol] = 'S';
                                territory[snakeRow, snakeCol] = '.';
                                snakeRow = snakeRow + 1;
                            }
                            else if (territory[snakeRow + 1, snakeCol] == 'B')
                            {
                                territory[snakeRow + 1, snakeCol] = '.';
                                for (int row = 0; row < n; row++)
                                {
                                    for (int col = 0; col < n; col++)
                                    {
                                        if (territory[row, col] == 'B')
                                        {
                                            territory[row, col] = 'S';
                                            territory[snakeRow, snakeCol] = '.';
                                            snakeRow = row;
                                            snakeCol = col;
                                            break;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                territory[snakeRow + 1, snakeCol] = 'S';
                                territory[snakeRow, snakeCol] = '.';
                                snakeRow = snakeRow + 1;
                            }
                        }
                        else
                        {
                            isOver = true;
                            territory[snakeRow, snakeCol] = '.';
                        }

                        break;
                }

                if (isOver == true || foodQuantity == 10)
                {
                    break;
                }

                command = Console.ReadLine();
            }
            if (foodQuantity >= 10)
            {
                Console.WriteLine("You won! You fed the snake.");
            }
            else if (isOver)
            {
                Console.WriteLine("Game over!");
            }
            Console.WriteLine($"Food eaten: {foodQuantity}");

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write(territory[row, col]);
                }
                Console.WriteLine();
            }

        }
    }
}

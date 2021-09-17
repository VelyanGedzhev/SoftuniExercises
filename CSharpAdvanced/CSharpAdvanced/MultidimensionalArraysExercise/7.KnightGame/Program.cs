using System;

namespace _7.KnightGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] chessBoard = ReadMatrix(n);

            //PrintMatrix(chessBoard);
            int replacedKnights = 0;
            int knightRow = 0;
            int knightCol = 0;

            while (true)
            {
                int maxAttacks = 0;
                for (int row = 0; row < chessBoard.GetLength(0); row++)
                {
                    for (int col = 0; col < chessBoard.GetLength(1); col++)
                    {
                        char currentSymbol = chessBoard[row, col];
                        int currentAttacks = 0;
                        if (currentSymbol == 'K')
                            currentAttacks = IsAttacking(chessBoard, row, col, currentAttacks);
                        if (currentAttacks > maxAttacks)
                        {
                            maxAttacks = currentAttacks;
                            knightRow = row;
                            knightCol = col;
                        }
                    }
                }
                if (maxAttacks > 0)
                {
                    chessBoard[knightRow, knightCol] = '0';
                    replacedKnights++;
                }
                else 
                {
                    Console.WriteLine(replacedKnights);
                    break;
                }
            }

        }

        private static int IsAttacking(char[,] chessBoard, int row, int col, int currentAttacks)
        {
            {
                if (IsInside(chessBoard, row - 2, col + 1) && chessBoard[row - 2, col + 1] == 'K')
                {
                    currentAttacks++;
                }
                if (IsInside(chessBoard, row - 2, col - 1) && chessBoard[row - 2, col - 1] == 'K')
                {
                    currentAttacks++;
                }
                if (IsInside(chessBoard, row + 1, col + 2) && chessBoard[row + 1, col + 2] == 'K')
                {
                    currentAttacks++;
                }
                if (IsInside(chessBoard, row + 1, col - 2) && chessBoard[row + 1, col - 2] == 'K')
                {
                    currentAttacks++;
                }
                if (IsInside(chessBoard, row - 1, col + 2) && chessBoard[row - 1, col + 2] == 'K')
                {
                    currentAttacks++;
                }
                if (IsInside(chessBoard, row - 1, col - 2) && chessBoard[row - 1, col - 2] == 'K')
                {
                    currentAttacks++;
                }
                if (IsInside(chessBoard, row + 2, col - 1) && chessBoard[row + 2, col - 1] == 'K')
                {
                    currentAttacks++;
                }
                if (IsInside(chessBoard, row + 2, col + 1) && chessBoard[row + 2, col + 1] == 'K')
                {
                    currentAttacks++;
                }
            }

            return currentAttacks;
        }

        public static char[,] ReadMatrix(int n)
        {
            char[,] matrix = new char[n, n];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] input = Console.ReadLine().ToCharArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row,col] = input[col];
                }   
            }
            return matrix;
        }
        public static void PrintMatrix(char[,] matrix)
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
        public static bool IsInside(char[,] chessBoard, int targetRow, int targetCol)
        {
            return targetRow >=0 && targetRow < chessBoard.GetLength(0) && targetCol >= 0 && targetCol < chessBoard.GetLength(1);
        }
    }
}

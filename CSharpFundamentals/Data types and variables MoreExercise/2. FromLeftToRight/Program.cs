using System;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace _2._FromLeftToRight
    {
        class Program
        {
            static void Main(string[] args)
            {
                int count = int.Parse(Console.ReadLine());

                for (int i = 0; i < count; i++)
                {
                    long[] num = Console.ReadLine()
                        .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(long.Parse)
                        .ToArray();

                     long leftSide = num[0];
                     long rightSide = num[1];

                    if (leftSide > rightSide)
                    {
                        leftSide = Math.Abs(leftSide);
                        string leftNum = leftSide.ToString();
                        int sum = 0;
                        for (int j = 0; j < leftNum.Length; j++)
                        {
                            double currentDigit = char.GetNumericValue(leftNum[j]);
                            sum += (int)currentDigit;
                        }
                        Console.WriteLine(sum);
                    }
                    else 
                    {
                        rightSide = Math.Abs(rightSide);
                        string rightNum = rightSide.ToString();
                        int sum = 0;
                        for (int j = 0; j < rightNum.Length; j++)
                        {
                            double currentDigit = char.GetNumericValue(rightNum[j]);
                            sum += (int)currentDigit;
                        }
                        Console.WriteLine(sum);
                    }
                }
            }
        }
    }
   
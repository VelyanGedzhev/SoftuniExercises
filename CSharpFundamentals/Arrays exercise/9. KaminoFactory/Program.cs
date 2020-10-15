using System;
using System.Linq;

namespace _9._KaminoFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int bestSum = 0;
            int[] maxArray = new int[num];
            int maxLength = 0;
            int maxIndex = 0;
            int maxSample = 1;
            int currentSample = 0;

            while (true)
            {
                string input = Console.ReadLine();
                if(input == "Clone them!")
                {
                    break;
                }

                int[] array = input
                    .Split("!", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                currentSample++;

                int bestCurrentLength = 0;
                int bestCurrentIndex = 0;
                int bestCurrentSum = 0;
                

                for (int i = 0; i < array.Length; i++)
                {
                    int currentElement = array[i];
                    int currentLength = 1;
                    

                    if (currentElement == 0)
                    {
                        continue;
                    }
                    for (int index = i + 1; index < array.Length; index++)
                    {
                        if (array[index] == 1)
                        {
                            currentLength++;
                        }
                        else
                        {
                            break;
                        }
                    }
                    if (currentLength > bestCurrentLength)
                    {
                        bestCurrentLength = currentLength;
                        bestCurrentIndex = i;
                        bestCurrentSum = array.Sum();
                       
                    }
                }
                if (bestCurrentLength > maxLength || 
                    bestCurrentLength == maxLength && maxIndex > bestCurrentIndex ||
                    maxArray.Sum() < bestCurrentSum)
                {
                    maxIndex = bestCurrentIndex;
                    maxLength = bestCurrentLength;
                    maxArray = array;
                    maxSample = currentSample;
                    bestSum = bestCurrentSum;
                } 
            }
            Console.WriteLine($"Best DNA sample {maxSample} with sum: {maxArray.Sum()}.");
            Console.WriteLine(string.Join(" ", maxArray));

            //---------------------------------------100/100-----------------------------------------//
            //int sequenceLength = int.Parse(Console.ReadLine());
            //string input = Console.ReadLine();

            //int[] bestDNA = new int[sequenceLength];
            //int bestLength = -1;
            //int bestIndex = -1;
            //int bestSum = 0;
            //int sequenceIndex = 0;
            //int counter = 0;


            //while (input != "Clone them!")
            //{
            //    int currentSum = 0;
            //    int currentLength = 0;
            //    int length = 0;
            //    int currrentIndex = 0;
            //    int index = 0;
            //    bool isBetter = false;

            //    int[] currentSequence = input.
            //        Split("!", StringSplitOptions.RemoveEmptyEntries)
            //        .Select(int.Parse)
            //        .ToArray();

            //    counter++;

            //    for (int i = 0; i < currentSequence.Length; i++)
            //    {
            //        //currentsum += currentsequence[i];
            //        //curentsum = currentsequence.sum();
            //        if (currentSequence[i] != 1)
            //        {
            //            length = 0;
            //            continue;
            //        }

            //        length++;

            //        if (currentLength < length)
            //        {
            //            currentLength = length;
            //            index = i;
            //        }
            //    }
            //    currrentIndex = index - 1;
            //    currentSum = currentSequence.Sum();
            //    if (currentLength > bestLength)
            //    {
            //        isBetter = true;
            //    }
            //    else if (currentLength == bestLength)
            //    {
            //        if (currrentIndex < bestIndex)
            //        {
            //            isBetter = true;
            //        }
            //        else if (currrentIndex == bestIndex)
            //        {
            //            if (currentSum > bestSum)
            //            {
            //                isBetter = true;
            //            }
            //        }
            //    }
            //    if (isBetter)
            //    {
            //        bestLength = currentLength;
            //        bestIndex = currrentIndex;
            //        bestSum = currentSum;
            //        bestDNA = currentSequence.ToArray();
            //        sequenceIndex = counter;
            //    }
            //    input = Console.ReadLine();
            //}
            //Console.WriteLine($"Best DNA sample {sequenceIndex} with sum: {bestSum}.");
            //Console.WriteLine(string.Join(" ", bestDNA));
        }
    }
}

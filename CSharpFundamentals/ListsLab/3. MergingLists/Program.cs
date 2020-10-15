using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._MergingLists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> firstList = ReadSingleLine();
            List<int> secondList = ReadSingleLine();
            Console.WriteLine(String.Join(" ", MergeLists(firstList,secondList)));
        }
        static List<int> ReadSingleLine()
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            return numbers;
        }
        static List<int> MergeLists(List<int> firstList, List<int> secondList)
        {
            List<int> result = new List<int>();
            int count = Math.Max(firstList.Count, secondList.Count);

            for (int i = 0; i < count; i++)
            {

                if(firstList.Count > i)
                {
                    result.Add(firstList[i]);
                }

                if(secondList.Count > i)
                {
                    result.Add(secondList[i]);
                }
            }
            return result;
        }
    }
}

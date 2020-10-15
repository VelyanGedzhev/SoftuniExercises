using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._ChangeList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numList = ReadSingleLineIntegers();
            string input = Console.ReadLine();

            while (input != "end")
            {
                List<string> command = input
                    .Split()
                    .ToList();

                if(command[0] == "Delete")
                {
                    int elementToDelete = int.Parse(command[1]);

                    for (int i = 0; i < numList.Count; i++)
                    {
                        if (numList[i] == elementToDelete)
                        {
                            numList.RemoveAt(i);
                            i--;
                        }
                    }
                }
                else if (command[0] == "Insert")
                {
                    int elementToInsert = int.Parse(command[1]);
                    int index = int.Parse(command[2]);

                    numList.Insert(index, elementToInsert);
                }

                input = Console.ReadLine();
            }
            Console.WriteLine(String.Join(" ", numList));
        }
        static List<int> ReadSingleLineIntegers()
        {
           List<int> input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            return input;
        }
    }
}

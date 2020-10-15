using System;
using System.Collections.Generic;
using System.Linq;

namespace _8._AnonymousThreat
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> data = Console.ReadLine()
                .Split()
                .ToList();
            string input = Console.ReadLine();

            while(input != "3:1")
            {
                List<string> command = input
                    .Split()
                    .ToList();

                if (command[0] == "merge")
                {
                    int startIndex = int.Parse(command[1]);
                    int endIndex = int.Parse(command[2]);

                    string concatData = String.Empty;

                    if (startIndex < 0)
                    {
                        if (endIndex >= 0 && endIndex <= data.Count - 1)
                        {
                            startIndex = 0;
                        }
                    }
                    if (endIndex > data.Count - 1)
                    {
                        if (startIndex >= 0 && startIndex <= data.Count -1)
                        {
                            endIndex = data.Count - 1;
                        }
                    }
                    if (startIndex < 0 && endIndex > data.Count -1)
                    {
                        startIndex = 0;
                        endIndex = data.Count - 1;
                    }
                    if ((startIndex >= 0 && startIndex <= data.Count -1) 
                        &&(endIndex >= 0 && endIndex <= data.Count -1))
                    {
                        for (int i = startIndex; i <= endIndex; i++)
                        {
                            concatData += data[i];
                        }
                        data.RemoveRange(startIndex, endIndex - startIndex + 1);
                        data.Insert(startIndex, concatData);
                    }
                }
                else if (command[0] == "divide")
                {
                    int index = int.Parse(command[1]);
                    int partitions = int.Parse(command[2]);

                    if (index >= 0 && index <= data.Count -1)
                    {
                        string word = data[index];
                        List<string> dividedWord = new List<string>();
                        int stringLengthToAdd = word.Length / partitions;

                        int startIndex = 0;
                        for (int i = 0; i < partitions; i++)
                        {
                            if (i == partitions - 1)
                            {
                                dividedWord.Add(word.Substring(startIndex, word.Length - startIndex));
                                startIndex += stringLengthToAdd;
                            }
                            else
                            {
                                dividedWord.Add(word.Substring(startIndex, stringLengthToAdd));
                                startIndex += stringLengthToAdd;
                            }
                        }
                        data.RemoveAt(index);
                        data.InsertRange(index, dividedWord);
                    }
                }
                input = Console.ReadLine();
            }
            Console.WriteLine(String.Join(" ", data));
        }
    }
}

using System;
using System.Linq;

namespace _1.ActivationKeyes
{
    class Program
    {
        static void Main(string[] args)
        {
            string rawKey = Console.ReadLine();
            string command = Console.ReadLine();

            while (command != "Generate")
            {
                if (command.Contains("Contains"))
                {
                    string[] input = command
                        .Split(">>>");
                        
                    string substring = input[1];

                    if (rawKey.Contains(substring))
                    {
                        Console.WriteLine($"{rawKey} contains {substring}");
                    }
                    else
                    {
                        Console.WriteLine("Substring not found!");
                    }
                }
                else if (command.Contains("Flip"))
                {
                    string[] input = command
                        .Split(">>>");

                    string operation = input[1];
                    int startIndex = int.Parse(input[2]);
                    int endIndex = int.Parse(input[3]);
                    string flip = string.Empty;
                    string toFlip = string.Empty;

                    for (int i = startIndex; i <= endIndex - 1; i++)
                    {
                        
                        if (operation == "Upper")
                        {
                            flip += String.Concat(rawKey[i].ToString().ToUpper());
                            toFlip += String.Concat(rawKey[i]);
                        }
                        else
                        {
                            flip += String.Concat(rawKey[i].ToString().ToLower());
                            toFlip += String.Concat(rawKey[i]);
                        }
                    }
                    rawKey = rawKey.Replace(toFlip, flip);
                    Console.WriteLine(rawKey);
                }
                else if (command.Contains("Slice"))
                {
                    string[] input = command
                        .Split(">>>");

                    int startIndex = int.Parse(input[1]);
                    int endIndex = int.Parse(input[2]);
                    rawKey = rawKey.Remove(startIndex,endIndex - startIndex);
                    Console.WriteLine(rawKey);
                }
                command = Console.ReadLine();
            }
            Console.WriteLine($"Your activation key is: {rawKey}");
        }
    }
}

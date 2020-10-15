using System;
using System.Linq;

namespace _1.SecretChat
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string command = Console.ReadLine();

            while (command != "Reveal")
            {
                if (command.Contains("InsertSpace"))
                {
                    string[] operation = command
                        .Split(":|:");
                    int index = int.Parse(operation[1]);

                    input = input.Insert(index, " ");
                    Console.WriteLine(input);
                }
                else if (command.Contains("Reverse"))
                {
                    string[] operation = command
                        .Split(":|:");
                    string substring = operation[1];

                    if (input.Contains(substring))
                    {
                        input = input.Remove(input.IndexOf(substring), substring.Length);
                        var reversed = string.Concat(substring.Reverse());
                        input = input.Insert(input.Length, reversed);
                        Console.WriteLine(input);
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }
                else if (command.Contains("ChangeAll"))
                {
                    string[] operation = command
                        .Split(":|:");
                    string substring = operation[1];
                    string replacement = operation[2];

                    input = input.Replace(substring, replacement);
                    Console.WriteLine(input);
                }
                command = Console.ReadLine();
            }
            Console.WriteLine($"You have a new text message: {input}");
        }
    }
}

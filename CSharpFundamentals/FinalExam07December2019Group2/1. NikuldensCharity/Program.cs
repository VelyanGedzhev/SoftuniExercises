using System;
using System.Text;

namespace _1._NikuldensCharity
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string command = Console.ReadLine();

            while (command != "Finish")
            {
                string[] toDecrypt = command
                    .Split();

                if (command.Contains("Replace"))
                {
                    char currChar = char.Parse(toDecrypt[1]);
                    char newChar = char.Parse(toDecrypt[2]);
                    input = input.Replace(currChar, newChar);
                    Console.WriteLine(input);
                }
                else if (command.Contains("Cut"))
                {
                    int startIndex = int.Parse(toDecrypt[1]);
                    int endIndex = int.Parse(toDecrypt[2]);

                    if (startIndex >= 0 && endIndex >= 0 && endIndex <= input.Length - 1)
                    {
                        input = input.Remove(startIndex, endIndex);
                        Console.WriteLine(input);
                    }
                    else
                    {
                        Console.WriteLine("Invalid indexes!");
                    }
                }
                else if (command.Contains("Make"))
                {
                    string operation = toDecrypt[1];
                    StringBuilder sb = new StringBuilder();

                    for (int i = 0; i < input.Length; i++)
                    {
                        if (operation == "Upper")
                        {
                            sb.Append(char.Parse(input[i].ToString().ToUpper())); 
                        }
                        else if (operation == "Lower")
                        {
                            sb.Append(char.Parse(input[i].ToString().ToLower()));
                        }
                    }
                    input = sb.ToString().Trim();
                    Console.WriteLine(input);
                }
                else if (command.Contains("Check"))
                {
                    string text = toDecrypt[1];

                    if (input.Contains(text))
                    {
                        Console.WriteLine($"Message contains {text}");
                    }
                    else
                    {
                        Console.WriteLine($"Message doesn't contain {text}");
                    }
                }
                else if (command.Contains("Sum"))
                {
                    int startIndex = int.Parse(toDecrypt[1]);
                    int endIndex = int.Parse(toDecrypt[2]);
                    int sum = 0;

                    if (startIndex >= 0 && endIndex >= 0 && endIndex <= input.Length - 1)
                    {
                        for (int i = startIndex; i <= endIndex; i++)
                        {
                            sum += input[i];
                        }
                        Console.WriteLine(sum);
                    }
                    else
                    {
                        Console.WriteLine("Invalid indexes!");
                    }
                    
                }

                command = Console.ReadLine();
            }
        }
    }
}

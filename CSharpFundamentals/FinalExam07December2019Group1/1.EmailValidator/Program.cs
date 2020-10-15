using System;
using System.Text;

namespace _1.EmailValidator
{
    class Program
    {
        static void Main(string[] args)
        {
            string email = Console.ReadLine();
            string command = Console.ReadLine();

            while (command != "Complete")
            {
                if (command.Contains("Make Upper"))
                {
                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < email.Length; i++)
                    {
                        sb.Append(email[i].ToString().ToUpper());
                    }
                    email = sb.ToString().Trim();
                    Console.WriteLine(email);
                }
                else if (command.Contains("Make Lower"))
                {
                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < email.Length; i++)
                    {
                        sb.Append(email[i].ToString().ToLower());
                    }
                    email = sb.ToString().Trim();
                    Console.WriteLine(email);
                }
                else if (command.Contains("GetDomain"))
                {
                    string[] operation = command
                        .Split();
                    int count = int.Parse(operation[1]);
                    int startingIndex = email.Length - count;

                    for (int i = startingIndex; i < email.Length; i++)
                    {
                        Console.Write(email[i]);
                    }
                    Console.WriteLine();
                }
                else if (command.Contains("GetUsername"))
                {

                    if (email.Contains("@"))
                    {
                        for (int i = 0; i < email.Length; i++)
                        {
                            if (email[i] == '@')
                            {
                                break;
                            }
                            else
                            {
                                Console.Write(email[i]);
                            }
                        }
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine($"The email {email} doesn't contain the @ symbol.");
                    }
                }
                else if (command.Contains("Replace"))
                {
                    string[] symbols = command
                        .Split();
                    char symbol = char.Parse(symbols[1]);

                    email = email.Replace(symbol, '-');
                    Console.WriteLine(email);
                }
                else if (command.Contains("Encrypt"))
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (var item in email)
                    {
                        sb.Append((int)item + " ");
                    }
                    Console.WriteLine(sb.ToString().Trim());
                }
                command = Console.ReadLine();
            }

        }
    }
}

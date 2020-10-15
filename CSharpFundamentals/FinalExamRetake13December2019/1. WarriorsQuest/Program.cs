using System;
using System.Collections.Generic;
using System.Linq;

namespace _1._WarriorsQuest
{
    class Program
    {
        static void Main(string[] args)
        {
            string skill = Console.ReadLine();
            string input = string.Empty;
            string skills = skill;
            
            while ((input = Console.ReadLine()) != "For Azeroth")
            {
                string[] command = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (command[0] == "GladiatorStance")
                {
                    for (int i = 0; i < skills.Length; i++)
                    {
                        string upperCase = skills[i].ToString().ToUpper();
                        skills = skills.Replace(skills[i].ToString(), upperCase);
                    }
                    Console.WriteLine(skills);
                }
                else if (command[0] == "DefensiveStance")
                {
                    for (int i = 0; i < skills.Length; i++)
                    {
                        string lowerCase = skills[i].ToString().ToLower();
                        skills = skills.Replace(skills[i].ToString(), lowerCase);
                    }
                    Console.WriteLine(skills);
                }
                else if (command[0] == "Dispel")
                {
                    int index = int.Parse(command[1]);

                    if (index > skills.Length - 1)
                    {
                        Console.WriteLine("Dispel too weak.");
                        continue;
                    }
                    else
                    {
                        skills = skills.Replace(skills[index].ToString(), command[2]);
                        //skills.Insert(index, command[2]);
                        //skills.Remove(index, 1);
                        Console.WriteLine("Success!");
                    }
                    
                }
                else if (command[0] == "Target" && command[1] == "Change")
                {
                    string firstSubstring = command[2];
                    string secondSubstring = command[3];

                    if (skills.Contains(firstSubstring))
                    {
                        skills = skills.Replace(firstSubstring, secondSubstring);
                    }
                    Console.WriteLine(skills);
                }
                else if (command[0] == "Target" && command[1] == "Remove")
                {
                    string substring = command[2];

                    if (skills.Contains(substring))
                    {
                        skills = skills.Replace(substring, "");
                    }
                    Console.WriteLine(skills);
                }
                else
                {
                    Console.WriteLine("Command doesn't exist!");
                }

            }
            
        }
    }
}

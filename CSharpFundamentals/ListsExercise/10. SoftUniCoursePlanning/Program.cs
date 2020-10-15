using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._SoftUniCoursePlanning
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> schedule = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string input = Console.ReadLine();

            while (input != "course start")
            {
                List<string> command = input.Split(':').ToList();

                if (command[0] == "Add")
                {
                    if (!schedule.Contains(command[1]))
                    {
                        schedule.Add(command[1]);
                    }
                    
                }
                else if (command[0] == "Insert")
                {
                    int index = int.Parse(command[2]);
                    if (!schedule.Contains(command[1]))
                    {
                        schedule.Insert(index, command[1]);
                    }
                }
                else if (command[0] == "Remove")
                {
                    if (schedule.Contains(command[1]))
                    {
                        string cuurentLesson = command[1];
                        int index = schedule.IndexOf(cuurentLesson);
                        schedule.RemoveAt(index);

                        if (command[1] == command[1] + "-Exercise")
                        {
                            if (index + 1 > schedule.Count - 1)
                            {
                                schedule.RemoveAt(schedule.Count - 1);
                            }
                            else
                            {
                                schedule.RemoveAt(index + 1);
                            }
                        }
                    }
                }
                else if (command[0] == "Swap")
                {
                    if (schedule.Contains(command[1]) && schedule.Contains(command[2]))
                    {
                        string first = command[1];
                        int firstIndex = schedule.IndexOf(first);
                        string second = command[2];
                        int secondIndex = schedule.IndexOf(second);

                        schedule.Remove(second);
                        schedule.Insert(secondIndex, first);
                        schedule.Remove(first);
                        schedule.Insert(firstIndex, second);


                        if (schedule.Contains(command[1] + "-Exercise")) // !!!!
                        {
                            int currentIndex = schedule.IndexOf(command[1] + "-Exercise");
                            schedule.RemoveAt(currentIndex);
                            schedule.Insert(secondIndex + 1, (command[1] + "-Exercise"));
                        }

                        

                        if (schedule.Contains(command[2] + "-Exercise"))
                        {
                            int currentIndex = schedule.IndexOf(command[2] + "-Exercise");
                            schedule.RemoveAt(currentIndex);
                            schedule.Insert(firstIndex + 1, (command[2] + "-Exercise"));
                        }
                    }
                }
                else if (command[0] == "Exercise")
                {
                    string currentLesson = command[1];

                    if (schedule.Contains(command[1]))
                    {
                        int index = schedule.IndexOf(currentLesson);

                        if (schedule[index + 1] != currentLesson + "-Exercise")
                        {
                            schedule.Insert(index + 1, currentLesson + "-Exercise");
                        }
                    }
                    else
                    {
                        schedule.Add(command[1]);
                        schedule.Add(command[1] + "-Exercise");
                    }
                }
                input = Console.ReadLine();
            }
            for (int i = 0; i < schedule.Count; i++)
            {
                Console.WriteLine($"{i + 1}.{schedule[i]}");
            }
            
        }
    }
}

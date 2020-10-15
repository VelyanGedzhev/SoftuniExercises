using System;

namespace FirstTask
    //WorldTour
{
    class Program
    {
        static void Main(string[] args)
        {
            string stops = Console.ReadLine();
            string command = Console.ReadLine();

            while (command != "Travel")
            {
                string[] operation = command
                    .Split(":");

                if (command.Contains("Add"))
                {
                    int index = int.Parse(operation[1]);
                    string text = operation[2];

                    if (index >= 0 && index < stops.Length)
                    {
                        stops = stops.Insert(index, text);
                    }
                    Console.WriteLine(stops);
                }
                else if (command.Contains("Remove Stop"))
                {
                    int startIndex = int.Parse(operation[1]);
                    int endIndex = int.Parse(operation[2]);

                    if (startIndex >= 0 && endIndex >= 0 && endIndex <= stops.Length - 1)
                    {
                        stops = stops.Remove(startIndex, endIndex - startIndex + 1);
                    }
                    Console.WriteLine(stops);
                }
                else if (command.Contains("Switch"))
                {
                    string oldString = operation[1];
                    string newString = operation[2];

                    if (stops.Contains(oldString))
                    {
                        stops = stops.Replace(oldString, newString);
                    }
                    Console.WriteLine(stops);
                }

                command = Console.ReadLine();
            }
            Console.WriteLine($"Ready for world tour! Planned stops: {stops}");
        }
    }
}

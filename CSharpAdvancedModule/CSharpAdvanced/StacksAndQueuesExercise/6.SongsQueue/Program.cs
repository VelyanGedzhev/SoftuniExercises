using System;
using System.Collections.Generic;
using System.Text;

namespace _6.SongsQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);

            Queue<string> songs = new Queue<string>(input);

            while (songs.Count != 0)
            {
                string[] command = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (command[0] == "Play")
                {
                    if (songs.Count > 0)
                    {
                        songs.Dequeue();
                    }
                }
                else if (command[0] == "Add")
                {
                    string songToAdd = string.Empty;
                    StringBuilder sb = new StringBuilder();
                    for (int i = 1; i < command.Length; i++)
                    {
                        sb.Append(command[i] + " ");
                    }
                    songToAdd = sb.ToString().TrimEnd();
                    bool toAdd = true;

                    foreach (var song in songs)
                    {
                        if(song == songToAdd)
                        {
                            toAdd = false;
                            Console.WriteLine($"{song} is already contained!");
                        }
                    }
                    if (toAdd)
                    {
                        songs.Enqueue(songToAdd);
                    }
                }
                else if (command[0] == "Show")
                {
                    Console.WriteLine(string.Join(", ", songs));
                }
            }
            if (songs.Count < 1)
            {
                Console.WriteLine("No more songs!");
            }    
        }
    }
}

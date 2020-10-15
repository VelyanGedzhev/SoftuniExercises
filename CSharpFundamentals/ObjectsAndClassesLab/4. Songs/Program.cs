using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace _4._Songs
{
    class Program
    {
        static void Main(string[] args)
        {
            int songCount = int.Parse(Console.ReadLine());
            List<Song> songs = new List<Song>();

            for (int i = 0; i < songCount; i++)
            {
                string[] data = Console.ReadLine().Split("_");
                Song song = new Song(data);
                songs.Add(song);
            }
            string typeList = Console.ReadLine();

            if (typeList == "all")
            {
                foreach (Song song in songs)
                {
                    Console.WriteLine(song.Name);
                }
            }
            else
            {
                foreach (Song song in songs)
                {
                    if (song.TypeList == typeList)
                    {
                        Console.WriteLine(song.Name);
                    }
                }
            }
        }
    }

    public class Song
    {
        public Song(string[] data)
        {
            TypeList = data[0];
            Name = data[1];
            Time = data[2];

        }
        public string TypeList { get; set; }
        public string Name { get; set; }
        public string Time { get; set; }
    }    
}

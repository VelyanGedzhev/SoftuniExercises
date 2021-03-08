using AutoMappingDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AutoMappingDemo
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var songs = GetSongs("Ni");

            Console.WriteLine(string.Join(Environment.NewLine, songs.Select(x => x.Name)));
        }

        public static IEnumerable<SongInfoDto> GetSongs(string startsWith)
        {
            var db = new MusicXContext();

            var songs = db.Songs
                .Where(x => x.Name.StartsWith(startsWith))
                .Select(x => new SongInfoDto
                {
                    Name = x.Name,
                    SourceName = x.Source.Name,
                }).ToList();

            return songs;
        }
    }

    public class SongInfoDto
    {
        public string Name { get; set; }

        public string SourceName { get; set; }
    }
}

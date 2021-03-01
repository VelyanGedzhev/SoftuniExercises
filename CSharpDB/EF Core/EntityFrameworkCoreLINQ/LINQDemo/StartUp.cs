using LINQDemo.Models;
using System;
using System.Linq;

namespace LINQDemo
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var db = new MusicXContext();
            GetSongsWithArtists(db);
        }

        private static void GetSongsWithArtists(MusicXContext db)
        {
            var songs = db.Songs
                            .Where(x => x.Source.Name == "User")
                            .Select(x => new
                            {
                                x.Name,
                                Source = x.Source.Name,
                                Artists = string.Join(", ", x.SongArtists.Select(a => a.Artist.Name))
                            })
                            .ToList();

            foreach (var song in songs)
            {
                Console.WriteLine(song.Artists + " - " + song.Name);
            }
        }
    }
}

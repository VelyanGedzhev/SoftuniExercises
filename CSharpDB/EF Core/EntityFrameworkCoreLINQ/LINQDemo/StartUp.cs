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
            //GetSongsWithArtists(db);
            //GetAllSongsWithSource(db);
            GetArtistsGroupsByFirstLetter(db);

        }

        private static void GetArtistsGroupsByFirstLetter(MusicXContext db)
        {
            var groups = db.Artists
                .GroupBy(x => x.Name.Substring(0, 1))
                .Select(x => new
                {
                    FirstLetter = x.Key,
                    Count = x.Count(),
                    Min = x.Min(a => a.Name),
                    Max = x.Max(a => a.Name),
                }).ToList();

            foreach (var group in groups)
            {
                Console.WriteLine(group);
            }
        }

        private static void GetAllSongsWithSource(MusicXContext db)
        {
            var songs = db.Songs.Join(
                            db.Sources,
                            x => x.SourceId,
                            x => x.Id,
                            (song, source) => new
                            {
                                SongName = song.Name,
                                SourceName = source.Name,
                            }).ToList();

            foreach (var song in songs)
            {
                Console.WriteLine(song);
            }
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

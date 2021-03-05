using AdvancedQueryingDemo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Z.EntityFramework.Plus;

namespace AdvancedQueryingDemo
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var db = new MusicXContext();
            //ExecuteNativeSqlQueries(db);
            //BulkOperations(db);
            //ExplicitLoading(db);
            //EagerLoading(db);
            LazyLoading(db); 
        }

        private static void LazyLoading(MusicXContext db)
        {
            var songs = db.Songs
                            .Where(x => x.Id <= 10)
                            .ToList();

            foreach (var song in songs)
            {
                Console.WriteLine(song.Name);
                Console.WriteLine(song.SongArtists.Count());
                Console.WriteLine(song.Source.Name);
                Console.WriteLine("------------------------------");
            }
        }

        private static void EagerLoading(MusicXContext db)
        {
            var songs = db.Songs
                  .Include(x => x.Source)
                  .Include(x => x.SongArtists)
                  .ThenInclude(x => x.Artist)
                  .Where(x => x.Id <= 10)
                  .ToList();

            foreach (var song in songs)
            {
                Console.WriteLine(song.Name);
                Console.WriteLine(song.SongArtists.Count());
                Console.WriteLine(song.Source.Name);
                Console.WriteLine("------------------------------");
            }
        }

        private static void ExplicitLoading(MusicXContext db)
        {
            var songs = db.Songs
                .Where(x => x.Id <= 10)
                .ToList();

            foreach (var song in songs)
            {

                Console.WriteLine(song.Name);

                db.Entry(song)
                    .Collection(x => x.SongArtists).Load();
                Console.WriteLine(song.SongArtists.Count());

                db.Entry(song)
                    .Reference(x => x.Source).Load();
                Console.WriteLine(song.Source.Name);
                Console.WriteLine("------------------------------");
            }
        }

        private static void BulkOperations(MusicXContext db)
        {
            db.Songs
                .Where(x => x.Id <= 10)
                .Update(oldSong => new Song { SourceItemId = oldSong.Id.ToString() });
        }

        private static void ExecuteNativeSqlQueries(MusicXContext db)
        {
            //db.Database.ExecuteSqlRaw("UPDATE Songs SET ModifiedOn = GETDATE()");
            var maxId = Console.ReadLine();

            var songs = db.Songs
                //TO DO: Check FromSqlInterpolated($"SELECT * FROM Songs WHERE Id <= {maxId}")
                .FromSqlRaw("SELECT * FROM Songs WHERE Id <= {0}", maxId)
                .ToList();

            foreach (var song in songs)
            {
                Console.WriteLine(song.Id + " " + song.Name);
            }
        }
    }
}

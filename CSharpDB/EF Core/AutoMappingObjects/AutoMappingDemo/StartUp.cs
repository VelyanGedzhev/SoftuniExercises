using AutoMappingDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Newtonsoft.Json;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using AutoMappingDemo.MapProfiles;

namespace AutoMappingDemo
{
    public class StartUp
    {
        public static void Main(string[] args)
        {

            //var songs = GetSongsManualMapping();
            //Console.WriteLine(JsonConvert.SerializeObject(songs, Formatting.Indented));


            //GetSongByIdAutoMapping();

            var db = new MusicXContext();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new SongInfoDtoProfile());
            });

            GetSongsAutoMapping(db, config);
        }

        private static void GetSongsAutoMapping(MusicXContext db, MapperConfiguration config)
        {
            var songs = db.Songs
                            .Where(x => x.Name.StartsWith("Nik"))
                            .ProjectTo<SongInfoDto>(config)
                            .ToList();

            Console.WriteLine(JsonConvert.SerializeObject(songs, Formatting.Indented));
        }

        public static IEnumerable<SongInfoDto> GetSongsManualMapping()
        {
            var db = new MusicXContext();

            var songs = db.Songs
                .Where(x => x.Name.StartsWith("Nik"))
                .Select(x => new SongInfoDto
                {
                    Name = x.Name,
                    CreatedOn = x.CreatedOn,
                    Artists = string.Join(", ", x.SongArtists.Select(a => a.Artist.Name)),
                    SourceName = x.Source.Name,
                    SearchTerms = x.SearchTerms,
                }).ToList();

            return songs;
        }
    }

    public class SongInfoDto
    {
        public string Name { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Artists { get; set; }

        public string SourceName { get; set; }

        public string SearchTerms { get; set; }

        public int SongArtistsCount { get; set; }
    }
}

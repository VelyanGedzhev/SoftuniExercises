namespace MusicHub
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Data;
    using Initializer;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            MusicHubDbContext context = 
                new MusicHubDbContext();

            DbInitializer.ResetDatabase(context);

            //int producerId = int.Parse(Console.ReadLine());
            //var result = ExportAlbumsInfo(context, producerId);
            //Console.WriteLine(result);

            //var duration = int.Parse(Console.ReadLine());
            var result = ExportSongsAboveDuration(context, 4);
            Console.WriteLine(result);
        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            var albums = context
                .Producers
                .FirstOrDefault(x => x.Id == producerId)
                .Albums
                .Select(x => new
                {
                    AlbumName = x.Name,
                    ReleaseDate = x.ReleaseDate,
                    ProducerName = x.Producer.Name,
                    Songs = x.Songs.Select(s => new
                    {
                        SongName = s.Name,
                        SongPrice = s.Price,
                        SongWriter = s.Writer.Name,
                    })
                    .OrderByDescending(x => x.SongName)
                    .ThenBy(x => x.SongWriter)
                    .ToList(),
                    AlbumPrice = x.Price
                })
                .OrderByDescending(x => x.AlbumPrice)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var album in albums)
            {
                int counter = 0;

                sb
                    .AppendLine($"-AlbumName: {album.AlbumName}")
                    .AppendLine($"-ReleaseDate: {album.ReleaseDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture)}")
                    .AppendLine($"-ProducerName: {album.ProducerName}")
                    .AppendLine("-Songs:");

                foreach (var song in album.Songs)
                {
                    counter++;
                    sb
                        .AppendLine($"---#{counter}")
                        .AppendLine($"---SongName: {song.SongName}")
                        .AppendLine($"---Price: {song.SongPrice:f2}")
                        .AppendLine($"---Writer: {song.SongWriter}");
                }

                sb.AppendLine($"-AlbumPrice: {album.AlbumPrice:f2}");
            }
            return sb.ToString().TrimEnd();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            var sb = new StringBuilder();

            var songs = context
                .Songs
                .Where(s => s.Duration.TotalSeconds > duration)
                .Select(s => new
                {
                    Writer = s.Writer.Name,
                    Performer = s.SongPerformers
                        .Select(sp => sp.Performer.FirstName + " " + sp.Performer.LastName)
                        .FirstOrDefault(),
                    SongName = s.Name,
                    AlbumProducer = s.Album.Producer.Name,
                    Duration = s.Duration
                })
                .ToList()
                .OrderBy(s => s.SongName)
                .ThenBy(s => s.Writer)
                .ThenBy(s => s.Performer)
                .ToList();

            var counter = 1;
            foreach (var song in songs)
            {

                sb.AppendLine($"-Song #{counter}");
                sb.AppendLine($"---SongName: {song.SongName}");
                sb.AppendLine($"---Writer: {song.Writer}");
                sb.AppendLine($"---Performer: {song.Performer}");
                sb.AppendLine($"---AlbumProducer: {song.AlbumProducer}");
                sb.AppendLine($"---Duration: {song.Duration.ToString("c")}");

                counter++;
            }

            return sb.ToString().Trim();
        }
    }
}

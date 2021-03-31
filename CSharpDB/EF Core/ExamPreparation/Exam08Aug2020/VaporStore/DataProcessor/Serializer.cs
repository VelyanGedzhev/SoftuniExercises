namespace VaporStore.DataProcessor
{
	using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using VaporStore.DataProcessor.Dto.Export;

    public static class Serializer
	{
		public static string ExportGamesByGenres(VaporStoreDbContext context, string[] genreNames)
		{
			var genres = context.Genres
				.ToList()
				.Where(x => genreNames.Contains(x.Name))
				.Select(x => new
				{
					Id = x.Id,
					Genre = x.Name,
					Games = x.Games.Select(g => new
						{
							Id = g.Id,
							Title = g.Name,
							Developer = g.Developer.Name,
							Tags = string.Join(", ", g.GameTags.Select(t => t.Tag.Name)),
							Players = g.Purchases.Count(),
						})
						.Where(g => g.Players > 0)
						.OrderByDescending(g => g.Players)
						.ThenBy(g => g.Id),
					TotalPlayers = x.Games.Sum(g => g.Purchases.Count()),
				})
				.OrderByDescending(x => x.TotalPlayers)
				.ThenBy(x => x.Id);

			return JsonConvert.SerializeObject(genres, Formatting.Indented);
		}

		public static string ExportUserPurchasesByType(VaporStoreDbContext context, string storeType)
		{
			var users = context.Users.ToList()
				.Where(x => x.Cards.Any(c => c.Purchases.Any(p => p.Type.ToString() == storeType)))
				.Select(u => new UserOutputModel
				{
					Username = u.Username,
					TotalSpent = u.Cards.Sum(
						c => c.Purchases
						.Where(p => p.Type.ToString() == storeType)
						.Sum(p => p.Game.Price)),
					Purchases = u.Cards.SelectMany(c => c.Purchases)
						.Where(p => p.Type.ToString() == storeType)
						.Select(p => new PurchaseOutputModel
						{
							Card = p.Card.Number,
							CVC = p.Card.Cvc,
							Date = p.Date.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
							Game = new GameOutputModel
                            {
								Genre = p.Game.Genre.Name,
								Title = p.Game.Name,
								Price = p.Game.Price,
                            },
						})
						.OrderBy(x => x.Date)
						.ToArray()
				})
				.OrderByDescending(x => x.TotalSpent)
				.ThenBy(x => x.Username)
				.ToArray();

			XmlSerializer xmlSerializer = 
				new XmlSerializer(typeof(UserOutputModel[]),new XmlRootAttribute("Users"));

			XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
			ns.Add("", "");

			var stringWriter = new StringWriter();

			xmlSerializer.Serialize(stringWriter, users, ns);
				
			return stringWriter.ToString();
		}
	}
}
namespace VaporStore.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using VaporStore.Data.Models;
    using VaporStore.DataProcessor.Dto.Import;

    public static class Deserializer
	{
		public static string ImportGames(VaporStoreDbContext context, string jsonString)
		{
			var output = new StringBuilder();

			var games = JsonConvert
				.DeserializeObject<IEnumerable<GameInputModel>>(jsonString);

            foreach (var jsonGame in games)
            {
                if (!IsValid(jsonGame) ||
					jsonGame.Tags.Count() == 0)
                {
					output.AppendLine("Invalid Data");
					continue;
                }

				var genre = context.Genres.FirstOrDefault(x => x.Name == jsonGame.Genre)
					?? new Genre { Name = jsonGame.Genre };


				var developer = context.Developers.FirstOrDefault(x => x.Name == jsonGame.Developer)
					?? new Developer { Name = jsonGame.Developer};

				var game = new Game
				{
					Name = jsonGame.Name,
					Price = jsonGame.Price,
					Genre = genre,
					Developer = developer,
					ReleaseDate = jsonGame.ReleaseDate.Value,
				};

                foreach (var jsonTag in jsonGame.Tags)
                {
					var tag = context.Tags.FirstOrDefault(x => x.Name == jsonTag)
						?? new Tag { Name = jsonTag};

					game.GameTags.Add(new GameTag { Tag = tag});
                }

				context.Games.Add(game);
				context.SaveChanges();

				output.AppendLine($"Added {game.Name} ({game.Genre.Name}) with {game.GameTags.Count()} tags");
            }


			return output.ToString();
		}

		public static string ImportUsers(VaporStoreDbContext context, string jsonString)
		{
			var output = new StringBuilder();

			var users = new List<User>();

			var jsonUsers = JsonConvert
				.DeserializeObject<IEnumerable<UserInputModel>>(jsonString);

            foreach (var jsonUser in jsonUsers)
            {
                if (!IsValid(jsonUser) ||
					!jsonUser.Cards.All(IsValid))
                {
					output.AppendLine("Invalid Data");
					continue;
                }

				var user = new User()
				{
					FullName = jsonUser.FullName,
					Username = jsonUser.Username,
					Email = jsonUser.Email,
					Age = jsonUser.Age,
					Cards = jsonUser.Cards
						.Select(c => new Card
						{
							Number = c.Number,
							Cvc = c.CVC,
							Type = c.Type.Value,
						}).ToList()
				};

				users.Add(user);
				output.AppendLine($"Imported {user.Username} with {user.Cards.Count} cards");
            }
			context.Users.AddRange(users);
			context.SaveChanges();

			return output.ToString().TrimEnd();
		}

		public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
		{
			var output = new StringBuilder();
			var purchases = new List<Purchase>();

			var xmlSerializer = new XmlSerializer(typeof(PurchaseInputXmlModel[]), new XmlRootAttribute("Purchases"));


			var xmlPurchases = (PurchaseInputXmlModel[])xmlSerializer.Deserialize(new StringReader(xmlString));

            foreach (var xmlPurchase in xmlPurchases)
            {
                if (!IsValid(xmlPurchase))
                {
					output.AppendLine("Invalid Data");
					continue;
                }

				var isValidDate = DateTime.TryParseExact(xmlPurchase.Date, "dd/MM/yyyy HH:mm",
					CultureInfo.InvariantCulture,
					DateTimeStyles.None,
					out DateTime date);

				if (!isValidDate)
				{
					output.AppendLine("Invalid Data");
					continue;
				}


				var card = context.Cards
					.FirstOrDefault(c => c.Number == xmlPurchase.Card);

				var game = context.Games
					.FirstOrDefault(g => g.Name == xmlPurchase.Title);

				var purchase = new Purchase
				{
					Type = xmlPurchase.Type.Value,
					ProductKey = xmlPurchase.Key,
					Card = card,
					Date = date,
					Game = game,
				};

				purchases.Add(purchase);
				output.AppendLine($"Imported {purchase.Game.Name} for {purchase.Card.User.Username}");
            }
			context.Purchases.AddRange(purchases);
			context.SaveChanges();

			return output.ToString().TrimEnd();
		}

		private static bool IsValid(object dto)
		{
			var validationContext = new ValidationContext(dto);
			var validationResult = new List<ValidationResult>();

			return Validator.TryValidateObject(dto, validationContext, validationResult, true);
		}
	}
}
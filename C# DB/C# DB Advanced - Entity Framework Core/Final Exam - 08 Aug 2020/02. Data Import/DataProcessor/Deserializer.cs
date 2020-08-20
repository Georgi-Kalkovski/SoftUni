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
    using VaporStore.Data.Models.Enums;
    using VaporStore.DataProcessor.Dto;
    using VaporStore.DataProcessor.Dto.Import;

	public static class Deserializer
	{
		public static string ErrorMessage { get; set; } = "Invalid Data";
		public static string SuccessfulAppendGames { get; set; } = "Added {0} ({1}) with {2} tags";
		public static string SuccessfulAppendUsers { get; set; } = "Imported {0} with {1} cards";
		public static string SuccessfulAppendPurchases { get; set; } = "Imported {0} for {1}";
		public static string ImportGames(VaporStoreDbContext context, string jsonString)
		{
			var gamesDto = JsonConvert.DeserializeObject<List<ImportGamesDevsGenresAndTagsDto>>(jsonString);
			var sb = new StringBuilder();

			var games = new List<Game>();
			var devs = new List<Developer>();
			var genres = new List<Genre>();
			var tags = new List<Tag>();

			foreach (var gameDto in gamesDto)
			{
				if (!IsValid(gameDto))
				{
					sb.AppendLine(ErrorMessage);
					continue;
				}
				if (gameDto.Tags.Length == 0)
				{
					sb.AppendLine(ErrorMessage);
					continue;
				}

				var dateTime = new DateTime();

				if (DateTime.TryParseExact(gameDto.ReleaseDate, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime) == false)
				{
					sb.AppendLine(ErrorMessage);
					continue;
				}

				var game = new Game
				{
					Price = gameDto.Price,
					Name = gameDto.Name,
					ReleaseDate = dateTime,
					GameTags = new List<GameTag>()
				};

				var dev = devs.FirstOrDefault(x => x.Name == gameDto.Developer);

				if (dev == null)
				{
					dev = new Developer { Name = gameDto.Developer };
				}

				devs.Add(dev);
				game.Developer = dev;

				var genre = genres.FirstOrDefault(x => x.Name == gameDto.Genre);

				if (genre == null)
				{
					genre = new Genre { Name = gameDto.Genre };
				}

				genres.Add(genre);
				game.Genre = genre;

				foreach (var tagDto in gameDto.Tags)
				{
					var tag = tags.FirstOrDefault(x => x.Name == tagDto);
					if (tag == null)
					{
						tag = new Tag { Name = tagDto };
					}

					tags.Add(tag);

					game.GameTags.Add(new GameTag { Tag = tag, Game = game });
				}

				games.Add(game);
				sb.AppendLine(String.Format(SuccessfulAppendGames, game.Name, game.Genre.Name, game.GameTags.Count));
			}

			var debugDevelopersCount = devs.Select(x => x.Name).Distinct().Count();
			var debugGenreCount = genres.Select(x => x.Name).Distinct().Count();
			var debugTagsCount = tags.Select(x => x.Name).Distinct().Count();

			context.Tags.AddRange(tags);
			context.Genres.AddRange(genres);
			context.Developers.AddRange(devs);
			context.Games.AddRange(games);
			context.SaveChanges();

			return sb.ToString().Trim();
		}

		public static string ImportUsers(VaporStoreDbContext context, string jsonString)
		{
			var usersDto = JsonConvert.DeserializeObject<List<ImportUsersАndCardsDto>>(jsonString);
			var sb = new StringBuilder();

			var users = new List<User>();
			var cards = new List<Card>();

			foreach (var userDto in usersDto)
			{
				if (!IsValid(userDto))
				{
					sb.AppendLine(ErrorMessage);
					continue;
				}

				var user = new User
				{
					Age = userDto.Age,
					FullName = userDto.FullName,
					Username = userDto.Username,
					Email = userDto.Email,
					Cards = new List<Card>()
				};

				var validCard = true;
				foreach (var cardDto in userDto.Cards)
				{
					if (!IsValid(cardDto))
					{
						sb.AppendLine(ErrorMessage);
						validCard = false;
						break;
					}

					var validType = new object { };

					if (Enum.TryParse(typeof(CardType), cardDto.Type, false, out validType) == false)
					{
						sb.AppendLine(ErrorMessage);
						validCard = false;
						break;
					}

					var card = new Card 
					{
						Cvc = cardDto.Cvc, 
						Number = cardDto.Number, 
						Type = (CardType)Enum.Parse(typeof(CardType), cardDto.Type) 
					};

					user.Cards.Add(card);
				}

				if (!validCard)
				{
					continue;
				}

				users.Add(user);

				foreach (var card in user.Cards)
				{
					cards.Add(card);
				}

				sb.AppendLine(String.Format(SuccessfulAppendUsers, user.Username, user.Cards.Count));
			}
			var debugCardsCount = cards.Count;
			context.Cards.AddRange(cards);
			context.Users.AddRange(users);
			context.SaveChanges();

			return sb.ToString().Trim();
		}

		public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
		{
			var serializer = new XmlSerializer(typeof(List<ImportPurchasesDto>), new XmlRootAttribute("Purchases"));
			var purchasesDto = (List<ImportPurchasesDto>)serializer.Deserialize(new StringReader(xmlString));

			var sb = new StringBuilder();
			var purchases = new List<Purchase>();

			foreach (var purchaseDto in purchasesDto)
			{
				if (!IsValid(purchaseDto))
				{
					sb.AppendLine(ErrorMessage);
					continue;
				}

				var newDate = new DateTime();

				if (DateTime.TryParseExact(purchaseDto.Date, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out newDate) == false)
				{
					sb.AppendLine(ErrorMessage);
					continue;
				}

				var purchaseCard = context.Cards.FirstOrDefault(card => card.Number == purchaseDto.Card);

				if (purchaseCard == null)
				{
					sb.AppendLine(ErrorMessage);
					continue;
				}

				var purchaseGame = context.Games.FirstOrDefault(game => game.Name == purchaseDto.Title);

				if (purchaseGame == null)
				{
					sb.AppendLine(ErrorMessage);
					continue;
				}

				var purchaseValid = new object { };

				if (Enum.TryParse(typeof(PurchaseType), purchaseDto.Type, out purchaseValid) == false)
				{
					sb.AppendLine(ErrorMessage);
					continue;
				}

				var purchase = new Purchase
				{
					Date = newDate,
					ProductKey = purchaseDto.ProductKey,
					Type = (PurchaseType)Enum.Parse(typeof(PurchaseType), purchaseDto.Type),
					Card = purchaseCard,
					Game = purchaseGame
				};

				purchases.Add(purchase);
				sb.AppendLine(String.Format(SuccessfulAppendPurchases, purchase.Game.Name, purchase.Card.User.Username));
			}

			context.Purchases.AddRange(purchases);
			context.SaveChanges();

			return sb.ToString().Trim();
		}

		private static bool IsValid(object dto)
		{
			var validationContext = new ValidationContext(dto);
			var validationResult = new List<ValidationResult>();

			return Validator.TryValidateObject(dto, validationContext, validationResult, true);
		}
	}
}
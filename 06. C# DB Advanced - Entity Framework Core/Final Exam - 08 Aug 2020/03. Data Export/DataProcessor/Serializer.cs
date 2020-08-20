namespace VaporStore.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using VaporStore.DataProcessor.Dto.Export;

    public static class Serializer
    {
        public static string ExportGamesByGenres(VaporStoreDbContext context, string[] genreNames)
        {
            var gamesByGenres = context
                .Genres
                .ToArray()
                .Where(gnr => genreNames.Contains(gnr.Name) == true)
                .Select(gnr => new
                {
                    gnr.Id,
                    Genre = gnr.Name,
                    Games = gnr.Games
                        .Where(gms => gms.Purchases.Count > 0)
                        .Select(gms => new
                        {
                            gms.Id,
                            Title = gms.Name,
                            Developer = gms.Developer.Name,
                            Tags = String.Join(", ", gms.GameTags.Select(gt => gt.Tag.Name)),
                            Players = gms.Purchases.Count
                        })
                        .OrderByDescending(g => g.Players)
                        .ThenBy(g => g.Id)
                        .ToList(),
                    TotalPlayers = gnr.Games.SelectMany(g => g.Purchases).Count(),
                })
                .OrderByDescending(x => x.TotalPlayers)
                .ThenBy(x => x.Id)
                .ToList();

            var jsonOutput = JsonConvert.SerializeObject(gamesByGenres, Formatting.Indented);

            return jsonOutput;
        }

        public static string ExportUserPurchasesByType(VaporStoreDbContext context, string storeType)
        {
            var serializer = new XmlSerializer(typeof(List<ExportUserPurchasesDto>), new XmlRootAttribute("Users"));
            var xmlNamespaces = new XmlSerializerNamespaces();

            var sb = new StringBuilder();

            xmlNamespaces.Add("", "");

            var userPurchasesByType = context
                .Users
                .Include(u => u.Cards)
                .ThenInclude(u => u.Purchases)
                .ThenInclude(u => u.Game)
                .ThenInclude(u => u.Genre)
                .ToList()
                .Where(u => u.Cards.SelectMany(c => c.Purchases).Count() > 0)
                .Select(u => new ExportUserPurchasesDto
                {
                    Username = u.Username,
                    Purchases = u.Cards.SelectMany(c => c.Purchases)
                        .Where(p => p.Type.ToString() == storeType)
                        .Select(p => new PurchasesDto
                        {
                            Card = p.Card.Number,
                            Cvc = p.Card.Cvc,
                            Date = p.Date.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                            Game = new GameDto
                            {
                                Title = p.Game.Name,
                                Genre = p.Game.Genre.Name,
                                Price = p.Game.Price
                            }
                        })
                        .OrderBy(p => DateTime.Parse(p.Date))
                        .ToList(),
                    TotalMoneySpent = u.Cards.SelectMany(c => c.Purchases)
                        .Where(p => p.Type.ToString() == storeType)
                        .Sum(p => p.Game.Price)
                })
                .Where(u => u.Purchases.Count > 0)
                .OrderByDescending(u => u.TotalMoneySpent)
                .ThenBy(u => u.Username)
                .ToList();

            serializer.Serialize(new StringWriter(sb), userPurchasesByType, xmlNamespaces);
            return sb.ToString();
        }
    }
}
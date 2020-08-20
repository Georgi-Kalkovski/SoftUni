namespace BookShop.DataProcessor
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using BookShop.Data.Models;
    using BookShop.Data.Models.Enums;
    using BookShop.DataProcessor.ExportDto;
    using Data;
    using Newtonsoft.Json;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportMostCraziestAuthors(BookShopContext context)
        {
            var mostCraziestAuthors = context
                .Authors
                .Select(a => new
                {
                    AuthorName = a.FirstName + " " + a.LastName,
                    Books = a.AuthorsBooks
                    .Select(ab => ab.Book)
                    .OrderByDescending(ab => ab.Price)
                    .Select(ab => new
                    {
                        BookName = ab.Name,
                        BookPrice = ab.Price.ToString("F2")
                    })
                    .ToList()
                })
                .ToList()
                .OrderByDescending(a => a.Books.Count())
                .ThenBy(a => a.AuthorName)
                .ToList();

            var jsonOutput = JsonConvert.SerializeObject(mostCraziestAuthors, Formatting.Indented);

            return jsonOutput;

        }

        public static string ExportOldestBooks(BookShopContext context, DateTime date)
        {
            var sb = new StringBuilder();

            var books = context
                .Books
                .Where(b => b.PublishedOn < date && b.Genre == Genre.Science)
                .ToArray()
                .OrderByDescending(b => b.Pages)
                .ThenByDescending(b => b.PublishedOn)
                .Take(10)
                .Select(b => new ExportOldestBooksDto()
                {
                    Name = b.Name,
                    Pages = b.Pages,
                    Date = b.PublishedOn.ToString("d", CultureInfo.InvariantCulture)
                })
                .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(ExportOldestBooksDto[]), new XmlRootAttribute("Books"));
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(String.Empty, String.Empty);

            xmlSerializer.Serialize(new StringWriter(sb), books, namespaces);
            return sb.ToString().Trim();
        }
    }
}
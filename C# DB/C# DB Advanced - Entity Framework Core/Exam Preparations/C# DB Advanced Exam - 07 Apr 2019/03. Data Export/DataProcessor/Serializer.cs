namespace Cinema.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Cinema.Data.Models;
    using Cinema.DataProcessor.ExportDto;
    using Data;
    using Newtonsoft.Json;

    public class Serializer
    {
        public static string ExportTopMovies(CinemaContext context, int rating)
        {
            var topMovies = context
                .Movies
                .ToList()
                .Where(m => m.Rating >= rating && m.Projections.Any(t => t.Tickets.Count > 0))
                .OrderByDescending(m => m.Rating)
                .ThenByDescending(m => m.Projections.Sum(t => t.Tickets.Sum(p => p.Price)))
                .Select(m => new
                {
                    MovieName = m.Title,
                    Rating = m.Rating.ToString("F2"),
                    TotalIncomes = m.Projections.Sum(t => t.Tickets.Sum(p => p.Price)).ToString("F2"),
                    Customers = m.Projections.SelectMany(t => t.Tickets)
                    .Select(c => new
                    {
                        FirstName = c.Customer.FirstName,
                        LastName = c.Customer.LastName,
                        Balance = c.Customer.Balance.ToString("F2")
                    })
                    .OrderByDescending(c => c.Balance)
                    .ThenBy(c => c.FirstName)
                    .ThenBy(c => c.LastName)
                    .ToList()
                })
                .Take(10)
                .ToList();

            var jsonOutput = JsonConvert.SerializeObject(topMovies, Formatting.Indented);

            return jsonOutput;
        }

        public static string ExportTopCustomers(CinemaContext context, int age)
        {
            var sb = new StringBuilder();

            var topCustomers = context
                .Customers
                .ToList()
                .Where(c=>c.Age >= age)
                .OrderByDescending(c => c.Tickets.Sum(p => p.Price))
                .Take(10)
                .Select(c => new ExportTopCustomersDto
                {
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    SpentMoney = c.Tickets.Sum(p => p.Price).ToString("F2"),
                    SpentTime = TimeSpan.FromSeconds(c.Tickets.Sum(t => t.Projection.Movie.Duration.TotalSeconds)).ToString(@"hh\:mm\:ss")
                })
                .ToList();

            var xmlSerializer = new XmlSerializer(typeof(List<ExportTopCustomersDto>), new XmlRootAttribute("Customers"));

            var namespaces = new XmlSerializerNamespaces();

            namespaces.Add(string.Empty, string.Empty);

            xmlSerializer.Serialize(new StringWriter(sb), topCustomers, namespaces);

            return sb.ToString().Trim();
        }
    }
}
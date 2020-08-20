namespace Cinema.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Text;
    using System.Xml.Serialization;
    using Cinema.Data.Models;
    using Cinema.Data.Models.Enums;
    using Cinema.DataProcessor.ImportDto;
    using Data;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";
        private const string SuccessfulImportMovie
            = "Successfully imported {0} with genre {1} and rating {2}!";
        private const string SuccessfulImportHallSeat
            = "Successfully imported {0}({1}) with {2} seats!";
        private const string SuccessfulImportProjection
            = "Successfully imported projection {0} on {1}!";
        private const string SuccessfulImportCustomerTicket
            = "Successfully imported customer {0} {1} with bought tickets: {2}!";

        public static string ImportMovies(CinemaContext context, string jsonString)
        {
            var moviesDto = JsonConvert.DeserializeObject<List<ImportMoviesDto>>(jsonString);
            var sb = new StringBuilder();
            var movies = new List<Movie>();

            foreach (var movieDto in moviesDto)
            {
                if (!IsValid(movieDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var movie = new Movie
                {
                    Title = movieDto.Title,
                    Genre = movieDto.Genre,
                    Duration = movieDto.Duration,
                    Rating = movieDto.Rating,
                    Director = movieDto.Director
                };

                if (movies.Contains(movie))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                movies.Add(movie);
                sb.AppendLine(String.Format(SuccessfulImportMovie, movie.Title, movie.Genre, movie.Rating.ToString("F2")));
            }

            context.AddRange(movies);
            context.SaveChanges();

            return sb.ToString().Trim();
        }

        public static string ImportHallSeats(CinemaContext context, string jsonString)
        {
            var hallsDto = JsonConvert.DeserializeObject<List<ImportHallsAndSeatsDto>>(jsonString);
            var sb = new StringBuilder();
            var halls = new List<Hall>();

            foreach (var hallDto in hallsDto)
            {
                if (!IsValid(hallDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var hall = new Hall
                {
                    Name = hallDto.Name,
                    Is4Dx = hallDto.Is4Dx,
                    Is3D = hallDto.Is3D,
                };

                for (int i = 0; i < hallDto.Seats; i++)
                {
                    hall.Seats.Add(new Seat());
                }

                halls.Add(hall);

                string status = "";

                if (hall.Is4Dx)
                {
                    status = hall.Is3D ? "4Dx/3D" : "4Dx";
                }
                else if (hall.Is3D)
                {
                    status = "3D";
                }
                else
                { 
                    status = "Normal";
                }

                sb.AppendLine(String.Format(SuccessfulImportHallSeat,hall.Name, status, hall.Seats.Count));
            }

            context.AddRange(halls);
            context.SaveChanges();

            return sb.ToString().Trim();
        }

        public static string ImportProjections(CinemaContext context, string xmlString)
        {
            var xmlSerializer = new XmlSerializer(typeof(List<ImportProjectionsDto>), new XmlRootAttribute("Projections"));

            var projectionsDto = (List<ImportProjectionsDto>)xmlSerializer.Deserialize(new StringReader(xmlString));

            var sb = new StringBuilder();
            var projections = new List<Projection>();

            foreach (var projectionDto in projectionsDto)
            {
                if (!IsValid(projectionDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var movie = context.Movies.Find(projectionDto.MovieId);
                var hall = context.Halls.Find(projectionDto.HallId);

                if (movie == null || hall == null)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var projection = new Projection
                {
                    MovieId = projectionDto.MovieId,
                    HallId = projectionDto.HallId,
                    DateTime = DateTime.ParseExact(projectionDto.DateTime, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture)
                };

                projections.Add(projection);
                sb.AppendLine(String.Format(SuccessfulImportProjection, movie.Title, projection.DateTime.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture)));
            }

            context.AddRange(projections);
            context.SaveChanges();

            return sb.ToString().Trim();
        }

        public static string ImportCustomerTickets(CinemaContext context, string xmlString)
        {
            var xmlSerializer = new XmlSerializer(typeof(List<ImportCustomerTicketsDto>), new XmlRootAttribute("Customers"));

            var customersDto = (List<ImportCustomerTicketsDto>)xmlSerializer.Deserialize(new StringReader(xmlString));

            var sb = new StringBuilder();
            var customers = new List<Customer>();

            foreach (var customerDto in customersDto)
            {
                if (!IsValid(customerDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var customer = new Customer
                {
                    FirstName = customerDto.FirstName,
                    LastName = customerDto.LastName,
                    Age = customerDto.Age,
                    Balance = customerDto.Balance
                };

                foreach (var ticketDto in customerDto.Tickets)
                {
                    if (!IsValid(ticketDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var ticket = new Ticket
                    {
                        ProjectionId = ticketDto.ProjectionId,
                        Price = ticketDto.Price
                    };

                    customer.Tickets.Add(ticket);
                }

                customers.Add(customer);
                sb.AppendLine(String.Format(SuccessfulImportCustomerTicket, customer.FirstName, customer.LastName, customer.Tickets.Count));
            }

            context.AddRange(customers);
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
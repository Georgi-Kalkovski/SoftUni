namespace BookShop
{
    using BookShop.Models;
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore.Internal;
    using System;
    using System.Linq;
    using System.Security.Cryptography.X509Certificates;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            DbInitializer.ResetDatabase(db);

            //var input = Console.ReadLine();

            // Problem 01 - Age Restriction
            //GetBooksByAgeRestriction(db, input);

            // Problem 02 - Golden Books
            //GetGoldenBooks(db);

            // Problem 03 - Books by Price
            //GetBooksByPrice(db);

            // Problem 04 - Not Released In
            //GetBooksNotReleasedIn(db, int.Parse(input));

            // Problem 05 - Book Titles by Category
            //GetBooksByCategory(db, input);

            // Problem 06 - Released Before Date
            //GetBooksReleasedBefore(db, input);

            // Problem 07 - Author Search
            //GetAuthorNamesEndingIn(db, input);

            // Problem 08 - Book Search
            //GetBookTitlesContaining(db, input);

            // Problem 09 - Book Search by Author
            //GetBooksByAuthor(db, input);

            // Problem 10 - Count Books
            //CountBooks(db, int.Parse(input));

            // Problem 11 - Total Book Copies
            //CountCopiesByAuthor(db);

            // Problem 12 - Profit by Category
            //GetTotalProfitByCategory(db);

            // Problem 13 - Most Recent Books
            //GetMostRecentBooks(db);

            // Problem 14 - Increase Prices
            //IncreasePrices(db);

            // Problem 15 - Remove Books
            //RemoveBooks(db);
        }

        // Problem 01 - Age Restriction
        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            var booksByAgeRestriction = context
                .Books
                .Where(b => b.AgeRestriction.ToString().ToLower() == command.ToLower())
                .Select(b => b.Title)
                .OrderBy(b => b)
                .ToList();

            var sb = new StringBuilder();

            foreach (var book in booksByAgeRestriction)
            {
                sb.AppendLine(book);
            }

            return sb.ToString().Trim();
        }

        // Problem 02 - Golden Books
        public static string GetGoldenBooks(BookShopContext context)
        {
            var goldenBooks = context
                .Books
                .Where(b => b.EditionType.ToString() == "Gold")
                .Where(b => b.Copies < 5000)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToList();

            var sb = new StringBuilder();

            foreach (var book in goldenBooks)
            {
                sb.AppendLine(book);
            }

            return sb.ToString().Trim();
        }

        // Problem 03 - Books by Price
        public static string GetBooksByPrice(BookShopContext context)
        {
            var booksByPrice = context
                .Books
                .Where(b => b.Price > 40)
                .Select(b => new
                {
                    b.Title,
                    b.Price
                })
                .OrderByDescending(b => b.Price)
                .ToList();

            var sb = new StringBuilder();

            foreach (var book in booksByPrice)
            {
                sb.AppendLine($"{book.Title} - ${book.Price:F2}");
            }

            return sb.ToString().Trim();
        }

        // Problem 04 - Not Released In
        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var booksNotReleasedIn = context
                .Books
                .Where(b => b.ReleaseDate.Value.Year != year)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToList();

            var sb = new StringBuilder();

            foreach (var book in booksNotReleasedIn)
            {
                sb.AppendLine(book);
            }

            return sb.ToString().Trim();
        }

        // Problem 05 - Book Titles by Category
        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            var arrayOfCategories = input.ToLower().Split();

            var booksByCategory = context
                .BooksCategories
                .Where(c => arrayOfCategories.Contains(c.Category.Name.ToLower()))
                .OrderBy(b => b.Book.Title)
                .Select(b => b.Book.Title)
                .ToList();

            var sb = new StringBuilder();

            foreach (var book in booksByCategory)
            {
                sb.AppendLine(book);
            }

            return sb.ToString().Trim();
        }

        // Problem 06 - Released Before Date
        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {

            var trueDate = DateTime.ParseExact(date, "dd-MM-yyyy", null);

            var booksReleasedBefore = context
                .Books
                .Where(b => b.ReleaseDate < trueDate)
                .OrderByDescending(b => b.ReleaseDate)
                .Select(b => new
                {
                    b.Title,
                    b.EditionType,
                    b.Price
                })
                .ToList();

            var sb = new StringBuilder();

            foreach (var book in booksReleasedBefore)
            {
                sb.AppendLine($"{book.Title} - {book.EditionType} - ${book.Price:F2}");
            }

            return sb.ToString().Trim();
        }

        // Problem 07 - Author Search
        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var authorNamesEndingIn = context
                .Authors
                .Where(a => a.FirstName.EndsWith(input.ToLower()))
                .Select(a => new
                {
                    Name = a.FirstName + " " + a.LastName
                })
                .OrderBy(a => a.Name)
                .ToList();

            var sb = new StringBuilder();

            foreach (var author in authorNamesEndingIn)
            {
                sb.AppendLine(author.Name);
            }

            return sb.ToString().Trim();
        }

        // Problem 08 - Book Search
        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var bookTitlesContaining = context
                .Books
                .Where(b => b.Title.ToLower().Contains(input.ToLower()))
                .OrderBy(b => b.Title)
                .Select(b => b.Title)
                .ToList();

            var sb = new StringBuilder();

            foreach (var book in bookTitlesContaining)
            {
                sb.AppendLine(book);
            }

            return sb.ToString().Trim();
        }

        // Problem 09 - Book Search by Author
        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var booksByAuthor = context
                .Books
                .Where(b => b.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .OrderBy(b => b.BookId)
                .Select(b => new
                {
                    AuthorFullName = b.Author.FirstName + " " + b.Author.LastName,
                    b.Title
                })
                .ToList();


            var sb = new StringBuilder();

            foreach (var book in booksByAuthor)
            {
                sb.AppendLine($"{book.Title} ({book.AuthorFullName})");
            }

            return sb.ToString().Trim();
        }

        // Problem 10 - Count Books
        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            var count = context
                .Books
                .Where(b => b.Title.Length > lengthCheck)
                .Count();

            return count;
        }

        // Problem 11 - Total Book Copies
        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var authors = context
                    .Authors
                    .Select(a => new
                    {
                        FullName = a.FirstName + " " + a.LastName,
                        Count = a.Books.Sum(b => b.Copies)
                    })
                    .OrderByDescending(a => a.Count)
                    .ToList();

            var sb = new StringBuilder();

            foreach (var author in authors)
            {
                sb.AppendLine($"{author.FullName} - {author.Count}");
            }

            return sb.ToString().Trim();
        }

        // Problem 12 - Profit by Category
        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var totalProfitByCategory = context
                .Categories
                .Select(c => new
                {
                    c.Name,
                    Sum = c.CategoryBooks.Sum(b => b.Book.Price * b.Book.Copies)
                })
                .OrderByDescending(p => p.Sum)
                .ThenBy(c => c.Name)
                .ToList();

            var sb = new StringBuilder();

            foreach (var category in totalProfitByCategory)
            {
                sb.AppendLine($"{category.Name} ${category.Sum:F2}");
            }

            return sb.ToString().Trim();
        }

        // Problem 13 - Most Recent Books
        public static string GetMostRecentBooks(BookShopContext context)
        {
            var categories = context
                .Categories
                .Select(c => new
                {
                    c.Name,
                    MostRecentBooks = c.CategoryBooks
                      .Where(b => b.Book.ReleaseDate != null)
                      .OrderByDescending(b => b.Book.ReleaseDate)
                      .Select(b => new
                      {
                          b.Book.Title,
                          b.Book.ReleaseDate.Value.Year
                      })
                      .Take(3)
                })
                .OrderBy(x => x.Name)
                .ToList();

            var sb = new StringBuilder();

            foreach (var category in categories)
            {
                sb.AppendLine($"--{category.Name}");

                foreach (var book in category.MostRecentBooks)
                {
                    sb.AppendLine($"{book.Title} ({book.Year})");
                }
            }

            return sb.ToString().Trim();
        }

        // Problem 14 - Increase Prices
        public static void IncreasePrices(BookShopContext context)
        {
            var booksBefore2010 = context
                    .Books
                    .Where(b => b.ReleaseDate.Value.Year < 2010)
                    .ToList();

            foreach (var book in booksBefore2010)
            {
                book.Price += 5;
            }

            context.SaveChanges();
        }

        // Problem 15 - Remove Books
        public static int RemoveBooks(BookShopContext context)
        {
            var booksBelow4200Copies = context
                    .Books
                    .Where(b => b.Copies < 4200)
                    .ToList();

            context.RemoveRange(booksBelow4200Copies);
            context.SaveChanges();

            return booksBelow4200Copies.Count();
        }
    }
}

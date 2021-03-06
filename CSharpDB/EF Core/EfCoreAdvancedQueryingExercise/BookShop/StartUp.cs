namespace BookShop
{
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            DbInitializer.ResetDatabase(db);

            //var inputString = Console.ReadLine();
            //Console.WriteLine(GetBooksByAgeRestriction(db, inputString));
            //Console.WriteLine(GetGoldenBooks(db));
            //Console.WriteLine(GetBooksByPrice(db));

            //int inputInt = int.Parse(Console.ReadLine());
            //Console.WriteLine(GetBooksNotReleasedIn(db, inputInt));
            //Console.WriteLine(GetBooksByCategory(db, inputString));
            //Console.WriteLine(GetBooksReleasedBefore(db, inputString));
            //Console.WriteLine(GetAuthorNamesEndingIn(db, inputString));
            //Console.WriteLine(GetBookTitlesContaining(db, inputString));
            //Console.WriteLine(GetBooksByAuthor(db, inputString));
            //Console.WriteLine(CountBooks(db, inputInt));
            Console.WriteLine(CountCopiesByAuthor(db));


        }
        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var authors = context.Authors
                .Select(x => new
                {
                    Name = x.FirstName + " " + x.LastName,
                    Books = x.Books.Sum(y => y.Copies),
                })
                .OrderByDescending(x => x.Books)
                .ToList();

            return string.Join(Environment.NewLine, authors.Select(x =>
                $"{x.Name} - {x.Books}"));
        }

        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            var books = context.Books
                .Where(x => x.Title.Length > lengthCheck)
                .Select(x => x.BookId)
                .ToList();

            return books.Count();
        }

        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var books = context.Books
                .Where(x => x.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .Select(x => new
                {
                    Id = x.BookId,
                    Title = x.Title,
                    Author = x.Author.FirstName + " " + x.Author.LastName,
                })
                .OrderBy(x => x.Id)
                .ToList();
                

            return string.Join(Environment.NewLine, books.Select(x => 
                $"{x.Title} ({x.Author})"));
        }

        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var books = context.Books
                .Where(x => x.Title.ToLower().Contains(input.ToLower()))
                .Select(x => x.Title)
                .OrderBy(x => x)
                .ToList();

            return string.Join(Environment.NewLine, books);
        }

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var authors = context.Authors
                .Where(x => x.FirstName.EndsWith(input))
                .Select(x => new
                {
                    FullName = x.FirstName + " " + x.LastName,
                })
                .OrderBy(x => x.FullName)
                .ToList();

            return string.Join(Environment.NewLine, authors.Select(x => x.FullName));
        }

        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            var targetDate = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            var books = context.Books
                .Where(x => x.ReleaseDate < targetDate)
                .Select(x => new
                {
                    x.Title,
                    x.EditionType,
                    x.Price,
                    x.ReleaseDate,
                })
                .OrderByDescending(x => x.ReleaseDate)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - {book.EditionType} - ${book.Price:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            var categories = input
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.ToLower())
                .ToArray();


            var books = context.Books
                .Include(x => x.BookCategories)
                .ThenInclude(x => x.Category)
                .ToList()
                .Where(book => book.BookCategories
                    .Any(category => categories.Contains(category.Category.Name.ToLower())))
                .Select(x => x.Title)
                .OrderBy(x => x)
                .ToList();

            return string.Join(Environment.NewLine, books);
        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            var ageRestriction = Enum.Parse<AgeRestriction>(command, true);
            var books = context.Books
                .Where(x => x.AgeRestriction == ageRestriction)
                .Select(x => x.Title)
                .OrderBy(x => x)
                .ToList();

            return string.Join(Environment.NewLine, books);
        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            var books = context.Books
                .Where(x => x.EditionType == EditionType.Gold && x.Copies < 5000)
                .Select(x => new 
                { 
                    Title = x.Title,
                    Id = x.BookId,
                })
                .OrderBy(x => x.Id)
                .ToList();

            var result = string.Join(Environment.NewLine, 
                books.Select(x => x.Title));

            return result;
        }

        public static string GetBooksByPrice(BookShopContext context)
        {
            var books = context.Books
                .Where(x => x.Price > 40)
                .Select(x => new
                {
                    Title = x.Title,
                    Price = x.Price,
                })
                .OrderByDescending(x => x.Price)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - ${book.Price:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var books = context.Books
                .Where(x => x.ReleaseDate.Value.Year != year)
                .Select(x => new
                {
                    Id = x.BookId,
                    Title = x.Title,
                })
                .OrderBy(x => x.Id)
                .ToList();

            return string.Join(Environment.NewLine, books.Select(x => x.Title));
        }
    }
}

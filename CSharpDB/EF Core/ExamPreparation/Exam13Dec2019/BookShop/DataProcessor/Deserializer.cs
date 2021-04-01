namespace BookShop.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using BookShop.Data.Models;
    using BookShop.DataProcessor.ImportDto;
    using Data;
    using Newtonsoft.Json;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedBook
            = "Successfully imported book {0} for {1:F2}.";

        private const string SuccessfullyImportedAuthor
            = "Successfully imported author - {0} with {1} books.";

        public static string ImportBooks(BookShopContext context, string xmlString)
        {
            var output = new StringBuilder();
            var books = new List<Book>();

            var xmlSerlializer =
                new XmlSerializer(typeof(BookInputModelXml[]), new XmlRootAttribute("Books"));

            var xmlBooks = (BookInputModelXml[])xmlSerlializer.Deserialize(new StringReader(xmlString));

            foreach (var xmlBook in xmlBooks)
            {
                if (!IsValid(xmlBook))
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                var isValidDate =
                    DateTime.TryParseExact(xmlBook.PublishedOn, "MM/dd/yyyy",
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out DateTime date);

                if (!isValidDate)
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                var book = new Book
                {
                    Name = xmlBook.Name,
                    Genre = Enum.Parse<Genre>(xmlBook.Genre),
                    Price = xmlBook.Price,
                    Pages = xmlBook.Pages,
                    PublishedOn = date,
                };

                output.AppendLine(string.Format(SuccessfullyImportedBook, book.Name, book.Price));

                books.Add(book);
            }

            context.Books.AddRange(books);
            context.SaveChanges();

            return output.ToString().TrimEnd();

        }

        public static string ImportAuthors(BookShopContext context, string jsonString)
        {
            var output = new StringBuilder();
            var authors = new List<Author>();

            var jsonAuthours = JsonConvert.DeserializeObject<IEnumerable<AuthorInputModelJson>>(jsonString);

            foreach (var jsonAuthor in jsonAuthours)
            {
                if (!IsValid(jsonAuthor) ||
                    !jsonAuthor.Books.Any() ||
                    authors.Any(x => x.Email == jsonAuthor.Email))
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                var author = new Author
                {
                    FirstName = jsonAuthor.FirstName,
                    LastName = jsonAuthor.LastName,
                    Phone = jsonAuthor.Phone,
                    Email = jsonAuthor.Email,
                };

                foreach (var jsonBook in jsonAuthor.Books)
                {
                    if (!jsonBook.Id.HasValue ||
                        !context.Books.Any(x => x.Id == jsonBook.Id))
                    {
                        continue;
                    }

                    var book = context.Books
                        .FirstOrDefault(x => x.Id == jsonBook.Id);

                    author.AuthorsBooks.Add(new AuthorBook
                    {
                        Author = author,
                        Book = book,
                    });
                }

                if (!author.AuthorsBooks.Any())
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                authors.Add(author);
                output.AppendLine(string.Format(
                    SuccessfullyImportedAuthor, author.FirstName + 
                    " " + author.LastName, author.AuthorsBooks.Count));

            }
            context.AttachRange(authors);
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
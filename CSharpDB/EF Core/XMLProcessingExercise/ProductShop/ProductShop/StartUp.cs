using ProductShop.Data;
using ProductShop.Dtos.Import;
using ProductShop.Models;
using System;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var db = new ProductShopContext();
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();

            var usersXml = File.ReadAllText("./Datasets/users.xml");
            var result = ImportUsers(db, usersXml);
            Console.WriteLine(result);

        }

        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(UserInputModel[]), new XmlRootAttribute("Users"));

            var textReader = new StringReader(inputXml);

            var usersDto = (UserInputModel[])xmlSerializer.Deserialize(textReader);

            var users = usersDto
                .Select(x => new User
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Age = x.Age
                }).ToList();

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count}";
        }
    }
}
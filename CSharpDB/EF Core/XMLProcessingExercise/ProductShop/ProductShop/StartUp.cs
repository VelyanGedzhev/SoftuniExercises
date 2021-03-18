using ProductShop.Data;
using ProductShop.Dtos.Import;
using ProductShop.Models;
using System;
using System.Collections.Generic;
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

            var productsXml = File.ReadAllText("./Datasets/products.xml");
            result = ImportProducts(db, productsXml);
            Console.WriteLine(result);

        }
        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(ProductInputModel[]), new XmlRootAttribute("Products"));

            var textReader = new StringReader(inputXml);

            var productsDto = (ProductInputModel[])xmlSerializer.Deserialize(textReader);

            var products = new List<Product>();

            foreach (var productDto in productsDto)
            {
                var product = new Product()
                {
                    Name = productDto.Name,
                    Price = productDto.Price,
                    SellerId = productDto.SellerId,
                    BuyerId = productDto.BuyerId,
                };
                products.Add(product);
            }

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count}";
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
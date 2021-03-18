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

            var categoriesXml = File.ReadAllText("./Datasets/categories.xml");
            result = ImportCategories(db, categoriesXml);
            Console.WriteLine(result);

            var categoryProductsXml = File.ReadAllText("./Datasets/categories-products.xml");
            result = ImportCategoryProducts(db, categoryProductsXml);
            Console.WriteLine(result);
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(CategoryProductInputModel[]), new XmlRootAttribute("CategoryProducts"));

            var textReader = new StringReader(inputXml);

            var categoryProductsDto = (CategoryProductInputModel[])xmlSerializer.Deserialize(textReader);

            var categories = context.Categories
                .Select(x => x.Id)
                .ToList();

            var products = context.Products
                .Select(x => x.Id)
                .ToList();

            var categoryProducts = categoryProductsDto
                .Where(x => categories.Contains(x.CategoryId) && products.Contains(x.ProductId))
                .Select(x => new CategoryProduct
                {
                    CategoryId = x.CategoryId,
                    ProductId = x.ProductId,
                })
                .ToList();

            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Count}";
        }

        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(CategoryInputModel[]), new XmlRootAttribute("Categories"));

            var textReader = new StringReader(inputXml);

            var categoriesDto = (CategoryInputModel[])xmlSerializer.Deserialize(textReader);

            var categories = categoriesDto
                .Where(x => x.Name != null)
                .Select(x => new Category
                {
                    Name = x.Name,
                }).ToList();

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count}";
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
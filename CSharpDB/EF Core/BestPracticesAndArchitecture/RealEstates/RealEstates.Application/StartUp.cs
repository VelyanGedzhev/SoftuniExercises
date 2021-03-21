using Microsoft.EntityFrameworkCore;
using RealEstates.Data;
using RealEstates.Services;
using System;
using System.Text;

namespace RealEstates.Application
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;

            var db = new ApplicationDbContext();
            db.Database.Migrate();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Choose an option: ");
                Console.WriteLine("Press [1] for Property Search");
                Console.WriteLine("Press [2] for Most expensive districts");
                Console.WriteLine("Press [3] for Average price per square meter");
                Console.WriteLine("Press [4] to add new Tag");
                Console.WriteLine("Press [5] to add Tags to Properties");
                Console.WriteLine("Press [0] for Exit");

                bool parsed = int.TryParse(Console.ReadLine(), out int option);
                if (parsed && option == 0)
                {
                    break;
                }

                if (parsed && option >=1 && option <= 5)
                {
                    switch (option)
                    {
                        case 1: 
                            PropertySearch(db);
                            break;
                        case 2:
                            MostExpensiveDistricts(db);
                            break;
                        case 3:
                            AveragePricePerSquareMeter(db);
                            break;
                        case 4:
                            AddTag(db);
                            break;
                        case 5:
                            BulkAddTags(db);
                            break;
                    }

                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
            }
        }

        private static void BulkAddTags(ApplicationDbContext dbContext)
        {
            Console.WriteLine("Bulk operation started!");
            IPropertiesService propertiesService = new PropertiesService(dbContext);
            ITagService tagService = new TagService(dbContext, propertiesService);
            tagService.BulkTagToPropertiesRelation();
            Console.WriteLine("Bulk operation finished!");
        }

        private static void AddTag(ApplicationDbContext dbContext)
        {
            IPropertiesService propertiesService = new PropertiesService(dbContext);
            ITagService tagService = new TagService(dbContext, propertiesService);

            Console.Write("Add tag name: ");
            var tagName = Console.ReadLine();
            Console.Write("Add tag importance (optional): ");
            var parsed = int.TryParse(Console.ReadLine(), out int tagImportance);
            int? importance = parsed ? tagImportance : null;

            tagService.Add(tagName, importance);
        }

        private static void AveragePricePerSquareMeter(ApplicationDbContext dbContext)
        {
            IPropertiesService propertiesService = new PropertiesService(dbContext);

            Console.WriteLine($"Average price per square meter: {propertiesService.AveragePricePerSquareMeter():f2} €/m²");
        }

        private static void MostExpensiveDistricts(ApplicationDbContext dbContext)
        {
            IDistrictsService service = new DistrictsService(dbContext);

            Console.WriteLine("District count: ");
            int districtCount = int.Parse(Console.ReadLine());

            var districts = service.GetMostExpensiveDistricts(districtCount);

            foreach (var district in districts)
            {
                Console.WriteLine($"{district.Name} -- {district.AveragePricePerSqrMeter:f2} €/m² -- {district.PropertiesCount}");
            }
        }

        private static void PropertySearch(ApplicationDbContext dbContext)
        {
            Console.Write("Min price: ");
            int minPrice = int.Parse(Console.ReadLine());
            Console.Write("Max price: ");
            int maxPrice = int.Parse(Console.ReadLine());
            Console.Write("Min size: ");
            int minSize = int.Parse(Console.ReadLine());
            Console.Write("Max size: ");
            int maxSize = int.Parse(Console.ReadLine());

            IPropertiesService service = new PropertiesService(dbContext);
            var properties = service.Search(minPrice, maxPrice, minSize, maxSize);

            foreach (var property in properties)
            {
                Console.WriteLine($"{property.District} -- {property.BuildingType} -- {property.PropertyType} -- {property.Price} € -- {property.Size} m²");
            }
        }
    }
}

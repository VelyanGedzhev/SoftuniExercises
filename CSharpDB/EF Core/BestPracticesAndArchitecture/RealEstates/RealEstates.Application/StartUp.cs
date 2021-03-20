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
            var db = new ApplicationDbContext();
            db.Database.Migrate();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Choose an option: ");
                Console.WriteLine("Press [1] for Property Search");
                Console.WriteLine("Press [2] for Most expensive districts");
                Console.WriteLine("Press [0] for Exit");

                bool parsed = int.TryParse(Console.ReadLine(), out int option);
                if (parsed && option == 0)
                {
                    break;
                }

                if (parsed && option >=1 && option <= 2)
                {
                    switch (option)
                    {
                        case 1: 
                            PropertySearch(db);
                            break;
                        case 2:
                            MostExpensiveDistricts(db);
                            break;
                    }

                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
            }
        }

        private static void MostExpensiveDistricts(ApplicationDbContext dbContext)
        {
            IDistrictsService service = new DistrictsService(dbContext);

            Console.WriteLine("District count: ");
            int districtCount = int.Parse(Console.ReadLine());

            var districts = service.GetMostExpensiveDistricts(districtCount);

            foreach (var district in districts)
            {
                Console.WriteLine($"{district.Name} -- {district.AveragePricePerSqrMeter}€/m² -- {district.PropertiesCount}");
            }
        }

        private static void PropertySearch(ApplicationDbContext dbContext)
        {
            Console.WriteLine("Min price: ");
            int minPrice = int.Parse(Console.ReadLine());
            Console.WriteLine("Max price: ");
            int maxPrice = int.Parse(Console.ReadLine());
            Console.WriteLine("Min size: ");
            int minSize = int.Parse(Console.ReadLine());
            Console.WriteLine("Max size: ");
            int maxSize = int.Parse(Console.ReadLine());

            IPropertiesService service = new PropertiesService(dbContext);
            var properties = service.Search(minPrice, maxPrice, minSize, maxSize);

            foreach (var property in properties)
            {
                Console.WriteLine($"{property.District} -- {property.BuildingType} -- {property.PropertyType} -- {property.Price}€ -- {property.Size}m²");
            }
        }
    }
}

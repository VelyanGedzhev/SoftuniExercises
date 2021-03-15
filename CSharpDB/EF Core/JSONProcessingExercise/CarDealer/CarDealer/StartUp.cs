using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using CarDealer.Data;
using CarDealer.DTO;
using CarDealer.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace CarDealer
{
    public class StartUp
    {
        static IMapper mapper;

        public static void Main(string[] args)
        {
            var db = new CarDealerContext();
            //db.Database.EnsureDeleted();
            //db.Database.EnsureCreated();
            //ImportData(db);

            Console.WriteLine(GetCarsWithTheirListOfParts(db));
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context.Cars
                .Include(x => x.PartCars)
                .Select(x => new
                {
                    car = new
                    {
                        Make = x.Make,
                        Model = x.Model,
                        TravelledDistance = x.TravelledDistance,
                    },
                    parts = x.PartCars
                    .Select(p => new
                    {
                        Name = p.Part.Name,
                        Price = p.Part.Price.ToString("f2"),
                    }).ToList()
                }).ToList();

            return JsonConvert.SerializeObject(cars, Formatting.Indented);
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                .Where(x => x.IsImporter == false)
                .Select(x => new
                {
                    Id = x.Id,
                    Name = x.Name,
                    PartsCount = x.Parts.Count(),
                }).ToList();

            return JsonConvert.SerializeObject(suppliers, Formatting.Indented);
        }

        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var cars = context.Cars
                .Where(x => x.Make == "Toyota")
                .Select(x => new
                {
                    Id = x.Id,
                    Make = x.Make,
                    Model = x.Model,
                    TravelledDistance = x.TravelledDistance,
                })
                .OrderBy(x => x.Model)
                .ThenByDescending(x => x.TravelledDistance)
                .ToList();

            return JsonConvert.SerializeObject(cars, Formatting.Indented);
        }

        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var customers = context.Customers
                .OrderBy(x => x.BirthDate)
                .ThenBy(x => x.IsYoungDriver)
                .Select(x => new
                {
                    Name = x.Name,
                    BirthDate = x.BirthDate.ToString("dd/MM/yyyy"),
                    IsYoungDriver = x.IsYoungDriver,
                })
                .ToList();

            return JsonConvert.SerializeObject(customers, Formatting.Indented);
        }

        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            InitializeAutomapper();

            var salesDto = JsonConvert.DeserializeObject<IEnumerable<SaleInputModel>>(inputJson);

            var sales = mapper.Map<IEnumerable<Sale>>(salesDto);

            context.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count()}.";
        }

        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            InitializeAutomapper();

            var customersDto = JsonConvert.DeserializeObject<IEnumerable<CustomerInputModel>>(inputJson);

            var customers = mapper.Map<IEnumerable<Customer>>(customersDto);

            context.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count()}.";
        }

        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            var carsDto = JsonConvert.DeserializeObject<IEnumerable<CartInputModel>>(inputJson);

            var cars = new List<Car>();

            foreach (var car in carsDto)
            {
                var currentCar = new Car()
                {
                    Make = car.Make,
                    Model = car.Model,
                    TravelledDistance = car.TravelledDistance,
                };

                foreach (var partId in car?.PartsId.Distinct())
                {
                    currentCar.PartCars.Add(new PartCar
                    {
                        PartId = partId,
                    });
                }

                cars.Add(currentCar);
            }

            context.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count()}.";
        }

        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            InitializeAutomapper();

            var suppplierIds = context.Suppliers
               .Select(x => x.Id).ToList();

            var partsDto = JsonConvert.DeserializeObject<IEnumerable<PartInputModel>>(inputJson)
                .Where(s => suppplierIds.Contains(s.SupplierId))
                .ToList();

            var parts = mapper.Map<IEnumerable<Part>>(partsDto);
            context.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count()}.";
        }

        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            var suppliersDto = JsonConvert.DeserializeObject<IEnumerable<SupplierInputModel>>(inputJson);

            var suppliers = suppliersDto.Select(x => new Supplier
            {
                Name = x.Name,
                IsImporter = x.IsImporter,
            }).ToList();

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count()}."; ;
        }

        private static void InitializeAutomapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            });

            mapper = config.CreateMapper();
        }

        private static void ImportData(CarDealerContext db)
        {
            var json = File.ReadAllText("../../../Datasets/suppliers.json");
            Console.WriteLine(ImportSuppliers(db, json));

            json = File.ReadAllText("../../../Datasets/parts.json");
            Console.WriteLine(ImportParts(db, json));

            json = File.ReadAllText("../../../Datasets/cars.json");
            Console.WriteLine(ImportCars(db, json));

            json = File.ReadAllText("../../../Datasets/customers.json");
            Console.WriteLine(ImportCustomers(db, json));

            json = File.ReadAllText("../../../Datasets/sales.json");
            Console.WriteLine(ImportSales(db, json));
        }

    }
}
using AutoMapper;
using CarDealer.Data;
using CarDealer.DataTransferObjects.Input;
using CarDealer.DataTransferObjects.Output;
using CarDealer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

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

            //Console.WriteLine(GetCarsWithDistance(db));
            //Console.WriteLine(GetCarsFromMakeBmw(db));
            //Console.WriteLine(GetLocalSuppliers(db));
            //Console.WriteLine(GetCarsWithTheirListOfParts(db));
            Console.WriteLine(GetTotalSalesByCustomer(db));
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context.Customers
                .Where(x => x.Sales.Any())
                .Select(x => new CustomerOutputModel
                {
                    FullName = x.Name,
                    BoughtCars = x.Sales.Count,
                    SpentMoney = x.Sales
                        .Select(s => s.Car)
                        .SelectMany(pc => pc.PartCars).Sum(p => p.Part.Price)
                })
                .OrderByDescending(x => x.SpentMoney)
                .ToArray();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(CustomerOutputModel[]), new XmlRootAttribute("customers"));

            var textWriter = new StringWriter();

            xmlSerializer.Serialize(textWriter, customers, GetXmlNamesspaces());

            return textWriter.ToString();
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context.Cars
                .Select(x => new CarPartOutputModel
                {
                    Make = x.Make,
                    Model = x.Model,
                    TravelledDistance = x.TravelledDistance,
                    Parts = x.PartCars.Select(p => new CarPartInfoOutputModel
                    {
                        Name = p.Part.Name,
                        Price = p.Part.Price,
                    })
                    .OrderByDescending(p => p.Price)
                    .ToArray()
                })
                .OrderByDescending(x => x.TravelledDistance)
                .ThenBy(x => x.Model)
                .Take(5)
                .ToArray();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(CarPartOutputModel[]), new XmlRootAttribute("cars"));

            var textWriter = new StringWriter();

            xmlSerializer.Serialize(textWriter, cars, GetXmlNamesspaces());

            return textWriter.ToString();
        }
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                .Where(x => !x.IsImporter)
                .Select(x => new SupplierOutputModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    PartsCount = x.Parts.Count,
                }).ToArray();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(SupplierOutputModel[]), new XmlRootAttribute("suppliers"));

            var textWriter = new StringWriter();

            xmlSerializer.Serialize(textWriter, suppliers, GetXmlNamesspaces());

            return textWriter.ToString().Trim();
        }

        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            var cars = context.Cars
                .Where(x => x.Make == "BMW")
                .Select(x => new BmwCarOutputModel
                {
                    Id = x.Id,
                    Model = x.Model,
                    TravelledDistance = x.TravelledDistance,
                })
                .OrderBy(x => x.Model)
                .ThenByDescending(x => x.TravelledDistance)
                .ToArray();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(BmwCarOutputModel[]), new XmlRootAttribute("cars"));

            var textWriter = new StringWriter();


            xmlSerializer.Serialize(textWriter, cars, GetXmlNamesspaces());

            return textWriter.ToString();
        }
        public static string GetCarsWithDistance(CarDealerContext context)
        {
            var cars = context.Cars
                .Where(x => x.TravelledDistance > 2_000_000)
                .Select(x => new CarOutputModel
                {
                    Make = x.Make,
                    Model = x.Model,
                    TravelledDistance = x.TravelledDistance,
                })
                .OrderBy(x => x.Make)
                .ThenBy(x => x.Model)
                .Take(10)
                .ToArray();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(CarOutputModel[]), new XmlRootAttribute("cars"));

            var textWriter = new StringWriter();  

            xmlSerializer.Serialize(textWriter, cars, GetXmlNamesspaces());

            return textWriter.ToString();
        }

        private static void ImportData(CarDealerContext db)
        {

            var supplierXml = File.ReadAllText("./Datasets/suppliers.xml");
            var result = ImportSuppliers(db, supplierXml);
            Console.WriteLine(result);

            var partsXml = File.ReadAllText("./Datasets/parts.xml");
            result = ImportParts(db, partsXml);
            Console.WriteLine(result);

            var carsXml = File.ReadAllText("./Datasets/cars.xml");
            result = ImportCars(db, carsXml);
            Console.WriteLine(result);

            var customersXml = File.ReadAllText("./Datasets/customers.xml");
            result = ImportCustomers(db, customersXml);
            Console.WriteLine(result);

            var salesXml = File.ReadAllText("./Datasets/sales.xml");
            result = ImportSales(db, salesXml);
            Console.WriteLine(result);
        }

        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            var allCars = context.Cars.Select(x => x.Id).ToList();

            var xmlSerializer = new XmlSerializer(typeof(SaleInputModel[]), new XmlRootAttribute("Sales"));

            var textReader = new StringReader(inputXml);
            var salesDto = xmlSerializer.Deserialize(textReader) as SaleInputModel[];

            var sales = salesDto
                .Where(x => allCars.Contains(x.CarId))
                .Select(x => new Sale
                {
                    CarId = x.CarId,
                    CustomerId = x.CustomerId,
                    Discount = x.Discount
                }).ToList();

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count()}"; ;
        }

        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            InitializeAutoMapper();
            var xmlSerializer = new XmlSerializer(typeof(CustomerInputModel[]), new XmlRootAttribute("Customers"));

            var textReader = new StringReader(inputXml);
            var customersDto = xmlSerializer.Deserialize(textReader) as CustomerInputModel[];

            var customers = mapper.Map<Customer[]>(customersDto);

            context.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count()}";
        }

        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(CarInputModel[]), new XmlRootAttribute("Cars"));

            var textReader = new StringReader(inputXml);
            var carsDto = xmlSerializer.Deserialize(textReader) as CarInputModel[];

            var allParts = context.Parts.Select(x => x.Id).Distinct();

            var cars = carsDto
                .Select(x => new Car
                {
                    Make = x.Make,
                    Model = x.Model,
                    TravelledDistance = x.TravelledDistance,
                    PartCars = x.CarPartsInputModel.Select(x => x.Id)
                        .Distinct()
                        .Intersect(allParts)
                        .Select(pc => new PartCar
                        {
                            PartId = pc,
                        }).ToList()
                }).ToList();

            context.Cars.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count()}";
        }

        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(PartInputModel[]), new XmlRootAttribute("Parts"));

            var textReader = new StringReader(inputXml);
            var partsDto = xmlSerializer.Deserialize(textReader) as PartInputModel[];

            var suppliersIds = context.Suppliers
                .Select(x => x.Id).ToList();

            var parts = partsDto
                .Where(x => suppliersIds.Contains(x.SupplierId))
                .Select(x => new Part
                {
                    Name = x.Name,
                    Price = x.Price,
                    Quantity = x.Quantity,
                    SupplierId = x.SupplierId,
                }).ToList();

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count}";
        }

        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(SupplierInputModel[]), new XmlRootAttribute("Suppliers"));
            var textReader = new StringReader(inputXml);
            var suppliersDto = (SupplierInputModel[])xmlSerializer.Deserialize(textReader);

            var suppliers = suppliersDto
                .Select(x => new Supplier
                {
                    Name = x.Name,
                    IsImporter = x.IsImporter
                }).ToList();

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count}";
        }

        private static void InitializeAutoMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            });

            mapper = config.CreateMapper();
        }

        private static XmlSerializerNamespaces GetXmlNamesspaces()
        {
            XmlSerializerNamespaces xmlSerializerNamespaces = new XmlSerializerNamespaces();
            xmlSerializerNamespaces.Add(string.Empty, string.Empty);

            return xmlSerializerNamespaces;
        }
    }
}
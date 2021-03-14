using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using CarDealer.Data;
using CarDealer.DTO;
using CarDealer.Models;
using Newtonsoft.Json;

namespace CarDealer
{
    public class StartUp
    {
        static IMapper mapper;

        public static void Main(string[] args)
        {
            var db = new CarDealerContext();
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();

           var json = File.ReadAllText("../../../Datasets/suppliers.json");
           Console.WriteLine(ImportSuppliers(db, json));

            json = File.ReadAllText("../../../Datasets/parts.json");
            Console.WriteLine(ImportParts(db, json));


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
            var suppliersDto = JsonConvert.DeserializeObject<IEnumerable<ImportSupplierInputModel>>(inputJson);

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

    }
}
using RealEstates.Data;
using RealEstates.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace RealEstates.Importer
{
    class StartUp
    {
        static void Main(string[] args)
        {
            ImportJsonFile("houses.json");
            ImportJsonFile("apartments.json");
        }

        private static void ImportJsonFile(string fileName)
        {
            var db = new ApplicationDbContext();
            IPropertiesService propertiesService = new PropertiesService(db);

            var properties = JsonSerializer.Deserialize<IEnumerable<PropertyAsJson>>(
                            File.ReadAllText(fileName));

            foreach (var jsonProp in properties)
            {
                propertiesService.Add(jsonProp.District, jsonProp.Floor,
                    jsonProp.TotalFloors, jsonProp.Size, jsonProp.YardSize,
                    jsonProp.Year, jsonProp.Type, jsonProp.BuildingType, jsonProp.Price);
                Console.WriteLine(".");
            }
        }
    }
}

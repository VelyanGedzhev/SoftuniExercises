using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.IO;
//using Newtonsoft.Json;

namespace JSONProcessingDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //System.Text.Json
            Serialize();
            Deserialize();


            //Json.net - newtonsoft.json
            //Console.WriteLine(JsonConvert.SerializeObject(new { Name = "Niki", Course = "EF Core"}));

            //var json = File.ReadAllText("myCar.json");
            //var car = JsonConvert.DeserializeObject<Car>(json);

        }

        private static void Deserialize()
        {
            var json = File.ReadAllText("myCar.json");
            Car car = JsonSerializer.Deserialize<Car>(json);
        }

        private static void Serialize()
        {
            var car = new Car
            {
                Extras = new List<string> { "Climatronic", "4x4", "Xenon lights" },
                ManufacturedOn = DateTime.Now,
                Model = "Golf",
                Vendor = "VW",
                Price = 12355.9M,
                Engine = new Engine { Volume = 1.6, HorsePower = 90 },
            };

            File.WriteAllText("myCar.json", JsonSerializer.Serialize(car));
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                WriteIndented = true,
            };

            Console.WriteLine(JsonSerializer.Serialize(car, options));
        }
    }
}

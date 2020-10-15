using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace _6._VehicleCatalogue
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = string.Empty;
            List<Vehicle> vehicles = new List<Vehicle>();

            while ((command = Console.ReadLine()) != "End")
            {
                string[] data = command
                    .Split()
                    .ToArray();

                Vehicle currentVehicle = new Vehicle(data);
                vehicles.Add(currentVehicle);
                
            }

            while ((command = Console.ReadLine()) != "Close the Catalogue")
            {
                Console.WriteLine(vehicles.FirstOrDefault(x => x.Model == command));
            }
            var cars = vehicles.FindAll(x => x.VehicleType == "car");
            var averageHorsepowerCars = cars.Sum(c => c.Horsepower) * 1.0 / cars.Count;
            var trucks = vehicles.FindAll(k => k.VehicleType == "truck");
            var averageHorsepowerTrucks = trucks.Sum(z => z.Horsepower) * 1.0 / trucks.Count ;

            if (cars.Count == 0)
            {
                averageHorsepowerCars = 0;
            }
            if (trucks.Count == 0)
            {
                averageHorsepowerTrucks = 0;
            }
            Console.WriteLine($"Cars have average horsepower of: {averageHorsepowerCars:f2}.");
            Console.WriteLine($"Trucks have average horsepower of: {averageHorsepowerTrucks:f2}.");
            
        }
        public class Vehicle
        {
            public string VehicleType { get; set; }
            public string Model { get; set; }
            public string Color { get; set; }
            public int Horsepower { get; set; }

            public Vehicle(string[] input)
            {
                VehicleType = input[0];
                Model = input[1];
                Color = input[2];
                Horsepower = int.Parse(input[3]);
            }

            public override string ToString()
            {
                StringBuilder result = new StringBuilder();

                if (VehicleType == "car")
                {
                    result.AppendLine("Type: Car");
                }
                else
                {
                    result.AppendLine("Type: Truck");

                }
                
                result.AppendLine("Model: " + Model);
                result.AppendLine("Color: " + Color);
                result.AppendLine("Horsepower: " + Horsepower.ToString());

                return result.ToString().TrimEnd();
            }
        }
    }
}

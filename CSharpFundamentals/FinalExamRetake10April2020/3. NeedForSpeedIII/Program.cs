using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace _3._NeedForSpeedIII
{
    class Program
    {
        static void Main(string[] args)
        {
            int carsCount = int.Parse(Console.ReadLine());
            Dictionary<string, Vehicle> vehicles = new Dictionary<string, Vehicle>();

            for (int i = 1; i <= carsCount; i++)
            {
                string[] cars = Console.ReadLine()
                    .Split("|");
                Vehicle vehicle = new Vehicle(cars);
                vehicles.Add(cars[0], vehicle);
            }
            string command = Console.ReadLine();
            while (command != "Stop")
            {
                string[] operation = command
                    .Split(" : ");
                string car = operation[1];

                if (command.Contains("Drive"))
                {
                    int distance = int.Parse(operation[2]);
                    int fuelNeeded = int.Parse(operation[3]);

                    if (vehicles[car].Fuel < fuelNeeded)
                    {
                        Console.WriteLine("Not enough fuel to make that ride");
                        
                    }
                    else
                    {
                        vehicles[car].Fuel -= fuelNeeded;
                        vehicles[car].Mileage += distance;
                        Console.WriteLine($"{car} driven for {distance} kilometers. {fuelNeeded} liters of fuel consumed.");
                    }

                    if (vehicles[car].Mileage >= 100000)
                    {
                        vehicles.Remove(car);
                        Console.WriteLine($"Time to sell the {car}!");
                    }
                }
                else if (command.Contains("Refuel"))
                {
                    int amount = int.Parse(operation[2]);
                    int fuel = 0;

                    if (vehicles[car].Fuel + amount <= 75)
                    {
                        vehicles[car].Fuel += amount;
                        fuel = amount;
                    }
                    else
                    {
                        fuel = (75 - vehicles[car].Fuel);
                        vehicles[car].Fuel += fuel;
                        
                    }
                    Console.WriteLine($"{car} refueled with {fuel} liters");
                }
                else if (command.Contains("Revert"))
                {
                    int kilometers = int.Parse(operation[2]);

                    vehicles[car].Mileage -= kilometers;
                    
                    if (vehicles[car].Mileage < 10000)
                    {
                        vehicles[car].Mileage = 10000;
                        continue;
                    }
                    Console.WriteLine($"{car} mileage decreased by {kilometers} kilometers");
                }
                command = Console.ReadLine();
            }
            var sortedVehicles = vehicles.OrderByDescending(x => x.Value.Mileage)
                .ThenBy(x => x.Key);

            foreach (var item in sortedVehicles)
            {
                Console.WriteLine($"{item.Key} -> Mileage: {item.Value.Mileage} kms," +
                    $" Fuel in the tank: {item.Value.Fuel} lt.");
            }
        }
        public class Vehicle
        {
            public int Mileage { get; set; }
            public int Fuel { get; set; }

            public Vehicle(string[] cars)
            {
                this.Mileage = int.Parse(cars[1]);
                this.Fuel = int.Parse(cars[2]);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Vehicles.Core.Interfaces;
using Vehicles.Factories;
using Vehicles.Models;

namespace Vehicles.Core
{
    public class Engine : IEngine
    {

        private readonly VehicleFactory vehicleFactory;
        public Engine()
        {
            vehicleFactory = new VehicleFactory();
        }
        public void Run()
        {
            Vehicle car = GetVehicleInfo();
            Vehicle truck = GetVehicleInfo();
            Vehicle bus = GetVehicleInfo();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string commandType = command[0];
                string vehicleType = command[1];
                double amount = double.Parse(command[2]);

                try
                {
                    if (commandType == "Drive")
                    {
                        if (vehicleType == "Car")
                        {
                            Drive(car, amount);
                        }
                        else if (vehicleType == "Truck")
                        {
                            Drive(truck, amount);
                        }
                        else if (vehicleType == "Bus")
                        {
                            Drive(bus, amount);
                        }
                       
                    }
                    else if (commandType == "DriveEmpty")
                    {
                        DriveEmpty(bus, amount);
                    }
                    else if (commandType == "Refuel")
                    {
                        if (vehicleType == "Car")
                        {
                            Refuel(car, amount);
                        }
                        else if (vehicleType == "Truck")
                        {
                            Refuel(truck, amount);
                        }
                        else if (vehicleType == "Bus")
                        {
                            Refuel(bus, amount);
                        }
                    }
                }
                catch (InvalidOperationException ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }
            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);
        }
        
        private Vehicle GetVehicleInfo()
        {

            string[] vehicleArgs = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string vehicleType = vehicleArgs[0];
            double fuel = double.Parse(vehicleArgs[1]);
            double fuelConsumption = double.Parse(vehicleArgs[2]);
            double tankCapacity = double.Parse(vehicleArgs[3]);

            return vehicleFactory.CreateVehicle(vehicleType, fuel, fuelConsumption, tankCapacity);
        }
        private void Drive(Vehicle vehicle, double amount)
        {
            Console.WriteLine(vehicle.Drive(amount));
        }
        private void DriveEmpty(Vehicle vehicle, double amount)
        {
            Console.WriteLine(vehicle.DriveEmpty(amount));
        }
        private void Refuel(Vehicle vehicle, double amount)
        {
            vehicle.Refuel(amount);
        }
    }
}

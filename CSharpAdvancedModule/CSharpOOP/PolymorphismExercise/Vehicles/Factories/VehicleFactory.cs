using System;
using System.Collections.Generic;
using System.Text;
using Vehicles.Models;
using Vehicles.Models.Common;

namespace Vehicles.Factories
{
    public class VehicleFactory
    {
        public Vehicle CreateVehicle(string type, double fuel, double fuelConsumption, double tankCapacity)
        {
            Vehicle vehicle = null;

            if (type == "Car")
            {
                
                vehicle = new Car(fuel, fuelConsumption, tankCapacity);
            }
            else if (type == "Truck")
            {
                
                vehicle = new Truck(fuel, fuelConsumption, tankCapacity);
            }
            else if (type == "Bus")
            {
                //if (fuel > tankCapacity)
                //{
                //    fuel = 0;
                //}
                vehicle = new Bus(fuel, fuelConsumption, tankCapacity);
            }
            else if(vehicle == null)
            {
                throw new InvalidCastException(string.Format(ExceptionMessages.INVALID_VEHICLE, type));
            }
            return vehicle;
        }
    }
}

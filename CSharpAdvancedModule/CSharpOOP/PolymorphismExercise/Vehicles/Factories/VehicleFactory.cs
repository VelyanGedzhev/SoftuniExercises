using System;
using System.Collections.Generic;
using System.Text;
using Vehicles.Models;
using Vehicles.Models.Common;

namespace Vehicles.Factories
{
    public class VehicleFactory
    {
        public Vehicle CreateVehicle(string type, double fuel, double fuelConsumption)
        {
            Vehicle vehicle;

            if (type == "Car")
            {
                vehicle = new Car(fuel, fuelConsumption);
            }
            else if (type == "Truck")
            {
                vehicle = new Truck(fuel, fuelConsumption);
            }
            else
            {
                throw new InvalidCastException(string.Format(ExceptionMessages.INVALID_VEHICLE, type));
            }
            return vehicle;
        }
    }
}

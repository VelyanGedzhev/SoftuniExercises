using System;
using System.Collections.Generic;
using System.Text;
using Vehicles.Models.Common;

namespace Vehicles.Models
{
    public class Bus : Vehicle
    {
        private const double SUMMER_CONSUMPTION_MODIFIER = 1.4;

        public Bus(double fuel, double fuelConsumption, double tankCapacity) 
            : base(fuel, fuelConsumption, tankCapacity)
        {
        }
        public override string Drive(double kilometers)
        {
            double fuelNeeded = kilometers * (FuelConsumption + SUMMER_CONSUMPTION_MODIFIER);

            if (Fuel < fuelNeeded)
            {
                string excMsg = string.Format(ExceptionMessages.NOT_ENOUGH_FUEL, GetType().Name);
                throw new InvalidOperationException(excMsg);
            }

            Fuel -= fuelNeeded;

            return $"{GetType().Name} travelled {kilometers} km";
        }
        public override string DriveEmpty(double kilometers)
        {
            double fuelNeeded = kilometers * FuelConsumption;

            if (Fuel < fuelNeeded)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.NOT_ENOUGH_FUEL, GetType().Name));
            }

            Fuel -= fuelNeeded;
            return base.DriveEmpty(kilometers);
        }
    }
}

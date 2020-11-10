using System;
using Vehicles.Models.Common;
using Vehicles.Models.Interfaces;

namespace Vehicles.Models
{
    public abstract class Vehicle : IDrive, IRefuel
    {
        private const string ENOUGH_FUEL = "{0} travelled {1} km";

        protected Vehicle(double fuel, double fuelConsumption)
        {
            Fuel = fuel;
            FuelConsumption = fuelConsumption;
        }

        public double Fuel { get; private set; }
        public virtual double FuelConsumption { get; }
        public string Drive(double kilometers)
        {
            double fuelNeeded = kilometers * FuelConsumption;

            if (fuelNeeded <= Fuel)
            {
                Fuel -= fuelNeeded;
                return string.Format(ENOUGH_FUEL, GetType().Name, kilometers);
            }
            else
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.NOT_ENOUGH_FUEL, GetType().Name));
            }
        }

        public virtual void Refuel(double amount)
        {
            Fuel += amount;
        }

        public override string ToString()
        {
            return $"{GetType().Name}: {Fuel:f2}";
        }
    }
}

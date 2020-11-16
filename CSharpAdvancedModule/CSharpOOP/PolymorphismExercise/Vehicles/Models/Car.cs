using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Models
{
    public class Car : Vehicle
    {
        private const double SUMMER_CONSUMPTION_MODIFIER = 0.9;

        public Car(double fuel, double fuelConsumption, double tankCapacity) 
            : base(fuel, fuelConsumption, tankCapacity)
        {
        }

        public override double FuelConsumption 
        { 
            get => base.FuelConsumption; 
            protected set => base.FuelConsumption = value + SUMMER_CONSUMPTION_MODIFIER; 
        }
    }
}

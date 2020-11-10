using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Models
{
    public class Car : Vehicle
    {
        private const double SUMMER_CONSUMPTION_MODIFIER = 0.9;
        public Car(double fuel, double fuelConsumption) : base(fuel, fuelConsumption)
        {
        }

        public override double FuelConsumption => base.FuelConsumption + SUMMER_CONSUMPTION_MODIFIER;
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Models.Common
{
    public static class ExceptionMessages
    {
        public const string NOT_ENOUGH_FUEL = "{0} needs refueling";
        public const string INVALID_VEHICLE = "{0} is invalid type";
        public const string NOT_ENOUGH_TANK_CAPACITY = "Cannot fit {0} fuel in the tank";
        public const string INVALID_FUEL_QUANTITY = "Fuel must be a positive number";
    }
}

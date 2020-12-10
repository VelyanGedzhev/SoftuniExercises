using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Cars.Entities
{
    public class MuscleCar : Car
    {
        private int horsePower;

        public MuscleCar(string model, int horsePower) 
            : base(model, horsePower, 5000)
        {
        }

        public override int HorsePower
        {
            get => horsePower;

            protected set
            {
                if (value < 400 || value > 600)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidHorsePower, value));
                }

                horsePower = value;
            }
        }
    }
}




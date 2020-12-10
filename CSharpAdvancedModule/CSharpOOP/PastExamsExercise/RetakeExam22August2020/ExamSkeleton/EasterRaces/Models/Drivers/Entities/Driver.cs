using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Drivers.Entities
{
    public class Driver : IDriver
    {
        private string name;
        private ICar car;
        private int wins;

        public Driver(string name)
        {
            Name = name;
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 5)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidName, value, 5));
                         
                }
                name = value;
            }
        }

        public ICar Car => car;

        public int NumberOfWins => wins;

        public bool CanParticipate
        {
            get
            {
                if (Car != null)
                {
                    return true;
                }
                return false;
            }
        }

        public void AddCar(ICar car)
        {
            if (car == null)
            {
                throw new ArgumentException(ExceptionMessages.CarInvalid);
            }

            this.car = car;
        }

        public void WinRace()
        {
            wins++;
        }
    }
}

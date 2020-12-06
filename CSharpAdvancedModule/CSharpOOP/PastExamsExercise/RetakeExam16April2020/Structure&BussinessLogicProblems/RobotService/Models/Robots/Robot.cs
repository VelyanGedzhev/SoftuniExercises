using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotService.Models.Robots
{
    public abstract class Robot : IRobot
    {
        private int happiness;
        private int energy;
        protected Robot(string name, int happiness, int energy, int procedureTime)
        {
            Name = name;
            Happiness = happiness;
            Energy = energy;
            ProcedureTime = procedureTime;
            Owner = "Service";
            IsBought = false;
            IsChipped = false;
            IsChecked = false;
        }

        public  string Name { get; }
        public  int Happiness
        {
            get => happiness;

            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidHappiness);
                }

                happiness = value;
            }
        }
        public  int Energy
        {
            get => energy;

            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidEnergy);
                }

                energy = value;
            }
        }
        public  int ProcedureTime { get; set; }
        public  string Owner { get; set; }
        public  bool IsBought { get; set; }
        public  bool IsChipped { get; set; }
        public  bool IsChecked { get; set; }

        public override string ToString()
        {
            return $" Robot type: {GetType().Name} - {Name} - Happiness: {Happiness} - Energy: {Energy}";
        }
    }
}

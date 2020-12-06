using RobotService.Core.Contracts;
using RobotService.Models.Garages;
using RobotService.Models.Garages.Contracts;
using RobotService.Models.Procedures;
using RobotService.Models.Procedures.Contracts;
using RobotService.Models.Robots;
using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Enums;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotService.Core
{
    public class Controller : IController
    {
        private readonly IGarage garage;
        private readonly Dictionary<Procedures, IProcedure> procedurs;
       
        public Controller()
        {
            garage = new Garage();
            procedurs = new Dictionary<Procedures, IProcedure>();
            CreateProcedures();
        }

        public string Charge(string robotName, int procedureTime)
        {
            IRobot robot = GetRobotByName(robotName);
            IProcedure procedure = procedurs[Procedures.Charge];
            procedure.DoService(robot, procedureTime);

            return $"{robot.Name} had charge procedure";
        }

        public string Chip(string robotName, int procedureTime)
        {
            IRobot robot = GetRobotByName(robotName);
            IProcedure procedure = procedurs[Procedures.Chip];
            procedure.DoService(robot, procedureTime);

            return $"{robot.Name} had chip procedure";
        }

        public string History(string procedureType)
        {
            Enum.TryParse(procedureType, out Procedures procedureTypeEnum);

            IProcedure procedure = procedurs[procedureTypeEnum];

            return procedure.History();
        }

        public string Manufacture(string robotType, string name, int energy, int happiness, int procedureTime)
        {
            if (!Enum.TryParse(robotType, out Robots robotTypeName))
            {
                throw new ArgumentException($"{robotType} type doesn't exist");
            }

            IRobot robot = CreateRobot(name, energy, happiness, procedureTime, robotTypeName);

            garage.Manufacture(robot);

            return $"Robot {robot.Name} registered successfully";
        }

        public string Polish(string robotName, int procedureTime)
        {
            IRobot robot = GetRobotByName(robotName);
            IProcedure procedure = procedurs[Procedures.Polish];
            procedure.DoService(robot, procedureTime);

            return $"{robot.Name} had polish procedure";
        }

        public string Rest(string robotName, int procedureTime)
        {
            IRobot robot = GetRobotByName(robotName);
            IProcedure procedure = procedurs[Procedures.Rest];
            procedure.DoService(robot, procedureTime);

            return $"{robot.Name} had rest procedure";
        }

        public string Sell(string robotName, string ownerName)
        {
            IRobot robot = GetRobotByName(robotName);
            garage.Sell(robotName, ownerName);

            string outputMsg;
            if (robot.IsChipped)
            {
                outputMsg = $"{ownerName} bought robot with chip";

            }
            else
            {
                outputMsg = $"{ownerName} bought robot without chip";

            }

            return outputMsg;
        }

        public string TechCheck(string robotName, int procedureTime)
        {
            IRobot robot = GetRobotByName(robotName);
            IProcedure procedure = procedurs[Procedures.TechCheck];
            procedure.DoService(robot, procedureTime);

            return $"{robot.Name} had tech check procedure";
        }

        public string Work(string robotName, int procedureTime)
        {
            IRobot robot = GetRobotByName(robotName);
            IProcedure procedure = procedurs[Procedures.Work];
            procedure.DoService(robot, procedureTime);

            return $"{robot.Name} was working for {procedureTime} hours";
        }

        private void CreateProcedures()
        {
            procedurs.Add(Procedures.Chip, new Chip());
            procedurs.Add(Procedures.Charge, new Charge());
            procedurs.Add(Procedures.Rest, new Rest());
            procedurs.Add(Procedures.Polish, new Polish());
            procedurs.Add(Procedures.Work, new Work());
            procedurs.Add(Procedures.TechCheck, new TechCheck());
        }

        private IRobot GetRobotByName(string robotName)
        {
            if (!garage.Robots.ContainsKey(robotName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InexistingRobot, robotName));
            }
            return garage.Robots[robotName];
        }

        private static IRobot CreateRobot(string name, int energy, int happiness, int procedureTime, Robots robotTypeName)
        {
            IRobot robot = null;

            switch (robotTypeName)
            {
                case Robots.PetRobot:
                    robot = new PetRobot(name, energy, happiness, procedureTime);
                    break;
                case Robots.HouseholdRobot:
                    robot = new HouseholdRobot(name, energy, happiness, procedureTime);
                    break;
                case Robots.WalkerRobot:
                    robot = new WalkerRobot(name, energy, happiness, procedureTime);
                    break;

            }

            return robot;
        }
    }
}

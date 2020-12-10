using EasterRaces.Core.Contracts;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Cars.Entities;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Drivers.Entities;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Models.Races.Entities;
using EasterRaces.Repositories.Contracts;
using EasterRaces.Repositories.Entities;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Core.Entities
{
    public class ChampionshipController : IChampionshipController
    {
        private IRepository<IDriver> driverRepository;
        private IRepository<IRace> raceRepository;
        private IRepository<ICar> carRepository;

        public ChampionshipController()
        {
            carRepository = new CarRepository();
            driverRepository = new DriverRepository();
            raceRepository = new RaceRepository();
        }

        public string AddCarToDriver(string driverName, string carModel)
        {

            if (!driverRepository.GetAll().Any(x => x.Name == driverName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.DriverNotFound, driverName));
            }

            if (!carRepository.GetAll().Any(x => x.Model == carModel))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.CarNotFound, carModel));
            }

            IDriver driver = driverRepository.GetByName(driverName);
            ICar car = carRepository.GetByName(carModel);

            driver.AddCar(car);

            return string.Format(OutputMessages.CarAdded, driverName, carModel);
        }

        public string AddDriverToRace(string raceName, string driverName)
        {
            if (!raceRepository.GetAll().Any(x => x.Name == raceName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }

            if (!driverRepository.GetAll().Any(x => x.Name == driverName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.DriverNotFound, driverName));
            }

            IRace race = raceRepository.GetByName(raceName);
            IDriver driver = driverRepository.GetByName(driverName);

            race.AddDriver(driver);

            return string.Format(OutputMessages.DriverAdded, driverName, raceName);
        }

        public string CreateCar(string type, string model, int horsePower)
        {
            ICar car = null;

            if (carRepository.GetAll().Any(x => x.Model == model))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CarExists, model));
            }
            

            if (type == "Muscle")
            {
                car = new MuscleCar(model, horsePower);
            }
            else if (type == "Sports")
            {
                car = new SportsCar(model, horsePower);
            }

            carRepository.Add(car);

            return string.Format(OutputMessages.CarCreated, car.GetType().Name, model);
        }

        public string CreateDriver(string driverName)
        {

            if (driverRepository.GetAll().Any(x => x.Name == driverName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.DriversExists, driverName));
            }

            IDriver driver = new Driver(driverName);
            driverRepository.Add(driver);

            return string.Format(OutputMessages.DriverCreated, driverName);
        }

        public string CreateRace(string name, int laps)
        {
            if (raceRepository.GetAll().Any(x => x.Name == name))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceExists, name));
            }

            raceRepository.Add(new Race(name, laps));

            return string.Format(OutputMessages.RaceCreated, name);
        }

        public string StartRace(string raceName)
        {
            if (!raceRepository.GetAll().Any(x => x.Name == raceName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }

            var raceParticipants = raceRepository.GetByName(raceName).Drivers.Count;

            if (raceParticipants < 3)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceInvalid, raceName, 3));
            }

            var currentRace = raceRepository.GetByName(raceName);

            var drivers = currentRace.Drivers
                .OrderByDescending(x => x.Car.CalculateRacePoints(currentRace.Laps))
                .ToList();

            var winner = drivers.FirstOrDefault();
            var second = drivers.Skip(1).FirstOrDefault();
            var third = drivers.Skip(2).FirstOrDefault();

            StringBuilder sb = new StringBuilder();
            sb
                .AppendLine(string.Format(OutputMessages.DriverFirstPosition, winner.Name, currentRace.Name))
                .AppendLine(string.Format(OutputMessages.DriverSecondPosition, second.Name, currentRace.Name))
                .AppendLine(string.Format(OutputMessages.DriverThirdPosition, third.Name, currentRace.Name));

            raceRepository.Remove(currentRace);

            return sb.ToString().TrimEnd();

            
        }
    }
}

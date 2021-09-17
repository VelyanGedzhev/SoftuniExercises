using NUnit.Framework;
using System;
using TheRace;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        private UnitCar car;
        private UnitCar anotherCar;
        private UnitDriver driver;
        private UnitDriver anotherDriver;
        private RaceEntry race;

        [SetUp]
        public void Setup()
        {
            car = new UnitCar("Golf", 110, 2000);
            anotherCar = new UnitCar("Lada", 90, 1800);
            driver = new UnitDriver("Mikka", car);
            anotherDriver = new UnitDriver("Ivancho", anotherCar);
            race = new RaceEntry();
        }

        [Test]
        [Category("UnitCar")]
        [TestCase("Golf", 110, 2000)]
        public void UnitCarConstructorShouldSetPropertiesCorrectly(string model, int horsePower, double cubicCentimeters)
        {
            Assert.AreEqual(model, car.Model);
            Assert.AreEqual(horsePower, car.HorsePower);
            Assert.AreEqual(cubicCentimeters, car.CubicCentimeters);
        }

        [Test]
        [Category("UnitDriver")]
        public void UnitDriverConstructorShouldSetPropertiesCorrectly()
        {
            Assert.AreEqual("Mikka", driver.Name);
            Assert.AreEqual(car, driver.Car);
        }

        [Test]
        [Category("UnitDriver")]
        public void UnitDriverNameShouldThrowExceptionIfInvalid()
        {
            Assert.Throws<ArgumentNullException>(() =>
            new UnitDriver(null, car));
        }

        //TODO: Unit tests for RaceEntry

        [Test]
        [Category("RaceEntry")]
        public void WhenAddIsCalledItShouldThrowExceptionIfDriverIsNull()
        {
            Assert.Throws<InvalidOperationException>(() =>
            race.AddDriver(null));
        }

        [Test]
        [Category("RaceEntry")]
        public void WhenAddIsCalledItShouldThrowExceptionIfDriverExist()
        {
            race.AddDriver(driver);

            Assert.Throws<InvalidOperationException>(() =>
            race.AddDriver(driver));
        }

        [Test]
        [Category("RaceEntry")]
        public void WhenAddIsCalledDriverCountShouldIncrease()
        {
            race.AddDriver(driver);

            Assert.AreEqual(1, race.Counter);
        }

        [Test]
        [Category("RaceEntry")]
        public void WhenAddIsCalledItShouldReturnCorrectResult()
        {

            Assert.AreEqual("Driver Mikka added in race.", race.AddDriver(driver));
        }

        [Test]
        [Category("RaceEntry")]
        public void WhenCalculateAverageHorsePowerIsCalledItShouldThrowExceptionIfDriversCountIsLessThanMinParticipants()
        {
            race.AddDriver(driver);

            Assert.Throws<InvalidOperationException>(() =>
            race.CalculateAverageHorsePower());
        }

        [Test]
        [Category("RaceEntry")]
        public void WhenCalculateAverageHorsePowerIsCalledItShouldReturnCorrectAvgHorsePower()
        {
            race.AddDriver(driver);
            race.AddDriver(anotherDriver);

            Assert.AreEqual(100, race.CalculateAverageHorsePower());
        }
    }
}
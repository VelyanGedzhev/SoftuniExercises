using NUnit.Framework;
using System;
using TheRace;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        private UnitCar car;
        private UnitDriver driver;
        private RaceEntry race;

        [SetUp]
        public void Setup()
        {
            car = new UnitCar("Golf", 110, 2000);
            driver = new UnitDriver("Mikka", car);
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
    }
}
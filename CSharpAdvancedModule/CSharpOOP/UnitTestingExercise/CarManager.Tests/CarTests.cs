using CarManager;
using NUnit.Framework;
using System;

namespace Tests
{
    public class CarTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase("Honda", "Civic", 5, 80, 0)]
        [TestCase("BMW", "3", 9, 100, 0)]
        [TestCase("VW", "Golf", 7, 60, 0)]
        public void CarConstructorShouldSetAllDataCorrectly(string make, string model, double fuelConsumption, double fuelCapacity, double fuelAmount)
        {
            //Arrange - Act
            Car car = new Car(
                make: make,
                model: model,
                fuelConsumption: fuelConsumption,
                fuelCapacity: fuelCapacity
                );

            //Assert
            Assert.AreEqual(car.Make, make);
            Assert.AreEqual(car.Model, model);
            Assert.AreEqual(car.FuelConsumption, fuelConsumption);
            Assert.AreEqual(car.FuelCapacity, fuelCapacity);
            Assert.AreEqual(car.FuelAmount, fuelAmount);
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void CarConstructorShouldThrowExceptionIfMakeIsNullOrEmpty(string make)
        {
            //Arrange - Act - Assert
            Assert.Throws<ArgumentException>(() =>
            new Car(make, "Civic", 7, 60));
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void CarConstructorShouldThrowExceptionIfModelIsNullOrEmpty(string model)
        {
            //Arrange - Act - Assert
            Assert.Throws<ArgumentException>(() =>
            new Car("Honda", model, 7, 60));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-12)]
        public void CarConstructorShouldThrowExceptionIfFuelConsumptionIsNegativeOrZero(double fuelConsumption)
        {
            //Arrange - Act - Assert
            Assert.Throws<ArgumentException>(() =>
            new Car("Honda", "Civic", fuelConsumption, 60));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-12)]
        public void CarConstructorShouldThrowExceptionIfFuelCapacityIsNegativeOrZero(double fuelCapacity)
        {
            //Arrange - Act - Assert
            Assert.Throws<ArgumentException>(() =>
            new Car("Honda", "Civic", 10, fuelCapacity));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-12)]
        public void RefuelShouldThrowExceptionWhenPassedValueIsNegativeOrZero(double value)
        {
            //Arrange
            Car car = new Car("VW", "Golf", 10, 50);

            //Act - Assert
            Assert.Throws<ArgumentException>(() =>
            car.Refuel(value));
        }

        [Test]
        [TestCase(70, 100, 70)]
        [TestCase(150, 100, 100)]
        public void RefuelShouldWorkAsExpected(double refuelValue, double fuelCapacity, double expectedResult)
        {
            //Arrange
            Car car = new Car("Honda", "Civic", 20, fuelCapacity);

            //Act
            car.Refuel(refuelValue);

            //Assert
            var actualResult = car.FuelAmount;
            Assert.AreEqual(expectedResult, actualResult);

        }

        [Test]
        [TestCase(10, 50, 505)]
        [TestCase(15, 30, 201)]
        public void DriveShouldThrowExceptionIfFuelAmountIsNotEnough(double fuelConsumption, double refuelValue, double distance)
        {
            //Arrange
            Car car = new Car("Honda", "Civic", fuelConsumption, 100);
         
            //Act - Assert
            Assert.Throws<InvalidOperationException>(() =>
            car.Drive(distance));
        }

        [Test]
        [TestCase(10, 100, 50, 95)]
        [TestCase(5, 26, 500, 1)]
        public void DriveShouldWorkAsExpected(double fuelConsumption, double refuelValue, double distance, double expectedValue)
        {
            //Arrange
            Car car = new Car("Honda", "Civic", fuelConsumption, 100);
            car.Refuel(refuelValue);

            //Act
            car.Drive(distance);

            //Assert
            var actualValue = car.FuelAmount;
            Assert.AreEqual(expectedValue, actualValue);

        }

    }
}
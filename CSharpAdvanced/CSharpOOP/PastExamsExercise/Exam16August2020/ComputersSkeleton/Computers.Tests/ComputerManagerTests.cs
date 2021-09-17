using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Computers.Tests
{
    public class Tests
    {
        private Computer computer;
        private Computer otherComputer;
        private Computer anotherComputer;
        private ComputerManager manager;

        [SetUp]
        public void Setup()
        {
            computer = new Computer("Intel", "i7", 340);
            otherComputer = new Computer("Intel", "i3", 190);
            anotherComputer = new Computer("AMD", "Phenom II", 300);
            manager = new ComputerManager();
        }

        [Test]
        [Category("Computer")]
        [TestCase("Intel", "i7", 340)]
        public void WhenArgumentsAreGivenComputerPropertiesShouldBeSetCorrectly(string expectedManufacturer, string exptectedModel, decimal expectedPrice)
        {
            Assert.AreEqual(expectedManufacturer, computer.Manufacturer);
            Assert.AreEqual(exptectedModel, computer.Model);
            Assert.AreEqual(expectedPrice, computer.Price);
        }

        [Test]
        [Category("ComputerManager")]
        public void WhenAddIsCalledExceptionIsThrownIfInvalidComputer()
        {
            Assert.Throws<ArgumentNullException>(()=> 
            manager.AddComputer(null));
        }

        [Test]
        [Category("ComputerManager")]
        public void WhenAddIsCalledExceptionIsThrownIfComputerAlreadyExist()
        {
            manager.AddComputer(computer);

            Assert.Throws<ArgumentException>(() =>
            manager.AddComputer(computer));
        }

        [Test]
        [Category("ComputerManager")]
        public void WhenAddIsCalledCountShouldIncreaseIfComputerIsValid()
        {
            manager.AddComputer(computer);

            Assert.AreEqual(1, manager.Count);
        }

        [Test]
        [Category("ComputerManager")]
        public void WhenGetComputerIsCalledExceptionIsThrownIfComputerDoesntExist()
        {
            Assert.Throws<ArgumentException>(() =>
            manager.GetComputer(computer.Manufacturer, computer.Model));
        }

        [Test]
        [Category("ComputerManager")]
        public void WhenGetComputerIsCalledExceptionIsThrownIfManufacturerIsNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            manager.GetComputer(null, computer.Model));
        }

        [Test]
        [Category("ComputerManager")]
        public void WhenGetComputerIsCalledExceptionIsThrownIfModelIsNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            manager.GetComputer(computer.Manufacturer, null));
        }

        [Test]
        [Category("ComputerManager")]
        public void WhenGetComputerIsCalledItShouldReturnCorrectComputer()
        {
            manager.AddComputer(computer);

            Assert.AreEqual(computer, manager.GetComputer(computer.Manufacturer, computer.Model));
        }

        [Test]
        [Category("ComputerManager")]
        public void WhenRemoveIsCalledExceptionIsThrownIfManufacturerIsNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            manager.RemoveComputer(null, computer.Model));
        }

        [Test]
        [Category("ComputerManager")]
        public void WhenRemoveIsCalledExceptionIsThrownIfModelIsNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            manager.RemoveComputer(computer.Manufacturer, null));
        }

        [Test]
        [Category("ComputerManager")]
        public void WhenRemoveIsCalledItShouldReturnCorrectComputerAndCountShouldDecrease()
        {
            manager.AddComputer(computer);

            Assert.AreEqual(computer, manager.RemoveComputer(computer.Manufacturer, computer.Model));
            Assert.AreEqual(0, manager.Count);
        }

        [Test]
        [Category("ComputerManager")]
        public void WhenGetComputersByManufacturerIsCalledExceptionIsThrownIfManufacturerIsNull()
        {
            manager.AddComputer(computer);

            Assert.Throws<ArgumentNullException>(() =>
            manager.GetComputersByManufacturer(null));
        }

        [Test]
        [Category("ComputerManager")]
        public void GetComputersByManufacturerShouldReturnEmptyCollectionWhenNoMatchesFound()
        {
            manager.AddComputer(computer);

            var collection = manager.GetComputersByManufacturer("Asus").ToList();

            CollectionAssert.IsEmpty(collection);
        }

        [Test]
        [Category("ComputerManager")]
        public void WhenGetComputersByManufacturerIsCalledItShouldReturnCorrectComputers()
        {
            manager.AddComputer(computer);
            manager.AddComputer(otherComputer);
            manager.AddComputer(anotherComputer);
            
            List<Computer> computers = manager.GetComputersByManufacturer("Intel").ToList();

            Assert.AreEqual(2, computers.Count);
            Assert.AreEqual(computer, computers[0]);
        }
    }
}
namespace INStock.Tests
{
    using INStock.Interfaces;
    using INStock.Models;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class ProductTests
    {
        [Test]
        public void QuantityCannotBeNegative()
        {
            //Assert
            Assert.Throws<ArgumentException>(() =>
            new Product("Carlsberg", 2.50m, -1));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void LabelCannotBeNullOrEmpty(string label)
        {
            //Assert
            Assert.Throws<ArgumentException>(() =>
            new Product(label, 2.50m, -1));
        }

        [Test]
        public void PriceCannotBeNegative()
        {
            //Assert
            Assert.Throws<ArgumentException>(() =>
            new Product("Carlsberg", -2.50m, 1));
        }

        [Test]
        public void ProductsShouldBeComparedByPriceWhenOrderIsIncorrect()
        {
            //Arrange
            IProduct firstProduct = new Product("Carlsberg", 5m, 3);
            IProduct secondProduct = new Product("Tuborg", 2m, 3);

            //Act
            int incorrectOrderResult = firstProduct.CompareTo(secondProduct);

            //Assert
            Assert.That(incorrectOrderResult > 0, Is.True);
        }

        [Test]
        public void ProductsShouldBeComparedByPriceWhenOrderIsCorrect()
        {
            //Arrange
            IProduct firstProduct = new Product("Carlsberg", 5m , 3);
            IProduct secondProduct = new Product("Tuborg", 2m , 3);

            //Act
            var correctOrderResult = secondProduct.CompareTo(firstProduct);

            //Assert
            Assert.That(correctOrderResult < 0, Is.True);
        }  

        [Test]
        public void ProductsShouldBeComparedByPriceWhenOrderIsEqual()
        {
            //Arrange
            IProduct firstProduct = new Product("Tuborg", 2m, 3);
            IProduct secondProduct = new Product("Shumensko", 2m, 3);

            //Act
            var equalOrderResult = firstProduct.CompareTo(secondProduct);

            //Assert
            Assert.That(equalOrderResult == 0, Is.True);
        }
    }
}
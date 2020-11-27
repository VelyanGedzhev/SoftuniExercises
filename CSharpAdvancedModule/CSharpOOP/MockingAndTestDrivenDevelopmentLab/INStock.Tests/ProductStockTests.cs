namespace INStock.Tests
{
    using INStock.Interfaces;
    using INStock.Models;
    using Moq;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    //[TestFixture]
    public class ProductStockTests
    {
        private IList<IProduct> Repo;
        private Mock<IProduct> product;
        private ProductStock productStock;

        [SetUp]
        public void Initialize()
        {
            Repo = new List<IProduct>();
            product = new Mock<IProduct>();
            productStock = new ProductStock(Repo);
            product.Setup(p => p.Label).Returns("Carlsberg");
        }

        [Test]
        public void ProductShouldBeAddedCorrectly()
        {
            //Act
            productStock.Add(product.Object);

            //Assert
            Assert.That(productStock[0].Label, Is.EqualTo("Carlsberg"));
        }
        [Test]
        public void LabelMustBeUnique()
        {
            productStock.Add(product.Object);


            Assert.Throws<ArgumentException>(() =>
            productStock.Add(product.Object));
        }

        [Test]
        public void ContainsOperationShouldWorkCorrectly()
        {
            //Act
            productStock.Add(product.Object);
            bool containsProduct = productStock.Contains(product.Object);

            //Assert
            Assert.That(containsProduct, Is.EqualTo(true));
        }

        [Test]
        public void ProductStockShouldCountProductsCorrectly()
        {
            Repo.Add(product.Object);

            int count = productStock.Count;

            Assert.AreEqual(1, count);
        }

        [Test]
        public void FindShouldThrowExceptionIfIndexIsNegative()
        {

            Assert.Throws<InvalidOperationException>(() =>
            productStock.Find(-1));
        }

        [Test]
        [TestCase(1)]
        public void FindShouldThrowExceptionIfIndexIsBiggerThanProductStockCount(int index)
        {
            productStock.Add(product.Object);
            Assert.Throws<InvalidOperationException>(() =>
            productStock.Find(index));
        }

        [Test]
        [TestCase(0, "Carlsberg")]
        public void FindShouldReturnCorrectProduct(int index, string expectedLabel)
        {
            productStock.Add(product.Object);
            
            string actualLabel = productStock.Find(index).Label;

            Assert.AreEqual(expectedLabel, actualLabel);
        }
    }
}

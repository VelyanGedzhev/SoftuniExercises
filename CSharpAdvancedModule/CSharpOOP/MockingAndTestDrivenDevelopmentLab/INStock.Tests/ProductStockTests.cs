namespace INStock.Tests
{
    using INStock.Interfaces;
    using INStock.Models;
    using Moq;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [TestFixture]
    public class ProductStockTests
    {
        private const string productLabel = "Carlsberg";
        private const string anotherProductLabel = "Tuborg";

        private IProductStock productStock;
        private IProduct product;
        private IProduct secondProduct;

        [SetUp]
        public void SetUpProduct()
        {
            product = new Product(productLabel, 3m, 2);
            productStock = new ProductStock();
            secondProduct = new Product(anotherProductLabel, 2m, 5);
        }

        [Test]
        public void AddProductShouldSaveTheProductCorrectly()
        {
            //Act
            productStock.Add(product);

            //Assert
            IProduct expectedProduct = productStock.FindByLabel(productLabel);

            Assert.AreEqual(expectedProduct.Label, productStock[0].Label);
            Assert.AreEqual(expectedProduct.Price, productStock[0].Price);
            Assert.AreEqual(expectedProduct.Quantity, productStock[0].Quantity);

        }

        [Test]
        public void AddProductShouldThrowExceptionWhenDuplicatLabel()
        {
            productStock.Add(product);

            Assert.Throws<ArgumentException>(() =>
            productStock.Add(product));
        }
        [Test]
        public void RemoveShouldThrowExceptionWhenProductIsNull()
        {
            Assert.Throws<ArgumentException>(() =>
            productStock.Remove(null));
        }

        [Test]
        public void RemoveShouldReturnTrueWhenProductIsRemoved()
        {
            //Arrange
            AddMultipleProducts();
            var productToRemove = productStock.Find(3);

            //Act
            var result = productStock.Remove(productToRemove);

            //Assert
            Assert.That(result, Is.True);
            Assert.That(productStock.Count, Is.EqualTo(6));
            Assert.That(productStock[3].Label, Is.EqualTo("SomeHighEndBeer"));

        }
        [Test]
        public void RemoveShouldReturnFalseWhenProductIsNotRemoved()
        {
            //Arrange
            AddMultipleProducts();
            var productToRemove = new Product("beer", 1m ,12);

            //Act
            var result = productStock.Remove(productToRemove);

            //Assert
            Assert.That(result, Is.False);
            Assert.That(productStock.Count, Is.EqualTo(7));
        }

        [Test]
        public void ContainsShouldReturnTrueWhenProductExcists()
        {
            //Arrange
            productStock.Add(product);

            //Act
            var result = productStock.Contains(product);

            //Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public void ContainsShouldReturnFalseWhenProductDoesntExcists()
        {
            //Arrange
            productStock.Add(product);

            //Act
            var result = productStock.Contains(secondProduct);

            //Assert
            Assert.That(result, Is.False);
        }

        [Test]
        public void ContainsShouldThrowExeptionWhenProductIsNull()
        {
            Assert.Throws<ArgumentException>(() =>
            productStock.Contains(null));
        }

        [Test]
        public void CountShouldReturnCorrectCount()
        {
            //Arrange
            productStock.Add(product);
            productStock.Add(secondProduct);

            //Act
            var expectedResult = 2;

            //Assert
            Assert.AreEqual(expectedResult, productStock.Count);
        }

        [Test]
        public void FindShouldReturnCorrectProductByGivenIndex()
        {
            productStock.Add(product);
            productStock.Add(secondProduct);

            var actualResult = productStock.Find(1);

            Assert.AreEqual(secondProduct, actualResult);
        }

        [Test]
        public void FindShouldThrowExceptionWhenIndexIsOutOfRange()
        {
            productStock.Add(product);

            Assert.Throws<IndexOutOfRangeException>(() =>
            productStock.Find(1));
        }

        [Test]
        public void FindShouldThrowExceptionWhenIndexIsBelowZero()
        {
            Assert.Throws<IndexOutOfRangeException>(() =>
            productStock.Find(-1));
        }

        [Test]
        public void FindByLabelShouldThrowExceptionWhenLabelIsNull()
        {
            Assert.Throws<ArgumentException>(() =>
           productStock.FindByLabel(null));
        }

        [Test]
        public void FindByLabelShouldThrowExceptionWhenLabelDoesntExcist()
        {
            Assert.Throws<ArgumentException>(() =>
           productStock.FindByLabel("Invalid label"));
        }

        [Test]
        public void FindByLabelShouldReturnCorrectProduct()
        {
            //Arrange
            productStock.Add(product);
            productStock.Add(secondProduct);

            //Act
            var expectedProduct = productLabel;
            var actualProduct = productStock.FindByLabel(productLabel).Label;

            //Assert
            Assert.AreEqual(expectedProduct, actualProduct);
        }

        [Test]
        public void FindAllInPriceRangeShouldReturnEmptyCollectionWhenNoProductMatch()
        {
            //Arrange
            AddMultipleProducts();

            //Act
            var result = productStock.FindAllInPriceRange(5, 7);

            //Assrt
            Assert.That(result, Is.Empty);

        }

        [Test]
        public void FindAllInPriceRangeShouldReturnCorrectCollectionInCorrectOrder()
        {
            //Arrange
            AddMultipleProducts();

            //Act
            var expectedResult = 4;
            var result = productStock.FindAllInPriceRange(1, 5).ToList();

            //Assrt
            Assert.AreEqual(expectedResult, result.Count);
            Assert.That(result[0].Price, Is.EqualTo(4m));
            Assert.That(result[1].Price, Is.EqualTo(3m));
            Assert.That(result[2].Price, Is.EqualTo(2m));
        }

        [Test]
        public void FindAllByPriceShoudlReturnEmptyCollectionWhenNoProductMatch()
        {
            //Arrange
            AddMultipleProducts();

            //Act
            var result = productStock.FindAllByPrice(405);

            //Assrt
            Assert.That(result, Is.Empty);
        }

        [Test]
        public void FindAllByPriceShouldReturnCorrectCollection()
        {
            //Arrange
            AddMultipleProducts();

            //Act
            var expectedResult = 2;
            var result = productStock.FindAllByPrice(45).ToList();

            //Assrt
            Assert.AreEqual(expectedResult, result.Count);
            Assert.That(result[0].Price, Is.EqualTo(45m));
            Assert.That(result[1].Price, Is.EqualTo(45m));

        }

        [Test]
        public void FindMostExpensiveProductShouldThrowExceptionWhenCollectionIsEmpty()
        {
            Assert.Throws<ArgumentException>(() =>
            productStock.FindMostExpensiveProduct());

        }

        [Test]
        public void FindMostExpensiveProductShouldReturnCorrectProduct()
        {
            //Arrange
            AddMultipleProducts();

            //Act
            var actualResult = productStock.FindMostExpensiveProduct();


            //Assert
            Assert.That(actualResult.Label, Is.EqualTo("TopNotchBeer"));
            Assert.That(actualResult.Price, Is.EqualTo(70m));
            Assert.That(actualResult.Quantity, Is.EqualTo(1));
        }

        [Test]
        public void FindallByQuantityhoudlReturnEmptyCollectionWhenNoProductMatch()
        {
            //Arrange
            AddMultipleProducts();

            //Act
            var result = productStock.FindAllByQuantity(5);

            //Assert
            Assert.That(result, Is.Empty);
        }

        [Test]
        public void FindallByQuantityhoudlReturnCorrectCollection()
        {
            //Arrange
            AddMultipleProducts();

            //Act
            var result = productStock.FindAllByQuantity(1);

            //Assert
            Assert.That(result.Count(), Is.EqualTo(7));
        }

        [Test]
        public void GetEnumeratorShouldReturnCorrectInsertionOrder()
        {
            //Arrange
            AddMultipleProducts();
            var result = new List<IProduct>();

            //Act
            foreach (IProduct product in productStock)
            {
                result.Add(product);
            }
            //Assert
            Assert.That(result[0].Label, Is.EqualTo("Shumensko"));
            Assert.That(result[1].Label, Is.EqualTo("Tuborg"));
            Assert.That(result[2].Label, Is.EqualTo("Carlsberg"));
            Assert.That(result[3].Label, Is.EqualTo("Duvel"));
            Assert.That(result[4].Label, Is.EqualTo("SomeHighEndBeer"));
            Assert.That(result[5].Label, Is.EqualTo("AnotherHighEndBeer"));
            Assert.That(result[6].Label, Is.EqualTo("TopNotchBeer"));

        }

        [Test]
        public void GetIndexShouldReturnCorrectProductByIndex()
        {
            productStock.Add(product);
            productStock.Add(secondProduct);

            var actualResult = productStock[1];

            Assert.AreEqual(secondProduct, actualResult);
        }

        [Test]
        public void SetIndexShouldThrowExceptionWhenIndesIsOutOfRange()
        {
            productStock.Add(product);

            Assert.Throws<IndexOutOfRangeException>(() =>
            productStock.Find(1));
        }

        [Test]
        public void SetIndexShouldThrowExceptionWhenIndexIsBelowZero()
        {
            Assert.Throws<IndexOutOfRangeException>(() =>
            productStock.Find(-1));
        }

        [Test]
        public void SetIndexShouldChangeProduct()
        {
            const string label = "Yet another product";
            //Arrange
            AddMultipleProducts();

            //Act
            productStock[3] = new Product(label, 50m , 3);

            //Assert
            var productInStock = productStock.Find(3);

            Assert.AreEqual(productInStock.Label, label);
            Assert.AreEqual(productInStock.Price, 50m);
            Assert.AreEqual(productInStock.Quantity, 3);
        }

        private void AddMultipleProducts()
        {
            productStock.Add(new Product("Shumensko", 1m, 1));
            productStock.Add(new Product("Tuborg", 2m, 1));
            productStock.Add(new Product("Carlsberg", 3m, 1));
            productStock.Add(new Product("Duvel", 4m, 1));
            productStock.Add(new Product("SomeHighEndBeer", 45m, 1));
            productStock.Add(new Product("AnotherHighEndBeer", 45m, 1));
            productStock.Add(new Product("TopNotchBeer", 70m, 1));

            var result = productStock.FindAllInPriceRange(1, 5);
        }
    }
}

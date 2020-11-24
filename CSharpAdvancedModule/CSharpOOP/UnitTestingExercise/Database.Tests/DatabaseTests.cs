using NUnit.Framework;
using System;
using System.Linq;

namespace Tests
{
    public class DatabaseTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ConstructorShouldBeInitializedWithSixteenElements()
        {
            //Arrange
            int[] numbers = Enumerable.Range(1, 16).ToArray();
            Database.Database database = new Database.Database(numbers);

            //Act - Assert
            var expectedResult = 16;
            var actualResult = database.Count;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void ConstructorShouldThrowExceptionIfThereAreNoSixteenElements()
        {
            //Arrange
            int[] numbers = Enumerable.Range(1, 14).ToArray();
            Database.Database database = new Database.Database(numbers);


            //Act - Assert
            var expectedResult = 14;
            var actualResult = database.Count;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void AddOperationShouldAddElementAtNextFreeCell()
        {
            //Arrange
            int[] numbers = Enumerable.Range(1, 10).ToArray();
            Database.Database database = new Database.Database(numbers);

            //Act
            database.Add(5);
            var allElements = database.Fetch();

            //Assert
            var expectedValue = 5;
            var actualValue = allElements[10];
            var expectedCount = 11;
            var actualCount = database.Count;

            Assert.AreEqual(expectedValue, actualValue);
            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void AddOperationShouldThrowExceptionIfElementsAreMoreThanSixteen()
        {
            //Arrange
            int[] numbers = Enumerable.Range(1, 16).ToArray();
            Database.Database database = new Database.Database(numbers);

            //Act - Assert
            Assert.Throws<InvalidOperationException>(() =>
            database.Add(15));
        }

        [Test]
        public void RemoveOperationShouldRemoveOnlyTheElementAtTheLastIndex()
        {
            //Arrange
            int[] numbers = Enumerable.Range(1, 16).ToArray();
            Database.Database database = new Database.Database(numbers);

            //Act
            database.Remove();

            //Assert
            var expectedResult = 15;
            var actualResult = database.Fetch()[14];

            var expectedCount = 15;
            var actualCount = database.Count;

            Assert.AreEqual(expectedResult, actualResult);
            Assert.AreEqual(expectedCount, actualCount);
            
        }

        [Test]
        public void RemoveOperationShouldThrowExceptionIfDatabaseIsEmpty()
        {
            //Arrange
            Database.Database database = new Database.Database();

            //Act - Assert
            Assert.Throws<InvalidOperationException>(() =>
            database.Remove());
        }

        [Test]
        public void FetchShouldReturnAllElements()
        {
            //Arrange
            int[] numbers = Enumerable.Range(1, 5).ToArray();
            Database.Database database = new Database.Database(numbers);

            //Act
            var allElements = database.Fetch();

            //Assert
            int[] expectedValues = new int[] { 1, 2, 3, 4, 5 };

            CollectionAssert.AreEqual(allElements, expectedValues);
        }
    }
}
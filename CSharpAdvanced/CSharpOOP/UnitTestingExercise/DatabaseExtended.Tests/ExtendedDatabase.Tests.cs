using System;
using ExtendedDatabase;
using NUnit.Framework;

public class ExtendedDatabaseTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void EmptyConstructorShouldReturnCountZero()
    {
        // Arrange
        var db = new ExtendedDatabase.ExtendedDatabase();

        // Act
        var actualResult = db.Count;
        var expectedResult = 0;

        //Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void AddOnePersonInTheConstructorShouldReturnCountOne()
    {
        // Arrange
        var person = new Person(1, "James Milner");
        var db = new ExtendedDatabase.ExtendedDatabase(person);

        // Act
        var actualResult = db.Count;
        var expectedResult = 1;

        //Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void ConstructorShouldThrowExceptionIfElementsAreMoreThanCollectionSize()
    {
        // Arrange
        var personArr = new Person[17];

        for (int i = 0; i < personArr.Length; i++)
        {
            personArr[i] = new Person(i + 1, $"Firmino {i + 1}");
        }

        // Assert
        Assert.Throws<ArgumentException>(
            () => new ExtendedDatabase.ExtendedDatabase(personArr), // Act
            "The collection is not full.");
    }

    [Test]
    public void AddShouldWorkCorrectly()
    {
        // Arrange
        var db = new ExtendedDatabase.ExtendedDatabase(new Person(5, "Firmino"));

        // Act
        db.Add(new Person(9, "Mane"));

        var actualResult = db.FindById(9);

        // Assert
        Assert.That(actualResult.Id, Is.EqualTo(9));
        Assert.That(actualResult.UserName, Is.EqualTo("Mane"));
    }

    [Test]
    public void AddShouldThrowExceptionWhenAddingPersonInFullCollection()
    {
        // Arrange
        var personArr = new Person[16];

        for (int i = 0; i < personArr.Length; i++)
        {
            personArr[i] = new Person(i + 1, $"Klopp {i + 1}");
        }

        var db = new ExtendedDatabase.ExtendedDatabase(personArr);

        // Assert
        Assert.Throws<InvalidOperationException>(
            () => db.Add(new Person(105, "Jurgen")), // Act
            "The collection is not full.");
    }

    [Test]
    public void AddShouldThrowExceptionIfUsernameExists()
    {
        // Arrange
        var db = new ExtendedDatabase.ExtendedDatabase(new Person(4, "Firmino"));

        // Assert
        Assert.Throws<InvalidOperationException>(
            () => db.Add(new Person(1, "Firmino")), // Act
            "The person NAME is unique.");
    }

    [Test]
    public void AddShouldThrowExceptionIfIDExists()
    {
        // Arrange
        var db = new ExtendedDatabase.ExtendedDatabase(new Person(15, "Milner"));

        // Assert
        Assert.Throws<InvalidOperationException>(
            () => db.Add(new Person(15, "Firmino")), // Act
            "The person ID is unique.");
    }

    [Test]
    public void AddPersonShouldIncrementCount()
    {
        // Arrange
        var db = new ExtendedDatabase.ExtendedDatabase(new Person(48, "Mane"));

        // Act
        db.Add(new Person(3, "Salah"));

        var actualResult = db.Count;
        var expectedResult = 2;

        // Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void AddTwoPersonsShouldIncrementCountWithTwo()
    {
        // Arrange
        var db = new ExtendedDatabase.ExtendedDatabase(new Person(8, "Gerrard"));

        // Act
        db.Add(new Person(5, "Agger"));
        db.Add(new Person(1, "Allison"));

        var actualResult = db.Count;
        var expectedResult = 3;

        // Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void RemovePersonShouldDecrementCount()
    {
        // Arrange
        var db = new ExtendedDatabase.ExtendedDatabase(new Person(9, "Firmino"));

        // Act
        db.Add(new Person(5, "Agger"));
        db.Add(new Person(1, "Allison"));
        db.Add(new Person(66, "TAA"));

        db.Remove();

        var actualResult = db.Count;
        var expectedResult = 3;

        // Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void RemoveTwoPersonsShouldDecrementCountWithTwo()
    {
        // Arrange
        var db = new ExtendedDatabase.ExtendedDatabase(new Person(9, "Firmino"));

        // Act
        db.Add(new Person(66, "TAA"));
        db.Add(new Person(3, "Robertson"));

        db.Remove();
        db.Remove();

        var actualResult = db.Count;
        var expectedResult = 1;

        // Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void RemoveShouldThrowExceptionWhenCollectionIsEmpty()
    {
        // Arrange
        var db = new ExtendedDatabase.ExtendedDatabase();

        // Assert
        Assert.Throws<InvalidOperationException>(
            () => db.Remove(), // Act
            "The collection is not empty.");
    }

    [TestCase(null)]
    [TestCase("")]
    public void FindByUsernameShouldThrowAnExceptionIfUsernameIsNullOrWhitespace(string username)
    {
        // Arrange
        var db = new ExtendedDatabase.ExtendedDatabase();

        // Assert
        Assert.Throws<ArgumentNullException>(
            () => db.FindByUsername(username),
            "The username is not null or whitespace.");
    }

    [Test]
    public void FindByUsernameShouldThrowAnExceptionIfUsernameDoesntExist()
    {
        // Arrange
        var db = new ExtendedDatabase.ExtendedDatabase(new Person(5, "Firmino"));

        // Assert
        Assert.Throws<InvalidOperationException>(
            () => db.FindByUsername("Firmino1"),
            "The username is already in the collection.");
    }

    [Test]
    public void FindByUsernameShouldReturnPersonCorrectly()
    {
        // Arrange
        var db = new ExtendedDatabase.ExtendedDatabase(new Person(12, "Firmino"));

        // Act
        var actualResult = db.FindByUsername("Firmino");

        // Assert
        Assert.That(actualResult.Id, Is.EqualTo(12));

        Assert.That(actualResult.UserName, Is.EqualTo("Firmino"));
    }

    [Test]
    public void FindByIdShouldThrowExceptionIfIDIsNegative()
    {
        // Arrange
        var db = new ExtendedDatabase.ExtendedDatabase(new Person(5, "Firmino"));

        // Assert
        Assert.Throws<ArgumentOutOfRangeException>(
            () => db.FindById(-1),
            "The id is not negative.");
    }

    [Test]
    public void FindByIDShouldThrowAnExceptionIfIDDoesntExist()
    {
        // Arrange
        var db = new ExtendedDatabase.ExtendedDatabase(new Person(55, "Firmino"));

        // Assert
        Assert.Throws<InvalidOperationException>(
            () => db.FindById(45),
            "The id is already in the collection.");
    }

    [Test]
    public void FindByIDShouldReturnPersonCorrectly()
    {
        // Arrange
        var db = new ExtendedDatabase.ExtendedDatabase(new Person(12, "Firmino"));

        // Act
        var actualResult = db.FindById(12);

        // Assert
        Assert.That(actualResult.Id, Is.EqualTo(12));

        Assert.That(actualResult.UserName, Is.EqualTo("Firmino"));
    }
}

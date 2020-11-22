using NUnit.Framework;
using System;

[TestFixture]
public class DummyTests
{
    [TestCase(100, 100, 20, 20)]
    public void DummyShouldLoseHealthIfAttacked(int health, int exp, int attack, int durability)
    {
        //Arange
        Dummy dummy = new Dummy(health, exp);

        //Act
        dummy.TakeAttack(attack);
        //Assert
        var expectedResult = 80;
        var actualResult = dummy.Health;

        Assert.AreEqual(expectedResult, actualResult);

    }

    [TestCase(0, 100, 20, 20)]
    public void DeadDummyShouldThrowExceptionIfAttacked(int health, int exp, int attack, int durability)
    {
        //Arange
        Dummy dummy = new Dummy(health, exp);
        //Act - Assert
        Assert.Throws<InvalidOperationException>(() =>
        dummy.TakeAttack(attack));
        
    }

    [TestCase(0, 100, 20, 20)]
    public void DeadDummyShouldGiveExp(int health, int exp, int attack, int durability)
    {
        //Arange
        Dummy dummy = new Dummy(health, exp);
        //Act - Assert
        var expectedExp = 100;
        var actualResult = dummy.GiveExperience();

        Assert.AreEqual(expectedExp, actualResult);

    }

    [TestCase(10, 100, 20, 20)]
    public void AliveDummyShouldNotGiveExp(int health, int exp, int attack, int durability)
    {
        //Arange
        Dummy dummy = new Dummy(health, exp);
        //Act - Assert
        Assert.Throws<InvalidOperationException>(() => 
        dummy.GiveExperience());
    }
}

using NUnit.Framework;
using System;

[TestFixture]
public class AxeTests
{
    [Test]
    [TestCase(100, 100, 100, 100, 99)]
    public void WeaponShouldLoseDurabilityAfterAttack(int health, int exp, int attack, int durability, int expectedResult)
    {
        //Arange
        Dummy dummy = new Dummy(health, exp);
        Axe axe = new Axe(attack, durability);
        //Act
        axe.Attack(dummy);
        //Assert
        var actualResult = axe.DurabilityPoints;
        Assert.AreEqual(expectedResult, actualResult);
    }
    [TestCase(20,20,10,0)]
    public void AttackShouldThrowInvalidOperationExceptionWhenDurabilityIsEqualOrBelowZero(int health, int exp, int attack, int durability)
    {
        //Arange
        Dummy dummy = new Dummy(health, exp);
        Axe axe = new Axe(attack, durability);
        //Act - Assert
        Assert.Throws<InvalidOperationException>(() =>
        axe.Attack(dummy));
        
    }
}
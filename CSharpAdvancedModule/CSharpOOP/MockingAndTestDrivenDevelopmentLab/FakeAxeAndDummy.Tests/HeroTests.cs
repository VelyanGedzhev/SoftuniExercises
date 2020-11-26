using FakeAxeAndDummy.Interfaces;
using FakeAxeAndDummy.Tests.Fakes;
using NUnit.Framework;

//[TestFixture]
public class HeroTests
{
    [SetUp]
    public void Setup()
    {
    }
    [Test]
    public void GivenHeroShouldReceiveExperienceWhenAttackedTargetDies()
    {
        //Arrange
        IWeapon weapon = new IWeaponFake();
        IAttackable target = new IAttackableFake();
        Hero hero = new Hero("Firmino", weapon);

        //Act
        hero.Attack(target);

        //Assert
        Assert.AreEqual(20, hero.Experience);
    }
}
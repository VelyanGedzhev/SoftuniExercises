using FakeAxeAndDummy.Interfaces;
using FakeAxeAndDummy.Tests.Fakes;
using Moq;
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
        //IWeapon weapon = new IWeaponFake();
        //IAttackable target = new IAttackableFake();

        Mock<IAttackable> target = new Mock<IAttackable>();
        target.Setup(g => g.GiveExperience()).Returns(20);
        target.Setup(f => f.IsDead()).Returns(true);

        Mock<IWeapon> weapon = new Mock<IWeapon>();


        Hero hero = new Hero("Firmino", weapon.Object);

        //Act
        hero.Attack(target.Object);

        //Assert
        Assert.AreEqual(20, hero.Experience);
    }
}
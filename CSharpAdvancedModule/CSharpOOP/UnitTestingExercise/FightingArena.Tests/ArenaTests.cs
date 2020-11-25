
using FightingArena;
using NUnit.Framework;
using System;
using System.Linq;

namespace Tests
{
    public class ArenaTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ConstructorShouldInitializedDependentValues()
        {
            Arena arena = new Arena();

            Assert.IsNotNull(arena.Warriors);
        }

        [Test]
        [TestCase("Firmino", 50, 50)]
        [TestCase("Robo", 31, 50)]
        public void EnrollShouldThrowExceptionIfWarriorExists(string name, int damage, int hp)
        {
            //Arrange
            Warrior warrior = new Warrior(name, damage, hp);
            Arena arena = new Arena();

            //Act
            arena.Enroll(warrior);

            //Assert
            Assert.Throws<InvalidOperationException>(() =>
            arena.Enroll(warrior));
        }

        [Test]
        [TestCase("Firmino", 50, 50, 1)]
        public void EnrollShouldAddWarriorToTheCollection(string name, int damage, int hp, int expectedCount)
        {
            //Arrange
            Warrior warrior = new Warrior(name, damage, hp);
            Arena arena = new Arena();

            //Act
            arena.Enroll(warrior);
            var isAny = arena.Warriors.Any(n => n.Name == name);

            //Assert
            Assert.AreEqual(arena.Count, expectedCount);
            Assert.IsTrue(isAny);
        }

        [Test]
        [TestCase("Ragnar", 10, 50, "Ezio", 10, 50)]
        [TestCase("Ezio", 10, 50, "Ragnar", 10, 50)]
        public void FightOperationShouldThrowExceptionIfOneOfTheWarriorsDoesntExists(string attacker, int attackerDamage, int attackerHP, string defender, int defenderDamage, int defenderHP)
        {
            //Arrange
            Warrior attackingWarrior = new Warrior(attacker, attackerDamage, attackerHP);
            Warrior defendingWarrior = new Warrior(defender, defenderDamage, defenderHP);

            Arena arena = new Arena();

            //Act - Assert
            Assert.Throws<InvalidOperationException>(() =>
            arena.Fight(attackingWarrior.Name, defendingWarrior.Name));

            arena.Enroll(attackingWarrior);

            Assert.Throws<InvalidOperationException>(() =>
            arena.Fight(attackingWarrior.Name, defendingWarrior.Name));
        }

        [Test]
        [TestCase("Ragnar", 10, 50, "Ezio", 10, 50, 40)]
        public void FightOperationShouldWorkAsExpected(string attacker, int attackerDamage, int attackerHP, string defender, int defenderDamage, int defenderHP,int expectedHPLeft)
        {
            //Arrange
            Arena arena = new Arena();
            Warrior attackingWarrior = new Warrior(attacker, attackerDamage, attackerHP);
            Warrior defendingWarrior = new Warrior(defender, defenderDamage, defenderHP);

            //Act
            arena.Enroll(attackingWarrior);
            arena.Enroll(defendingWarrior);

            arena.Fight(attackingWarrior.Name, defendingWarrior.Name);

            //Assert
            var attackingWarriorHp = attackingWarrior.HP;
            var defendingWarriorHp = defendingWarrior.HP;

            Assert.AreEqual(attackingWarriorHp, expectedHPLeft);
            Assert.AreEqual(defendingWarriorHp, expectedHPLeft);
        }
    }
}

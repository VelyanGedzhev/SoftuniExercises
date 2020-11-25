
using FightingArena;
using NUnit.Framework;
using System;

namespace Tests
{
    public class WarriorTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase("Ragnar", 50, 100)]
        [TestCase("Ezio", 70, 55)]
        [TestCase("Ezio", 70, 0)]
        public void WarriorConstructorShouldSetDataCorrectly(string name, int damage, int hp)
        {
            //Arrange
            Warrior warrior = new Warrior(name, damage, hp);

            //Act - Assert
            Assert.AreEqual(name, warrior.Name);
            Assert.AreEqual(damage, warrior.Damage);
            Assert.AreEqual(hp, warrior.HP);
        }

        [Test]
        [TestCase("", 50, 100)]
        [TestCase(" ", 50, 100)]
        [TestCase(null, 70, 55)]
        public void WarriorConstructorShouldThrowExceptionIfInvalidName(string name, int damage, int hp)
        {
            Assert.Throws<ArgumentException>(() =>
            new Warrior(name, damage, hp));
        }

        [Test]
        [TestCase("Ragnar", 0, 100)]
        [TestCase("Ezio", -15, 55)]
        public void WarriorConstructorShouldThrowExceptionIfInvalidDamage(string name, int damage, int hp)
        {
            Assert.Throws<ArgumentException>(() =>
            new Warrior(name, damage, hp));
        }

        [Test]
        [TestCase("Ragnar", 50, -100)]
        [TestCase("Ezio", 15, -55)]
        public void WarriorConstructorShouldThrowExceptionIfInvalidHP(string name, int damage, int hp)
        {
            Assert.Throws<ArgumentException>(() =>
            new Warrior(name, damage, hp));
        }

        [Test]
        [TestCase("Ragnar", 50, 12, 50)]
        [TestCase("Ezio", 15, 30, 50)]
        public void AttackOperationShouldThrowExceptionIfHPIsInvalid(string name, int damage, int firstWarriorHP, int secondWarriorHP)
        {
            //Arrange
            Warrior attackingWarrior = new Warrior(name, damage, firstWarriorHP);
            Warrior defendingWarrior = new Warrior(name, damage, secondWarriorHP);

            //Act - Assert
            Assert.Throws<InvalidOperationException>(() => 
            attackingWarrior.Attack(defendingWarrior));
        }

        [Test]
        [TestCase("Ragnar", 50, 50, 12)]
        [TestCase("Ezio", 15, 31, 30)]
        public void AttackOperationShouldThrowExceptionIfDefendersHPIsBelow30(string name, int damage, int firstWarriorHP, int secondWarriorHP)
        {
            //Arrange
            Warrior attackingWarrior = new Warrior(name, damage, firstWarriorHP);
            Warrior defendingWarrior = new Warrior(name, damage, secondWarriorHP);

            //Act - Assert
            Assert.Throws<InvalidOperationException>(() =>
            attackingWarrior.Attack(defendingWarrior));
        }


        [Test]
        [TestCase("Ragnar", 50, 50, 51)]
        [TestCase("Ezio", 15, 31, 300)]
        public void AttackOperationShouldThrowExceptionIfDefendersIsStrongerThanAttacker(string name, int damage, int hp, int secondWarriorDamage)
        {
            //Arrange
            Warrior attackingWarrior = new Warrior(name, damage, hp);
            Warrior defendingWarrior = new Warrior(name, secondWarriorDamage, hp);

            //Act - Assert
            Assert.Throws<InvalidOperationException>(() =>
            attackingWarrior.Attack(defendingWarrior));
        }

        [Test]
        [TestCase("Ragnar", 10, 50, 40, "Ezio", 10, 50, 40)]
        [TestCase("Ragnar", 10, 100, 80, "Ezio", 20, 50, 40)]
        [TestCase("Ragnar", 50, 100, 80, "Ezio", 20, 40, 0)]
        public void AttackOperationShouldDecreaseHP(string attacker, int attackerDamage, int attackerHP,int attackerHPLeft, string defender, int defenderDamage, int defenderHP, int defenderHPLeft)
        {
            //Arrange
            Warrior attackingWarrior = new Warrior(attacker, attackerDamage, attackerHP);
            Warrior defendingWarrior = new Warrior(defender, defenderDamage, defenderHP);

            //Act
            attackingWarrior.Attack(defendingWarrior);

            //Assert
            Assert.AreEqual(attackingWarrior.HP, attackerHPLeft);
            Assert.AreEqual(defendingWarrior.HP, defenderHPLeft);
        }
    }
}
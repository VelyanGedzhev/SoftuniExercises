namespace Computers.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    public class ComputerTests
    {
        Part part;
        Computer computer;

        [SetUp]
        public void Setup()
        {
            part = new Part("SSD", 150m);
            computer = new Computer("My PC");
        }

        [Test]
        [Category("Part class")]
        public void WhenPartArgumentsAreGivenTheyShouldSetCorrectly()
        {
            Assert.AreEqual("SSD", part.Name);
            Assert.AreEqual(150m, part.Price);
        }

        [Test]
        [Category("Computer class")]
        [TestCase("")]
        [TestCase(null)]
        public void WhenIncorrectComputerNameIsGivenThenExceptionIsThrown(string name)
        {
            Assert.Throws<ArgumentNullException>(() =>
            new Computer(name));
        }

        [Test]
        [Category("Computer class")]
        public void WhenCorrectComputerNameIsGivenThenItShouldSetCorrectly()
        {
            Assert.AreEqual("My PC", computer.Name);
        }

        [Test]
        [Category("Computer class")]
        public void GivenPartWhenAddIsCalledThenExceptionIsThrownIfPartIsNull()
        {
            Assert.Throws<InvalidOperationException>(() => 
            computer.AddPart(null));
        }

        [Test]
        [Category("Computer class")]
        public void GivenPartWhenAddIsCalledThenPartShouldBeAddedCorrectly()
        {
            computer.AddPart(part);

            Assert.AreEqual(1, computer.Parts.Count);
        }

        [Test]
        [Category("Computer class")]
        public void WhenPartExistsAndRemoveIsCalledItShouldReturnTrueAndCountShouldDecrease()
        {
            computer.AddPart(part);

            Assert.That(computer.RemovePart(part), Is.True);
            Assert.AreEqual(0, computer.Parts.Count);
        }

        [Test]
        [Category("Computer class")]
        public void WhenPartDoesntExistsAndRemoveIsCalledItShouldReturnFalseAndCountShouldNotChange()
        {
            computer.AddPart(new Part("i7", 340m));

            Assert.That(computer.RemovePart(part), Is.False);
            Assert.AreEqual(1, computer.Parts.Count);
        }

        [Test]
        [Category("Computer class")]
        public void WhenPartExistsAndGetPartIsCalledItShouldReturnPartCorrectly()
        {
            computer.AddPart(part);

            Assert.AreEqual(part, computer.GetPart("SSD"));
        }
        [Test]
        [Category("Computer class")]
        public void WhenPartDoesntExistsAndGetPartIsCalledItShouldReturnNull()
        {
            computer.AddPart(part);

            Assert.That(computer.GetPart("HDD"), Is.Null);
        }

        [Test]
        [Category("Computer class")]
        public void WhenTotalPriceIsCalledItShouldReturnCorrectSum()
        {
            computer.AddPart(part);
            computer.AddPart(new Part("HDD", 70m));
            computer.AddPart(new Part("i7", 330m));

            Assert.AreEqual(550m, computer.TotalPrice);
        }
    }
}

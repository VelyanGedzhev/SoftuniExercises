namespace Robots.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class RobotsTests
    {
        private Robot robot;
        private RobotManager manager;

        [SetUp]
        public void SetUp()
        {
            robot = new Robot("R2D2", 10);
            manager = new RobotManager(10);
        }

        [Test]
        [Category("Robot class")]
        [TestCase("R2D2", 10, 10)]
        public void WhenRobotIsCreatedPropertiesShouldBeSet(string expectedName,int expectedBattery, int expectedMaxBattery)
        {
            Assert.AreEqual(expectedName, robot.Name);
            Assert.AreEqual(expectedMaxBattery, robot.MaximumBattery);
            Assert.AreEqual(expectedBattery, robot.Battery);
        }

        [Test]
        [Category("RobotManager class")]
        [TestCase(10)]
        public void WhenRobotManagerIsCreatedThenCapacityIsSet(int expectedCapacity)
        {
            Assert.AreEqual(expectedCapacity, manager.Capacity);
        }

        [Test]
        [Category("RobotManager class")]
        [TestCase(-1)]
        public void WhenRobotManagerIsCreatedWithNegativeCapacityThenExceptionIsThrown(int capacity)
        {
            RobotManager manager;
            Assert.Throws<ArgumentException>(() =>
            manager = new RobotManager(capacity));
        }

        [Test]
        [Category("RobotManager class")]
        [TestCase(0)]
        public void WhenRobotManagerIsCreatedThenCountShouldBeZero(int expectedCount)
        {
            Assert.AreEqual(expectedCount, manager.Count);
        }

        [Test]
        [Category("RobotManager class")]
        public void WhenAddSameRobotsExceptionIsThrown()
        {
            manager.Add(robot);

            Assert.Throws<InvalidOperationException>(() =>
            manager.Add(robot));
        }

        [Test]
        [Category("RobotManager class")]
        public void WhenAddRobotWithCapacityFullExceptionIsThrown()
        {
            RobotManager manager = new RobotManager(1);
            manager.Add(robot);

            Assert.Throws<InvalidOperationException>(() =>
            manager.Add(new Robot("3PIO", 10)));
        }

        [Test]
        [Category("RobotManager class")]
        [TestCase(1)]
        public void WhenAddRobotThenCountIncreases(int expectedCount)
        {
            manager.Add(robot);
            Assert.AreEqual(expectedCount, manager.Count);

        }

        [Test]
        [Category("RobotManager class")]
        public void WhenRobotToBeRemovedDoesntExistExceptionIsThrown()
        {
            manager.Add(robot);

            Assert.Throws<InvalidOperationException>(() =>
            manager.Remove("R3D3"));
        }

        [Test]
        [Category("RobotManager class")]
        public void WhenRemoveExistingRobotCountShouldDecrease()
        {
            manager.Add(robot);
            Assert.AreEqual(1, manager.Count);

            manager.Remove("R2D2");
            Assert.AreEqual(0, manager.Count);
        }

        [Test]
        [Category("RobotManager class")]
        public void WhenRobotToBeWorkingDoesntExistThenExceptionIsThrown()
        {
            manager.Add(robot);

            Assert.Throws<InvalidOperationException>(() =>
            manager.Work("3PIO", "ConstantTalk", 5));
        }


        [Test]
        [Category("RobotManager class")]
        public void WhenRobotBatteryIsntEnoughToWorThenExceptionIsThrown()
        {
            manager.Add(robot);

            Assert.Throws<InvalidOperationException>(() =>
            manager.Work("R2D2", "PioPio", 15));
        }

        [Test]
        [Category("RobotManager class")]
        [TestCase(5)]
        public void WhenRobotBatteryIsEnoughToWorThenRobotBatteryShouldDecrease(int exptectedBatteryLeft)
        {
            manager.Add(robot);
            manager.Work(robot.Name, "Repair", 5);

            Assert.AreEqual(exptectedBatteryLeft, robot.Battery);
        }

        [Test]
        [Category("RobotManager class")]
        public void WhenRobotToBeChargedDoesntExistThenExceptionIsThrown()
        {
            manager.Add(robot);

            Assert.Throws<InvalidOperationException>(() =>
            manager.Charge("3PIO"));
        }


        [Test]
        [Category("RobotManager class")]

        public void WhenRobotIsChargedThenBatteryMustGetMaxValue()
        {
            manager.Add(robot);
            manager.Work(robot.Name, "Repair", 5);
            manager.Charge(robot.Name);

            Assert.AreEqual(robot.Battery, robot.MaximumBattery);
        }
    }
}

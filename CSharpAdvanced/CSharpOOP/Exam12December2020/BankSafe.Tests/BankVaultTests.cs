using NUnit.Framework;
using System;

namespace BankSafe.Tests
{
    public class BankVaultTests
    {
        private BankVault bankVault;
        private Item firstItem;

        [SetUp]
        public void Setup()
        {
            firstItem = new Item("Klopp", "Z4");
            bankVault = new BankVault();
        }

        [Test]
        public void AddItemShouldThrowExceptionIfCellDoesntExists()
        {
            Assert.Throws<ArgumentException>(() =>
            bankVault.AddItem("Z4", firstItem));
        }

        [Test]
        public void AddItemShouldThrowExceptionIfCellIsTaken()
        {
            bankVault.AddItem("C4", firstItem);

            Assert.Throws<ArgumentException>(() =>
            bankVault.AddItem("C4", firstItem));
        }

        [Test] //??
        public void AddItemShouldThrowExceptionIfItemExist()
        {
            bankVault.AddItem("C4", firstItem);

            Assert.Throws<InvalidOperationException>(() =>
            bankVault.AddItem("C3", firstItem));
        }

        [Test]
        public void AddItemShouldWorkCorrectly()
        {
            string result = bankVault.AddItem("C4", firstItem);

            string exptectedResult = $"Item:{firstItem.ItemId} saved successfully!";

            Assert.AreEqual(exptectedResult, result);
        }

        [Test]
        public void RemoveItemShouldThrowExceptionIfCellDoesntExists()
        {
            Assert.Throws<ArgumentException>(() =>
            bankVault.RemoveItem("Z4", firstItem));
        }

        [Test]
        public void RemoveItemShouldThrowExceptionIfItemDoesntExists()
        { 

            Assert.Throws<ArgumentException>(() =>
            bankVault.RemoveItem("C4", firstItem));
        }

        //$"Remove item:{item.ItemId} successfully!"

        [Test]
        public void RemoveItemShouldWorkCorrectly()
        {
            bankVault.AddItem("C4", firstItem);

            string result = bankVault.RemoveItem("C4", firstItem);

            string exptectedResult = $"Remove item:{firstItem.ItemId} successfully!";

            Assert.AreEqual(exptectedResult, result);

        }
    }
}

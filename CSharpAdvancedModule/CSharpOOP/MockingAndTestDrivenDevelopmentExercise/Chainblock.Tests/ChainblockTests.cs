

using Chainblock.Contracts;
using Chainblock.Models;
using NUnit.Framework;
using System;

namespace Chainblock.Tests
{
    [TestFixture]
    public class ChainblockTests
    {
        private ITransaction transaction;
        private IChainblock chainblock;

        [SetUp]
        public void SetUp()
        {
            transaction = new Transaction()
            {
                Id = 1,
                From = "Klopp",
                To = "Firmino",
                Status = TransactionStatus.Successfull,
                Amount = 60000
            };
            chainblock = new ChainBlock(); ;
        }
       
        [Test]
        [Category("Add method")]
        public void GivenTransactionWhenAddTransactionIsCalledThenTransactionCountIncreses()
        {
            //Act
            chainblock.Add(transaction);

            //Assert
            Assert.AreEqual(1, chainblock.Count);
        }

        [Test]
        [Category("Add method")]
        public void GivenDuplicateTransactionWhenAddTransactionIsCalledThenExceptionIsThrown()
        {
            //Act
            chainblock.Add(transaction);

            //Assert
            Assert.Throws<InvalidOperationException>(() =>
            chainblock.Add(transaction));
        }
    }
}

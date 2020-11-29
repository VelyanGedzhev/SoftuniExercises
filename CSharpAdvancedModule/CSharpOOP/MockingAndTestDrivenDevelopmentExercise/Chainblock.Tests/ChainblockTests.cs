

using Chainblock.Contracts;
using Chainblock.Models;
using Moq;
using NUnit.Framework;
using System;

namespace Chainblock.Tests
{
    [TestFixture]
    public class ChainblockTests
    {
        private ITransaction transaction;
        private ITransaction otherTransaction;
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
            otherTransaction = new Transaction()
            {
                Id = 2,
                From = "Klopp",
                To = "Mane",
                Status = TransactionStatus.Successfull,
                Amount = 62000
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

        [Test]
        [Category("Contains(id) method")]
        public void GivenIdWhenContainsByIdIsCalledThenReturnsTrueIfTransactionIsFound()
        {
            //Act
            chainblock.Add(transaction);

            //Assert
            Assert.That(chainblock.Contains(transaction.Id), Is.True);
        }

        [Test]
        [Category("Contains(id) method")]
        public void GivenIdWhenContainsByIdIsCalledThenReturnsFalseIfTransactionIsntFound()
        {
            //Act
            chainblock.Add(otherTransaction);

            //Assert
            Assert.That(chainblock.Contains(transaction.Id), Is.False);
        }

        [Test]
        [Category("Contains(id) method")]
        public void GivenNegativeIdWhenContainsByIdIsCalledThenExceptionIsThrown()
        {
            //Act
            chainblock.Add(transaction);

            //Assert
            Assert.Throws<ArgumentException>(() =>
            chainblock.Contains(-1));
        }

        [Test]
        [Category("Contains(ITransaction transaction) method")]
        public void GivenTransactionWhenContainsIsCalledThenReturnsTrueIfTransactionIsFound()
        {
            //Act
            chainblock.Add(transaction);

            //Assert
            Assert.That(chainblock.Contains(transaction), Is.True);
        }
        [Test]
        [Category("Contains(ITransaction transaction) method")]
        public void GivenTransactionWhenContainsIsCalledThenReturnsFalseIfTransactionIsntFound()
        {
            //Act
            chainblock.Add(otherTransaction);

            //Assert
            Assert.That(chainblock.Contains(transaction), Is.False);
        }
            [Test]
        [Category("Contains(ITransaction transaction) method")]
        public void GivenInvalidTransactionWhenContainsIsCalledThenExceptionIsThrown()
        {
            Assert.Throws<ArgumentException>(() =>
            chainblock.Contains(null));
        }

        [Test]
        [Category("ChangeTransactionStatus method")]
        public void GivenStatusWhenChangeTransactionStatusIsCalledThenTransactionStatusGangesCorrectly()
        {

        }

        [Test]
        [Category("ChangeTransactionStatus method")]
        public void GivenStatusWhenChangeTransactionStatusIsCalledThenExceptionIsTrown()
        {

        }
    }
}

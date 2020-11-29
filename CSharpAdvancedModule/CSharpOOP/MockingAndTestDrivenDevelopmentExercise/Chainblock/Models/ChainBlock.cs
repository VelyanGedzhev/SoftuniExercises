using Chainblock.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Chainblock.Models
{
    public class ChainBlock : IChainblock
    {
        private readonly Dictionary<int, ITransaction> transactions;

        public ChainBlock()
        {
            transactions = new Dictionary<int, ITransaction>();
        }
        public int Count => transactions.Count;

        public void Add(ITransaction tx)
        {
            if (transactions.ContainsKey(tx.Id))
            {
                throw new InvalidOperationException($"Transaction Id must be unique. Id {tx.Id} already exists.");
            }

            transactions[tx.Id] = tx;
        }

        public void ChangeTransactionStatus(int id, TransactionStatus newStatus)
        {
            throw new NotImplementedException();
        }

        public bool Contains(ITransaction tx)
        {
            throw new NotImplementedException();
        }

        public bool Contains(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ITransaction> GetAllInAmountRange(double lo, double hi)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ITransaction> GetAllOrderedByAmountDescendingThenById()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> GetAllReceiversWithTransactionStatus(TransactionStatus status)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> GetAllSendersWithTransactionStatus(TransactionStatus status)
        {
            throw new NotImplementedException();
        }

        public ITransaction GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ITransaction> GetByReceiverAndAmountRange(string receiver, double lo, double hi)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ITransaction> GetByReceiverOrderedByAmountThenById(string receiver)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ITransaction> GetBySenderAndMinimumAmountDescending(string sender, double amount)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ITransaction> GetBySenderOrderedByAmountDescending(string sender)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ITransaction> GetByTransactionStatus(TransactionStatus status)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ITransaction> GetByTransactionStatusAndMaximumAmount(TransactionStatus status, double amount)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<ITransaction> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public void RemoveTransactionById(int id)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}

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
            if (!transactions.ContainsKey(id))
            {
                throw new ArgumentException($"Id {id} doesn't exists!");
            }

            if (!Enum.IsDefined(typeof(TransactionStatus), newStatus))
            {
                throw new ArgumentException("Invalid transaction status.");
            }

            var transaction = transactions[id];

            if (transaction.Status == newStatus)
            {
                throw new InvalidOperationException($"Cannot change {transaction.Status} to {newStatus}");
            }

            transactions[id].Status = newStatus;
        }

        public bool Contains(ITransaction tx)
        {
            if (tx == null)
            {
                throw new ArgumentException("Transaction cannot be null.");
            }

            if (!transactions.ContainsValue(tx))
            {
                return false;
            }

            return true;
        }

        public bool Contains(int id)
        {
            if (id < 0)
            {
                throw new ArgumentException("Id cannot be negative.");
            }
            if (!transactions.ContainsKey(id))
            {
                return false;
            }

            return true;
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

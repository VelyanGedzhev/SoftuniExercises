namespace Problem03.Queue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Queue<T> : IAbstractQueue<T>
    {
        private Node<T> _head;

        public Queue()
        {
            this._head = null;
            Count = 0;
        }

        public Queue(Node<T> head)
        {
            this._head = head;
            Count = 1;
        }

        public int Count { get; private set; }

        public bool Contains(T item)
        {
            var current = this._head;

            while (current != null)
            {
                if (current.Item.Equals(item))
                {
                    return true;
                }
                current = current.Next;
            }

            return false;
        }

        public T Dequeue()
        {
            ValidateIfNotEmpty();

            var current = this._head;
            this._head = this._head.Next;
            Count--;
            return current.Item;
        }

        public void Enqueue(T item)
        {
            var current = this._head;
            var elementToInsert = new Node<T>(item);

            if (current == null)
            {
                this._head = elementToInsert;
            }
            else
            {
                while (current.Next != null)
                {
                    current = current.Next;
                }

                current.Next = elementToInsert;
            }

            Count++;
        }


        public T Peek()
        {
            ValidateIfNotEmpty();
            return this._head.Item;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = this._head;

            while (current != null)
            {
                yield return current.Item;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();

        private void ValidateIfNotEmpty()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException();
            }
        }
    }
}
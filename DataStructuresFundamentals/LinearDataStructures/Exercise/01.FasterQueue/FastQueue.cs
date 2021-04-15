namespace Problem01.FasterQueue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class FastQueue<T> : IAbstractQueue<T>
    {
        private Node<T> _head;
        private Node<T> _tail;

        public FastQueue()
        {
            this._head = null;
            this._tail = null;
            Count = 0;
        }

        public FastQueue(Node<T> head)
        {
            this._head = head;
            this._tail = _head;
            Count = 1;
        }

        public int Count { get; private set; }

        //O(n)
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

        //O(1)
        public T Dequeue()
        {
            EnsureNotEmpty();
            var current = this._head;

            if (Count == 1)
            {
                this._head = this._tail = null;
            }
            else
            {
                this._head = this._head.Next;
            }

            Count--;
            return current.Item;
        }

        //O(1)
        public void Enqueue(T item)
        {
            var elementToInsert = new Node<T>
            {
                Item = item
            };

            if (Count == 0)
            {
                this._head = this._tail = elementToInsert;
            }
            else
            {
                this._tail.Next = elementToInsert;
                this._tail = elementToInsert;
            }
            Count++;
        }

        public T Peek()
        {
            EnsureNotEmpty();
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
            => this.GetEnumerator();

        private void EnsureNotEmpty()
        {
            if (this.Count == 0)
                throw new InvalidOperationException();
        }
    }
}
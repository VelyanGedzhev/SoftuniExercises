namespace Problem02.DoublyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class DoublyLinkedList<T> : IAbstractLinkedList<T>
    {
        private Node<T> head;
        private Node<T> tail;

        public DoublyLinkedList()
        {
            this.head = this.tail = null;
            Count = 0;
        }
        public DoublyLinkedList(Node<T> head)
        {
            this.head = this.tail = head;
            Count = 1;
        }

        public int Count { get; private set; }

        public void AddFirst(T item)
        {
            var current = new Node<T>
            {
                Item = item,
            };

            if (Count == 0)
            {
                this.head = this.tail = current;
            }
            else
            {
                this.head.Previous = current;
                current.Next = this.head;
                this.head = current;
            }

            Count++;
        }

        public void AddLast(T item)
        {
            var current = new Node<T>
            {
                Item = item,
            };

            if (Count == 0)
            {
                this.head = this.tail = current;
            }
            else
            {
                current.Previous = this.tail;
                this.tail.Next = current;
                this.tail = current;
            }

            Count++;
        }

        public T GetFirst()
        {
            EnsureNotEmpty();

            return this.head.Item;
        }

        public T GetLast()
        {
            EnsureNotEmpty();

            return this.tail.Item;
        }

        public T RemoveFirst()
        {
            EnsureNotEmpty();

            var elementToReturn = this.head;

            if (Count == 1)
            {
                this.head = this.tail = null;
            }
            else
            {
                this.head = this.head.Next;
                this.head.Previous = null;
            }

            Count--;

            return elementToReturn.Item;
        }

        public T RemoveLast()
        {
            EnsureNotEmpty();

            var elementToReturn = this.tail;

            if (Count == 1)
            {
                this.head = this.tail = null;
            }
            else
            {
                this.tail = this.tail.Previous;
                this.tail.Next = null;
            }

            Count--;
            return elementToReturn.Item;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = this.head;

            while (current != null)
            {
                yield return current.Item;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        private void EnsureNotEmpty()
        {
            if (this.Count == 0)
                throw new InvalidOperationException();
        }
    }
}
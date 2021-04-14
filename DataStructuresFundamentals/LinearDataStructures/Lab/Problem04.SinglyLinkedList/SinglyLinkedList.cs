namespace Problem04.SinglyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class SinglyLinkedList<T> : IAbstractLinkedList<T>
    {
        private Node<T> _head;

        public SinglyLinkedList()
        {
            this._head = null;
            Count = 0;
        }

        public SinglyLinkedList(Node<T> topElement)
        {
            this._head = topElement;
            Count = 1;
        }

        public int Count { get; private set; }

        public void AddFirst(T item)
        {
            var itemToInsert = new Node<T>(item, this._head);
            this._head = itemToInsert;
            Count++;
        }

        public void AddLast(T item)
        {
            var itemToInsert = new Node<T>(item);
            var current = this._head;

            if (current == null)
            {
                this._head = itemToInsert;
                Count++;
            }

            else
            {
                while (current.Next != null)
                {
                    current = current.Next;
                }

                current.Next = itemToInsert;
                Count++;
            }
        }

        public T GetFirst()
        {
            ValidateIfIsEmpty();

            return this._head.Item;
        }

        public T GetLast()
        {
            ValidateIfIsEmpty();

            var itemToReturn = this._head;

            while (itemToReturn.Next != null)
            {
                itemToReturn = itemToReturn.Next;
            }

            return itemToReturn.Item;
        }

        public T RemoveFirst()
        {
            ValidateIfIsEmpty();
            var itemToReturn = this._head;
            this._head = this._head.Next;

            Count--;

            return itemToReturn.Item;
        }

        public T RemoveLast()
        {
            ValidateIfIsEmpty();
            var itemToRemove = this._head;
            var currentLast = this._head;

            while (itemToRemove.Next != null)
            {
                currentLast = itemToRemove;
                itemToRemove = itemToRemove.Next;
            }
            currentLast.Next = null;
            Count--;

            return itemToRemove.Item;
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

        private void ValidateIfIsEmpty()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException();
            }
        }
    }
}
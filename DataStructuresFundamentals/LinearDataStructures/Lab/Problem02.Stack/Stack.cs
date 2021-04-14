namespace Problem02.Stack
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Stack<T> : IAbstractStack<T>
    {
        private Node<T> _top;

        public Stack()
        {
            this._top = null;
            Count = 0;
        }

        public Stack(Node<T> topElement)
        {
            this._top = topElement;
            Count = 1;
        }

        public int Count { get; private set; }

        public bool Contains(T item)
        {
            var current = this._top;

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

        public T Peek()
        {
            ValidateIfEmpty();
            return this._top.Item;
        }

        public T Pop()
        {
            ValidateIfEmpty();

            var elementToReturn = this._top;
            this._top = this._top.Next;
            Count--;

            return elementToReturn.Item;
        }


        public void Push(T item)
        {
            var newNode = new Node<T>
            {
                Item = item,
                Next = this._top,
            };

            this._top = newNode;
            this.Count++;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = this._top;

            while(current != null)
            {
                yield return current.Item;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() 
            => GetEnumerator();

        private void ValidateIfEmpty()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Stack is empty");
            }
        }
    }
}
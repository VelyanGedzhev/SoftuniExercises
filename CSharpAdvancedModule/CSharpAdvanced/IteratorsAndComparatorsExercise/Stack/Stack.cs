using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Stack
{
    public class Stack<T> : IEnumerable<T>
    {
        private const int INITIAL_CAPACITY = 2;

        private T[] items;

        public Stack()
        {
            items = new T[INITIAL_CAPACITY];
        }
        public int Count { get; private set; }
        public void Push(T item)
        {
            if (Count == items.Length)
            {
                Resize();
            }
            items[Count] = item;
            Count++;
        }
        public void Push(IEnumerable<T> elements)
        {
            foreach (var item in elements)
            {
                this.Push(item);
            }
        }
        public T Pop()
        {
            if (Count == 0)
            {
                throw new ArgumentException("No elements");
            }
            T poppedItem = items[Count - 1];
            items[Count - 1] = default;
            Count--;

            return poppedItem;
        }
        public void ForEach(Action<T> action)
        {
            for (int i = 0; i < Count; i++)
            {
                action(items[i]);
            }
        }
        private void Resize()
        {
            T[] copy = new T[items.Length * 2];

            for (int i = 0; i < items.Length; i++)
            {
                copy[i] = items[i];
            }
            items = copy;
        }
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = Count - 1; i >= 0; i--)
            {
                yield return items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}

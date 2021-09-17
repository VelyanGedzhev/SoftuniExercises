using System;
using System.Collections.Generic;
using System.Text;

namespace ImplementingStackАndQueue
{
    public class CustomStack
    {
        private const int INITIAL_CAPACITY = 4;
        private const string EMPTY_STACK_EXCEPTION = "Stack is empty!";

        private int[] items;

        public CustomStack()
        {
            items = new int[INITIAL_CAPACITY];
        }

        public int Count { get; private set; }
        public void Push(int item)
        {
            if (Count == items.Length)
            {
                Resize();
            }
            items[Count] = item;
            Count++;
        }
        public int Pop()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException(EMPTY_STACK_EXCEPTION);
            }
            int poppedItem = items[Count - 1];
            items[Count - 1] = default;
            Count--;

            return poppedItem;
        }
        public int Peek()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException(EMPTY_STACK_EXCEPTION);
            }
            int itemToPeek = items[Count - 1];
            

            return itemToPeek;
        }
        public void ForEach(Action<int> action)
        {
            for (int i = 0; i < Count; i++)
            {
                action(items[i]);
            }
        }
        private void Resize()
        {
            int[] copy = new int[items.Length * 2];

            for (int i = 0; i < items.Length; i++)
            {
                copy[i] = items[i];
            }
            items = copy;
        }
    }
}

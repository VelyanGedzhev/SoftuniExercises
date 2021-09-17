using System;
using System.Collections.Generic;
using System.Text;

namespace ImplementingStackАndQueue
{
    public class CustomList
    {
        private const int INITIAL_CAPACITY = 2;
        private int[] items;
        public CustomList()
        {
            this.items = new int[INITIAL_CAPACITY];
        }
        public int Count { get; private set; }
        public void Add(int item)
        {
            if (this.Count == items.Length)
            {
                this.Resize();
            }
            
            items[Count] = item;
            Count++;
        }

        public int this[int index]
        {
            get
            {
                if (!isValid(index))
                {
                    throw new ArgumentOutOfRangeException();
                }

                return items[index];
            }
            set
            {
                if (!isValid(index))
                {
                    throw new ArgumentOutOfRangeException();
                }

                items[index] = value;
            }
        }

        public int RemoveAt(int index)
        {
            if (!isValid(index))
            {
                throw new ArgumentOutOfRangeException();
            }
            int removedItem = items[index];
            items[index] = default;
            this.ShiftToLeft(index);

            Count--;
            if (Count <= items.Length / 4)
            {
                Shrink();
            }

            return removedItem;
        }
        public void InsertAt(int index, int item)
        {
            if (!isValid(index))
            {
                throw new ArgumentOutOfRangeException();
            }
            if (Count == items.Length)
            {
                Resize();
            }
            ShiftToRight(index);
            items[index] = item;
            Count++;
        }
        public bool Contains(int searchedItem)
        {
            
            for (int i = 0; i < Count; i++)
            {
                int currentElement = items[i];

                if (currentElement == searchedItem)
                {
                    return true;
                }
            }
            return false;
        }
        public void Swap(int firstIndex, int secondIndex)
        {
            if (!isValid(firstIndex) || !isValid(secondIndex))
            {
                throw new ArgumentOutOfRangeException();
            }
            // with additional variable
            int elementAtFirstIndex = items[firstIndex];
            items[firstIndex] = items[secondIndex];
            items[secondIndex] = elementAtFirstIndex;
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
        private void Shrink()
        {
            int[] copy = new int[items.Length / 2];

            for (int i = 0; i < Count; i++)
            {
                copy[i] = items[i];
            }
            items = copy;
        }
        private void ShiftToRight(int index)
        {
            for (int i = Count; i < index; i--)
            {
                items[i] = items[i - 1];
            }
        }
        private void ShiftToLeft(int index)
        {
            for (int i = index; i < Count - 1; i++)
            {
                items[i] = items[i + 1];
            }
            //items[Count - 1] = default;
            for (int i = Count - 1; i < items.Length; i++)
            {
                items[i] = default;
            }
        }
        private bool isValid(int index)
            // => index < this.Count;
        {
            return index < this.Count;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < Count; i++)
            {
                if (i == Count - 1)
                {
                    // final interation
                    sb.Append($"{items[i]}");
                }
                else
                {
                    sb.Append($"{items[i]}, ");
                }
            }
            return sb.ToString().TrimEnd();
        }
    }
}

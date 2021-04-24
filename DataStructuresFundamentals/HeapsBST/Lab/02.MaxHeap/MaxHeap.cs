namespace _02.MaxHeap
{
    using System;
    using System.Collections.Generic;

    public class MaxHeap<T> : IAbstractHeap<T>
        where T : IComparable<T>
    {
        private List<T> elements;

        public MaxHeap()
        {
            this.elements = new List<T>();
        }

        public int Size => this.elements.Count;

        public void Add(T element)
        {
            this.elements.Add(element);

            HeapifyUp();
        }


        public T Peek()
        {
            EnsureHeapNotEmpty();
            return this.elements[0];
        }

        private void EnsureHeapNotEmpty()
        {
            if (Size == 0)
            {
                throw new InvalidOperationException("MaxHeap is empty");
            }
        }

        private void HeapifyUp()
        {
            int currentIndex = Size - 1;
            int parentIndex = GetParentIndex(currentIndex);

            while (IsValidIndex(currentIndex) &&
                IsGreater(currentIndex, parentIndex))
            {
                SwapElements(currentIndex, parentIndex);
                currentIndex = parentIndex;
                parentIndex = GetParentIndex(currentIndex);
            }
        }

        private void SwapElements(int currentIndex, int parentIndex)
        {
            var temp = this.elements[currentIndex];
            this.elements[currentIndex] = this.elements[parentIndex];
            this.elements[parentIndex] = temp;
        }

        private int GetParentIndex(int childIndex)
        {
            EnsureHeapNotEmpty();

            return (childIndex - 1) / 2;
        }

        private bool IsValidIndex(int index)
        {
            return index > 0;
        }

        private bool IsGreater(int childIndex, int parentIndex)
        {
            return this.elements[childIndex]
                .CompareTo(this.elements[parentIndex]) > 0;
        }
    }
}

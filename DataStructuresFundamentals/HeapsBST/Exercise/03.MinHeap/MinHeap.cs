namespace _03.MinHeap
{
    using System;
    using System.Collections.Generic;

    public class MinHeap<T> : IAbstractHeap<T>
        where T : IComparable<T>
    {
        private List<T> elements;

        public MinHeap()
        {
            this.elements = new List<T>();
        }

        public int Size => this.elements.Count;

        public T Dequeue()
        {
            var firstElement = Peek();
            SwapElements(0, Size - 1);
            this.elements.RemoveAt(Size - 1);
            HeapifyDown();

            return firstElement;
        }

        public void Add(T element)
        {
            this.elements.Add(element);

            HeapifyUp();
        }

        public T Peek()
        {
            EnsureQueueIsNotEmpty();

            return this.elements[0];
        }

        private void EnsureQueueIsNotEmpty()
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

            while (currentIndex > 0 &&
                IsLess(currentIndex, parentIndex))
            {
                SwapElements(currentIndex, parentIndex);
                currentIndex = parentIndex;
                parentIndex = GetParentIndex(currentIndex);
            }
        }

        private void HeapifyDown()
        {
            int index = 0;
            int leftChildIndex = GetLeftChildIndex(index);

            while (leftChildIndex < Size &&
                IsGreater(index, leftChildIndex))
            {
                int toSwapWith = leftChildIndex;
                int rightChildIndex = GetRightChildIndex(index);

                if (rightChildIndex < Size &&
                    IsGreater(toSwapWith, rightChildIndex))
                {
                    toSwapWith = rightChildIndex;
                }

                SwapElements(toSwapWith, index);
                index = toSwapWith;
                leftChildIndex = GetLeftChildIndex(index);
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
            EnsureQueueIsNotEmpty();

            return (childIndex - 1) / 2;
        }

        private bool IsValidIndex(int index)
        {
            return index < Size;
        }

        private bool IsGreater(int childIndex, int parentIndex)
        {
            return this.elements[childIndex]
                .CompareTo(this.elements[parentIndex]) > 0;
        }

        private bool IsLess(int childIndex, int parentIndex)
        {
            return this.elements[childIndex]
                .CompareTo(this.elements[parentIndex]) < 0;
        }

        private int GetLeftChildIndex(int parentIndex)
        {
            return 2 * parentIndex + 1;
        }

        private int GetRightChildIndex(int parentIndex)
        {
            return 2 * parentIndex + 2;
        }
    }
}

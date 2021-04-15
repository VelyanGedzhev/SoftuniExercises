namespace Problem03.ReversedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class ReversedList<T> : IAbstractList<T>
    {
        private const int DefaultCapacity = 4;

        private T[] _items;

        public ReversedList()
            : this(DefaultCapacity) { }

        public ReversedList(int capacity)
        {
            if (capacity < 0)
                throw new ArgumentOutOfRangeException(nameof(capacity));

            this._items = new T[capacity];
        }

        public T this[int index]
        {
            get
            {
                ValidateIndex(index);
                return this._items[Count - 1 - index];
            }
            set
            {
                ValidateIndex(index);
                this._items[index] = value;
            }
        }

        public int Count { get; private set; }

        public void Add(T item)
        {
            GrowIfNecessary();
            this._items[Count++] = item;
        }

        public bool Contains(T item)
        {
            return IndexOf(item) != -1;
        }

        public int IndexOf(T item)
        {
            for (int i = 1; i <= Count; i++)
            {
                if (this._items[Count - i].Equals(item))
                {
                    return i - 1;
                }
            }

            return -1;
            
        }

        public void Insert(int index, T item)
        {
            GrowIfNecessary();
            ValidateIndex(index);

            int indexToInsert = Count - index;

            for (int i = Count; i >= indexToInsert; i--)
            {
                this._items[i] = this._items[i - 1];
            }

            this._items[indexToInsert] = item;
            Count++;
        }

        public bool Remove(T item)
        {
            int elementIndex = IndexOf(item);

            if (elementIndex == -1)
            {
                return false;
            }

            RemoveAt(elementIndex);
            return true;
        }

        public void RemoveAt(int index)
        {
            ValidateIndex(index);
            int elementIndex = Count - 1 - index;

            for (int i = elementIndex; i < Count - 1; i++)
            {
                this._items[i] = this._items[i + 1];
            }

            this._items[Count - 1] = default;
            Count--;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = Count - 1; i >= 0; i--)
            {
                yield return this._items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        private void GrowIfNecessary()
        {
            if (Count == this._items.Length)
            {
                Grow();
            }
        }

        private void Grow()
        {
            var newArr = new T[this._items.Length * 2];
            Array.Copy(this._items, newArr, this._items.Length);
            this._items = newArr;
        }

        private void EnsureNotEmpty()
        {
            if (this.Count == 0)
                throw new InvalidOperationException();
        }

        private void ValidateIndex(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException();
            }
        }
    }
}
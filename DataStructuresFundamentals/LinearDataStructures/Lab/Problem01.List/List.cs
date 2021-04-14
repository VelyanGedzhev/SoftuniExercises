namespace Problem01.List
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class List<T> : IAbstractList<T>
    {
        private const int DEFAULT_CAPACITY = 4;
        private T[] _items;

        public List()
            : this(DEFAULT_CAPACITY) 
        {
        }

        public List(int capacity)
        {
            if (capacity <= 0)
            {
                throw new ArgumentOutOfRangeException($"{nameof(capacity)} can't be negative!");
            }
            this._items = new T[capacity];
        }

        public T this[int index]
        {
            get
            {
                ValidateIndex(index);
                return _items[index];
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
            foreach (var element in this._items)
            {
                if (element.Equals(item))
                {
                    return true;
                }
            }

            return false;
        }


        public int IndexOf(T item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (this._items[i].Equals(item))
                {
                    return i;
                }
            }

            return -1;
        }

        public void Insert(int index, T item)
        {
            ValidateIndex(index);
            GrowIfNecessary();

            for (int i = Count; i > index; i--)
            {
                this._items[i] = this._items[i - 1];
            }

            this._items[index] = item;

            Count++;
        }


        public bool Remove(T item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (this._items[i].Equals(item))
                {
                    RemoveAt(i);
                    return true;
                }
            }

            return false;
        }

        public void RemoveAt(int index)
        {
            ValidateIndex(index);

            for (int i = index; i < Count - 1; i++)
            {
                this._items[i] = this._items[i + 1];
            }

            this._items[Count - 1] = default;
            Count--;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return this._items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() 
            => GetEnumerator();

        private void GrowIfNecessary()
        {
            if (Count == this._items.Length)
            {
                Grow();
            }
        }

        private void Grow()
        {
            var newArray = new T[this._items.Length * 2];

            for (int i = 0; i < this._items.Length; i++)
            {
                newArray[i] = this._items[i];
            }

            this._items = newArray;
        }

        private void ValidateIndex(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException($"{nameof(index)} is not valid!");
            }
        }
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ListyIterator
{
    public class ListyIterator<T> : IEnumerable<T>
    {
        private const int DEFAULT_INTERNAL_INDEX = 0;
        private List<T> list;
        private int currentIndex;

        public ListyIterator()
        {
            this.list = new List<T>();
            this.currentIndex = DEFAULT_INTERNAL_INDEX;
        }
        public ListyIterator(IEnumerable<T> collection)
        {
            this.list = new List<T>(collection);
        }
        public bool Move()
        {
            if (this.currentIndex < this.list.Count - 1)
            {
                this.currentIndex++;
            }
            else
            {
                return false;
            }
            return true;
        }
        public bool HasNext() => this.currentIndex < this.list.Count - 1;
        public T Print()
        {
            if (this.list.Count == 0)
            {
                throw new ArgumentException("Invalid Operation!");
            }
            return this.list[this.currentIndex];
        }
       
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.list.Count; i++)
            {
                yield return this.list[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        private class ListyIteratorEnumerator : IEnumerator<T>
        {
            private List<T> list;
            private int currentIndex;

            public ListyIteratorEnumerator(List<T> list)
            {
                this.Reset();
                this.list = list;
            }

           
            public T Current => this.list[this.currentIndex];

            object IEnumerator.Current => this.Current;

            public void Dispose()
            {
                
            }

            public bool MoveNext() => ++this.currentIndex < this.list.Count;


            public void Reset() => this.currentIndex = -1;
            
        }
    }
}

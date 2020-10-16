using System;
using System.Collections.Generic;
using System.Text;

namespace GenericBoxOfString
{
    public class Box<T> where T: IComparable
    {
        
        public Box(List<T> values)
        {
            this.Values = values;
        }
        public List<T> Values { get; set; } = new List<T>();
        
        public void Swap(int firstIndex, int secondIndex)
        {
            T temporaryValue = Values[firstIndex];
            Values[firstIndex] = Values[secondIndex];
            Values[secondIndex] = temporaryValue;
        }
        public int CountBiggerValues(T comparator)
        {
            int counter = 0;
            foreach (T value in Values)
            {
                if (comparator.CompareTo(value) < 0)
                {
                    counter++;
                }
            }

            return counter;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (T value in Values)
            {
                sb.AppendLine($"{value.GetType()}: {value}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}

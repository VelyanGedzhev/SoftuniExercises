using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Christmas
{
    public class Bag
    {
        private List<Present> data;

        public Bag(string color, int capacity)
        {
            Color = color;
            Capacity = capacity;
            data = new List<Present>();
        }

        public string Color { get; set; }
        public int Capacity { get; set; }
        public int Count
        {
            get
            {
                return data.Count;
            }
        }

        public void Add(Present present)
        {
            if (Capacity > Count)
            {
                data.Add(present);
            }
        }
        public bool Remove(string name)
        {
            Present presentToRemove = data.FirstOrDefault(n => n.Name == name);
            return data.Remove(presentToRemove);
        }
        public Present GetHeaviestPresent()
        {
            return data.OrderByDescending(x => x.Weight).FirstOrDefault();
        }
        public Present GetPresent(string name)
        {
            Present presentToGet = data.FirstOrDefault(n => n.Name == name);
            return presentToGet;
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{Color} bag contains:");

            foreach (Present present in data)
            {
                sb.AppendLine(present.ToString());
            }
            return sb.ToString().TrimEnd();
        }

    }
}

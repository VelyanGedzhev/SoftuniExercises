using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rabbits
{
    public class Cage
    {
        private List<Rabbit> data;

        public Cage(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            data = new List<Rabbit>();
        }
        public int Count
        {
            get
            {
                return data.Count;
            }
        }
        public string Name { get; set; }
        public int Capacity { get; set; }

        public void Add(Rabbit rabbit)
        {
            if (Count < Capacity)
            {
                data.Add(rabbit);
            }
        }
        public bool RemoveRabbit(string name)
        {
            //Rabbit rabbitToRemove = data.FirstOrDefault(n => n.Name == name);

            //return data.Remove(rabbitToRemove);
            if (this.data.Any(r => r.Name == name))
            {
                var current = this.data.Where(r => r.Name == name).FirstOrDefault();
                this.data.Remove(current);
                return true;
            }

            return false;
        }
        public void RemoveSpecies(string species)
        {
            
            data.RemoveAll(s => s.Species == species);

           
        }
        public Rabbit SellRabbit(string name)
        {
            Rabbit rabbit = this.data.FirstOrDefault(r => r.Name == name);
            if (rabbit != null)
            {
                rabbit.Available = false;
            }

            return rabbit;
        }
        public Rabbit[] SellRabbitsBySpecies(string species)
        {
            var rabbits = new List<Rabbit>();
            foreach (Rabbit rabbit in data)
            {
                if (rabbit.Species == species)
                {
                    rabbit.Available = false;
                    rabbits.Add(rabbit);
                }
            }

            return rabbits.ToArray();
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Rabbits available at {Name}");

            foreach (Rabbit rabbit in data.Where(a => a.Available == true))
            {
                sb.AppendLine(rabbit.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}

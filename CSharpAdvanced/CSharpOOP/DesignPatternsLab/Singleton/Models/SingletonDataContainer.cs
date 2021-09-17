using Singleton.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Singleton.Models
{
    public class SingletonDataContainer : ISingletonContainer
    {
        private Dictionary<string, int> capitals = new Dictionary<string, int>();

        private SingletonDataContainer()
        {
            Console.WriteLine("Initializing singleton object");

            var elements = File.ReadAllLines("capitals.txt");

            for (int i = 0; i < elements.Length; i += 2)
            {
                capitals.Add(elements[i], int.Parse(elements[i + 1]));
            }
        }

        public int GetPopulation(string name)
        {
            return capitals[name];
            
        }
        public static SingletonDataContainer Instance { get; } = new SingletonDataContainer();
    }
}

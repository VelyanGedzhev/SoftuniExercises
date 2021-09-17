using System;
using System.Collections.Generic;
using System.Text;

namespace Person
{
    public class Person
    {

        private int PERSON_MIN_AGE = 0;
        private int age;

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Name { get; set; }
        public virtual int Age
        {
            get
            {
                return age;
            }
            set
            {
                if (value < PERSON_MIN_AGE)
                {
                    throw new ArgumentException("Person age cannot be negative");
                }
                age = value;
            }
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Name: {Name}, Age: {Age}");

            return sb.ToString().Trim();
        }
    }
}

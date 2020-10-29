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
        public int Age
        {
            get
            {
                return age;
            }
            protected set
            {
                if (value >= PERSON_MIN_AGE)
                {
                    age = value;
                }
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

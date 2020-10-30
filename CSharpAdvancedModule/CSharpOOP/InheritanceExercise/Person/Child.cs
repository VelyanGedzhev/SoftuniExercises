using System;
using System.Collections.Generic;
using System.Text;

namespace Person
{
    class Child : Person
    {
        private const int CHILD_MAX_AGE = 15;
        
        public Child(string name, int age) : base(name, age)
        {

        }
        public override int Age
        {
            get
            {
                return base.Age;
            }
            set
            {
                if (value > CHILD_MAX_AGE)
                {
                    throw new ArgumentException("Child age must be less than 15");
                }
                base.Age = value;

            }
        }

    }
}

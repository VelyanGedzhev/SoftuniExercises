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
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Prototype
{
    public abstract class SandwichPrototype<T>
    {
        public abstract T ShallowClone();
        public abstract T DeepClone();
    }
}

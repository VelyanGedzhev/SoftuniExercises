using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl.Interfaces
{
    public interface IBuyer : ICheck
    {
        public int Food { get; }

        public int BuyFood();
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace CompositePattern.Interfaces
{
    public interface IGiftOperations
    {
        void Add(BaseGift baseGift);

        bool Remove(BaseGift baseGift);
    }
}

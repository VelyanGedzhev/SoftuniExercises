using CompositePattern.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompositePattern
{
    public class Composite : BaseGift, IGiftOperations
    {
        private ICollection<BaseGift> gifts;

        public Composite(decimal price, string name) 
            : base(price, name)
        {
            this.gifts = new List<BaseGift>();
        }

        public void Add(BaseGift baseGift)
        {
            gifts.Add(baseGift);
        }

        public bool Remove(BaseGift baseGift)
        {
           return gifts.Remove(baseGift);
        }

        public override decimal CalculateTotalPrice()
        {
            decimal totalPrice = 0;

            foreach (var item in gifts)
            {
                totalPrice += item.CalculateTotalPrice();
            }

            return totalPrice;
        }
    }
}

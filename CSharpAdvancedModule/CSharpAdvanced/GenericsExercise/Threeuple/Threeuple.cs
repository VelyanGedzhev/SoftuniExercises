using System;
using System.Collections.Generic;
using System.Text;

namespace Threeuple
{
    public class Threeuple<TFirst, TSecond, TThird>
    {
        public Threeuple(TFirst firstItem, TSecond secondItem, TThird thirdItem)
        {
            this.FirstItem = firstItem;
            this.SecondItem = secondItem;
            this.ThirdItem = thirdItem;
        }

        public TFirst FirstItem { get; set; }
        public TSecond SecondItem { get; set; }
        public TThird ThirdItem { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{FirstItem} -> {SecondItem} -> {ThirdItem}");

            return sb.ToString().TrimEnd();

        }
    }
}

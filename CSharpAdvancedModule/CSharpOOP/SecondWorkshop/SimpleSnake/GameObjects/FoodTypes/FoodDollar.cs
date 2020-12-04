using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSnake.GameObjects.FoodTypes
{
    public class FoodDollar : Food
    {
        private const char DOLLAR_SYMBOL = '$';
        private const int DOLLAR_POINTS = 2;

        public FoodDollar(Wall wall)
            : base(wall, DOLLAR_SYMBOL, DOLLAR_POINTS)
        {
        }
    }
}

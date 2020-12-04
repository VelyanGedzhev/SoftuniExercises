using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSnake.GameObjects.FoodTypes
{
    public class FoodHash : Food
    {
        private const char HASH_SYMBOL = '#';
        private const int HASH_POINTS = 3;

        public FoodHash(Wall wall)
            : base(wall, HASH_SYMBOL, HASH_POINTS)
        {
        }
    }
}

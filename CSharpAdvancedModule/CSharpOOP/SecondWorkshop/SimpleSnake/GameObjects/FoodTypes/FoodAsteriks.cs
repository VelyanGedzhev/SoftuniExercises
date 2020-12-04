using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSnake.GameObjects.FoodTypes
{
    public class FoodAsteriks : Food
    {
        private const char ASTERIKS_SYMBOL = '*';
        private const int ASTERIKS_POINTS = 1;

        public FoodAsteriks(Wall wall) 
            : base(wall, ASTERIKS_SYMBOL, ASTERIKS_POINTS)
        {
        }
    }
}

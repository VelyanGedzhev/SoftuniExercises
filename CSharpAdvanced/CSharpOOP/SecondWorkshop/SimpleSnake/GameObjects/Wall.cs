using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSnake.GameObjects
{
    public class Wall : Point
    {
        private const char WALL_SYMBOL = '\u25A0';
        public Wall(int leftX, int topY) 
            : base(leftX, topY)
        {
            IntializeWallBorders();
        }
        private void SetHorizontalLine(int topY)
        {
            for (int leftX = 0; leftX < LeftX; leftX++)
            {
                Draw(leftX, topY, WALL_SYMBOL);
            }
        }
        private void SetVerticalLine(int leftX)
        {
            for (int topY = 0; topY < TopY; topY++)
            {
                Draw(leftX, topY, WALL_SYMBOL);
            }
        }

        private void IntializeWallBorders()
        {
            SetHorizontalLine(0);
            SetHorizontalLine(TopY - 1);

            SetVerticalLine(0);
            SetVerticalLine(LeftX - 1);
        }
    }
}

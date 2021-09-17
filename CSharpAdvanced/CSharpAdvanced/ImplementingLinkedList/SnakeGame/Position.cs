using System;
using System.Collections.Generic;
using System.Text;

namespace SnakeGame
{
    public class Position
    {
        public Position(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public int X { get; set; }
        public int Y { get; set; }
        public void ChangePosition(Position position)
        {
            this.X += position.X;
            this.Y += position.Y;
        }
        public Position GetNewPosition(Position position)
        {
            return new Position(this.X + position.X, this.Y + position.Y);
        }

        public static bool operator == (Position first, Position second)
        {
            if(first.X == second.X && first.Y == second.Y)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool operator != (Position first, Position second)
        {
            throw new NotImplementedException();
        }
    }
}

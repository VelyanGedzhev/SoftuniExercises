using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleSnake.GameObjects
{
    public abstract class Food : Point
    {
        private readonly Random rand;
        private readonly Wall wall;
        private char foodSymbol;

        protected Food(Wall wall, char symbol, int foodPoints) 
            : base(wall.LeftX, wall.TopY)
        {
            foodSymbol = symbol;
            FoodPoints = foodPoints;

            this.wall = wall;
            rand = new Random();
        }

        public int FoodPoints { get; private set; }

        public void SetRandomPosition(Queue<Point> snake)
        {
            LeftX = rand.Next(2, wall.LeftX - 2);
            TopY = rand.Next(2, wall.TopY - 2);

            bool isPartOfSnake = snake.Any(x => x.LeftX == LeftX && x.TopY == TopY);

            while (isPartOfSnake)
            {
                LeftX = rand.Next(2, wall.LeftX - 2);
                TopY = rand.Next(2, wall.TopY - 2);

                isPartOfSnake = snake.Any(x => x.LeftX == LeftX && x.TopY == TopY);
            }

            Draw(LeftX, TopY, foodSymbol);
        }

        public bool IsFoodPoint(Point snake)
        {
            return LeftX == snake.LeftX && TopY == snake.TopY;
        }

    }
}

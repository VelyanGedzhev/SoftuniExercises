using SimpleSnake.GameObjects.FoodTypes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleSnake.GameObjects
{
    public class Snake : Point
    {
        private const char SNAKE_SYMBOL = 'o';

        private readonly Queue<Point> snakeElements;
        private readonly Wall wall;
        private readonly Food[] food;

        private int foodIndex = new Random().Next(0, 3);

        public Snake(Wall wall, int leftX, int topY) 
            : base(leftX, topY)
        {
            this.wall = wall;
            snakeElements = new Queue<Point>();
            food = new Food[]
            {
                new FoodAsteriks(wall),
                new FoodDollar(wall),
                new FoodHash(wall)
            };

            CreateSnake();
        }

        public bool IsMoving(Point direction)
        {
            var snakeHead = snakeElements.Last();

            GetNextDirection(direction, snakeHead);

            if (LeftX == 0 || TopY == 0 || LeftX == wall.LeftX || TopY == wall.TopY)
            {
                return false;
            }

            if (snakeElements.Any(x => x.LeftX == LeftX && x.TopY == TopY))
            {
                return false;
            }

            var newSnakeHead = new Point(LeftX, TopY);
            newSnakeHead.Draw(SNAKE_SYMBOL);
            snakeElements.Enqueue(newSnakeHead);

            if (food[foodIndex].IsFoodPoint(newSnakeHead))
            {
                GetNextDirection(newSnakeHead, direction);
                newSnakeHead = new Point(LeftX, TopY);
                newSnakeHead.Draw(SNAKE_SYMBOL);
                snakeElements.Enqueue(newSnakeHead);

            }

            var tail = snakeElements.Dequeue();
            tail.Draw(' ');
              

            return true;
        }

        private void GetNextDirection(Point direction, Point head)
        {
            LeftX = head.LeftX +  direction.LeftX;
            TopY = head.TopY + direction.TopY;
        }

        private void CreateSnake()
        {
            for (int i = 0; i <= 6; i++)
            {
                var currentPoint = new Point(LeftX + i, TopY);
                currentPoint.Draw(SNAKE_SYMBOL);

                snakeElements.Enqueue(currentPoint);
            }
        }
    }
}

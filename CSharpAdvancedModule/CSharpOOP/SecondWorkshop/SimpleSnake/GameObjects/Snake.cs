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
            food[foodIndex].SetRandomPosition(snakeElements);
        }

        public int Lenght => snakeElements.Count;

        public bool IsMoving(Point direction)
        {
            var snakeHead = snakeElements.Last();

            GetNextDirection(direction, snakeHead);

            if (IsWallPoint())
            {
                return false;
            }

            if (IsPartOfSnake())
            {
                return false;
            }

            Point newSnakeHead = CreateNewHead();

            if (food[foodIndex].IsFoodPoint(newSnakeHead))
            {
                Eat(direction, newSnakeHead);

                food[foodIndex].SetRandomPosition(snakeElements);
            }

            RemoveSnakeTail();

            return true;
        }

        private void RemoveSnakeTail()
        {
            var tail = snakeElements.Dequeue();
            tail.Draw(' ');
        }

        private Point CreateNewHead()
        {
            var newSnakeHead = new Point(LeftX, TopY);
            newSnakeHead.Draw(SNAKE_SYMBOL);
            snakeElements.Enqueue(newSnakeHead);
            return newSnakeHead;
        }

        private void Eat(Point direction, Point newSnakeHead)
        {
            for (int i = 0; i < food[foodIndex].FoodPoints; i++)
            {
                GetNextDirection(newSnakeHead, direction);
                newSnakeHead = new Point(LeftX, TopY);
                newSnakeHead.Draw(SNAKE_SYMBOL);
                snakeElements.Enqueue(newSnakeHead);
            }
        }

        private Point NewMethod(Point direction, Point newSnakeHead)
        {
            for (int i = 0; i < food[foodIndex].FoodPoints; i++)
            {
                GetNextDirection(newSnakeHead, direction);
                newSnakeHead = new Point(LeftX, TopY);
                newSnakeHead.Draw(SNAKE_SYMBOL);
                snakeElements.Enqueue(newSnakeHead);
            }

            return newSnakeHead;
        }

        private bool IsPartOfSnake()
        {
            return snakeElements.Any(x => x.LeftX == LeftX && x.TopY == TopY);
        }

        private bool IsWallPoint()
        {
            return LeftX == 0 || TopY == 0 || LeftX == wall.LeftX - 1 || TopY == wall.TopY - 1;
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

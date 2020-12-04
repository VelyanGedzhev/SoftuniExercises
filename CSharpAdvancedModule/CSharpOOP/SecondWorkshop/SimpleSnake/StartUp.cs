namespace SimpleSnake
{
    using SimpleSnake.GameObjects;
    using SimpleSnake.GameObjects.FoodTypes;
    using System.Collections.Generic;
    using Utilities;

    public class StartUp
    {
        public static void Main()
        {
            Wall wall = new Wall(70, 20);

            Food food = new FoodDollar(wall);
            food.SetRandomPosition(new Queue<Point>());

            Snake snake = new Snake(1, 1);
            snake.IsMoving(new Point(1, 0));
            snake.IsMoving(new Point(1, 0));
            snake.IsMoving(new Point(1, 0));
            snake.IsMoving(new Point(1, 0));
            snake.IsMoving(new Point(0, 1));
            snake.IsMoving(new Point(0, 1));
            snake.IsMoving(new Point(0, 1));
            
        }
    }
}

namespace SimpleSnake
{
    using SimpleSnake.GameObjects;
    using System.Collections.Generic;
    using Utilities;

    public class StartUp
    {
        public static void Main()
        {
            Wall wall = new Wall(70, 20);

            Food food = new Food(wall, 1, 12);
            food.SetRandomPosition(new Queue<Point>());
        }
    }
}

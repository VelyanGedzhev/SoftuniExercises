namespace SimpleSnake
{
    using SimpleSnake.Core;
    using SimpleSnake.GameObjects;
    using SimpleSnake.GameObjects.FoodTypes;
    using System.Collections.Generic;
    using Utilities;

    public class StartUp
    {
        public static void Main()
        {
            Wall wall = new Wall(70, 20);

            Snake snake = new Snake(wall, 1, 6);

            Engine engine = new Engine(snake, wall);
            engine.Run();
            
        }
    }
}

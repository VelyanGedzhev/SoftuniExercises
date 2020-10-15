using SnakeGame.Helpers;
using SnakeGame.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SnakeGame
{
    public class GameEngine
    {
        private bool isStarted = false;
        private List<IDrawable> gameItems = new List<IDrawable>();
        public Snake Snake { get; set; }
        private Random rand = new Random();
        public GameEngine()
        {
            Snake = new Snake(new Position(30, 20));
            gameItems.Add(Snake);

            for (int i = 0; i < 20; i++)
            {
                var food = new Food(new Position(rand.Next(0, Console.WindowWidth),
                    rand.Next(0, Console.WindowHeight)));

                gameItems.Add(food);
                Snake.Foods.Add(food);
            }
        }
        public void Start()
        {
            isStarted = true;
            Position movementPosition = new Position(0, 0);
            while (isStarted == true)
            {
              BoundariesCheck.CheckBoundaries(Snake.SnakeBody.Head.Value, movementPosition);
                //Console.WriteLine("Playing the game");
                Snake.Move(movementPosition);
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(false).Key;
                    movementPosition = ReadUserInput.GetMovement(key);
                }
                
                Thread.Sleep(50);
                //Console.Clear();
                gameItems.ForEach(i => i.Draw());
            }
        }
        public void Stop()
        {
            isStarted = false;
        }
    }
}

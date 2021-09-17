using SnakeGame.Helpers;
using SnakeGame.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace SnakeGame
{
    public class Snake : IDrawable
    {
        public Snake(Position headPosition)
        {
            SnakeBody = new LinkedList();
            SnakeBody.AddHead(new Node(headPosition));
            Foods = new List<Food>();

            for (int i = 1; i < 10; i++)
            {
               SnakeBody.AddLast(new Node(new Position(headPosition.X + i, headPosition.Y)));
            }
        }
        public LinkedList SnakeBody { get; set; }
        public List<Food> Foods { get; set; }
        public void Draw()
        {
            SnakeBody.ForEach(n =>
            {
                var text = "*";
               
                if (n == SnakeBody.Head)
                {
                    text = "@";
                }
                ConsoleHelper.Write(n.Value, text);
            });

            
        }
        public void Move(Position position)
        {
            if (position.X == 0 && position.Y == 0)
            {
                return;
            }
            ConsoleHelper.Clear(SnakeBody.Tail.Value);
            SnakeBody.ReverseForEach(n =>
            {
                
                if (n.Previous != null)
                {
                    n.Value.X = n.Previous.Value.X;
                    n.Value.Y = n.Previous.Value.Y;
                }
            });
            SnakeBody.Head.Value.ChangePosition(position);

            for (int i = 0; i < Foods.Count; i++)
            {
                if (Foods[i].Position == SnakeBody.Head.Value)
                {
                    Foods[i].EatFood();
                    Grow(position);
                }
            }
        }
        public void Grow(Position position)
        {
            var oldPosition = SnakeBody.Head.Value;
            var newHead = new Node(new Position(oldPosition.X, oldPosition.Y));
            newHead.Value.ChangePosition(position);

            SnakeBody.AddHead(newHead);
        }

    }
}

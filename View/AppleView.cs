namespace SnakeCore.View
{
    using System;
    using SnakeCore.Models;

    public class AppleView
    {
        public AppleView()
        {
        }

        public void Draw(Apple apple)
        {
            if (apple.IsActive)
            {
                Console.SetCursorPosition(apple.Position.X, apple.Position.Y);
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("@");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public void Delete(Apple apple)
        {
            if (apple.IsActive)
            {
                Console.SetCursorPosition(apple.Position.X, apple.Position.Y);
                Console.Write(" ");
            }
        }
    }
}

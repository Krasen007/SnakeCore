namespace SnakeCore.View
{
    using System;
    using SnakeCore.Models;
    using SnakeCore.Tools;

    public class SnakeView
    {
        private readonly Snake snake;

        public SnakeView(Snake snake)
        {
            this.snake = snake;
        }

        public void Draw(Vector2 direction)
        {
            // Case right
            char headSymbol = ' ';
            if (direction.X == 1)
            {
                headSymbol = '>';
            }

            if (direction.X == -1)
            {
                headSymbol = '<';
            }

            if (direction.Y == 1)
            {
                headSymbol = 'V';
            }

            if (direction.Y == -1)
            {
                headSymbol = '^';
            }

            Console.SetCursorPosition(this.snake.SnakeElements[0].X, this.snake.SnakeElements[0].Y);
            Console.Write(headSymbol);

            for (int i = 1; i < this.snake.SnakeElements.Count; i++)
            {
                Console.SetCursorPosition(this.snake.SnakeElements[i].X, this.snake.SnakeElements[i].Y);
                Console.Write("*");
            }
        }

        public void Delete()
        {
            for (int i = 0; i < this.snake.SnakeElements.Count; i++)
            {
                Console.SetCursorPosition(this.snake.SnakeElements[i].X, this.snake.SnakeElements[i].Y);
                Console.Write(" ");
            }
        }
    }
}

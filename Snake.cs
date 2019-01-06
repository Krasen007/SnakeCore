namespace SnakeCore
{
    using System;
    using System.Collections.Generic;

    public class Snake
    {
        public Snake()
        {
            this.SnakeElements = new List<Vector2>
                {
                // get random starting position
                    new Vector2(10, 10),
                    new Vector2(10, 9),
                    new Vector2(10, 8),
                    new Vector2(10, 7),
                    new Vector2(10, 6),
                };
        }

        public List<Vector2> SnakeElements { get; }

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

            Console.SetCursorPosition(this.SnakeElements[0].X, this.SnakeElements[0].Y);
            Console.Write(headSymbol);

            for (int i = 1; i < this.SnakeElements.Count; i++)
            {
                Console.SetCursorPosition(this.SnakeElements[i].X, this.SnakeElements[i].Y);
                Console.Write("*");
            }
        }

        public void Delete()
        {
            for (int i = 0; i < this.SnakeElements.Count; i++)
            {
                Console.SetCursorPosition(this.SnakeElements[i].X, this.SnakeElements[i].Y);
                Console.Write(" ");
            }
        }

        public void Update(Vector2 direction)
        {
            // Move Snake
            for (int i = this.SnakeElements.Count - 1; i > 0; i--)
            {
                this.SnakeElements[i].X = this.SnakeElements[i - 1].X;
                this.SnakeElements[i].Y = this.SnakeElements[i - 1].Y;
            }

            this.SnakeElements[0].Add(direction);

            // Teleport snake
            if (this.SnakeElements[0].X == Console.BufferWidth)
            {
                this.SnakeElements[0].X = 0;
            }
            else if (this.SnakeElements[0].X == -1)
            {
                this.SnakeElements[0].X = Console.BufferWidth - 1;
            }
            else if (this.SnakeElements[0].Y == Console.BufferHeight)
            {
                this.SnakeElements[0].Y = 0;
            }
            else if (this.SnakeElements[0].Y == -1)
            {
                this.SnakeElements[0].Y = Console.BufferHeight - 1;
            }
        }
    }
}

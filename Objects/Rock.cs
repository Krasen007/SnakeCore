namespace SnakeCore.Objects
{
    using System;
    using SnakeCore.Tools;

    public class Rock
    {
        private readonly Random rng;
               
        public Rock(Snake snake)
        {
            this.rng = new Random();
            this.Generate(snake);
        }

        public Vector2 Position { get; set; }

        public void Draw()
        {
            Console.SetCursorPosition(this.Position.X, this.Position.Y);
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("X");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void Generate(Snake snake)
        {
            this.Position = new Vector2(0, 0);
            do
            {
                this.Position.X = this.rng.Next(0, Console.BufferWidth);
                this.Position.Y = this.rng.Next(0, Console.BufferHeight);
            }
            while (this.CollidesWithElements(snake));
        }

        public bool CollidesWithElements(Snake snake)
        {
            for (int i = 0; i < snake.SnakeElements.Count; i++)
            {
                if (snake.SnakeElements[i].IsEqualTo(this.Position))
                {
                    return true;
                }
            }

            return false;
        }
    }
}

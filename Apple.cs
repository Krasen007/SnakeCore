namespace SnakeCore
{
    using System;

    public class Apple
    {
        private readonly int spawnTimer;
        private readonly Random rng;
        private int timeSinceLastSpawn;

        public Apple()
        {
            this.Position = new Vector2(0, 0);
            this.IsActive = false;
            this.rng = new Random();

            // For proper Timer:
            this.timeSinceLastSpawn = Environment.TickCount;
            this.spawnTimer = 3000; // -> 5 seconds delay between apple spawns
        }

        public Vector2 Position { get; set; }

        public bool IsActive { get; set; }

        public void Draw()
        {
            if (this.IsActive)
            {
                Console.SetCursorPosition(this.Position.X, this.Position.Y);
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("@");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public void Update(Snake snake)
        {
            // For proper Timer:
            if (this.timeSinceLastSpawn + this.spawnTimer < Environment.TickCount)
            {
                this.timeSinceLastSpawn = Environment.TickCount; // -> resets the timer
                  this.Generate(snake);
            }
        }

        public void Generate(Snake snake)
        {
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

            this.IsActive = true;
            return false;
        }

        public void Delete()
        {
            if (this.IsActive)
            {
                Console.SetCursorPosition(this.Position.X, this.Position.Y);
                Console.Write(" ");
            }
        }
    }
}

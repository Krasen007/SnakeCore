namespace SnakeCore.Controllers
{
    using System;
    using SnakeCore.Models;
    using SnakeCore.Tools;

    public class RockController
    {
        private readonly Random rng;

        public RockController()
        {
            this.rng = new Random();
        }

        public void Generate(Snake snake, Rock rock)
        {                        
            do
            {
                rock.Position.X = this.rng.Next(0, Console.BufferWidth);
                rock.Position.Y = this.rng.Next(0, Console.BufferHeight);
            }
            while (this.CollidesWithElements(snake, rock));
        }

        public bool CollidesWithElements(Snake snake, Rock rock)
        {
            for (int i = 0; i < snake.SnakeElements.Count; i++)
            {
                if (snake.SnakeElements[i].IsEqualTo(rock.Position))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
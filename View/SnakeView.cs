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
            else if (direction.X == -1)
            {
                headSymbol = '<';
            }
            else if (direction.Y == 1)
            {
                headSymbol = 'V';
            }
            else if (direction.Y == -1)
            {
                headSymbol = '^';
            }

            if ((this.snake.SnakeElements[0].X == 49) && (this.snake.SnakeElements[0].Y == 24))
            {
                // test fix
                Console.SetCursorPosition(5, 5);
            }
            else
            {
                Console.SetCursorPosition(this.snake.SnakeElements[0].X, this.snake.SnakeElements[0].Y);
                Console.Write(headSymbol);
            }

            if (this.snake.SnakeElements.Count > 1)
            {
                if ((this.snake.SnakeElements[1].X == 49) && (this.snake.SnakeElements[1].Y == 24))
                {
                    // test fix
                    Console.SetCursorPosition(5, 5);
                }
                else
                {
                    for (int i = 1; i < this.snake.SnakeElements.Count; i++)
                    {
                        if ((this.snake.SnakeElements[i].X == 49) && (this.snake.SnakeElements[i].Y == 24))
                        {
                            Console.SetCursorPosition(5, 5);
                        } else
                        {
                            for (int j = 1; j < this.snake.SnakeElements.Count; j++)
                            {
                                Console.SetCursorPosition(this.snake.SnakeElements[i].X, this.snake.SnakeElements[i].Y);
                                Console.Write("*");
                            }
                        }
                    }                    
                }
            }
            //else
            //{
            //    if ((this.snake.SnakeElements[0].X == 49) && (this.snake.SnakeElements[0].Y == 24))
            //    {
            //        // test fix
            //        Console.SetCursorPosition(5, 5);
            //    } else
            //    {
            //        Console.SetCursorPosition(this.snake.SnakeElements[0].X, this.snake.SnakeElements[0].Y);
            //        Console.Write(headSymbol);
            //    }
            //}
        }

        public void Delete()
        {
            if (this.snake.SnakeElements.Count > 1)
            {
                for (int i = 1; i < this.snake.SnakeElements.Count; i++)
                {
                    if ((this.snake.SnakeElements[i].X == 49) && (this.snake.SnakeElements[i].Y == 24))
                    {
                        // test fix
                        Console.SetCursorPosition(5, 5);
                    }
                    else
                    {
                        Console.SetCursorPosition(
                        this.snake.SnakeElements[this.snake.SnakeElements.Count - 1].X,
                        this.snake.SnakeElements[this.snake.SnakeElements.Count - 1].Y);
                        Console.Write(" ");
                    }
                }

            }
            else
            {
                Console.SetCursorPosition(
                    this.snake.SnakeElements[this.snake.SnakeElements.Count - 1].X,
                    this.snake.SnakeElements[this.snake.SnakeElements.Count - 1].Y);
                Console.Write(" ");
            }
        }
    }
}

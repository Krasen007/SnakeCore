/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Krasen Ivanov. All rights reserved.
 *  Licensed under the MIT License. See License.txt in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

namespace SnakeCore.Controllers
{
    using System;
    using SnakeCore.Models;
    using SnakeCore.Tools;

    public class SnakeController
    {
        private readonly Snake snake;

        public SnakeController(Snake snake)
        {
            this.snake = snake;
        }

        public void Update(Vector2 direction)
        {
            // Update snake "*" body position
            for (int i = this.snake.SnakeElements.Count - 1; i > 0; i--)
            {
                this.snake.SnakeElements[i].X = this.snake.SnakeElements[i - 1].X;
                this.snake.SnakeElements[i].Y = this.snake.SnakeElements[i - 1].Y;
            }

            this.snake.SnakeElements[0].Move(direction);

            // Teleport snake
            if (this.snake.SnakeElements[0].X == Console.BufferWidth)
            {
                this.snake.SnakeElements[0].X = 0;
            }
            else if (this.snake.SnakeElements[0].X == -1)
            {
                this.snake.SnakeElements[0].X = Console.BufferWidth - 1;
            }
            else if (this.snake.SnakeElements[0].Y == Console.BufferHeight)
            {
                this.snake.SnakeElements[0].Y = 0;
            }
            else if (this.snake.SnakeElements[0].Y == -1)
            {
                this.snake.SnakeElements[0].Y = Console.BufferHeight - 1;
            }
        }
    }
}

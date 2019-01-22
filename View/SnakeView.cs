/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Krasen Ivanov. All rights reserved.
 *  Licensed under the MIT License. See License.txt in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

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

            for (int i = 1; i < this.snake.SnakeElements.Count; i++)
            {
                if (this.snake.SnakeElements.Count > 1)
                {
                    if ((this.snake.SnakeElements[i].X == 49) && (this.snake.SnakeElements[i].Y == 24))
                    {
                        // test fix
                        Console.SetCursorPosition(5, 5);
                    }
                    else
                    {
                        Console.SetCursorPosition(this.snake.SnakeElements[i].X, this.snake.SnakeElements[i].Y);
                        const string BodyString = "*";
                        Console.Write(BodyString);
                    }
                }
            }
        }

        public void Delete()
        {
            for (int i = 0; i < this.snake.SnakeElements.Count; i++)
            {
                if ((this.snake.SnakeElements[i].X == 49) && (this.snake.SnakeElements[i].Y == 24))
                {
                    // test fix
                    Console.SetCursorPosition(5, 5);
                }
                else
                {
                    if ((this.snake.SnakeElements[this.snake.SnakeElements.Count - 1].X == 49) && (this.snake.SnakeElements[this.snake.SnakeElements.Count - 1].Y == 24))
                    {
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
        }
    }
}

namespace SnakeCore
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using SnakeCore.Objects;
    using SnakeCore.Tools;

    public class SnakeGame
    {
        public SnakeGame()
        {
            bool isGameOver = false;
            double difficulty = 150;
            double changeDifficulty = 1;
            double worstDifficulty = 50;

            this.MainGame(difficulty, changeDifficulty, worstDifficulty, isGameOver);            
        }

        private void GameOver()
        {
            Console.Clear();
            Console.WriteLine("Thank you for playing!");
            Console.ReadKey(true);
        }

        private void MainGame(double difficulty, double changeDifficulty, double worstDifficulty, bool isGameOver)
        {
            // fix going up
            /// Vector2 up = new Vector2(0, -1);
            Vector2 down = new Vector2(0, 1);
            Vector2 left = new Vector2(-1, 0);
            Vector2 right = new Vector2(1, 0);

            List<Vector2> possibleDirections = new List<Vector2>()
            { 
                down,
                left,
                right
            };

            Random random = new Random();

            Vector2 selectedRandomDirection = possibleDirections[random.Next(0, possibleDirections.Count)];            

            Vector2 direction = selectedRandomDirection;

            Apple apple = new Apple();
            Snake snake = new Snake();
            List<Rock> rocks = new List<Rock>();

            while (!isGameOver)
            {
                this.InputHandler(direction);
                snake.Update(direction);
                apple.Update(snake);

                this.SnakeAppleCollision(snake, apple, rocks);

                if (this.SnakeRocksCollision(snake, rocks) || this.SnakeSelfCollision(snake))
                {
                    isGameOver = true;
                }

                foreach (var rock in rocks)
                {
                    rock.Draw();
                }

                apple.Draw();
                snake.Draw(direction);

                if (difficulty >= worstDifficulty)
                {
                    difficulty -= changeDifficulty;
                }

                int sleepTime = (int)Math.Max(Math.Round(difficulty), worstDifficulty);
                Thread.Sleep(sleepTime);
                apple.Delete();
                snake.Delete();
            }

            this.GameOver();
        }

        private void InputHandler(Vector2 direction)
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo userInput = Console.ReadKey();
                if (userInput.Key == ConsoleKey.RightArrow && direction.X != -1)
                {
                    direction.X = 1;
                    direction.Y = 0;
                }
                else if (userInput.Key == ConsoleKey.LeftArrow && direction.X != 1)
                {
                    direction.X = -1;
                    direction.Y = 0;
                }
                else if (userInput.Key == ConsoleKey.UpArrow && direction.Y != 1)
                {
                    direction.X = 0;
                    direction.Y = -1;
                }
                else if (userInput.Key == ConsoleKey.DownArrow && direction.Y != -1)
                {
                    direction.X = 0;
                    direction.Y = 1;
                }
                else if (userInput.Key == ConsoleKey.Escape)
                {
                    Console.WriteLine("Click the X button");
                }
            }
        }

        private void SnakeAppleCollision(Snake snake, Apple apple, List<Rock> rocks)
        {
            if (apple.IsActive && snake.SnakeElements[0].IsEqualTo(apple.Position))
            {
                apple.IsActive = false;
                snake.SnakeElements.Add(
                    new Vector2(
                        snake.SnakeElements[snake.SnakeElements.Count - 1].X,
                        snake.SnakeElements[snake.SnakeElements.Count - 1].Y));
                rocks.Add(new Rock(snake));
                rocks.Add(new Rock(snake));
                rocks.Add(new Rock(snake));
            }
        }

        private bool SnakeRocksCollision(Snake snake, List<Rock> rocks)
        {
            foreach (var rock in rocks)
            {
                if (rock.Position.IsEqualTo(snake.SnakeElements[0]))
                {
                    return true;
                }
            }

            return false;
        }

        private bool SnakeSelfCollision(Snake snake)
        {
            for (int i = 1; i < snake.SnakeElements.Count; i++)
            {
                if (snake.SnakeElements[0].IsEqualTo(snake.SnakeElements[i]))
                {
                    return true;
                }
            }

            return false;
        }
    }
}

/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Krasen Ivanov. All rights reserved.
 *  Licensed under the MIT License. See License.txt in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

namespace SnakeCore.View
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using SnakeCore.Controllers;
    using SnakeCore.Models;
    using SnakeCore.Tools;

    public class Game
    {
        /// <summary>
        /// Starts new game.
        /// </summary>
        public Game(double difficulty, double changeDifficulty, double worstDifficulty, int appleSpawnTime, bool rocksEnabled)
        {
            Console.Clear();
            bool isGameOver = false;

            this.MainGame(difficulty, changeDifficulty, worstDifficulty, isGameOver, appleSpawnTime, rocksEnabled);
        }

        /// <summary>
        /// Main Game Loop.
        /// </summary>
        private void MainGame(double difficulty, double changeDifficulty, double worstDifficulty, bool isGameOver, int appleSpawnTime, bool rocksEnabled)
        {
            double startDiff = difficulty;
            double startChangeDiff = changeDifficulty;
            double startWorstDiff = worstDifficulty;
            int startAppleSpawnTime = appleSpawnTime;
            bool startRocksEnabled = rocksEnabled;

            // Adds directions for random starting direction of snake.
            // fix starting in up
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
            AppleView appleView = new AppleView();

            Snake snake = new Snake();
            SnakeView snakeView = new SnakeView(snake);

            AppleController appleController = new AppleController(appleSpawnTime);
            SnakeController snakeController = new SnakeController(snake);
            RockController rockController = new RockController();

            List<Rock> rocks = new List<Rock>();
            RockView rockView = new RockView(rocks);

            // Main Loop
            while (!isGameOver)
            {
                if (this.InputHandler(direction))
                {
                    isGameOver = true;
                }

                snakeController.Update(direction);
                appleController.Update(snake, apple);

                if (this.SnakeAppleCollision(snake, apple) && snake.SnakeElements.Count >= Constants.DefaultSnakeLengthRockSpawn && rocksEnabled)
                {
                    rocks.Add(new Rock());
                    rocks.Add(new Rock());
                    rocks.Add(new Rock());

                    const int NumberOfRocksAdded = 3;
                    for (int i = rocks.Count - NumberOfRocksAdded; i < rocks.Count; i++)
                    {
                        rockController.Generate(snake, rocks[i]);
                    }
                }

                if (this.SnakeRocksCollision(snake, rocks) || this.SnakeSelfCollision(snake))
                {
                    isGameOver = true;
                }

                rockView.Draw();
                appleView.Draw(apple);
                snakeView.Draw(direction);

                if (difficulty >= worstDifficulty)
                {
                    difficulty -= changeDifficulty;
                }

                int sleepTime = (int)Math.Max(Math.Round(difficulty), worstDifficulty);
                Thread.Sleep(sleepTime);

                appleView.Delete(apple);
                snakeView.Delete();
            }

            this.GameOver(startDiff, startChangeDiff, startWorstDiff, startAppleSpawnTime, startRocksEnabled);
        }

        /// <summary>
        /// Displays game over text after crash of snake.
        /// </summary>
        private void GameOver(double difficulty, double changeDifficulty, double worstDifficulty, int appleSpawnTime, bool rocksEnabled)
        {
            Console.SetCursorPosition(0, 0);
            const string GameOver = "Game Over!\nYou will return to Main menu.\nPress any key...";
            Console.WriteLine(GameOver);
            Console.ReadKey(true);
            this.ReturnToMainMenu(difficulty, changeDifficulty, worstDifficulty, appleSpawnTime, rocksEnabled);
        }

        /// <summary>
        /// Returns the player to main menu.
        /// </summary>
        private void ReturnToMainMenu(double difficulty, double changeDifficulty, double worstDifficulty, int appleSpawnTime, bool rocksEnabled) => new MainMenu(false, difficulty, changeDifficulty, worstDifficulty, appleSpawnTime, rocksEnabled);
                
        /// <summary>
        /// Handles key input.
        /// </summary>
        /// <param name="direction">Current direction of snake.</param>
        /// <returns>Returns true if you want to exit the game.</returns>
        private bool InputHandler(Vector2 direction)
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo userInput = Console.ReadKey(true);
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
                    return true;
                } 
            }

            return false;
        }

        /// <summary>
        /// Checks for collision between snake and apple
        /// </summary>
        private bool SnakeAppleCollision(Snake snake, Apple apple)
        {
            if (apple.IsActive && snake.SnakeElements[0].IsEqualTo(apple.Position))
            {
                apple.IsActive = false;
                snake.SnakeElements.Add(
                    new Vector2(
                        snake.SnakeElements[snake.SnakeElements.Count - 1].X,
                        snake.SnakeElements[snake.SnakeElements.Count - 1].Y));
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Checks for collision between snake and rock
        /// </summary>
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

        /// <summary>
        /// Checks for collision between snake and itself
        /// </summary>
        private bool SnakeSelfCollision(Snake snake)
        {
            if (snake.SnakeElements.Count > 2)
            {
                for (int i = 1; i < snake.SnakeElements.Count; i++)
                {
                    if (snake.SnakeElements[0].IsEqualTo(snake.SnakeElements[i]))
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}

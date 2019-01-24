/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Krasen Ivanov. All rights reserved.
 *  Licensed under the MIT License. See License.txt in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

namespace SnakeCore.View
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using SnakeCore.Controllers;
    using SnakeCore.Models;
    using SnakeCore.Tools;

    public class Game
    {
        private readonly Dictionary<int, string> scoreboard;

        /// <summary>
        /// Starts new game.
        /// </summary>
        public Game(double difficulty, double changeDifficulty, double worstDifficulty, int appleSpawnTime, bool rocksEnabled)
        {
            Console.Clear();
            bool isGameOver = false;

            // fix this to be given before start of new game
            this.scoreboard = new Dictionary<int, string>();
            for (int i = 1; i < 10; i++)
            {
                scoreboard[i] = "AAA";
            }

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
                        rockController.SpawnRocks(snake, rocks[i]);
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
            const string GameOver = "Game Over!\nPress any key...";
            Console.WriteLine(GameOver);
            Console.ReadKey(true);
            this.LeaderboardScreen();
            this.ReturnToMainMenu(difficulty, changeDifficulty, worstDifficulty, appleSpawnTime, rocksEnabled);
        }

        private void LeaderboardScreen()
        {
            const int alphabetLettersCount = 26;
            char[] alphabet = new char[alphabetLettersCount];
            int counter = 0;

            for (char i = 'A'; i < '['; i++)
            {
                alphabet[counter] = i;
                counter++;
            }

            /* dictionary to hold:  
             * key      -> int, the score
             * value    -> string, the name (consisting of three letters) (for now just AAA)
             * */

            string currentLetterCombination = string.Empty;

            Console.Clear();
            Console.WriteLine("Enter your name by\npressing Up, Down and Enter on the\ndesired letter!");

            
            int widthLettersDisplay = Constants.GameWidth / 2;
            const int heightLettersDisplay = Constants.GameHeight / 4;
            Console.SetCursorPosition(widthLettersDisplay, heightLettersDisplay);

            Console.CursorVisible = true;

            int currentLetter = 0;
            Console.Write(alphabet[currentLetter]);

            int letterCounter = 0;
            while (letterCounter < 3)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo userInput = Console.ReadKey();

                    while (Console.KeyAvailable)
                    {
                        Console.ReadKey();
                    }

                    if (userInput.Key == ConsoleKey.UpArrow)
                    {
                        if (currentLetter < alphabetLettersCount - 1)
                        {
                            currentLetter++;
                            Console.SetCursorPosition(widthLettersDisplay, heightLettersDisplay);
                            Console.Write(alphabet[currentLetter]);
                        }
                    }
                    else if (userInput.Key == ConsoleKey.DownArrow)
                    {
                        //check if underflooding the alphabet
                        if (currentLetter > 0)
                        {
                            currentLetter--;
                            Console.SetCursorPosition(widthLettersDisplay, heightLettersDisplay);
                            Console.Write(alphabet[currentLetter]);
                        }
                    }
                    else if (userInput.Key == ConsoleKey.Enter)
                    {
#pragma warning disable S1643 // Strings should not be concatenated using '+' in a loop
                        currentLetterCombination += alphabet[currentLetter];
#pragma warning restore S1643 // Strings should not be concatenated using '+' in a loop

                        letterCounter++;
                        currentLetter = 0;

                        widthLettersDisplay++;

                        if (letterCounter < 3)
                        {
                            Console.SetCursorPosition(widthLettersDisplay, heightLettersDisplay);
                            Console.Write(alphabet[currentLetter]);
                        }
                    }
                }
            }

            // fix this (given score)
            int hiScore = 2018/*score*/;

           

            scoreboard[hiScore] = currentLetterCombination;

            const int scoreUIwidthPosition = Constants.GameWidth / 2;
            const int scoreUIheightPosition = Constants.GameHeight / 4;

            int increaserAndDisplayer = 1;

            foreach (var kvp in scoreboard.OrderByDescending(x => x.Key).Take(9))
            {
                Console.SetCursorPosition(scoreUIwidthPosition, scoreUIheightPosition + increaserAndDisplayer);
                Console.Write($"{increaserAndDisplayer} {kvp.Value} - {kvp.Key}");
                increaserAndDisplayer++;
            }
            Console.CursorVisible = false;

            Console.WriteLine("\n\n\nPress space \nto play again!");
            Console.ReadKey();
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

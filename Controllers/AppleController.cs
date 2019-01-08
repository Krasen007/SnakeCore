﻿namespace SnakeCore.Controllers
{
    using System;
    using SnakeCore.Models;

    public class AppleController
    {
        private readonly int spawnTimer;
        private readonly Random rng;
        private int timeSinceLastSpawn;

        public AppleController()
        {
            this.rng = new Random();

            // For proper Timer:
            this.timeSinceLastSpawn = Environment.TickCount;
            this.spawnTimer = 3000; // -> 5 seconds delay between apple spawns
        }

        public void Update(Snake snake, Apple apple)
        {
            // For proper Timer:
            if (this.timeSinceLastSpawn + this.spawnTimer < Environment.TickCount)
            {
                this.timeSinceLastSpawn = Environment.TickCount; // -> resets the timer
                this.Generate(snake, apple);
            }
        }

        public void Generate(Snake snake, Apple apple)
        {
            do
            {
                apple.Position.X = this.rng.Next(0, Console.BufferWidth);
                apple.Position.Y = this.rng.Next(0, Console.BufferHeight);
            }
            while (this.CollidesWithElements(snake, apple));
        }

        public bool CollidesWithElements(Snake snake, Apple apple)
        {
            for (int i = 0; i < snake.SnakeElements.Count; i++)

            {
                if (snake.SnakeElements[i].IsEqualTo(apple.Position))
                {
                    return true;
                }
            }

            apple.IsActive = true;
            return false;
        }
    }
}
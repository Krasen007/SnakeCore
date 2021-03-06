﻿/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Krasen Ivanov. All rights reserved.
 *  Licensed under the MIT License. See License.txt in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

namespace SnakeCore.Controllers
{
    using System;
    using SnakeCore.Models;
    using SnakeCore.Tools;

    public class AppleController
    {
        private readonly int spawnTimer;
        private readonly Random random;
        private int timeSinceLastSpawn;

        public AppleController(int appleSpawnTime)
        {
            this.random = new Random();

            this.timeSinceLastSpawn = Environment.TickCount;
            this.spawnTimer = appleSpawnTime;
        }

        public void Update(Snake snake, Apple apple)
        {
            if (this.timeSinceLastSpawn + this.spawnTimer < Environment.TickCount)
            {
                this.timeSinceLastSpawn = Environment.TickCount;
                this.Generate(snake, apple);
            }
        }

        public void Generate(Snake snake, Apple apple)
        {
            do
            {
                apple.Position.X = this.random.Next(0, Constants.PlayWidth);
                apple.Position.Y = this.random.Next(0, Constants.PlayHeigth);
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

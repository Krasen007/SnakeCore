/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Krasen Ivanov. All rights reserved.
 *  Licensed under the MIT License. See License.txt in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

namespace SnakeCore.Models
{
    using System;
    using System.Collections.Generic;
    using SnakeCore.Tools;

    public class Snake
    {
        public Snake()
        {
            Random random = new Random();

            int startPosX = random.Next(Console.BufferWidth);

            const int MinSpawnDistance = 3;
            int startPosY = random.Next(MinSpawnDistance, Console.BufferHeight);

            this.SnakeElements = new List<Vector2>
                {
                // get different starting lengths of snake
                    new Vector2(startPosX, startPosY),
                    ////new Vector2(startPosX, startPosY - 1),
                    ////new Vector2(startPosX, startPosY - 2),
                    ////new Vector2(startPosX, startPosY - 3),
                    ////new Vector2(startPosX, startPosY - 4),
                };
        }

        public List<Vector2> SnakeElements { get; }
    }
}

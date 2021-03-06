﻿/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Krasen Ivanov. All rights reserved.
 *  Licensed under the MIT License. See License.txt in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
 
 namespace SnakeCore.View
{
    using System;
    using System.Collections.Generic;
    using SnakeCore.Models;

    public class RockView
    {
        private readonly List<Rock> rocks;

        public RockView(List<Rock> rocks)
        {
            this.rocks = rocks;
        }

        public void Draw()
        {
            foreach (var rock in this.rocks)
            {
                Console.SetCursorPosition(rock.Position.X, rock.Position.Y);
                Console.ForegroundColor = ConsoleColor.DarkRed;
                const string RockString = "X";
                Console.Write(RockString);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}

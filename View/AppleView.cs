/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Krasen Ivanov. All rights reserved.
 *  Licensed under the MIT License. See License.txt in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

namespace SnakeCore.View
{
    using System;
    using SnakeCore.Models;

    public class AppleView
    {
        public AppleView()
        {
        }

        public void Draw(Apple apple)
        {
            if (apple.IsActive)
            {
                Console.SetCursorPosition(apple.Position.X, apple.Position.Y);
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                const string AppleSymbol = "@";
                Console.Write(AppleSymbol);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public void Delete(Apple apple)
        {
            if (apple.IsActive)
            {
                Console.SetCursorPosition(apple.Position.X, apple.Position.Y);
                const string EmptyString = " ";
                Console.Write(EmptyString);
            }
        }
    }
}

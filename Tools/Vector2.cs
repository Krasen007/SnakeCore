/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Krasen Ivanov. All rights reserved.
 *  Licensed under the MIT License. See License.txt in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

namespace SnakeCore.Tools
{
    public class Vector2
    {
        public Vector2(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public int X { get; set; }

        public int Y { get; set; }

        public void Move(Vector2 position)
        {
            this.X += position.X;
            this.Y += position.Y;
        }

        public bool IsEqualTo(Vector2 position)
        {
            return this.X == position.X && this.Y == position.Y;
        }
    }
}

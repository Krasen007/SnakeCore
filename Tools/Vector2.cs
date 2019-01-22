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

        public void Add(Vector2 newCoords)
        {
            this.X += newCoords.X;
            this.Y += newCoords.Y;
        }

        public bool IsEqualTo(Vector2 newCoords)
        {
            return this.X == newCoords.X && this.Y == newCoords.Y;
        }
    }
}

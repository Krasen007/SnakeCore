/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Krasen Ivanov. All rights reserved.
 *  Licensed under the MIT License. See License.txt in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

namespace SnakeCore.Models
{
    using SnakeCore.Tools;

    public class Rock
    {
        public Rock()
        {
            this.Position = new Vector2(0, 0);
        }

        public Vector2 Position { get; }        
    }
}

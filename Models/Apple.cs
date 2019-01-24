/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Krasen Ivanov. All rights reserved.
 *  Licensed under the MIT License. See License.txt in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

namespace SnakeCore.Models
{
    using SnakeCore.Tools;

    public class Apple
    {
        public Apple()
        {
            this.Position = new Vector2(0, 0);
            this.IsActive = false;
        }

        public Vector2 Position { get; }

        public bool IsActive { get; set; }            
    }
}

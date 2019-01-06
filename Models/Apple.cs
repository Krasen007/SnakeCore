namespace SnakeCore.Models
{
    using System;
    using SnakeCore.Tools;

    public class Apple
    {
        public Apple()
        {
            this.Position = new Vector2(0, 0);
            this.IsActive = false;
        }

        public Vector2 Position { get; set; }

        public bool IsActive { get; set; }            
    }
}

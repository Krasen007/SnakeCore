namespace SnakeCore.Models
{
    using System;
    using SnakeCore.Tools;

    public class Rock
    {
        public Rock()
        {
            this.Position = new Vector2(0, 0);
        }

        public Vector2 Position { get; set; }        
    }
}

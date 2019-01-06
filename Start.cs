namespace SnakeCore
{
    using System;

    public class Start
    {
        protected Start()
        {
        }
        
        public static void Main(string[] args)
        {
            /// fix console, if the game is run on other engine
            /// fix collision with self

            Console.CursorVisible = false;
            Console.BufferWidth = Console.WindowWidth = 50;
            Console.BufferHeight = Console.WindowHeight = 25;

            Console.WriteLine("Hello World!");
            Console.Clear();
#pragma warning disable S1848 // Objects should not be created to be dropped immediately without being used
            new SnakeGame();
#pragma warning restore S1848 // Objects should not be created to be dropped immediately without being used
        }
    }
}

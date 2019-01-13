/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Krasen Ivanov. All rights reserved.
 *  Licensed under the MIT License. See License.txt in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

namespace SnakeCore
{
    using System;
    using SnakeCore.Tools;
    using SnakeCore.View;

    public class Start
    {
        protected Start()
        {
        }

        public static void Main()
        {
            Console.Clear();
            Console.CursorVisible = false;
            Console.BufferWidth = Console.WindowWidth = Constants.GameWidth;
            Console.BufferHeight = Console.WindowHeight = Constants.GameHeight;

            DefineOs();
            PressAnyKey();
            StartGame();
        }

        /// <summary>
        /// Detects the current OS.
        /// </summary>
        private static void DefineOs()
        {
            OperatingSystem os = Environment.OSVersion;
            PlatformID pid = os.Platform;
            switch (pid)
            {
                case PlatformID.Win32NT:
                case PlatformID.Win32S:
                case PlatformID.Win32Windows:
                case PlatformID.WinCE:
                    {
                        const string WelcomeWindows = "Welcome to " + Constants.GameName + " for Windows.";
                        Console.WriteLine(WelcomeWindows);
                        break;
                    }

                case PlatformID.Unix:
                    const string WelcomeLinux = "Welcome to " + Constants.GameName + " for Linux.";
                    Console.WriteLine(WelcomeLinux);
                    break;
                case PlatformID.MacOSX:
                    const string WelcomeMac = "Welcome to " + Constants.GameName + " for Mac.";
                    Console.WriteLine(WelcomeMac);
                    break;
                default:
                    const string WelcomeAnyOS = "Welcome to " + Constants.GameName + "!";
                    Console.WriteLine(WelcomeAnyOS);
                    break;
            }
        }

        /// <summary>
        /// Asks for user keypress.
        /// </summary>
        private static void PressAnyKey()
        {
            const string AnyKeyStartText = "\nPress any key to start... ";
            Console.Write(AnyKeyStartText);
            Console.ReadKey(intercept: true);
        }

        private static void StartGame() => new MainMenu(true);
    }
}

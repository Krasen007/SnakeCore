﻿/*---------------------------------------------------------------------------------------------
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
        private static int currentBufferWidth;
        private static int currentBufferHeight;
        private static int currentWindowWidth;
        private static int currentWindowHeight;

        protected Start()
        {
        }

        public static void Main()
        {
            Initialize();
            DefineOs();
            PressAnyKeyToStart();
            StartGame();
            RestoreWindowInit();
        }        

        /// <summary>
        /// Sets initialization of Console window for the game.
        /// </summary>
        private static void Initialize()
        {
            currentBufferWidth = Console.BufferWidth;
            currentBufferHeight = Console.BufferHeight;

            currentWindowWidth = Console.WindowWidth;
            currentWindowHeight = Console.WindowHeight;

            Console.Clear();
            Console.CursorVisible = false;
            Console.BufferWidth = Console.WindowWidth = Constants.GameWidth;
            Console.BufferHeight = Console.WindowHeight = Constants.GameHeight;            
        }

        /// <summary>
        /// Detects the current OS.
        /// </summary>
        private static void DefineOs()
        {
            OperatingSystem os = Environment.OSVersion;
            PlatformID platformId = os.Platform;
            switch (platformId)
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
                    {
                        const string WelcomeLinux = "Welcome to " + Constants.GameName + " for Linux.";
                        Console.WriteLine(WelcomeLinux);
                        break;
                    }

                case PlatformID.MacOSX:
                    {
                        const string WelcomeMac = "Welcome to " + Constants.GameName + " for Mac.";
                        Console.WriteLine(WelcomeMac);
                        break;
                    }

                default:
                    {
                        const string WelcomeAnyOS = "Welcome to " + Constants.GameName + "!";
                        Console.WriteLine(WelcomeAnyOS);
                        break;
                    }
            }
        }

        /// <summary>
        /// Asks for user keypress for start of game.
        /// </summary>
        private static void PressAnyKeyToStart()
        {
            const string AnyKeyStartText = "\nPress any key to start... ";
            Console.Write(AnyKeyStartText);
            Console.ReadKey(intercept: true);
        }

        /// <summary>
        /// Starts a main menu instance.
        /// </summary>
        private static void StartGame() => new MainMenu(firstRun: true);

        /// <summary>
        /// Restores the settings for the console.
        /// </summary>
        private static void RestoreWindowInit()
        {
            Console.BufferWidth = currentBufferWidth;
            Console.BufferHeight = currentBufferHeight;
            Console.WindowWidth = currentWindowWidth;
            Console.WindowHeight = currentWindowHeight;
        }
    }
}

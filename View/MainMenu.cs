﻿/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Krasen Ivanov. All rights reserved.
 *  Licensed under the MIT License. See License.txt in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

namespace SnakeCore.View
{
    using System;
    using SnakeCore.Tools;

    public class MainMenu
    {
        private double difficulty;
        private double changeDifficulty;
        private double worstDifficulty;
        private int appleSpawnTime;
        private bool rocksEnabled;

        /// <summary>
        /// Displays main menu of the game.
        /// </summary>
        /// <param name="firstRun">Given for first startup of the game</param>
        public MainMenu(bool firstRun)
        {
            this.difficulty = Constants.DefaultDifficulty;
            this.changeDifficulty = Constants.DefaultChangeDifficulty;
            this.worstDifficulty = Constants.DefaultWorstDifficulty;
            this.appleSpawnTime = Constants.DefaultAppleSpawnTime;
            this.rocksEnabled = Constants.DefaultRocksEnabled;
            
            this.DrawMainMenu(firstRun);
        }

        public MainMenu(bool firstRun, double difficulty, double changeDifficulty, double worstDifficulty, int appleSpawnTime, bool rocksEnabled)
        {
            this.difficulty = difficulty;
            this.changeDifficulty = changeDifficulty;
            this.worstDifficulty = worstDifficulty;
            this.appleSpawnTime = appleSpawnTime;
            this.rocksEnabled = rocksEnabled;

            this.DrawMainMenu(firstRun);
        }


        /// <summary>
        /// Draws the UI of the main menu and displays current settings.
        /// </summary>
        private void DrawMainMenu(bool firstRun)
        {
            Console.Clear();
            string menuText = "Main menu\n" +
                            "1: New game\n" +
                            "2: Settings\n" +
                            "3: Exit\n\n" +
                            "Current settings: \n" +
                            "Difficulty: {0}, Diff Change: {1},\n" +
                            "Worst Diff: {2}, Apple Spawn Time: {3},\n" +
                            "Rocks Enabled: {4} \n" +
                            "Enter number for selection: ";
            Console.Write(menuText, this.difficulty, this.changeDifficulty, this.worstDifficulty, this.appleSpawnTime, this.rocksEnabled);

            string pickMenuItem = Console.ReadLine();

            switch (pickMenuItem)
            {
                case "1":
                    NewGameMenuItem(firstRun);
                    break;
                case "2":
                    SettingsMenuItem();
                    break;
                case "3":
                    ExitMenuItem();
                    break;
                default:
                    DrawMainMenu(firstRun);
                    break;
            }
        }

        private void NewGameMenuItem(bool firstRun)
        {
            if (firstRun)
            {
                this.DefaultNewGame();
            }
            else
            {
                this.SelectedCustomGame();
            }
        }
        private void SettingsMenuItem()
        {
            this.SettingsMenu();
        }
        private void ExitMenuItem()
        {
            this.DrawGameExitThankYou();
        }


        /// <summary>
        /// Lets the user select game mode.
        /// </summary>
        private void SettingsMenu()
        {
            bool wantToExit = false;

            Console.Clear();
            const string SelectDifficulty = "Select difficulty:\n" +
                "1: Easy\n" +
                "2: Medium\n" +
                "3: Hard\n" +
                "4: Enable/Disable rocks?\n" +
                "5: Exit game\n" +
                "Enter number for selection: ";
            Console.Write(SelectDifficulty);

            string pickDifficilty = Console.ReadLine();

            const string Easy = "1";
            const string Medium = "2";
            const string Hard = "3";
            const string DisableRocks = "4";
            const string Exit = "5";

            if (pickDifficilty.ToUpper() == Easy)
            {
                this.difficulty = 150;
                this.changeDifficulty = 1;
                this.worstDifficulty = 120;
                this.appleSpawnTime = 6000;
            }
            else if (pickDifficilty.ToUpper() == Medium)
            {
                this.difficulty = 120;
                this.changeDifficulty = 1;
                this.worstDifficulty = 70;
                this.appleSpawnTime = 3500;
            }
            else if (pickDifficilty.ToUpper() == Hard)
            {
                this.difficulty = 100;
                this.changeDifficulty = 2;
                this.worstDifficulty = 45;
                this.appleSpawnTime = 1900;
            }
            else if (pickDifficilty.ToUpper() == DisableRocks)
            {
                this.rocksEnabled = !this.rocksEnabled;
            }
            else if (pickDifficilty.ToUpper() == Exit)
            {
                wantToExit = true;
            }
            else
            {
                this.SettingsMenu();
            }

            if (wantToExit)
            {
                this.DrawGameExitThankYou();
            }
            else
            {
                this.DrawMainMenu(false);
            }
        }

        /// <summary>
        /// Starts new game with default settings.
        /// </summary>
        private void DefaultNewGame() => new Game(Constants.DefaultDifficulty, Constants.DefaultChangeDifficulty, Constants.DefaultWorstDifficulty, Constants.DefaultAppleSpawnTime, Constants.DefaultRocksEnabled);
        
        /// <summary>
        /// Starts new game with user selected settings.
        /// </summary>
        private void SelectedCustomGame() => new Game(this.difficulty, this.changeDifficulty, this.worstDifficulty, this.appleSpawnTime, this.rocksEnabled);

        /// <summary>
        /// Displays exit text.
        /// </summary>
        private void DrawGameExitThankYou()
        {
            Console.Clear();
            const string ExitString = "Thank you for playing!\n\nPress any key to exit... ";
            Console.Write(ExitString);
            Console.ReadKey(intercept: true);
            Console.Clear();
        }
    }
}

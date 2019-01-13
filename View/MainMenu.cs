namespace SnakeCore.View
{
    using System;

    public class MainMenu
    {
        public MainMenu()
        {
            this.DrawMainMenu();
        }

        private void DrawMainMenu()
        {
            Console.Clear();
            string menuText = "Main menu\n" +
                "1: New game\n" +
                "2: Settings\n" +
                "3: Exit\n\n" +
                "Current settings: \n" +
                "Enter number for selection: ";
            Console.Write(menuText);

            string pickMenuItem = Console.ReadLine();

            const string NewGame = "1";
            const string Settings = "2";
            const string Exit = "3";
            if (pickMenuItem.ToUpper() == NewGame)
            {
                this.NewGameMenu();
            }
            else if (pickMenuItem.ToUpper() == Settings)
            {
                ////this.customGame = true;
                this.SettingsMenu();
            }
            else if (pickMenuItem.ToUpper() == Exit)
            {
                this.ShowExitString();
            }
            else
            {
                this.DrawMainMenu();
            }
        }

        private void NewGameMenu()
        {
            this.DefaultNewGame();
        }

        private void DefaultNewGame() => new Game();

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
                "4: Exit game\n" +
                "Enter number for selection: ";
            Console.Write(SelectDifficulty);

            string pickDifficilty = Console.ReadLine();

            if (true)
            {
                const string Easy = "1";
                const string Medium = "2";
                const string Hard = "3";
                const string Exit = "4";
                if (pickDifficilty.ToUpper() == Easy)
                {
                    ////this.minLetterLength = 3;
                }
                else if (pickDifficilty.ToUpper() == Medium)
                {
                    ////this.minLetterLength = 4;
                }
                else if (pickDifficilty.ToUpper() == Hard)
                {
                    ////this.minLetterLength = 6;
                }                
                else if (pickDifficilty.ToUpper() == Exit)
                {
                    wantToExit = true;
                }
                else
                {
                    this.SettingsMenu();
                }
            }
            else
            {
                this.SettingsMenu();
            }

            if (wantToExit)
            {
                this.ShowExitString();
            }
            else
            {
                this.DrawMainMenu();
            }
        }

        /// <summary>
        /// Displays exit text.
        /// </summary>
        private void ShowExitString()
        {
            Console.Clear();
            const string ExitString = "Thank you for playing!\n\nPress any key to exit... ";
            Console.Write(ExitString);
            Console.ReadKey(intercept: true);
            Console.Clear();
        }
    }
}

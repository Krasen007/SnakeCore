/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Krasen Ivanov. All rights reserved.
 *  Licensed under the MIT License. See License.txt in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
 
 namespace SnakeCore.Tools
{
    public class Constants
    {
        internal const string GameName = "Snake Core";
        internal const int GameWidth = 50;
        internal const int GameHeight = 25;
        internal const double DefaultDifficulty = 150;
        internal const double DefaultChangeDifficulty = 1;
        internal const double DefaultWorstDifficulty = 50;
        internal const int DefaultAppleSpawnTime = 4000;
        internal const bool DefaultRocksEnabled = true;
        internal const int DefaultSnakeLengthRockSpawn = 6;

        protected Constants()
        {
        }
    }
}

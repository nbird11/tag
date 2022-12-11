using System;
using Microsoft.VisualBasic;
using Tag.Game.Casting;

namespace Tag
{
    /// <summary>
    /// <para> Global constants to be used throughout the program.
    /// </para>
    /// </summary>
    public class Constants
    {
        public static int COLUMNS = 40;
        public static int ROWS = 20;
        public static int CELL_SIZE = 15;
        public static int MAX_X = 900;
        public static int MAX_Y = 600;

        public static int FRAME_RATE = 15;
        public static int FONT_SIZE = 15;
        public static string CAPTION = "Tag";

        public static Color RED = new Color(255, 0, 0);
        public static Color BLUE = new Color(0, 0, 255);
        public static Color WHITE = new Color(255, 255, 255);
        public static Color YELLOW = new Color(255, 255, 0);
        public static Color GREEN = new Color(0, 255, 0);

        // Scripting categories
        public static string INITIALIZE = "initialize";
        public static string INPUT = "input";
        public static string UPDATE = "update";
        public static string OUTPUT = "output";

        // Casting categories
        public static string PLAYER1 = "player1";
        public static string PLAYER2 = "player2";
        public static string MAZE = "maze";
        public static string BLOCK = "block";

        // Boost Constants
        public static string NOBOOST = "none";
        public static string SPEED = "speed";
        public static string FREEZE = "freeze";

    }
}


using System;

namespace Tag.Game.Casting
{
    public class SpeedPowerup : Actor
    {

        // CONSTRUCTOR
        public SpeedPowerup()
        {
            this.SetText("*");
            this.SetFontSize(Constants.FONT_SIZE);
            this.SetColor(Constants.YELLOW);
            this.SetPosition(new Point(Constants.MAX_X / 2, Constants.MAX_Y / 2));
        }

        // METHODS
    }
}
using System;

namespace Tag.Game.Casting
{
    public class SpeedPowerup : Actor
    {

        // CONSTRUCTOR
        public SpeedPowerup(Cast cast)
        {
            SetText("!");
            SetColor(Constants.YELLOW);
            SetPosition(new Point(100,200));
        }

        // METHODS
    }
}
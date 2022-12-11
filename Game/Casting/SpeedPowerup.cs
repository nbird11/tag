using System;

namespace Tag.Game.Casting
{
    public class SpeedPowerup : Actor
    {
        // ATTRIBUTES
        

        // CONSTRUCTOR
        public SpeedPowerup()
        {
            SetText("!");
            SetColor(Constants.YELLOW);
            Reset();
        }

        // METHODS
        public void Reset()
        {
            Random random = new Random();
            int x = random.Next(Constants.COLUMNS);
            int y = random.Next(Constants.ROWS);
            Point position = new Point(x, y);
            position = position.Scale(Constants.CELL_SIZE);
            SetPosition(position);
        }
        

    }
}
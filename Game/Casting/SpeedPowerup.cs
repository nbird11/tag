using System;

namespace Tag.Game.Casting
{
    public class SpeedPowerup : Actor
    {
        // ATTRIBUTES
        

        // CONSTRUCTOR
        public SpeedPowerup(Cast cast)
        {
            SetText("!");
            SetColor(Constants.YELLOW);
            Reset(cast);
        }

        // METHODS
        public void Reset(Cast cast)
        {
            Maze maze = (Maze)cast.GetFirstActor(Constants.MAZE);
            bool foundXSpot = false;
            bool foundYSpot = false;
            int x = 100;
            int y = 200;
            while (!foundXSpot)
            {
                Random random = new Random();
                x = random.Next(Constants.COLUMNS);
                bool mazeSpot = false;
                foreach (Block block in maze._maze)
                {
                    if (x >= block.xCoordinate && x <= (block.xCoordinate + block.length))
                    {
                        mazeSpot = true;
                    }
                }
                if (mazeSpot == false)
                {
                    foundXSpot = true;
                }

            }

            while (!foundYSpot)
            {
                Random random = new Random();
                y = random.Next(Constants.COLUMNS);
                bool mazeSpot = false;
                foreach (Block block in maze._maze)
                {
                    if (y >= block.yCoordinate && y <= (block.yCoordinate + block.height))
                    {
                        mazeSpot = true;
                    }
                }
                if (mazeSpot == false)
                {
                    foundYSpot = true;
                }

            }

            Point position = new Point(x, y);
            position = position.Scale(Constants.CELL_SIZE);
            SetPosition(position);
        }
        

    }
}
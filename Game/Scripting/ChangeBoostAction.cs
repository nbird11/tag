using System;
using Tag.Game.Casting;

namespace Tag.Game.Scripting;

public class ChangeBoostAction : Action
{
    

    public void Execute(Cast cast, Script script)
    {
        Player player1 = (Player)cast.GetFirstActor(Constants.PLAYER1);
        Player player2 = (Player)cast.GetFirstActor(Constants.PLAYER2);
        Actor boost = (Actor)cast.GetFirstActor(Constants.BOOST);
        
    }

    public void CheckPlayerBoostCollision(Cast cast, Player player, Actor boost)
    {
        if ((player.GetPosition().GetX()+Constants.CELL_SIZE/2 >= boost.GetPosition().GetX()
            && player.GetPosition().GetX()+Constants.CELL_SIZE/2 <= boost.GetPosition().GetX()+Constants.CELL_SIZE)
            &&
            (player.GetPosition().GetY()+Constants.CELL_SIZE/2 >= boost.GetPosition().GetY()
            && player.GetPosition().GetY()+Constants.CELL_SIZE/2 <= boost.GetPosition().GetY()+Constants.CELL_SIZE))
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
            boost.SetPosition(position);
            player.SetBoost(Constants.SPEED);
        }

    }
}
using System;
using Tag.Game.Casting;

namespace Tag.Game.Scripting;

public class ChangeBoostAction : Action
{
    private int _speedSeconds = 3;    

    public void Execute(Cast cast, Script script)
    {
        Player player1 = (Player)cast.GetFirstActor(Constants.PLAYER1);
        Player player2 = (Player)cast.GetFirstActor(Constants.PLAYER2);
        Actor boost = (Actor)cast.GetFirstActor(Constants.BOOST);

        CheckBoostCollision(cast, player1, boost);
        CheckBoostCollision(cast, player2, boost);
        
    }

    public void CheckBoostCollision(Cast cast, Player player, Actor boost)
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
            int x = Constants.MAX_X / 2;
            int y = Constants.MAX_Y / 2;
            int safetyCushion = 10;

            while (!foundXSpot)
            {
                Random random = new Random();
                x = random.Next(Constants.MAX_X);
                bool mazeSpot = false;
                foreach (Block block in maze._maze)
                {
                    if (x >= (block.xCoordinate - safetyCushion) && x <= (block.xCoordinate + block.length + safetyCushion))
                    {
                        mazeSpot = true;
                    }
                }
                if (mazeSpot == false)
                {
                    foundXSpot = true;
                    break;
                }
            }

            while (!foundYSpot)
            {
                Random random = new Random();
                y = random.Next(Constants.MAX_Y);
                bool mazeSpot = false;
                foreach (Block block in maze._maze)
                {
                    if (y >= (block.yCoordinate - safetyCushion) && y <= (block.yCoordinate + block.height + safetyCushion))
                    {
                        mazeSpot = true;
                    }
                }

                if (mazeSpot == false)
                {
                    foundYSpot = true;
                    break;
                }

            }

            Point position = new Point(x, y);
            boost.SetPosition(position);
            player.SetBoost(Constants.SPEED);
            player.SetSpeedTime(Constants.FRAME_RATE * _speedSeconds);
        }

    }
}
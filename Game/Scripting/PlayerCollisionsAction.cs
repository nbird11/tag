using Tag.Game.Casting;
using Raylib_cs;

namespace Tag.Game.Scripting
{
    public class PlayerCollisionsAction : Action
    {
        public PlayerCollisionsAction()
        {

        }

        public void Execute(Cast cast, Script script)
        {
            Player player1 = (Player)cast.GetFirstActor(Constants.PLAYER1);
            Player player2 = (Player)cast.GetFirstActor(Constants.PLAYER2);

            if ((player1.GetPosition().GetX()+Constants.CELL_SIZE/2 >= player2.GetPosition().GetX()
                 && player1.GetPosition().GetX()+Constants.CELL_SIZE/2 <= player2.GetPosition().GetX()+Constants.CELL_SIZE)
                ||
                (player1.GetPosition().GetY()+Constants.CELL_SIZE/2 >= player2.GetPosition().GetY()
                 && player1.GetPosition().GetY()+Constants.CELL_SIZE/2 <= player2.GetPosition().GetY()+Constants.CELL_SIZE)
                ||
                (player2.GetPosition().GetX()+Constants.CELL_SIZE/2 >= player1.GetPosition().GetX()
                 && player2.GetPosition().GetX()+Constants.CELL_SIZE/2 <= player1.GetPosition().GetX()+Constants.CELL_SIZE)
                ||
                (player2.GetPosition().GetY()+Constants.CELL_SIZE/2 >= player1.GetPosition().GetY()
                 && player2.GetPosition().GetY()+Constants.CELL_SIZE/2 <= player1.GetPosition().GetY()+Constants.CELL_SIZE)
               )
            {
                if (player1.GetItStatus())
                {
                    player2.SetBoost(Constants.FREEZE);
                }
                else
                {
                    player1.SetBoost(Constants.FREEZE);
                }

            }


        }
    }
}
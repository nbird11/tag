using Tag.Game.Casting;
using Raylib_cs;

namespace Tag.Game.Scripting
{
    public class PlayerCollisionsAction : Action
    {
        private int _freezeSeconds = 2;

        public PlayerCollisionsAction()
        {

        }

        public void Execute(Cast cast, Script script)
        {
            Player player1 = (Player)cast.GetFirstActor(Constants.PLAYER1);
            Player player2 = (Player)cast.GetFirstActor(Constants.PLAYER2);
            if (player1.GetBoost() != Constants.FREEZE && player2.GetBoost() != Constants.FREEZE)
            {
                if ((player1.GetPosition().GetX()+Constants.CELL_SIZE/2 >= player2.GetPosition().GetX()
                    && player1.GetPosition().GetX()+Constants.CELL_SIZE/2 <= player2.GetPosition().GetX()+Constants.CELL_SIZE)
                    &&
                    (player1.GetPosition().GetY()+Constants.CELL_SIZE/2 >= player2.GetPosition().GetY()
                    && player1.GetPosition().GetY()+Constants.CELL_SIZE/2 <= player2.GetPosition().GetY()+Constants.CELL_SIZE)
                    ||
                    (player2.GetPosition().GetX()+Constants.CELL_SIZE/2 >= player1.GetPosition().GetX()
                    && player2.GetPosition().GetX()+Constants.CELL_SIZE/2 <= player1.GetPosition().GetX()+Constants.CELL_SIZE)
                    &&
                    (player2.GetPosition().GetY()+Constants.CELL_SIZE/2 >= player1.GetPosition().GetY()
                    && player2.GetPosition().GetY()+Constants.CELL_SIZE/2 <= player1.GetPosition().GetY()+Constants.CELL_SIZE)
                )
                {
                    if (player1.GetItStatus())
                    {
                        this.FreezePlayer(player2);
                        player2.SetBoost(Constants.FREEZE);
                    }
                    if (player2.GetItStatus())
                    {
                        this.FreezePlayer(player1);
                        player1.SetBoost(Constants.FREEZE);
                    }

                }
            }
        }

        public void FreezePlayer(Player player)
        {
            player.SetFrozenTime(Constants.FRAME_RATE * _freezeSeconds);
        }
    }
}
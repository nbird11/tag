using Tag.Game.Casting;

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
            Actor message = (Actor)cast.GetFirstActor(Constants.MESSAGE);
            Player player1 = (Player)cast.GetFirstActor(Constants.PLAYER1);
            Player player2 = (Player)cast.GetFirstActor(Constants.PLAYER2);
            if (player1.GetBoost() != Constants.FREEZE && player2.GetBoost() != Constants.FREEZE)
            {
                int playerWidth = player1.GetFontSize();
                if ((player1.GetPosition().GetX()+playerWidth/2 >= player2.GetPosition().GetX()
                    && player1.GetPosition().GetX()+playerWidth/2 <= player2.GetPosition().GetX()+playerWidth)
                    &&
                    (player1.GetPosition().GetY()+playerWidth/2 >= player2.GetPosition().GetY()
                    && player1.GetPosition().GetY()+playerWidth/2 <= player2.GetPosition().GetY()+playerWidth)
                    ||
                    (player2.GetPosition().GetX()+playerWidth/2 >= player1.GetPosition().GetX()
                    && player2.GetPosition().GetX()+playerWidth/2 <= player1.GetPosition().GetX()+playerWidth)
                    &&
                    (player2.GetPosition().GetY()+playerWidth/2 >= player1.GetPosition().GetY()
                    && player2.GetPosition().GetY()+playerWidth/2 <= player1.GetPosition().GetY()+playerWidth)
                )
                {
                    if (player1.GetItStatus())
                    {
                        this.FreezePlayer(player2);
                        player2.SetBoost(Constants.FREEZE);
                        message.SetColor(Constants.BLUE);
                        message.SetText("BLUE IS IT!");
                    }
                    if (player2.GetItStatus())
                    {
                        this.FreezePlayer(player1);
                        player1.SetBoost(Constants.FREEZE);
                        message.SetColor(Constants.RED);
                        message.SetText("RED IS IT!");
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
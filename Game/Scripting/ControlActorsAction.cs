using Tag.Game.Casting;
using Tag.Game.Services;
using System.Collections.Generic;


namespace Tag.Game.Scripting
{
    /// <summary>
    /// <para>An input action that controls the cycle.</para>
    /// <para>
    /// The responsibility of ControlActorsAction is to get the direction and move the cycle's head.
    /// </para>
    /// </summary>
    public class ControlActorsAction : Action
    {
        private KeyboardService _keyboardService;
        private Point _direction = new Point(Constants.CELL_SIZE, 0);
        private Point _direction2 = new Point(Constants.CELL_SIZE, 0);

        /// <summary>
        /// Constructs a new instance of ControlActorsAction using the given KeyboardService.
        /// </summary>
        public ControlActorsAction(KeyboardService keyboardService)
        {
            this._keyboardService = keyboardService;
        }

        /// <inheritdoc/>
        public void Execute(Cast cast, Script script)
        {

            List<string> p1Controls = new List<string>() {"a","d","w","s"};
            List<string> p2Controls = new List<string>() {"j","l","i","k"};

            Player player1 = (Player)cast.GetFirstActor(Constants.PLAYER1);
            player1.SetVelocity(new Point(0,0));

            Player player2 = (Player)cast.GetFirstActor(Constants.PLAYER2);
            player2.SetVelocity(new Point(0,0));

            ControlPlayer(player1, player2, p1Controls);
            ControlPlayer(player2, player1, p2Controls);
        }

        public void ControlPlayer(Player player, Player secondaryPlayer, List<string> control)
        {
            int isItSpeed = 2;
            int boostSpeed = 1;

            if (player.GetItStatus() == false)
            {
                isItSpeed = 0;
            }

            if (player.GetBoost() == Constants.SPEED)
            {
                player.SetColor(Constants.YELLOW);
                boostSpeed = 2;
            }

            else if (player.GetBoost() == Constants.FREEZE)
            {
                boostSpeed = 0;
                if (player.GetFrozenTime() <= 0)
                {
                    player.SetBoost(Constants.NOBOOST);
                    player.SetIsIt(true);
                    secondaryPlayer.SetIsIt(false);
                    player.BackToDefaultColor();
                }
                else
                {
                    player.SetColor(Constants.WHITE);
                    player.SetFrozenTime(player.GetFrozenTime() - 1);
                }
            }

            else
            {
                boostSpeed = 1;
                player.BackToDefaultColor();
            }

            //left
            if (_keyboardService.IsKeyDown(control[0]))
            {
                _direction = new Point((-Constants.CELL_SIZE - isItSpeed)*boostSpeed, 0);
                player.SetVelocity(_direction);
            }

            // right
            if (_keyboardService.IsKeyDown(control[1]))
            {
                _direction = new Point((Constants.CELL_SIZE + isItSpeed)*boostSpeed, 0);
                player.SetVelocity(_direction);
            }

            // up
            if (_keyboardService.IsKeyDown(control[2]))
            {
                _direction = new Point(0, (-Constants.CELL_SIZE - isItSpeed)*boostSpeed);
                player.SetVelocity(_direction);
            }

            // down
            if (_keyboardService.IsKeyDown(control[3]))
            {
                _direction = new Point(0, (Constants.CELL_SIZE + isItSpeed)*boostSpeed);
                player.SetVelocity(_direction);
            }
        }
    }
}
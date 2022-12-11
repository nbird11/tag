using Tag.Game.Casting;
using Tag.Game.Services;


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
            int isItSpeed1 = 2;
            int isItSpeed2 = 2;

            Player player1 = (Player)cast.GetFirstActor("player1");
            player1.SetVelocity(new Point(0,0));
            // left
            if (player1.GetBoost() == "none")
            {
                if (player1.GetItStatus() == false)
                {
                    isItSpeed1 = 0;
                }

                if (_keyboardService.IsKeyDown("a"))
                {
                    _direction = new Point(-Constants.CELL_SIZE - isItSpeed1, 0);
                    player1.SetVelocity(_direction);
                }

                // right
                if (_keyboardService.IsKeyDown("d"))
                {
                    _direction = new Point(Constants.CELL_SIZE + isItSpeed1, 0);
                    player1.SetVelocity(_direction);
                }

                // up
                if (_keyboardService.IsKeyDown("w"))
                {
                    _direction = new Point(0, -Constants.CELL_SIZE - isItSpeed1);
                    player1.SetVelocity(_direction);
                }

                // down
                if (_keyboardService.IsKeyDown("s"))
                {
                    _direction = new Point(0, Constants.CELL_SIZE + isItSpeed1);
                    player1.SetVelocity(_direction);
                }
            }

            


            Player player2 = (Player)cast.GetFirstActor("player2");
            player2.SetVelocity(new Point(0,0));
            if (player2.GetBoost() == "none")
            {
                if (player2.GetItStatus() == false)
                {
                    isItSpeed2 = 0;
                }

                // left
                if (_keyboardService.IsKeyDown("j"))
                {
                    _direction2 = new Point(-Constants.CELL_SIZE - isItSpeed2, 0);
                    player2.SetVelocity(_direction2);
                }

                // right
                if (_keyboardService.IsKeyDown("l"))
                {
                    _direction2 = new Point(Constants.CELL_SIZE + isItSpeed2, 0);
                    player2.SetVelocity(_direction2);
                }

                // up
                if (_keyboardService.IsKeyDown("i"))
                {
                    _direction2 = new Point(0, -Constants.CELL_SIZE - isItSpeed2);
                    player2.SetVelocity(_direction2);
                }

                // down
                if (_keyboardService.IsKeyDown("k"))
                {
                    _direction2 = new Point(0, Constants.CELL_SIZE + isItSpeed2);
                    player2.SetVelocity(_direction2);
                }
            }
        }
    }
}
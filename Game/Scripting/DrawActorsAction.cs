using Tag.Game.Casting;
using Tag.Game.Services;


namespace Tag.Game.Scripting
{
    /// <summary>
    /// <para>An output action that draws all the actors.</para>
    /// <para>The responsibility of DrawActorsAction is to draw each of the actors.</para>
    /// </summary>
    public class DrawActorsAction : Action
    {
        private VideoService _videoService;

        /// <summary>
        /// Constructs a new instance of ControlActorsAction using the given KeyboardService.
        /// </summary>
        public DrawActorsAction(VideoService videoService)
        {
            this._videoService = videoService;
        }

        /// <inheritdoc/>
        public void Execute(Cast cast, Script script)
        {
            Player player1 = (Player)cast.GetFirstActor(Constants.PLAYER1);
            Player player2 = (Player)cast.GetFirstActor(Constants.PLAYER2);
            Actor message = (Actor)cast.GetFirstActor(Constants.MESSAGE);
            Actor speedBoost = (Actor)cast.GetFirstActor(Constants.BOOST);
            
            _videoService.ClearBuffer();
            _videoService.DrawActor(player1);
            _videoService.DrawActor(player2);
            _videoService.DrawActor(message);
            _videoService.DrawActor(speedBoost);
            _videoService.FlushBuffer();
        }
    }
}
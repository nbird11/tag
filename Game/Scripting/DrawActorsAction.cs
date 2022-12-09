using System.Collections.Generic;
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
            Player player1 = (Player)cast.GetFirstActor("player1");
            player1.SetText("#");
            player1.SetColor(Constants.BLUE);
            player1.SetPosition(new Point(Constants.MAX_X / 4, Constants.MAX_Y / 2));
            Player player2 = (Player)cast.GetFirstActor("player2");
            player2.SetText("O");
            player2.SetColor(Constants.RED);
            player2.SetPosition(new Point(Constants.MAX_X * 3 / 4, Constants.MAX_Y / 2));


            
            _videoService.ClearBuffer();
            _videoService.DrawActor(player1);
            _videoService.DrawActor(player2);
            // _videoService.DrawActors(segments1);
            // _videoService.DrawActors(segments2);
            // _videoService.DrawActors(messages);
            _videoService.FlushBuffer();
        }
    }
}
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
            
            _videoService.ClearBuffer();
            // _videoService.DrawActors(segments1);
            // _videoService.DrawActors(segments2);
            // _videoService.DrawActors(messages);
            _videoService.FlushBuffer();
        }
    }
}
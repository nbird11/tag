using System.Collections.Generic;
using Tag.Game.Casting;
using Tag.Game.Services;

namespace Tag.Game.Scripting
{
    /// <summary>
    /// <para>An output action that draws all the actors.</para>
    /// <para>The responsibility of DrawActorsAction is to draw each of the actors.</para>
    /// </summary>
    public class DrawBlockAction : Action
    {
        private VideoService _videoService;

        /// <summary>
        /// Constructs a new instance of ControlActorsAction using the given KeyboardService.
        /// </summary>
        public DrawBlockAction(VideoService videoService)
        {
            //this._videoService = videoService;
        }

        /// <inheritdoc/>
        public void Execute(Cast cast, Script script)
        {
            List<List<float>> maze1 = [
            {201.000000, 226.000000, 0.000000, 0.000000},
            {199.000000, 229.000000, 150.394547, 779.317200},
            {499.000000, 235.000000, 111.481277, 291.323700},
            {601.000000, 578.000000, 519.544678, 118.843216},
            {500.000000, 741.000000, 111.481262, 281.858368},
            {1215.000000, 256.000000, 135.670593, 433.304657},
            {1216.000000, 795.000000, 119.894920, 222.962585},
            {1547.000000, 224.000000, 103.067612, 795.092957} ];
            Block block = new Block();
            block.drawblock();
           // _videoService.ClearBuffer();
            // _videoService.DrawActors(segments1);
            // _videoService.DrawActors(segments2);
            // _videoService.DrawActors(messages);
           // _videoService.FlushBuffer();
        }
    }
}
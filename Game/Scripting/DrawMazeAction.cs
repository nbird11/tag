using Tag.Game.Casting;
using Tag.Game.Services;

namespace Tag.Game.Scripting
{
    /// <summary>
    /// <para>An output action that draws all the actors.</para>
    /// <para>The responsibility of DrawActorsAction is to draw each of the actors.</para>
    /// </summary>
    public class DrawMazeAction : Action
    {
        //private VideoService _videoService;

        /// <summary>
        /// Constructs a new instance of ControlActorsAction using the given KeyboardService.
        /// </summary>
        public DrawMazeAction(VideoService videoService)
        {
            //this._videoService = videoService;
        }
        
        public void Execute(Cast cast, Script script)
        {
            Maze maze = (Maze)cast.GetFirstActor(Constants.MAZE);
            maze.DrawMaze();
        }
    }
}
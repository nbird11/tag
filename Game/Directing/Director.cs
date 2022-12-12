using System.Collections.Generic;
using Tag.Game.Services;
using Tag.Game.Casting;
using Tag.Game.Scripting;

namespace Tag.Game.Directing
{
    /// <summary> The responsibility of Director is to direct all of
    /// the actors in their separate functions and behaviors.
    /// <para> Control the sequence of play.
    /// </para>
    /// </summary>
    public class Director
    {
        private VideoService _videoService = null;

        /// <summary>
        /// Constructs a new instance of Director using the given VideoService.
        /// </summary>
        /// <param name="videoService">The given VideoService.</param>
        public Director(VideoService videoService)
        {
            this._videoService = videoService;
        }

        /// <summary>
        /// Starts the game by running the main game loop for the given cast and script.
        /// </summary>
        /// <param name="cast">The given cast.</param>
        /// <param name="script">The given script.</param>
        public void StartGame(Cast cast, Script script)
        {
            _videoService.OpenWindow();
            while (_videoService.IsWindowOpen())
            {
                // These Script Executions happen every tick.
                ExecuteActions(Constants.INITIALIZE, cast, script);
                ExecuteActions(Constants.INPUT, cast, script);
                ExecuteActions(Constants.UPDATE, cast, script);
                ExecuteActions(Constants.OUTPUT, cast, script);
            }
            _videoService.CloseWindow();
        }

        /// <summary>
        /// Calls execute for each action in the given group.
        /// </summary>
        /// <param name="group">The group name.</param>
        /// <param name="cast">The cast of actors.</param>
        /// <param name="script">The script of actions.</param>
        private void ExecuteActions(string group, Cast cast, Script script)
        {
            List<Action> actions = script.GetActions(group);
            foreach(Action action in actions)
            {
                action.Execute(cast, script);
            }
        }
    }
}
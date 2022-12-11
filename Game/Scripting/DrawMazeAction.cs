using System.Collections.Generic;
using Tag.Game.Casting;
using Tag.Game.Services;
using System;


namespace Tag.Game.Scripting
{
    /// <summary>
    /// <para>An output action that draws all the actors.</para>
    /// <para>The responsibility of DrawActorsAction is to draw each of the actors.</para>
    /// </summary>
    public class DrawMazeAction : Action
    {
        private VideoService _videoService;

        /// <summary>
        /// Constructs a new instance of ControlActorsAction using the given KeyboardService.
        /// </summary>
        public DrawMazeAction(VideoService videoService)
        {
            //this._videoService = videoService;
        }

        //List<Block> maze1 = new List<Block>();
        List<List<float>> obstacleList = new List<List<float>>()
        {
            
             new List<float> {201.000000f, 226.000000f, 100.000000f, 100.000000f},
             new List<float> {199.000000f, 229.000000f, 150.394547f, 779.317200f},
             new List<float> {499.000000f, 235.000000f, 111.481277f, 291.323700f},
             

        };
        
        public void Execute(Cast cast, Script script)
        {
            Maze maze = new Maze();
            maze.CreateMaze(obstacleList);
            maze.DrawMaze();
        }
    }
}
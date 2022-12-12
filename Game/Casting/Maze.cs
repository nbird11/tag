using System.Collections.Generic;
using static Raylib_cs.Raylib;
using static Raylib_cs.Color;

namespace Tag.Game.Casting
{
    /// <summary>
    /// <para>A thing that participates in the game.</para>
    /// <para>
    /// The responsibility of Actor is to keep track of its appearance, position and velocity in 2d 
    /// space.
    /// </para>
    /// </summary>
    public class Maze : Actor
    {
        public List<Block> _maze = new List<Block>();

        public Maze(List<List<float>> obstacleList)
        {
            foreach(List<float> obstacle in obstacleList)
            {
                Block block = new Block();
                block.CreateBlock(obstacle);
                _maze.Add(block);
            }
        }

        public void DrawMaze()
        {
            foreach(Block block in _maze)
            {
                BeginDrawing();
                DrawRectangle((int) block.xCoordinate, (int) block.yCoordinate, (int) block.length, (int) block.height, DARKGREEN);

            }
        }
    }
}

    
using System;
using System.Collections.Generic;
using static Raylib_cs.Raylib;
using Raylib_cs;
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
        //attributes
        public List<Block> maze = new List<Block>();
    
        


        //Methods

        public List<Block> CreateMaze(List<List<float>> obstacleList, Cast cast)
        {
            foreach(List<float> obstacle in obstacleList)
            {
                Block block = new Block();
                block.CreateBlock(obstacle);
                maze.Add(block);
                
                
                

            }
            cast.AddActor(Constants.MAZE, maze);
            return maze;
        }

        public void DrawMaze()
        {
            foreach(Block block in maze)
            {
                BeginDrawing();
                DrawRectangle((int) block.xCoordinate, (int) block.yCoordinate, (int) block.width, (int) block.length, WHITE);

            }
        }

        //
            
        }




        
        }

    
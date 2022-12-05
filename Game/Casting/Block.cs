using System;
using Raylib_cs;
using System.Collections.Generic;

namespace Tag.Game.Casting
{
    public class Block : Actor
    {
        // ATTRIBUTES
        // private Point _oldPos = new Point(0, 0);
        // private Point _size = new Point(0, 0);

        public float xCoordinate = 0;
        public float yCoordinate = 0;
        public float length = 0;
        public float width = 0;
        public List<Block> maze;


        

        // CONTRUCTOR
        public Block()
        {
            
        }



        // METHODS
        public void drawblock()
        {
            //TODO add the raylib draw rectangle function

        }

        public void createBlockList(List<List<float>> obstacleList)
        {
            foreach(List<float> obstacle in obstacleList)
            {
                Block block = new Block();
                SetxCoordinate(obstacle[0]);
                Setycoordinate(obstacle[1]);
                Setlength(obstacle[2]);
                SetWidth(obstacle[3]);
                maze.Add(block);


            }
        }

        public void SetxCoordinate(float xCoordinate)
        {
            this.xCoordinate = xCoordinate;
        }

        public void Setycoordinate(float yCoordinate)
        {
            this.yCoordinate = yCoordinate;
        }

        public void Setlength(float length)
        {
            this.length = length;
        }

        public void SetWidth(float width)
        {
            this.width = width;
        }



        

    }



}
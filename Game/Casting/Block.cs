using System;
using Raylib_cs;
using System.Collections.Generic;
using static Raylib_cs.Raylib;
using static Raylib_cs.Color;



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

        public Color color1 = new Color(5,5,5);


        

        // CONTRUCTOR
        public Block()
        {
            // xCoordinate = x;
            // yCoordinate = y;
            // length = width;
            // width = height;
            // return;
        }



        // METHODS
        public void drawblock(List<Block> maze)
        {
            //TODO add the raylib draw rectangle function
            foreach(Block block in maze)
            {
                length = block.length;
                xCoordinate = block.xCoordinate;
                yCoordinate = block.yCoordinate;
                width = block.width;
            
            
                Raylib.DrawRectangle((int) xCoordinate, (int) yCoordinate, (int) width, (int) length, color1.useRaylib());
                // Raylib.DrawRectangle((int) xCoordinate, (int) yCoordinate, (int) width, (int) length, color1);
            }

        }

        public List<Block> createBlockList(List<List<float>> obstacleList)
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
            return maze;
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
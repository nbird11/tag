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
        public float height = 0;
        public float length = 0;
        

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
        public void CreateBlock(List<float> obstacle)
        {
            xCoordinate = obstacle[0];
            yCoordinate =obstacle[1];
            length = obstacle[2];
            height = obstacle[3];
            
            

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
            this.height = length;
        }

        public void SetWidth(float width)
        {
            this.length = width;
        }



        

    }



}
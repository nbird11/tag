using System;
using Raylib_cs;

namespace Tag.Game.Casting
{
    public class Player : Actor
    {
        // ATTRIBUTES
        private Point _oldPos;
        private Point _size = new Point(0, 0);
        // CONTRUCTOR
        public Player()
        {
            _oldPos = this.GetPosition();
            return;
        }

        // METHODS
        public Point getSize(){
            return _size;
        }

        public Point getOldPos(){
            return _oldPos;
        }

    }



}
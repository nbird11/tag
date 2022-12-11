using System;
using Raylib_cs;


namespace Tag.Game.Casting
{
    public class Player : Actor
    // The role of the player is the same as Actor (velocity, position, appearance) as well as boost state.
    {
        // ATTRIBUTES
        private Point _oldPos;
        private Point _size = new Point(Constants.CELL_SIZE, Constants.CELL_SIZE);
        private string _boost;
        private bool _isIt;
        private int _frozenTime;

        // CONTRUCTOR
        public Player(Point start, Color color, bool itOrNot)
        {
            this.SetVelocity(new Point(0,0));
            this.SetColor(color);
            this.SetPosition(start);
            this.SetText("O");
            this._isIt = itOrNot;
            this._frozenTime = 0;

            _boost = "none"; // "none" "speed" or "freeze"
            _oldPos = this.GetPosition();
            return;
        }

        // METHODS
        public Point getSize()
        {
            return _size;
        }

        public Point getOldPos()
        {
            return _oldPos;
        }

        public void setOldPos(Point position){
            this._oldPos = position;
        }

        public void SetBoost(string boostType)
        {
            _boost = boostType;
        }

        public string GetBoost()
        {
            return _boost;
        }

        public void SetIsIt(bool setIt)
        {
            _isIt = setIt;
        }

        public bool GetItStatus()
        {
            return _isIt;
        }

        public int GetFrozenTime()
        {
            return _frozenTime;
        }

        public void SetFrozenTime(int ticks)
        {
            _frozenTime = ticks;
        }

    }



}
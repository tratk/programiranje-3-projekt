using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tocke
{
    public struct Tocka
    {
        private float _x;
        private float _y;
        private int _stevka;
        public float x { 
            get{ return _x; }
            set { _x = value; }
        }
        public float y { 
            get { return _y; }
            set { _y = value; }
        }
        public int stevka
        {
            get { return _stevka; }
            set { _y = value; }
        }

        public Tocka(float x, float y)
        {
            this._x = x;
            this._y = y;
            this._stevka = 0;
        }

        public Tocka(float x, float y, int st)
        {
            this._x = x;
            this._y = y;
            this._stevka = st;
        }

        public override string ToString()
        {
            return $"x: {this._x}, y: {this._y}, stevka: {this._stevka}";
        }

        public override bool Equals(object obj)
        {
            if (obj is Tocka)
            {
                Tocka p = (Tocka)obj;
                return this._x == p.x && this._y == p.y;
            }
            else
            {
                return false;
            }
        }

        public static bool operator < (Tocka p1, Tocka p2)
        {
            if (p1.y == p2.y)
            {
                return p1.x < p2.x;
            }
            return p1.y < p2.y;
        }

        public static bool operator > (Tocka p1, Tocka p2)
        {
            if (p1.y == p2.y)
            {
                return p1.x > p2.x;
            }
            return p1.y > p2.y;
        }

        public static bool operator == (Tocka p1, Tocka p2)
        {
            return p1.Equals(p2);
        }

        public static bool operator != (Tocka p1, Tocka p2)
        {
            return !p1.Equals(p2);
        }
    }
}

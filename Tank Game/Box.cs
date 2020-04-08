using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathClasses;
using rl = Raylib;
using static Raylib.Raylib;

namespace Tank_Game
{
    class Box
    {
        public Vector2 min;
        public Vector2 max;

        public Box()
        {
            min = new Vector2();
            max = new Vector2();
        }

        public Box(Vector2 _min, Vector2 _max)
        {
            min = _min;
            max = _max;
        }

        public Vector2 Center()
        {
            return (min + max) * 0.5f;
        }

        public bool Overlaps(Vector2 p)
        {
            return !(p.x < min.x || p.y < min.y || p.x > max.x || p.x > max.y);
        }

        public bool Overlaps(Box other)
        {
            return !(max.x < other.min.x || max.y < other.min.y || min.x > other.max.x || min.y > other.max.y);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathClasses
{
    class Vector2
    {
        public float x, y;

        public Vector2()
        {
            x = 0;
            y = 0;
        }

        public Vector2(float _x, float _y)
        {
            x = _x;
            y = _y;
        }

        public static Vector2 operator +(Vector2 v1, Vector2 v2)
        {
            return new Vector2(v1.x + v2.x, v1.y + v2.y);
        }

        public static Vector2 operator -(Vector2 v1, Vector2 v2)
        {
            return new Vector2(v1.x - v2.x, v1.y - v2.y);
        }

        public static Vector2 operator *(Vector2 v, float f)
        {
            return new Vector2(v.x * f, v.y * f);
        }

        public static Vector2 operator *(float f, Vector2 v)
        {
            return new Vector2(v.x * f, v.y * f);
        }

        public float Dot(Vector2 other)
        {
            return x * other.x + y * other.y;
        }

        public float Magnitude()
        {
            return (float)Math.Sqrt(x * x + y * y);
        }

        public void Normalize()
        {
            float m = Magnitude();
            x /= m;
            y /= m;
        }
    }
}

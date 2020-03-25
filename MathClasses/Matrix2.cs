using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathClasses
{
    public class Matrix2
    {
        public float m1, m2, m3, m4;

        public Matrix2()
        {
            m1 = 1; m2 = 0;
            m3 = 0; m4 = 1;
        }

        public Matrix2(float _m1, float _m2, float _m3, float _m4)
        {
            m1 = _m1; m2 = _m2;
            m3 = _m3; m4 = _m4;
        }

        public static Matrix2 operator *(Matrix2 ml, Matrix2 mr)
        {
            return new Matrix2(ml.m1 * mr.m1 + ml.m2 * mr.m3, ml.m1 * mr.m2 + ml.m2 * mr.m4,
                               ml.m3 * mr.m1 + ml.m4 * mr.m3, ml.m3 * mr.m2 + ml.m4 * mr.m4);
        }

        public static Vector2 operator *(Matrix2 m, Vector2 v)
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathClasses
{
    public class Matrix3
    {
        public float m1, m2, m3, m4, m5, m6, m7, m8, m9;

        public Matrix3()
        {
            m1 = 1; m2 = 0; m3 = 0;
            m4 = 0; m5 = 1; m6 = 0;
            m7 = 0; m8 = 0; m9 = 1;
        }

        public Matrix3(float _m1, float _m2, float _m3, float _m4, float _m5, float _m6, float _m7, float _m8, float _m9)
        {
            m1 = _m1; m2 = _m2; m3 = _m3;
            m4 = _m4; m5 = _m5; m6 = _m6;
            m7 = _m7; m8 = _m8; m9 = _m9;
        }

        public static Matrix3 operator *(Matrix3 ml, Matrix3 mr)
        {
            return new Matrix3(ml.m1 * mr.m1 + ml.m2 * mr.m4 + ml.m3 * mr.m7, ml.m1 * mr.m2 + ml.m2 * mr.m5 + ml.m3 * mr.m8, ml.m1 * mr.m3 + ml.m2 * mr.m6 + ml.m3 * mr.m9,
                               ml.m4 * mr.m1 + ml.m5 * mr.m3 + ml.m6 * mr.m7, ml.m2 * mr.m4 + ml.m5 * mr.m5 + ml.m8 * mr.m6, ml.m4 * mr.m3 + ml.m5 * mr.m6 + ml.m6 * mr.m9,
                               ml.m7 * mr.m1 + ml.m8 * mr.m4 + ml.m9 * mr.m7, ml.m8 * mr.m2 + ml.m8 * mr.m5 + ml.m9 * mr.m6, ml.m7 * mr.m3 + ml.m6 * mr.m8 + ml.m9 * mr.m9);
        }

        public static Vector3 operator *(Matrix3 m, Vector3 v)
        {
            return new Vector3(m.m1 * v.x + m.m4 * v.y + m.m7 * v.z,
                               m.m2 * v.x + m.m5 * v.y + m.m8 * v.z,
                               m.m3 * v.x + m.m6 * v.y + m.m9 * v.z);
        }

        public void Set(float _m1, float _m2, float _m3, float _m4, float _m5, float _m6, float _m7, float _m8, float _m9)
        {
            m1 = _m1; m2 = _m2; m3 = _m3;
            m4 = _m4; m5 = _m5; m6 = _m6;
            m7 = _m7; m8 = _m8; m9 = _m9;
        }

        public void SetRotateX(float radians)
        {
            Set(1, 0, 0,
                0, (float)Math.Cos(radians), (float)Math.Sin(radians),
                0, (float)-Math.Sin(radians), (float)Math.Cos(radians));
        }

        public void SetRotateY(float radians)
        {
            Set((float)Math.Cos(radians), 0, (float)-Math.Sin(radians),
                0, 1, 0,
                (float)Math.Sin(radians), 0, (float)Math.Cos(radians));
        }

        public void SetRotateZ(float radians)
        {
            Set((float)Math.Cos(radians), (float)Math.Sin(radians), 0,
                (float)-Math.Sin(radians), (float)Math.Cos(radians), 0,
                0, 0, 1);
        }
        
        public Matrix3 GetTranspose()
        {
            return new Matrix3(m1, m4, m7, m2, m5, m8, m3, m6, m9);
        }
    }
}
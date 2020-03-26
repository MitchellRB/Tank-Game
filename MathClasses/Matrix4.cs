using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathClasses
{
    public class Matrix4
    {
        public float m1, m2, m3, m4, m5, m6, m7, m8, m9, m10, m11, m12, m13, m14, m15, m16;

        public Matrix4()
        {
            m1 = 1; m2 = 0; m3 = 0; m4 = 0;
            m5 = 0; m6 = 1; m7 = 0; m8 = 0;
            m9 = 0; m10= 0; m11= 1; m12= 0;
            m13= 0; m14= 0; m15= 0; m16= 1;
        }

        public Matrix4(float _m1, float _m2, float _m3, float _m4, float _m5, float _m6, float _m7, float _m8, float _m9, float _m10, float _m11, float _m12, float _m13, float _m14, float _m15, float _m16)
        {
            m1 = _m1; m2 = _m2; m3 = _m3; m4 = _m4;
            m5 = _m5; m6 = _m6; m7 = _m7; m8 = _m8;
            m9 = _m9; m10= _m10; m11= _m11; m12= _m12;
            m13= _m13; m14= _m14; m15= _m15; m16= _m16;
        }

        public static Matrix4 operator *(Matrix4 ml, Matrix4 mr)
        {
            return new Matrix4(ml.m1 * mr.m1 + ml.m2 * mr.m5 + ml.m3 * mr.m9 + ml.m4 * mr.m13, ml.m1 * mr.m2 + ml.m2 * mr.m6 + ml.m3 * mr.m10 + ml.m4 * mr.m14, ml.m1 * mr.m3 + ml.m2 * mr.m7 + ml.m3 * mr.m11 + ml.m4 * mr.m15, ml.m1 * mr.m4 + ml.m2 * mr.m8 + ml.m3 * mr.m12 + ml.m4 * mr.m16,
                               ml.m5 * mr.m1 + ml.m6 * mr.m5 + ml.m7 * mr.m9 + ml.m8 * mr.m13, ml.m5 * mr.m2 + ml.m6 * mr.m6 + ml.m7 * mr.m10 + ml.m8 * mr.m14, ml.m5 * mr.m3 + ml.m6 * mr.m7 + ml.m7 * mr.m11 + ml.m8 * mr.m15, ml.m5 * mr.m4 + ml.m6 * mr.m8 + ml.m7 * mr.m12 + ml.m8 * mr.m16,
                               ml.m9 * mr.m1 + ml.m10 * mr.m5 + ml.m11 * mr.m9 + ml.m12 * mr.m13, ml.m9 * mr.m2 + ml.m10 * mr.m6 + ml.m11 * mr.m10 + ml.m12 * mr.m14, ml.m9 * mr.m3 + ml.m10 * mr.m7 + ml.m11 * mr.m11 + ml.m12 * mr.m15, ml.m9 * mr.m4 + ml.m10 * mr.m8 + ml.m11 * mr.m12 + ml.m12 * mr.m16,
                               ml.m13 * mr.m1 + ml.m14 * mr.m5 + ml.m15 * mr.m9 + ml.m16 * mr.m13, ml.m13 * mr.m2 + ml.m14 * mr.m6 + ml.m15 * mr.m10 + ml.m16 * mr.m14, ml.m13 * mr.m3 + ml.m14 * mr.m7 + ml.m15 * mr.m11 + ml.m16 * mr.m15, ml.m13 * mr.m4 + ml.m14 * mr.m8 + ml.m15 * mr.m12 + ml.m16 * mr.m16);
        }

        public static Vector4 operator *(Matrix4 m, Vector4 v)
        {
            return new Vector4(m.m1 * v.x + m.m5 * v.y + m.m9 * v.z + m.m13 * v.w,
                               m.m2 * v.x + m.m6 * v.y + m.m10 * v.z + m.m14 * v.w,
                               m.m3 * v.x + m.m7 * v.y + m.m11 * v.z + m.m15 * v.w,
                               m.m4 * v.x + m.m8 * v.y + m.m12 * v.z + m.m16 * v.w);
        }

        public void Set(float _m1, float _m2, float _m3, float _m4, float _m5, float _m6, float _m7, float _m8, float _m9, float _m10, float _m11, float _m12, float _m13, float _m14, float _m15, float _m16)
        {
            m1 = _m1; m2 = _m2; m3 = _m3; m4 = _m4;
            m5 = _m5; m6 = _m6; m7 = _m7; m8 = _m8;
            m9 = _m9; m10 = _m10; m11 = _m11; m12 = _m12;
            m13 = _m13; m14 = _m14; m15 = _m15; m16 = _m16;
        }

        public void SetRotateX(float radians)
        {
            Set(1, 0, 0, 0,
                0, (float)Math.Cos(radians), (float)Math.Sin(radians), 0,
                0, (float)-Math.Sin(radians), (float)Math.Cos(radians), 0,
                0, 0, 0, 1);
        }

        public void SetRotateY(float radians)
        {
            Set((float)Math.Cos(radians), 0, (float)-Math.Sin(radians), 0,
                0, 1, 0, 0,
                (float)Math.Sin(radians), 0, (float)Math.Cos(radians), 0,
                0, 0, 0, 1);
        }

        public void SetRotateZ(float radians)
        {
            Set((float)Math.Cos(radians), (float)Math.Sin(radians), 0, 0,
                (float)-Math.Sin(radians), (float)Math.Cos(radians), 0, 0,
                0, 0, 1, 0,
                0, 0, 0, 1);
        }

        public Matrix4 GetTranspose()
        {
            return new Matrix4(m1, m5, m9, m13, m2, m6, m10, m14, m3, m7, m11, m15, m4, m8, m12, m16);
        }
    }
}

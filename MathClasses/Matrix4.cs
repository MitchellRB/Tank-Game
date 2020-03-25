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

        public static Matrix4 operator *(Matrix4 m1, Matrix4 m2)
        {
            throw new NotImplementedException();
        }

        public static Vector4 operator *(Matrix4 m, Vector4 v)
        {
            throw new NotImplementedException();
        }

        public void SetRotateX(float x)
        {
            throw new NotImplementedException();
        }

        public void SetRotateY(float y)
        {
            throw new NotImplementedException();
        }

        public void SetRotateZ(float z)
        {
            throw new NotImplementedException();
        }

        public void SetRotateW(float w)
        {
            throw new NotImplementedException();
        }
    }
}

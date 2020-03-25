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

        public static Matrix3 operator *(Matrix3 m1, Matrix3 m2)
        {
            throw new NotImplementedException();
        }

        public static Vector3 operator *(Matrix3 m, Vector3 v)
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

    }
}
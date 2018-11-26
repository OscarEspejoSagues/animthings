using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//la inversa de un quaternion es el conjugado
//w=cos(alfa/2) x,y,z = sin(alfa/2)



namespace Assets.Scripts
{
    public class MyQuaternion
    {
        private float W;
        private float X;
        private float Y;
        private float Z;

        public void Constructor(float _w, float _x, float _y, float _z)
        {
            W = _w;
            X = _x;
            Y = _y;
            Z = _z;
        }

        public void Destructor()
        {

        }

        //https://www.mathworks.com/help/aeroblks/quaternionnormalize.html
        public MyQuaternion Normalize(MyQuaternion _A)
        {
            MyQuaternion Result = _A;
            float total = Mathf.Pow(Result.W, 2) + Mathf.Pow(Result.X, 2) + Mathf.Pow(Result.Y, 2) + Mathf.Pow(Result.Z, 2);
            Result.W /= Mathf.Sqrt(total);
            Result.X /= Mathf.Sqrt(total);
            Result.Y /= Mathf.Sqrt(total);
            Result.Z /= Mathf.Sqrt(total);
            return Result;
        }

        public MyQuaternion Multiply(MyQuaternion _A, MyQuaternion _B)
        {

            MyQuaternion result = _A;
            result.W = _A.W * _B.X - _A.X * _B.X - _A.Y * _B.Y - _A.Z * _B.Z;
            result.X = _A.W * _B.X + _A.X * _B.W - _A.Y * _B.Z + _A.Z * _B.Y;
            result.Y = _A.W * _B.Y + _A.X * _B.Z + _A.Y * _B.W - _A.Z * _B.X;
            result.Z = _A.W * _B.Z - _A.X * _B.Y + _A.Y * _B.X + _A.Z * _B.W;
            return result;
        }

        //https://www.mathworks.com/help/aeroblks/quaternioninverse.html

        public MyQuaternion InvertQuat(MyQuaternion _A)
        {
            MyQuaternion Inverted = _A;
            float totaldiv = Mathf.Pow(Inverted.W, 2) + Mathf.Pow(Inverted.X, 2) + Mathf.Pow(Inverted.Y, 2) + Mathf.Pow(Inverted.Z, 2);
            Inverted.W = Inverted.W / totaldiv;
            Inverted.X = -(Inverted.X / totaldiv);
            Inverted.Y = -(Inverted.Y / totaldiv);
            Inverted.Z = -(Inverted.Y / totaldiv);
            return Inverted;
        }

        //http://www.euclideanspace.com/maths/geometry/rotations/conversions/quaternionToAngle/

        public MyQuaternion ConverFromAxisAngle(MyQuaternion _A)
        {
            MyQuaternion Result = _A;
            if (Result.W > 1) _A.Normalize(Result);
            float angle = 2 * Mathf.Acos(Result.W);
            float s = Mathf.Acos(1 - Result.W * Result.W);
            if (s < 0.01f)
            {
                Result.X = _A.X;
                Result.Y = _A.Y;
                Result.Z = _A.Z;
            }
            else
            {
                Result.X = _A.X / s;
                Result.Y = _A.Y / s;
                Result.Z = _A.Z / s;
            }
            return Result;
        }

        //http://www.euclideanspace.com/maths/geometry/rotations/conversions/angleToQuaternion/index.htm
        public MyQuaternion ConvertToAxisAngle(MyQuaternion _A, float _ALFA)
        {
            MyQuaternion Result = _A;
            Result.W = Mathf.Cos(_ALFA / 2);//definicion del angulo teta
            Result.X = Result.X * Mathf.Sin(_ALFA / 2);
            Result.Y = Result.Y * Mathf.Sin(_ALFA / 2);
            Result.Z = Result.Z * Mathf.Sin(_ALFA / 2);
            Result.Normalize(Result);
            return Result;
        }



    }
}

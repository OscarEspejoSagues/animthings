using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestQuaternion : MonoBehaviour {
    public class MyQuaternion
    {
        public float W;
        public float X;
        public float Y;
        public float Z;

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
        public void Normalize() //THIS IS FINE WORKS
        {
            float total = Mathf.Pow(W, 2) + Mathf.Pow(X, 2) + Mathf.Pow(Y, 2) + Mathf.Pow(Z, 2);
            W /= Mathf.Sqrt(total);
            X /= Mathf.Sqrt(total);
            Y /= Mathf.Sqrt(total);
            Z /= Mathf.Sqrt(total);
        }

        public void Multiply(MyQuaternion _B) //THIS IS FINE WORKS
        {
            float w = W * _B.W - (X * _B.X + Y * _B.Y + Z * _B.Z);
            //
            float x = W * _B.X + X * _B.W + Y * _B.Z - Z * _B.Y;
            float y = W * _B.Y + Y * _B.W + Z * _B.X - X * _B.Z;
            float z = W * _B.Z + Z * _B.W + X * _B.Y - Y * _B.X;

            W = w;
            X = x;
            Y = y;
            Z = z;
        }

        //https://www.mathworks.com/help/aeroblks/quaternioninverse.html

        public void InvertQuat() //Check
        {
            /*float totaldiv = Mathf.Pow(Inverted.W, 2) + Mathf.Pow(Inverted.X, 2) + Mathf.Pow(Inverted.Y, 2) + Mathf.Pow(Inverted.Z, 2);
            Inverted.W = Inverted.W / totaldiv;
            Inverted.X = -(Inverted.X / totaldiv);
            Inverted.Y = -(Inverted.Y / totaldiv);
            Inverted.Z = -(Inverted.Y / totaldiv);*/
            float total = Mathf.Sqrt(W*W + X*X + Y*Y + Z*Z);
            if (total == 0)
                total = 1;

            float recip = 1 / total;

            W = W * recip;
            X = -X * recip;
            Y = -Y * recip;
            Z = -Z * recip;

        }

        public void QuaternionFromAxis(float ALFA, Vector3 Axis) //Check negative on Y
        {
            float constant = 0;
            float angle=0;
            float value = Mathf.Sqrt(Axis.x * Axis.x + Axis.y * Axis.y + Axis.z * Axis.z);
            if (Mathf.Abs(value)>float.MinValue)
            {
                constant = 1.0f / value;
                Axis.x *= constant;
                Axis.y *= constant;
                Axis.z *= constant;
                angle = 0.5f * (ALFA*Mathf.Deg2Rad);
                value = Mathf.Sin(angle);
                X = value * Axis.x;
                Y = value * Axis.y;
                Z = value * Axis.z;
                W = Mathf.Cos(angle);
            }
            else
            {
                X = 0.0f;
                Y = 0.0f;
                Z = 0.0f;
                W = 1.0f;
            }
            Normalize();
        }



        //http://www.euclideanspace.com/maths/geometry/rotations/conversions/quaternionToAngle/

        public float ConverFromAxisAngleANGLE()
        {
            if (W > 1)
            {
                Normalize();
            }
            float angle = 2 * Mathf.Acos(W);
            return angle;
        }

        /*
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
        }*/
    }

    // Use this for initialization
    void Start () {
        Quaternion X;
        MyQuaternion J = new MyQuaternion();
        X.w = 8;
        X.x = 2;
        X.y = 3;
        X.z = 4;
        J.Constructor(X.w, X.x, X.y, X.z);
        float heck = 0.0f;
        Vector3 maroast = Vector3.zero;
        X.ToAngleAxis(out heck, out maroast);
        float gocommitnofeelingsogood = J.ConverFromAxisAngleANGLE();
        Debug.Log(heck);
        Debug.Log(gocommitnofeelingsogood);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}

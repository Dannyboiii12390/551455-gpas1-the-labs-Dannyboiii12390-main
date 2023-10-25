
using System;
using System.Collections.Generic;

namespace MatrixVectorNamespace
{
    public class MyVector
    {
        public float X;
        public float Y;
        public float Z;
        public float W;
        public MyVector(float pX, float pY, float pZ, float pW = 1)
        {
            X = pX;
            Y = pY;
            Z = pZ;
            W = pW;
        }
        
        public MyVector Copy()
        {
            return new MyVector(X, Y, Z, W);
        }

        public MyVector Add(MyVector pMyVector)
        {
            return new MyVector(X + pMyVector.X, Y + pMyVector.Y, Z + pMyVector.Z, W + pMyVector.W);
        }

        public MyVector Subtract(MyVector pMyVector)
        {
            return new MyVector(X - pMyVector.X, Y - pMyVector.Y, Z - pMyVector.Z, W - pMyVector.W);
        }

        public MyVector Multiply(float pScalar)
        {
            return new MyVector(X * pScalar, Y * pScalar, Z * pScalar, W * pScalar);
        }

        public MyVector Divide(float pScalar)
        {
            return Multiply((1 / pScalar));
        }

        public float Magnitude()
        {
            float Xmag = X * X;
            float Ymag = Y * Y;
            float Zmag = Z * Z;
            float Wmag = W * W;
            float totMag = Xmag + Ymag + Zmag + Wmag;

            return (float)((int)Math.Sqrt(totMag));
        }

        public MyVector Normalise()
        {
            float Mag = Magnitude();
            float Xunit = X / Mag;
            float Yunit = Y / Mag;
            float Zunit = Z / Mag;
            float Wunit = W / Mag;

            return new MyVector(Xunit, Yunit, Zunit, Wunit);
        }

        public float DotProduct(MyVector pMyVector)
        {
            float XDot = X * pMyVector.X;
            float YDot = Y * pMyVector.Y;
            float ZDot = Z * pMyVector.Z;

            float DotTot = XDot + YDot + ZDot;

            return DotTot;
        }

        public MyVector RotateX(float pRadians)
        {
            float yDash = (float)(-Math.Sin(pRadians) * Z + Math.Cos(pRadians) * Y);
            float zDash = (float)(Math.Sin(pRadians) * Y + Math.Cos(pRadians) * Z);

            return new MyVector(X, yDash, zDash, W);
        }

        public MyVector RotateY(float pRadians)
        {
            float xDash = (float)Math.Cos(pRadians) * X + (float)Math.Sin(pRadians) * Z;
            float zDash = (float)-Math.Sin(pRadians) * X + (float)Math.Cos(pRadians) * Z;
            MyVector v = new MyVector(xDash, Y, zDash);

            return v;
        }

        public MyVector RotateZ(float pRadians)
        {
            float xDash = (float)(Math.Cos(pRadians) * X + (float)-Math.Sin(pRadians) * Y);
            float yDash = (float)(Math.Sin(pRadians) * X + (float)Math.Cos(pRadians) * Y);

            MyVector v = new MyVector(xDash, yDash, Z, W);

            return v;
        }

        public MyVector LimitTo(float pMax)
        {
            MyVector v;
            if (Magnitude() >= pMax)
            {
                MyVector vUnit = Normalise();

                v = vUnit.Copy();
                v = v.Multiply(pMax);
            }
            else
            {
                v = this.Copy();
            }


            return v;
        }

        public MyVector Interpolate(MyVector pMyVector, float pInterpolation)
        {
            /*
             *Interpolate method – your MyVector object should have a ‘Interpolate’ method 
             *that takes a single MyVector object and a single scalar float number as its parameter. 
             *The method should return a newly constructed MyVector object that is the result of interpolating between the 
             *‘this’ MyVector and the parameter MyVector by the parameter scalar float value.
             */
            float interpolatedX = X + (pMyVector.X - X) * pInterpolation;
            float interpolatedY = Y + (pMyVector.Y - Y) * pInterpolation;
            float interpolatedZ = Z + (pMyVector.Z - Z) * pInterpolation;
            float interpolatedW = W + (pMyVector.W - W) * pInterpolation;

            // Create a new MyVector object with the interpolated values
            MyVector interpolatedMyVector = new MyVector(interpolatedX, interpolatedY, interpolatedZ, interpolatedW);

            return interpolatedMyVector;

        }

        public float AngleBetween(MyVector pMyVector)
        {
            float dot = this.DotProduct(pMyVector);
            float Amag = this.Magnitude();
            float Bmag = this.Magnitude();

            float theta = (float)Math.Acos(dot / (Amag * Bmag));

            return theta;
        }

        public MyVector CrossProduct(MyVector pMyVector)
        {
            /*
             * Cross Product method – your MyVector object should have an ‘CrossProduct’ method that takes a single MyVector object as its parameter. 
             * The method should return a MyVector object that is the cross product between the ‘this’ MyVector and the parameter MyVector. 
             * This MyVector result will be perpendicular to the plane formed by the other two MyVectors.
             */
            float resultX = (Y * pMyVector.Z) - (Z * pMyVector.Y);
            float resultY = (Z * pMyVector.X) - (X * pMyVector.Z);
            float resultZ = (X * pMyVector.Y) - (Y * pMyVector.X);

            // Create a new MyVector3D object with the cross product result
            MyVector crossProduct = new MyVector(resultX, resultY, resultZ);

            return crossProduct;

        }

        public override string ToString()
        {
            string result = "X: " + X + " " + "Y: " + Y + " " + "Z: " + Z;
            return result;
        }
        public float GetElement(int x)
        {
            switch (x)
            {
                case 0:
                    return X;
                case 1:
                    return Y;
                case 2:
                    return Z;
                case 3:
                    return W;
                default:
                    throw new IndexOutOfRangeException();
            }
        }


    }

}
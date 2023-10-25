using Codice.Client.BaseCommands.Merge;
using Codice.CM.Common;
using log4net.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Numerics;
using UnityEngine;
namespace MatrixVectorNamespace
{
    public class MyMatrix

    {
        private float[][] matrix;
        public MyMatrix(
        float pRow0Column0, float pRow0Column1, float pRow0Column2, float pRow0Column3,
        float pRow1Column0, float pRow1Column1, float pRow1Column2, float pRow1Column3,
        float pRow2Column0, float pRow2Column1, float pRow2Column2, float pRow2Column3,
        float pRow3Column0, float pRow3Column1, float pRow3Column2, float pRow3Column3)

        {
            float[] row0 = { pRow0Column0, pRow0Column1, pRow0Column2, pRow0Column3 };
            float[] row1 = { pRow1Column0, pRow1Column1, pRow1Column2, pRow1Column3 };
            float[] row2 = { pRow2Column0, pRow2Column1, pRow2Column2, pRow2Column3 };
            float[] row3 = { pRow3Column0, pRow3Column1, pRow3Column2, pRow3Column3 };
            matrix = new float[4][] { row0, row1, row2, row3 };
        }
        public MyMatrix(float[,] pMatrix)
        {
           
            float[][] temp = new float[4][];
            for (int i = 0; i < pMatrix.Length; i++)
            {
                temp[i % 4][i / 2] = pMatrix[i % 4,i / 2];
            }


            this.matrix = temp;
            
        }

        public static MyMatrix CreateIdentity()
        {
            MyMatrix Mat = new MyMatrix(
                1, 0, 0, 0,
                0, 1, 0, 0,
                0, 0, 1, 0,
                0, 0, 0, 1);

            return Mat;
        }

        public static MyMatrix CreateTranslation(MyVector pTranslation)
        {
            MyMatrix eye = MyMatrix.CreateIdentity();
            eye.SetElement(3, 0, pTranslation.X);
            eye.SetElement(3, 1, pTranslation.Y);
            eye.SetElement(3, 2, pTranslation.Z);
            return eye;
        }

        public static MyMatrix CreateScale(MyVector pScale)
        {
            MyMatrix m1 = new MyMatrix(
                pScale.X, 0, 0, 0,
                0, pScale.Y, 0, 0,
                0, 0, pScale.Z, 0,
                0, 0, 0, 1);

            return m1;
        }

        public static MyMatrix CreateRotationX(float pAngle)
        {
            MyMatrix rotation = new MyMatrix(
                1, 0, 0, 0,
                0, (float)Math.Cos(pAngle), (float)-Math.Sin(pAngle), 0,
                0, (float)Math.Sin(pAngle), (float)Math.Cos(pAngle), 0,
                0, 0, 0, 1

                );
            return (MyMatrix)rotation;
        }

        public static MyMatrix CreateRotationY(float pAngle)
        {
            MyMatrix rotation = new MyMatrix(
               (float)Math.Cos(pAngle), 0, (float)Math.Sin(pAngle), 0,
               0, 1, 0, 0,
               (float)-Math.Sin(pAngle), 0, (float)Math.Cos(pAngle), 0,
               0, 0, 0, 1);
            return (MyMatrix)rotation;
        }

        public static MyMatrix CreateRotationZ(float pAngle)
        {
            MyMatrix rotation = new MyMatrix(
                (float)Math.Cos(pAngle), (float)-Math.Sin(pAngle), 0, 0,
                (float)Math.Sin(pAngle), (float)Math.Cos(pAngle), 0, 0,
                0, 0, 1, 0,
                0, 0, 0, 1);

            return (MyMatrix)rotation;
        }

        public MyVector Multiply(MyVector pVector)
        {

            float col0tot = pVector.X * (GetElement(0, 0) + GetElement(0, 1) + GetElement(0, 2) + GetElement(0, 3));
            float col1tot = pVector.Y * (GetElement(1, 0) + GetElement(1, 1) + GetElement(1, 2) + GetElement(1, 3));
            float col2tot = pVector.Z * (GetElement(2, 0) + GetElement(2, 1) + GetElement(2, 2) + GetElement(2, 3));
            float col3tot = pVector.W * (GetElement(3, 0) + GetElement(3, 1) + GetElement(3, 2) + GetElement(3, 3));
            MyVector v = new MyVector(col0tot, col1tot, col2tot, col3tot);

            return v;
        }
        
        public MyMatrix Multiply(MyMatrix pMyMatrix)
        {
            /*
            float[,] result = new float[4, 4];

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    float sum = 0;
                    for (int k = 0; k < 4; k++)
                    {
                        sum += this.GetElement(i, k) * pMyMatrix.GetElement(k, j);
                    }
                    result[i, j] = sum;

                }

            }
            MyMatrix m = new MyMatrix(
                result[0, 0], result[0, 1], result[0, 2], result[0, 3],
                result[1, 0], result[1, 1], result[1, 2], result[1, 3],
                result[2, 0], result[2, 1], result[2, 2], result[2, 3],
                result[3, 0], result[3, 1], result[3, 2], result[3, 3]);

            return m;
            */

            /*
            int thisMatrixNumRows = matrix.GetLength(0);
            int thisMatrixNumCols = matrix.GetLength(1);
            int pMatrixNumRows = pMyMatrix.matrix.GetLength(0);
            int pMatrixNumCols = pMyMatrix.matrix.GetLength(1);

            float[,] product = new float[thisMatrixNumRows, pMatrixNumCols];


            //looping through this matrix rows
            for (int i = 0; i < thisMatrixNumRows; i++)
            {
                //for each this matrix row, loop through pMatrix columns
                for (int j = 0; j < pMatrixNumCols; j++)
                {
                    //loop through this matrix columns to calculate the dot product
                    for (int k = 0; k < thisMatrixNumRows; k++)
                    {
                        product[i,j] = GetElement(i, k) * pMyMatrix.GetElement(k, j);
                    }
                }
            }
            MyMatrix m = new MyMatrix(product);

            return m;
            */

            
            return new MyMatrix(
                matrix[0][0] * pMyMatrix.matrix[0][0] + matrix[1][0] * pMyMatrix.matrix[0][1] + matrix[2][0] * pMyMatrix.matrix[0][2] + matrix[3][0] * pMyMatrix.matrix[0][3],
                matrix[0][0] * pMyMatrix.matrix[1][0] + matrix[1][0] * pMyMatrix.matrix[1][1] + matrix[2][0] * pMyMatrix.matrix[1][2] + matrix[3][0] * pMyMatrix.matrix[1][3],
                matrix[0][0] * pMyMatrix.matrix[2][0] + matrix[1][0] * pMyMatrix.matrix[2][1] + matrix[2][0] * pMyMatrix.matrix[2][2] + matrix[3][0] * pMyMatrix.matrix[2][3],
                matrix[0][0] * pMyMatrix.matrix[3][0] + matrix[1][0] * pMyMatrix.matrix[3][1] + matrix[2][0] * pMyMatrix.matrix[3][2] + matrix[3][0] * pMyMatrix.matrix[3][3],
                matrix[0][1] * pMyMatrix.matrix[0][0] + matrix[1][1] * pMyMatrix.matrix[0][1] + matrix[2][1] * pMyMatrix.matrix[0][2] + matrix[3][1] * pMyMatrix.matrix[0][3],
                matrix[0][1] * pMyMatrix.matrix[1][0] + matrix[1][1] * pMyMatrix.matrix[1][1] + matrix[2][1] * pMyMatrix.matrix[1][2] + matrix[3][1] * pMyMatrix.matrix[1][3],
                matrix[0][1] * pMyMatrix.matrix[2][0] + matrix[1][1] * pMyMatrix.matrix[2][1] + matrix[2][1] * pMyMatrix.matrix[2][2] + matrix[3][1] * pMyMatrix.matrix[2][3],
                matrix[0][1] * pMyMatrix.matrix[3][0] + matrix[1][1] * pMyMatrix.matrix[3][1] + matrix[2][1] * pMyMatrix.matrix[3][2] + matrix[3][1] * pMyMatrix.matrix[3][3],
                matrix[0][2] * pMyMatrix.matrix[0][0] + matrix[1][2] * pMyMatrix.matrix[0][1] + matrix[2][2] * pMyMatrix.matrix[0][2] + matrix[3][2] * pMyMatrix.matrix[0][3],
                matrix[0][2] * pMyMatrix.matrix[1][0] + matrix[1][2] * pMyMatrix.matrix[1][1] + matrix[2][2] * pMyMatrix.matrix[1][2] + matrix[3][2] * pMyMatrix.matrix[1][3],
                matrix[0][2] * pMyMatrix.matrix[2][0] + matrix[1][2] * pMyMatrix.matrix[2][1] + matrix[2][2] * pMyMatrix.matrix[2][2] + matrix[3][2] * pMyMatrix.matrix[2][3],
                matrix[0][2] * pMyMatrix.matrix[3][0] + matrix[1][2] * pMyMatrix.matrix[3][1] + matrix[2][2] * pMyMatrix.matrix[3][2] + matrix[3][2] * pMyMatrix.matrix[3][3],
                matrix[0][3] * pMyMatrix.matrix[0][0] + matrix[1][3] * pMyMatrix.matrix[0][1] + matrix[2][3] * pMyMatrix.matrix[0][2] + matrix[3][3] * pMyMatrix.matrix[0][3],
                matrix[0][3] * pMyMatrix.matrix[1][0] + matrix[1][3] * pMyMatrix.matrix[1][1] + matrix[2][3] * pMyMatrix.matrix[1][2] + matrix[3][3] * pMyMatrix.matrix[1][3],
                matrix[0][3] * pMyMatrix.matrix[2][0] + matrix[1][3] * pMyMatrix.matrix[2][1] + matrix[2][3] * pMyMatrix.matrix[2][2] + matrix[3][3] * pMyMatrix.matrix[2][3],
                matrix[0][3] * pMyMatrix.matrix[3][0] + matrix[1][3] * pMyMatrix.matrix[3][1] + matrix[2][3] * pMyMatrix.matrix[3][2] + matrix[3][3] * pMyMatrix.matrix[3][3]);
            
        }
        

        public MyMatrix Inverse()
        {
            return null;
        }

        public override string ToString()
        {
            string result = GetElement(0, 0) + " " + GetElement(0, 1) + " " + GetElement(0, 2) + " " + GetElement(0, 3) + "\n" +
                GetElement(1, 0) + " " + GetElement(1, 1) + " " + GetElement(1, 2) + " " + GetElement(1, 3) + "\n" +
                GetElement(2, 0) + " " + GetElement(2, 1) + " " + GetElement(2, 2) + " " + GetElement(2, 3) + "\n" +
                GetElement(3, 0) + " " + GetElement(3, 1) + " " + GetElement(3, 2) + " " + GetElement(3, 3) + "\n";
            return result;
        }
        public float GetElement(int pRow, int pColumn)
        {
            return matrix[pRow][pColumn];
        }
        public void SetElement(int pRow, int pColumn, float pValue)
        {
            matrix[pRow][pColumn] = pValue;
        }


        public void SetTransform(UnityEngine.GameObject pGameObject)
        {
            UnityEngine.Transform transform = pGameObject.transform;

            setPosition(transform);
            setRotation(transform);
            setScale(transform);

        }
    
        private void setPosition(UnityEngine.Transform pTransform)
        {
            UnityEngine.Vector3 positionVector;
            float X = GetElement(0, 3);
            float Y = GetElement(1, 3);
            float Z = GetElement(2, 3);
            positionVector = new UnityEngine.Vector3(X, Y, Z);

            pTransform.position = positionVector;
         
        }
        private void setScale(UnityEngine.Transform pTransform)
        {
            UnityEngine.Vector3 scale; 

            MyVector Vx = new MyVector(GetElement(0, 0), GetElement(1, 0), GetElement(2, 0), GetElement(3, 0));
            scale.x = Vx.Magnitude();

            MyVector Vy = new MyVector(GetElement(0,1), GetElement(1,1), GetElement(2,1), GetElement(3,1));
            scale.y = Vy.Magnitude();

            MyVector Vz = new MyVector(GetElement(0,2),GetElement(1,2),GetElement(2,2), GetElement(3,2));
            scale.z = Vz.Magnitude();

            pTransform.localScale = scale;

        }
        private void setRotation(UnityEngine.Transform pTransform)
        {
            UnityEngine.Vector3 forward = new UnityEngine.Vector3();
            forward.x = GetElement(0, 2);
            forward.y = GetElement(1, 2);
            forward.z = GetElement(2, 2);

            UnityEngine.Vector3 upwards = new UnityEngine.Vector3();
            upwards.x = GetElement(0, 1);
            upwards.y = GetElement(1, 1);
            upwards.z = GetElement(2, 1);

            pTransform.rotation = UnityEngine.Quaternion.LookRotation(forward, upwards);
            

        }



    }
};


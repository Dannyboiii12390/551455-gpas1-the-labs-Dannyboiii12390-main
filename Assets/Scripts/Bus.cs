using MatrixVectorNamespace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bus
{
    MyVector _Position;
    MyVector _Rotation;
    MyVector _Scale;
    GameObject bodyBottom = GameObject.CreatePrimitive(PrimitiveType.Cube);


    public Bus(MyVector pPosition, MyVector pRotation, MyVector pScale)
    {
        _Position = pPosition;
        _Rotation = pRotation;  
        _Scale = pScale;

        bodyBottom.GetComponent<Renderer>().material.color = Color.red;

        MyVector localTranslation = new MyVector(1,0,0);
        MyMatrix bottomTransformMatrix = MyMatrix.CreateTranslation(localTranslation);
        bottomTransformMatrix.SetTransform(bodyBottom);



        MyVector v1 = new MyVector(0, 0, -1);
        MyVector v2 = new MyVector(0, 0, 1);
        MyVector v3 = new MyVector(0, 1, -1);
        MyVector v4 = new MyVector(0, 1, 1);

        buildWheel(MyMatrix.CreateTranslation(v1));
        buildWheel(MyMatrix.CreateTranslation(v2));
        buildWheel(MyMatrix.CreateTranslation(v3));
        buildWheel(MyMatrix.CreateTranslation(v4));

    }
    private void buildWheel(MyMatrix pParentTransform)
    {
        MyMatrix localTransform = MyMatrix.CreateTranslation(new MyVector(0,0,0));
        MyMatrix comboTransform = pParentTransform.Multiply(localTransform);
        // code to create a primitive and set its transform to the comboTransform 
        comboTransform.SetTransform(bodyBottom);
    }
   


}

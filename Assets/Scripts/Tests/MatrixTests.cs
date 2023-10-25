using System;
using System.Collections;
using System.Collections.Generic;
using MatrixVectorNamespace;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class MatrixTests
{
    // A Test behaves as an ordinary method
    [Test]
    public void Constructor()
    {
        // Use the Assert class to test conditions
        MyMatrix myMatrix = new MyMatrix(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);
        Assert.AreEqual(1, myMatrix.GetElement(0, 0));
        Assert.AreEqual(2, myMatrix.GetElement(0, 1));
        Assert.AreEqual(3, myMatrix.GetElement(0, 2));
        Assert.AreEqual(4, myMatrix.GetElement(0, 3));
        Assert.AreEqual(5, myMatrix.GetElement(1, 0));
        Assert.AreEqual(6, myMatrix.GetElement(1, 1));
        Assert.AreEqual(7, myMatrix.GetElement(1, 2));
        Assert.AreEqual(8, myMatrix.GetElement(1, 3));
        Assert.AreEqual(9, myMatrix.GetElement(2, 0));
        Assert.AreEqual(10, myMatrix.GetElement(2, 1));
        Assert.AreEqual(11, myMatrix.GetElement(2, 2));
        Assert.AreEqual(12, myMatrix.GetElement(2, 3));
        Assert.AreEqual(13, myMatrix.GetElement(3, 0));
        Assert.AreEqual(14, myMatrix.GetElement(3, 1));
        Assert.AreEqual(15, myMatrix.GetElement(3, 2));
        Assert.AreEqual(16, myMatrix.GetElement(3, 3));

    }

    [Test]
    public void CreateIdentity()
    {
        // Use the Assert class to test conditions
        MyMatrix myMatrix = MyMatrix.CreateIdentity();
        Assert.AreEqual(1, myMatrix.GetElement(0, 0));
        Assert.AreEqual(0, myMatrix.GetElement(0, 1));
        Assert.AreEqual(0, myMatrix.GetElement(0, 2));
        Assert.AreEqual(0, myMatrix.GetElement(0, 3));
        Assert.AreEqual(0, myMatrix.GetElement(1, 0));
        Assert.AreEqual(1, myMatrix.GetElement(1, 1));
        Assert.AreEqual(0, myMatrix.GetElement(1, 2));
        Assert.AreEqual(0, myMatrix.GetElement(1, 3));
        Assert.AreEqual(0, myMatrix.GetElement(2, 0));
        Assert.AreEqual(0, myMatrix.GetElement(2, 1));
        Assert.AreEqual(1, myMatrix.GetElement(2, 2));
        Assert.AreEqual(0, myMatrix.GetElement(2, 3));
        Assert.AreEqual(0, myMatrix.GetElement(3, 0));
        Assert.AreEqual(0, myMatrix.GetElement(3, 1));
        Assert.AreEqual(0, myMatrix.GetElement(3, 2));
        Assert.AreEqual(1, myMatrix.GetElement(3, 3));

    }

    [Test]
    public void CreateTranslation()
    {
        // Use the Assert class to test conditions
        MyVector translationVector = new MyVector(30, 40, 50);
        MyMatrix myMatrix = MyMatrix.CreateTranslation(translationVector);
        Assert.AreEqual(1, myMatrix.GetElement(0, 0));
        Assert.AreEqual(0, myMatrix.GetElement(0, 1));
        Assert.AreEqual(0, myMatrix.GetElement(0, 2));
        Assert.AreEqual(30, myMatrix.GetElement(0, 3));
        Assert.AreEqual(0, myMatrix.GetElement(1, 0));
        Assert.AreEqual(1, myMatrix.GetElement(1, 1));
        Assert.AreEqual(0, myMatrix.GetElement(1, 2));
        Assert.AreEqual(40, myMatrix.GetElement(1, 3));
        Assert.AreEqual(0, myMatrix.GetElement(2, 0));
        Assert.AreEqual(0, myMatrix.GetElement(2, 1));
        Assert.AreEqual(1, myMatrix.GetElement(2, 2));
        Assert.AreEqual(50, myMatrix.GetElement(2, 3));
        Assert.AreEqual(0, myMatrix.GetElement(3, 0));
        Assert.AreEqual(0, myMatrix.GetElement(3, 1));
        Assert.AreEqual(0, myMatrix.GetElement(3, 2));
        Assert.AreEqual(1, myMatrix.GetElement(3, 3));

    }

    [Test]
    public void CreateScale()
    {
        // Use the Assert class to test conditions
        MyVector scaleVector = new MyVector(30, 40, 50);
        MyMatrix myMatrix = MyMatrix.CreateScale(scaleVector);
        Assert.AreEqual(30, myMatrix.GetElement(0, 0));
        Assert.AreEqual(0, myMatrix.GetElement(0, 1));
        Assert.AreEqual(0, myMatrix.GetElement(0, 2));
        Assert.AreEqual(0, myMatrix.GetElement(0, 3));
        Assert.AreEqual(0, myMatrix.GetElement(1, 0));
        Assert.AreEqual(40, myMatrix.GetElement(1, 1));
        Assert.AreEqual(0, myMatrix.GetElement(1, 2));
        Assert.AreEqual(0, myMatrix.GetElement(1, 3));
        Assert.AreEqual(0, myMatrix.GetElement(2, 0));
        Assert.AreEqual(0, myMatrix.GetElement(2, 1));
        Assert.AreEqual(50, myMatrix.GetElement(2, 2));
        Assert.AreEqual(0, myMatrix.GetElement(2, 3));
        Assert.AreEqual(0, myMatrix.GetElement(3, 0));
        Assert.AreEqual(0, myMatrix.GetElement(3, 1));
        Assert.AreEqual(0, myMatrix.GetElement(3, 2));
        Assert.AreEqual(1, myMatrix.GetElement(3, 3));

    }

    [Test]
    public void CreateRotationX()
    {
        // Use the Assert class to test conditions
        float angle = MathF.PI;
        float cosAngle = MathF.Cos(angle);
        float sinAngle = MathF.Sin(angle);
        MyMatrix myMatrix = MyMatrix.CreateRotationX(angle);
        Assert.AreEqual(1, myMatrix.GetElement(0, 0));
        Assert.AreEqual(0, myMatrix.GetElement(0, 1));
        Assert.AreEqual(0, myMatrix.GetElement(0, 2));
        Assert.AreEqual(0, myMatrix.GetElement(0, 3));
        Assert.AreEqual(0, myMatrix.GetElement(1, 0));
        Assert.AreEqual(cosAngle, myMatrix.GetElement(1, 1));
        Assert.AreEqual(-sinAngle, myMatrix.GetElement(1, 2));
        Assert.AreEqual(0, myMatrix.GetElement(1, 3));
        Assert.AreEqual(0, myMatrix.GetElement(2, 0));
        Assert.AreEqual(sinAngle, myMatrix.GetElement(2, 1));
        Assert.AreEqual(cosAngle, myMatrix.GetElement(2, 2));
        Assert.AreEqual(0, myMatrix.GetElement(2, 3));
        Assert.AreEqual(0, myMatrix.GetElement(3, 0));
        Assert.AreEqual(0, myMatrix.GetElement(3, 1));
        Assert.AreEqual(0, myMatrix.GetElement(3, 2));
        Assert.AreEqual(1, myMatrix.GetElement(3, 3));

    }

    [Test]
    public void CreateRotationY()
    {
        // Use the Assert class to test conditions
        float angle = MathF.PI;
        float cosAngle = MathF.Cos(angle);
        float sinAngle = MathF.Sin(angle);
        MyMatrix myMatrix = MyMatrix.CreateRotationY(angle);
        Assert.AreEqual(cosAngle, myMatrix.GetElement(0, 0));
        Assert.AreEqual(0, myMatrix.GetElement(0, 1));
        Assert.AreEqual(sinAngle, myMatrix.GetElement(0, 2));
        Assert.AreEqual(0, myMatrix.GetElement(0, 3));
        Assert.AreEqual(0, myMatrix.GetElement(1, 0));
        Assert.AreEqual(1, myMatrix.GetElement(1, 1));
        Assert.AreEqual(0, myMatrix.GetElement(1, 2));
        Assert.AreEqual(0, myMatrix.GetElement(1, 3));
        Assert.AreEqual(-sinAngle, myMatrix.GetElement(2, 0));
        Assert.AreEqual(0, myMatrix.GetElement(2, 1));
        Assert.AreEqual(cosAngle, myMatrix.GetElement(2, 2));
        Assert.AreEqual(0, myMatrix.GetElement(2, 3));
        Assert.AreEqual(0, myMatrix.GetElement(3, 0));
        Assert.AreEqual(0, myMatrix.GetElement(3, 1));
        Assert.AreEqual(0, myMatrix.GetElement(3, 2));
        Assert.AreEqual(1, myMatrix.GetElement(3, 3));

    }

    [Test]
    public void CreateRotationZ()
    {
        // Use the Assert class to test conditions
        float angle = MathF.PI;
        float cosAngle = MathF.Cos(angle);
        float sinAngle = MathF.Sin(angle);
        MyMatrix myMatrix = MyMatrix.CreateRotationZ(angle);
        Assert.AreEqual(cosAngle, myMatrix.GetElement(0, 0));
        Assert.AreEqual(-sinAngle, myMatrix.GetElement(0, 1));
        Assert.AreEqual(0, myMatrix.GetElement(0, 2));
        Assert.AreEqual(0, myMatrix.GetElement(0, 3));
        Assert.AreEqual(sinAngle, myMatrix.GetElement(1, 0));
        Assert.AreEqual(cosAngle, myMatrix.GetElement(1, 1));
        Assert.AreEqual(0, myMatrix.GetElement(1, 2));
        Assert.AreEqual(0, myMatrix.GetElement(1, 3));
        Assert.AreEqual(0, myMatrix.GetElement(2, 0));
        Assert.AreEqual(0, myMatrix.GetElement(2, 1));
        Assert.AreEqual(1, myMatrix.GetElement(2, 2));
        Assert.AreEqual(0, myMatrix.GetElement(2, 3));
        Assert.AreEqual(0, myMatrix.GetElement(3, 0));
        Assert.AreEqual(0, myMatrix.GetElement(3, 1));
        Assert.AreEqual(0, myMatrix.GetElement(3, 2));
        Assert.AreEqual(1, myMatrix.GetElement(3, 3));

    }

    [Test]
    public void MultiplyVector()
    {
        // Use the Assert class to test conditions
        MyVector myVector = new MyVector(30, 40, 0);
        MyVector translationVector = new MyVector(10, 20, 30);
        MyMatrix translationMatrix = MyMatrix.CreateTranslation(translationVector);
        MyVector translatedVector = translationMatrix.Multiply(myVector);

        Assert.AreEqual(40, translatedVector.X);
        Assert.AreEqual(60, translatedVector.Y);
        Assert.AreEqual(30, translatedVector.Z);
        Assert.AreEqual(1, translatedVector.W);

        MyVector scaleVector = new MyVector(2, 2, 2);
        MyMatrix scaleMatrix = MyMatrix.CreateScale(scaleVector);
        MyVector scaledVector = scaleMatrix.Multiply(myVector);

        Assert.AreEqual(60, scaledVector.X);
        Assert.AreEqual(80, scaledVector.Y);
        Assert.AreEqual(0, scaledVector.Z);
        Assert.AreEqual(1, scaledVector.W);

        float angle = MathF.PI / 2;
        MyMatrix rotationMatrix = MyMatrix.CreateRotationZ(angle);
        MyVector rotatedVector = rotationMatrix.Multiply(myVector);

        Assert.AreEqual(-40, rotatedVector.X, 0.001);
        Assert.AreEqual(30, rotatedVector.Y, 0.001);
        Assert.AreEqual(0, rotatedVector.Z, 0.001);
        Assert.AreEqual(1, rotatedVector.W, 0.001);
    }

    [Test]
    public void Multiply()
    {
        MyVector myVector = new MyVector(30, 40, 0);
        MyVector translationVector = new MyVector(10, 20, 30);
        MyMatrix translationMatrix = MyMatrix.CreateTranslation(translationVector);
        float angle = MathF.PI / 2;
        MyMatrix rotationMatrix = MyMatrix.CreateRotationZ(angle);
        MyVector scaleVector = new MyVector(2, 2, 2);
        MyMatrix scaleMatrix = MyMatrix.CreateScale(scaleVector);

        MyMatrix scaleXTranslationMatrix = scaleMatrix.Multiply(translationMatrix);
        Assert.AreEqual(2, scaleXTranslationMatrix.GetElement(0, 0));
        Assert.AreEqual(0, scaleXTranslationMatrix.GetElement(0, 1));
        Assert.AreEqual(0, scaleXTranslationMatrix.GetElement(0, 2));
        Assert.AreEqual(20, scaleXTranslationMatrix.GetElement(0, 3));
        Assert.AreEqual(0, scaleXTranslationMatrix.GetElement(1, 0));
        Assert.AreEqual(2, scaleXTranslationMatrix.GetElement(1, 1));
        Assert.AreEqual(0, scaleXTranslationMatrix.GetElement(1, 2));
        Assert.AreEqual(40, scaleXTranslationMatrix.GetElement(1, 3));
        Assert.AreEqual(0, scaleXTranslationMatrix.GetElement(2, 0));
        Assert.AreEqual(0, scaleXTranslationMatrix.GetElement(2, 1));
        Assert.AreEqual(2, scaleXTranslationMatrix.GetElement(2, 2));
        Assert.AreEqual(60, scaleXTranslationMatrix.GetElement(2, 3));
        Assert.AreEqual(0, scaleXTranslationMatrix.GetElement(3, 0));
        Assert.AreEqual(0, scaleXTranslationMatrix.GetElement(3, 1));
        Assert.AreEqual(0, scaleXTranslationMatrix.GetElement(3, 2));
        Assert.AreEqual(1, scaleXTranslationMatrix.GetElement(3, 3));

        MyMatrix translationXScaleMatrix = translationMatrix.Multiply(scaleMatrix);
        Assert.AreEqual(2, translationXScaleMatrix.GetElement(0, 0));
        Assert.AreEqual(0, translationXScaleMatrix.GetElement(0, 1));
        Assert.AreEqual(0, translationXScaleMatrix.GetElement(0, 2));
        Assert.AreEqual(10, translationXScaleMatrix.GetElement(0, 3));
        Assert.AreEqual(0, translationXScaleMatrix.GetElement(1, 0));
        Assert.AreEqual(2, translationXScaleMatrix.GetElement(1, 1));
        Assert.AreEqual(0, translationXScaleMatrix.GetElement(1, 2));
        Assert.AreEqual(20, translationXScaleMatrix.GetElement(1, 3));
        Assert.AreEqual(0, translationXScaleMatrix.GetElement(2, 0));
        Assert.AreEqual(0, translationXScaleMatrix.GetElement(2, 1));
        Assert.AreEqual(2, translationXScaleMatrix.GetElement(2, 2));
        Assert.AreEqual(30, translationXScaleMatrix.GetElement(2, 3));
        Assert.AreEqual(0, translationXScaleMatrix.GetElement(3, 0));
        Assert.AreEqual(0, translationXScaleMatrix.GetElement(3, 1));
        Assert.AreEqual(0, translationXScaleMatrix.GetElement(3, 2));
        Assert.AreEqual(1, translationXScaleMatrix.GetElement(3, 3));

        MyMatrix chainedMatrix = translationMatrix.Multiply(scaleMatrix).Multiply(rotationMatrix);

        float cosAngle = MathF.Cos(angle);
        float sinAngle = MathF.Sin(angle);

        Assert.AreEqual(2 * cosAngle, chainedMatrix.GetElement(0, 0));
        Assert.AreEqual(2 * -sinAngle, chainedMatrix.GetElement(0, 1));
        Assert.AreEqual(0, chainedMatrix.GetElement(0, 2));
        Assert.AreEqual(10, chainedMatrix.GetElement(0, 3));
        Assert.AreEqual(2 * sinAngle, chainedMatrix.GetElement(1, 0));
        Assert.AreEqual(2 * cosAngle, chainedMatrix.GetElement(1, 1));
        Assert.AreEqual(0, chainedMatrix.GetElement(1, 2));
        Assert.AreEqual(20, chainedMatrix.GetElement(1, 3));
        Assert.AreEqual(0, chainedMatrix.GetElement(2, 0));
        Assert.AreEqual(0, chainedMatrix.GetElement(2, 1));
        Assert.AreEqual(2, chainedMatrix.GetElement(2, 2));
        Assert.AreEqual(30, chainedMatrix.GetElement(2, 3));
        Assert.AreEqual(0, chainedMatrix.GetElement(3, 0));
        Assert.AreEqual(0, chainedMatrix.GetElement(3, 1));
        Assert.AreEqual(0, chainedMatrix.GetElement(3, 2));
        Assert.AreEqual(1, chainedMatrix.GetElement(3, 3));

    }

    [Test]
    public void Inverse()
    {
        MyVector translationVector = new MyVector(20, 10, 5);
        MyMatrix translationMatrix = MyMatrix.CreateTranslation(translationVector);
        MyVector scaleVector = new MyVector(2, 2, 2);
        MyMatrix scaleMatrix = MyMatrix.CreateScale(scaleVector);
        float angle = MathF.PI / 2;
        MyMatrix rotationZMatrix = MyMatrix.CreateRotationZ(angle);
        MyMatrix multipliedMatrix = translationMatrix.Multiply(scaleMatrix).Multiply(rotationZMatrix);
        MyMatrix inverseMatrix = multipliedMatrix.Inverse();
        MyMatrix identityMatrix = multipliedMatrix.Multiply(inverseMatrix);
        Assert.AreEqual(1, identityMatrix.GetElement(0, 0), 0.001);
        Assert.AreEqual(0, identityMatrix.GetElement(0, 1), 0.001);
        Assert.AreEqual(0, identityMatrix.GetElement(0, 2), 0.001);
        Assert.AreEqual(0, identityMatrix.GetElement(0, 3), 0.001);
        Assert.AreEqual(0, identityMatrix.GetElement(1, 0), 0.001);
        Assert.AreEqual(1, identityMatrix.GetElement(1, 1), 0.001);
        Assert.AreEqual(0, identityMatrix.GetElement(1, 2), 0.001);
        Assert.AreEqual(0, identityMatrix.GetElement(1, 3), 0.001);
        Assert.AreEqual(0, identityMatrix.GetElement(2, 0), 0.001);
        Assert.AreEqual(0, identityMatrix.GetElement(2, 1), 0.001);
        Assert.AreEqual(1, identityMatrix.GetElement(2, 2), 0.001);
        Assert.AreEqual(0, identityMatrix.GetElement(2, 3), 0.001);
        Assert.AreEqual(0, identityMatrix.GetElement(3, 0), 0.001);
        Assert.AreEqual(0, identityMatrix.GetElement(3, 1), 0.001);
        Assert.AreEqual(0, identityMatrix.GetElement(3, 2), 0.001);
        Assert.AreEqual(1, identityMatrix.GetElement(3, 3), 0.001);
    }

}
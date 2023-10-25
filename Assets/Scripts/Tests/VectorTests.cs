using System;
using System.Collections;
using System.Collections.Generic;
using MatrixVectorNamespace;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class VectorTests
{
    // A Test behaves as an ordinary method
    [Test]
    public void Constructor()
    {
        // Use the Assert class to test conditions
        MyVector myVector = new MyVector(30, 40, 0);
        Assert.AreEqual(30, myVector.X);
        Assert.AreEqual(40, myVector.Y);
        Assert.AreEqual(0, myVector.Z);
    }

    [Test]
    public void Add()
    {
        // Use the Assert class to test conditions
        MyVector firstVector = new MyVector(30, 40, 0);
        MyVector secondVector = new MyVector(20, 30, 0);
        MyVector thirdVector = firstVector.Add(secondVector);
        Assert.AreEqual(50, thirdVector.X);
        Assert.AreEqual(70, thirdVector.Y);
        Assert.AreEqual(0, thirdVector.Z);
        Assert.AreEqual(30, firstVector.X);
        Assert.AreEqual(40, firstVector.Y);
        Assert.AreEqual(0, firstVector.Z);
        Assert.AreEqual(20, secondVector.X);
        Assert.AreEqual(30, secondVector.Y);
        Assert.AreEqual(0, secondVector.Z);
    }

    [Test]
    public void Subtract()
    {
        // Use the Assert class to test conditions
        MyVector firstVector = new MyVector(30, 40, 0);
        MyVector secondVector = new MyVector(5, 10, 0);
        MyVector thirdVector = firstVector.Subtract(secondVector);
        Assert.AreEqual(25, thirdVector.X);
        Assert.AreEqual(30, thirdVector.Y);
        Assert.AreEqual(0, thirdVector.Z);
        Assert.AreEqual(30, firstVector.X);
        Assert.AreEqual(40, firstVector.Y);
        Assert.AreEqual(0, firstVector.Z);
        Assert.AreEqual(5, secondVector.X);
        Assert.AreEqual(10, secondVector.Y);
        Assert.AreEqual(0, secondVector.Z);
    }

    [Test]
    public void Multiply()
    {
        // Use the Assert class to test conditions
        MyVector firstVector = new MyVector(30, 40, 0);
        float scalar = 10;
        MyVector secondVector = firstVector.Multiply(scalar);
        Assert.AreEqual(300, secondVector.X);
        Assert.AreEqual(400, secondVector.Y);
        Assert.AreEqual(0, secondVector.Z);
        Assert.AreEqual(30, firstVector.X);
        Assert.AreEqual(40, firstVector.Y);
        Assert.AreEqual(0, firstVector.Z);
    }
    [Test]
    public void Divide()
    {
        // Use the Assert class to test conditions
        MyVector firstVector = new MyVector(30, 40, 0);
        float scalar = 10;
        MyVector secondVector = firstVector.Divide(scalar);
        Assert.AreEqual(3, secondVector.X);
        Assert.AreEqual(4, secondVector.Y);
        Assert.AreEqual(0, secondVector.Z);
        Assert.AreEqual(30, firstVector.X);
        Assert.AreEqual(40, firstVector.Y);
        Assert.AreEqual(0, firstVector.Z);
    }
    [Test]
    public void Magnitude()
    {
        // Use the Assert class to test conditions
        MyVector firstVector = new MyVector(30, 40, 0);
        float magnitude = firstVector.Magnitude();
        Assert.AreEqual(50, magnitude);
    }

    [Test]
    public void Normalise()
    {
        // Use the Assert class to test conditions
        MyVector firstVector = new MyVector(30, 40, 0);
        MyVector normalisedVector = firstVector.Normalise();
        float magnitude = normalisedVector.Magnitude();
        Assert.AreEqual(magnitude, 1);
        Assert.AreEqual(3.0f / 5, normalisedVector.X);
        Assert.AreEqual(4.0f / 5, normalisedVector.Y);
        Assert.AreEqual(0, normalisedVector.Z);
        Assert.AreEqual(30, firstVector.X);
        Assert.AreEqual(40, firstVector.Y);
        Assert.AreEqual(0, firstVector.Z);

    }

    [Test]
    public void LimitToBelowLimit()
    {
        // Use the Assert class to test conditions
        MyVector firstVector = new MyVector(30, 40, 0);
        MyVector limitedVector = firstVector.LimitTo(60);
        float magnitude = limitedVector.Magnitude();
        Assert.AreEqual(magnitude, 50);
        Assert.AreEqual(30, firstVector.X);
        Assert.AreEqual(40, firstVector.Y);
        Assert.AreEqual(0, firstVector.Z);

    }
    [Test]
    public void LimitToAboveLimit()
    {
        // Use the Assert class to test conditions
        MyVector firstVector = new MyVector(30, 40, 0);
        MyVector limitedVector = firstVector.LimitTo(30);
        float magnitude = limitedVector.Magnitude();
        Assert.AreEqual(magnitude, 30);
        Assert.AreEqual(30, firstVector.X);
        Assert.AreEqual(40, firstVector.Y);
        Assert.AreEqual(0, firstVector.Z);

    }

    [Test]
    public void DotProductIsZero()
    {
        // Use the Assert class to test conditions
        MyVector firstVector = new MyVector(30, 40, -10);
        MyVector secondVector = new MyVector(40, -20, 40);
        float dotProduct = firstVector.DotProduct(secondVector);
        Assert.AreEqual(0, dotProduct);

    }
    [Test]
    public void DotProductIsPositive()
    {
        // Use the Assert class to test conditions
        MyVector firstVector = new MyVector(30, 40, 10);
        MyVector secondVector = new MyVector(40, -30, 50);
        float dotProduct = firstVector.DotProduct(secondVector);
        Assert.AreEqual(500, dotProduct);

    }
    [Test]
    public void DotProductIsNegative()
    {
        // Use the Assert class to test conditions
        MyVector firstVector = new MyVector(30, 40, 10);
        MyVector secondVector = new MyVector(0, -30, 50);
        float dotProduct = firstVector.DotProduct(secondVector);
        Assert.AreEqual(-700, dotProduct);

    }
    [Test]
    public void Interpolate()
    {
        // Use the Assert class to test conditions
        MyVector firstVector = new MyVector(30, 40, 0);
        MyVector secondVector = new MyVector(60, 80, 0);
        float interpolation = 0.25f;
        MyVector interpolatedVector = firstVector.Interpolate(secondVector, interpolation);
        Assert.AreEqual(37.5f, interpolatedVector.X);
        Assert.AreEqual(50, interpolatedVector.Y);
        Assert.AreEqual(0, interpolatedVector.Z);
        Assert.AreEqual(30, firstVector.X);
        Assert.AreEqual(40, firstVector.Y);
        Assert.AreEqual(0, firstVector.Z);
        Assert.AreEqual(60, secondVector.X);
        Assert.AreEqual(80, secondVector.Y);
        Assert.AreEqual(0, secondVector.Z);

    }

    [Test]
    public void RotateX()
    {
        // Use the Assert class to test conditions
        MyVector firstVector = new MyVector(0, 30, 40);
        float rotation = (float)Math.PI / 2;
        MyVector rotatedVector = firstVector.RotateX(rotation);
        Assert.AreEqual(0, rotatedVector.X);
        Assert.AreEqual(-40f, rotatedVector.Y, 0.001);
        Assert.AreEqual(30f, rotatedVector.Z, 0.001);
        Assert.AreEqual(0, firstVector.X);
        Assert.AreEqual(30, firstVector.Y);
        Assert.AreEqual(40, firstVector.Z);

    }
    [Test]
    public void RotateY()
    {
        // Use the Assert class to test conditions
        MyVector firstVector = new MyVector(30, 0, 40);
        float rotation = (float)Math.PI / 2;
        MyVector rotatedVector = firstVector.RotateY(rotation);
        Assert.AreEqual(40f, rotatedVector.X, 0.001);
        Assert.AreEqual(0, rotatedVector.Y);
        Assert.AreEqual(-30f, rotatedVector.Z, 0.001);
        Assert.AreEqual(30, firstVector.X);
        Assert.AreEqual(0, firstVector.Y);
        Assert.AreEqual(40, firstVector.Z);
    }
    [Test]
    public void RotateZ()
    {
        // Use the Assert class to test conditions
        MyVector firstVector = new MyVector(30, 40, 0);
        float rotation = (float)Math.PI / 2;
        MyVector rotatedVector = firstVector.RotateZ(rotation);
        Assert.AreEqual(-40f, rotatedVector.X, 0.001);
        Assert.AreEqual(30f, rotatedVector.Y, 0.001);
        Assert.AreEqual(0, rotatedVector.Z);
        Assert.AreEqual(30, firstVector.X);
        Assert.AreEqual(40, firstVector.Y);
        Assert.AreEqual(0, firstVector.Z);
    }
    [Test]
    public void AngleBetween()
    {
        // Use the Assert class to test conditions
        MyVector firstVector = new MyVector(30, 40, 0);
        MyVector secondVector = new MyVector(-40, 30, 0);
        float angleBetween = firstVector.AngleBetween(secondVector);
        Assert.AreEqual(angleBetween, Math.PI / 2, 0.001);
        Assert.AreEqual(30, firstVector.X);
        Assert.AreEqual(40, firstVector.Y);
        Assert.AreEqual(0, firstVector.Z);
        Assert.AreEqual(-40, secondVector.X);
        Assert.AreEqual(30, secondVector.Y);
        Assert.AreEqual(0, secondVector.Z);
    }
    [Test]
    public void CrossProduct()
    {
        // Use the Assert class to test conditions
        MyVector firstVector = new MyVector(30, 40, 0);
        MyVector secondVector = new MyVector(-40, 30, 0);
        MyVector crossProduct = firstVector.CrossProduct(secondVector);
        Assert.AreEqual(0f, crossProduct.X, 0.001);
        Assert.AreEqual(0f, crossProduct.Y, 0.001);
        Assert.AreEqual(2500f, crossProduct.Z, 0.001);
        Assert.AreEqual(30, firstVector.X);
        Assert.AreEqual(40, firstVector.Y);
        Assert.AreEqual(0, firstVector.Z);
        Assert.AreEqual(-40, secondVector.X);
        Assert.AreEqual(30, secondVector.Y);
        Assert.AreEqual(0, secondVector.Z);

    }

}

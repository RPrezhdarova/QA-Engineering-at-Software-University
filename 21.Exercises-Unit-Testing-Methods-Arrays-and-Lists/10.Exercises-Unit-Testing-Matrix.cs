using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace TestApp.UnitTests;

public class MatrixTests
{
    [OneTimeSetUp]
    public void OneTimeSetUp()
    {

    }
    [Test]
    public void Test_MatrixAddition_ValidInput_ReturnsCorrectResult()
    {
        // Arrange
        List<List<int>> matrixA = new() { new() { 1, 2 }, new() { 3, 4 } };
        List<List<int>> matrixB = new() { new() { 5, 6 }, new() { 7, 8 } }; ;
        List<List<int>> expected = new() { new() { 6, 8 }, new() { 10, 12 } };

        // Act
        List<List<int>> actualResult = Matrix.MatrixAddition(matrixA, matrixB);

        // Assert
        Assert.That(actualResult, Is.EqualTo(expected));
    }

    [Test]
    public void Test_MatrixAddition_EmptyMatrices_ReturnsEmptyMatrix()
    {
        // Arrange
        List<List<int>> matrixA = new List<List<int>>();
        List<List<int>> matrixB = new List<List<int>>();
        List<List<int>> expectedResult = new List<List<int>>();

        //Act
        List<List<int>> actualResult = Matrix.MatrixAddition(matrixA, matrixB);

        //Assert
        Assert.That(actualResult, Is.Empty);

    }

    [Test]
    public void Test_MatrixAddition_DifferentDimensions_ThrowsArgumentException()
    {
        // Arrange
        List<List<int>> matrixA = new List<List<int>>()
        {
            new List<int>() {1, 2, 3 },
            new List<int>() {4, 5, 6 }
        };

        List<List<int>> matrixB = new List<List<int>>()
        {
            new List<int>() { 1, 2, 3 },
            new List<int>() { 4, 5, 6 },
            new List<int>() { 7, 8, 9 }
        };

        //Act
        //Assert
        Assert.Throws<ArgumentException>(() =>
            {
                Matrix.MatrixAddition(matrixA, matrixB);
            }, "Matrices must have the same dimensions for addition."); 
    }


    [Test]
    public void Test_MatrixAddition_NegativeNumbers_ReturnsCorrectResult()
    {

        // Arrange
        List<List<int>> matrixA = new() { new() { -1, -2 }, new() { -3, -4 } };
        List<List<int>> matrixB = new() { new() { -5, -6 }, new() { -7, -8 } }; ;
        List<List<int>> expected = new() { new() { -6, -8 }, new() { -10, -12 } };

        // Act
        List<List<int>> actualResult = Matrix.MatrixAddition(matrixA, matrixB);

        // Assert
        Assert.That(actualResult, Is.EqualTo(expected));
    }

    // TODO: finish test
    [Test]
    public void Test_MatrixAddition_ZeroMatrix_ReturnsOriginalMatrix()
    {
        // Arrange
        List<List<int>> matrixA = new List<List<int>>()
        {
            new List<int>() {0, 0, 0 },
            new List<int>() {0, 0, 0 }
        };

        List<List<int>> matrixB = new List<List<int>>()
        {
            new List<int>() {0, 0, 0 },
            new List<int>() {0, 0, 0 }

        };
        List<List<int>> expected = new List<List<int>>()
        {
            new List<int>() {0, 0, 0 },
            new List<int>() {0, 0, 0 }
        };

        // Act
        List<List<int>> actualResult = Matrix.MatrixAddition(matrixA, matrixB);

        // Assert
        Assert.That(actualResult, Is.EqualTo(expected));
    }
}

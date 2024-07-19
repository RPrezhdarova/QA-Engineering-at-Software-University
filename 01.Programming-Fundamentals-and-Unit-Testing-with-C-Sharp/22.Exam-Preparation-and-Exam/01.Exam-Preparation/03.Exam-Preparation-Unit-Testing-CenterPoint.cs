using System;
using System.Security.Cryptography;
using NUnit.Framework;

namespace TestApp.Tests;

public class CenterPointTests
{
    [Test]
    public void Test_GetClosest_WhenFirstPointIsCloser_ShouldReturnFirstPoint()
    {
        //Arrange
        string expectedResult = "(1, 1)";

        //Act
        string actualResult = CenterPoint.GetClosest(1, 1, 2, 2);
    
        //Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Test_GetClosest_WhenSecondPointIsCloser_ShouldReturnSecondPoint()
    {
        //Arrange
        string expectedResult = "(1, 1)";

        //Act
        string actualResult = CenterPoint.GetClosest(2, 2, 1, 1);

        //Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Test_GetClosest_WhenBothPointsHaveEqualDistance_ShouldReturnFirstPoint()
    {
        string expectedResult = "(1, 1)";
        string actualResult = CenterPoint.GetClosest(1, 1, 1, 1);

        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Test_GetClosest_WhenFirstPointIsNegative_ShouldReturnFirstPoint()
    {
        string expectedResult = "(-2, -2)";
        string actualResult = CenterPoint.GetClosest(-2, -2, 2, 2);
      
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Test_GetClosest_WhenSecondPointIsNegative_ShouldReturnSecondPoint()
    {
        string expectedResult = "(-2, -2)";
        string actualResult = CenterPoint.GetClosest(2, 2, -2, -2);

        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }
}

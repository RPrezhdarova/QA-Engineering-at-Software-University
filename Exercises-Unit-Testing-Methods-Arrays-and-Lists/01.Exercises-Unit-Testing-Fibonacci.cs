using NUnit.Framework;

namespace TestApp.UnitTests;

public class FibonacciTests
{
    [Test]
    public void Test_CalculateFibonacci_ZeroInput()
    {
        // Arrange
        int n = 0;

        // Act
        int actualResult = Fibonacci.CalculateFibonacci(n);

        // Assert
        int expectedResult = 0;
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Test_CalculateFibonacci_PositiveInput()
    {
        // Arrange
        int n = 10;
     
        // Act
        int actualResult = Fibonacci.CalculateFibonacci(n);

        // Assert
        int expectedResult = 55;
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }   
}

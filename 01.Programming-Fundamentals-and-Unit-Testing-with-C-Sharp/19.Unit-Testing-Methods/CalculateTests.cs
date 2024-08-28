using NUnit.Framework;

namespace TestApp.UnitTests;

public class CalculateTests
{
    [TestCase(1, 2, 3)]
    [TestCase(0, 5, 5)]
    [TestCase(5, 0, 5)]
    [TestCase(-10, 5, -5)]
    public void Test_Addition(int a, int b, int expected)
    {
        // Arrange
        Calculate calculator = new();

        // Act
        int actual = calculator.Addition(a, b);

        // Assert
        Assert.AreEqual(expected, actual, "Addition did not work properly.");
    }

    [Test]
    public void Test_Subtraction()
    {

        // Arrange
        Calculate calculator = new Calculate();
        int expectedResult = 3;

        // Act
        int actual = calculator.Subtraction(5, 2);

        // Assert
        Assert.AreEqual(expectedResult, actual);
    }
}

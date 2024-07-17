using NUnit.Framework;
namespace TestApp.UnitTests;
public class PrimeFactorTests
{
    [Test]
    public void Test_FindLargestPrimeFactor_PrimeNumber()
    {
        // Arrange
        long n = 3;

        // Act
        long actualResult = PrimeFactor.FindLargestPrimeFactor(n);

        // Assert
        int expectedResult = 3;
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Test_FindLargestPrimeFactor_LargeNumber()
    {
        // Arrange
        long n = 300;

        // Act
        long actualResult = PrimeFactor.FindLargestPrimeFactor(n);

        // Assert
        int expectedResult = 5;
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }
}

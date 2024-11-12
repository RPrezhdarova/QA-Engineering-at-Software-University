using NUnit.Framework;

namespace TestApp.Tests;

[TestFixture]
public class StringRotatorTests
{
    [Test]
    public void Test_RotateRight_EmptyString_ReturnsEmptyString()
    {
        //Arrange
        string input = string.Empty;
        int positions = 0;

        //Act
        string result = StringRotator.RotateRight(input, positions);

        //Assert
        Assert.That(result, Is.EqualTo(string.Empty));
    }

    [Test]
    public void Test_RotateRight_RotateByZeroPositions_ReturnsOriginalString()
    {
        //Arrange
        string input = "Hello";
        int positions = 0;
        string expected = "Hello";
        //Act
        string result = StringRotator.RotateRight(input, positions);

        //Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_RotateRight_RotateByPositivePositions_ReturnsRotatedString()
    {
        //Arrange
        string input = "Hello";
        int positions = 2;
        string expected = "loHel";
        //Act
        string result = StringRotator.RotateRight(input, positions);

        //Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_RotateRight_RotateByNegativePositions_ReturnsRotatedString()
    {
        //Arrange
        string input = "Hello";
        int positions = -2;
        string expected = "loHel";
        //Act
        string result = StringRotator.RotateRight(input, positions);

        //Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_RotateRight_RotateByMorePositionsThanStringLength_ReturnsRotatedString()
    {
        //Arrange
        string input = "Hello";
        int positions = 6;
        string expected = "oHell";
        //Act
        string result = StringRotator.RotateRight(input, positions);

        //Assert
        Assert.That(result, Is.EqualTo(expected));
    }
}

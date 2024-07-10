using NUnit.Framework;
using System;
namespace TestApp.UnitTests;

public class ReverserTests
{
    [Test]
    public void Test_ReverseStrings_WithEmptyArray_ReturnsEmptyArray()
    {
        // Arrange
        string[] inputArray = Array.Empty<string>();

        // Act
        string[] result = Reverser.ReverseStrings(inputArray);

        // Assert
        Assert.That(result, Is.Empty);
    }
  
    [Test]
    public void Test_ReverseStrings_WithSingleString_ReturnsReversedString()
    {
        // Arrange 
        string[] inputArray = new string[] { "Hello" };

        // Act
        string[] result = Reverser.ReverseStrings(inputArray);

        // Assert

        Assert.That(result, Is.EqualTo(new[] { "olleH" }));
    }

    [Test]
    public void Test_ReverseStrings_WithMultipleStrings_ReturnsReversedStrings()
    {
        // Arrange 
        string[] inputArray = new string[] { "Hello", "Rositsa" };

        // Act
        string[] result = Reverser.ReverseStrings(inputArray);

        // Assert

        Assert.That(result, Is.EqualTo(new[] { "olleH", "astisoR" }));
    }

    [Test]
    public void Test_ReverseStrings_WithSpecialCharacters_ReturnsReversedSpecialCharacters()
    {
        // Arrange 
        string[] inputArray = new string[] { "Hello!", "Rositsa" };

        // Act
        string[] result = Reverser.ReverseStrings(inputArray);

        // Assert

        Assert.That(result, Is.EqualTo(new[] { "!olleH", "astisoR" }));
    }
}

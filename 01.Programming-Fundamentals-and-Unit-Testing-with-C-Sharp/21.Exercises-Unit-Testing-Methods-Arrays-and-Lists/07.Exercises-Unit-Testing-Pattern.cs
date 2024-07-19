using NUnit.Framework;
using System;
namespace TestApp.UnitTests;

public class PatternTests
{
    [Test]
    public void Test_SortInPattern_SortsIntArrayInPattern_SortsCorrectly()
    {
        // Arrange
        int[] input = { 1, 2, 1, 3, 4, 10, 12, 15 };
        //Act
        int[] result = Pattern.SortInPattern(input);
        //Assert
        int[] expectedResult= new int[] { 1, 15, 2, 12, 3, 10, 4 };
        Assert.That(result, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Test_SortInPattern_EmptyArray_ReturnsEmptyArray()
    {
        // Arrange
        int[] input = {};
        //Act
        int[] result = Pattern.SortInPattern(input);
        //Assert
        Assert.That(result, Is.EqualTo(""));
    }

    [Test]
    public void Test_SortInPattern_SingleElementArray_ReturnsSameArray()
    {
        int[] input = { 1 };
        //Act
        int[] result = Pattern.SortInPattern(input);
        //Assert
        int[] expectedResult = new int[] { 1 };
        Assert.That(result, Is.EqualTo(expectedResult));
    }
}

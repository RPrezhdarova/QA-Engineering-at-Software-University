using NUnit.Framework;
using System;
namespace TestApp.Tests;

public class LongestIncreasingSubsequenceTests
{
    [Test]
    public void Test_GetLis_NullArray_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => LongestIncreasingSubsequence.GetLis(null));
    }
  
    [Test]
    public void Test_GetLis_EmptyArray_ReturnsEmptyString()
    {
        //Arrange
        int[] input = new int[] { };
        string expectedResult = "";

        //Act
        string actualResult=LongestIncreasingSubsequence.GetLis(input);

        //Assert
        Assert.That(expectedResult, Is.EqualTo(actualResult));
    }
  
    [Test]
    public void Test_GetLis_SingleElementArray_ReturnsElement()
    {
        //Arrange
        int[] input = new int[] { 1 };
        string expectedResult = "1";

        //Act
        string actualResult = LongestIncreasingSubsequence.GetLis(input);

        //Assert
        Assert.That(expectedResult, Is.EqualTo(actualResult));
    }

    [Test]
    public void Test_GetLis_UnsortedArray_ReturnsLongestIncreasingSubsequence()
    {
        //Arrange
        int[] input = new int[] { 10, 3, 5, 5, 60, 7 };
        string expectedResult = "3 5 60";

        //Act
        string actualResult = LongestIncreasingSubsequence.GetLis(input);

        //Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Test_GetLis_SortedArray_ReturnsItself()
    {
        //Arrange
        int[] input = new int[] { 1, 2, 3, 4, 5, 6 };
        string expectedResult = "1 2 3 4 5 6";

        //Act
        string actualResult = LongestIncreasingSubsequence.GetLis(input);

        //Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }
}

using System;
using NUnit.Framework;
namespace TestApp.Tests;

public class FoldSumTests
{
    [TestCase(new[] {1, 2, 3, 4, 5, 6, 7, 8}, "5 5 13 13")]
    [TestCase(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }, "7 7 7 19 19 19")]
    [TestCase(new[] { -1, -2, -3, -4 }, "-3 -7")]
    [TestCase(new[] { 1, -2, 3, -4, 5, -6, 7, -8, 9, -10, 11, -12 }, "-1 3 -5 -5 3 -1")]
    [TestCase(new[] { 1, 1, 1, 1 }, "2 2")]
    public void Test_FoldArray_ReturnsCorrectString(int[] arr, string expected)
    {
        //Act
        string actualResult = FoldSum.FoldArray(arr);
        //Assert
        Assert.That(actualResult, Is.EqualTo(expected));
    }
}

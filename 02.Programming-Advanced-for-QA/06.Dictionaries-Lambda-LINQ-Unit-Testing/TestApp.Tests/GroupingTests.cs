using NUnit.Framework;

using System;
using System.Collections.Generic;

namespace TestApp.Tests;

public class GroupingTests
{
    // TODO: finish test
    [Test]
    public void Test_GroupNumbers_WithEmptyList_ShouldReturnEmptyString()
    {
        // Arrange
        List<int> input = new List<int>();
        // Act
        string result = Grouping.GroupNumbers(input);
        // Assert
        Assert.That(result, Is.Empty);
    }

    [Test]
    public void Test_GroupNumbers_WithEvenAndOddNumbers_ShouldReturnGroupedString()
    {
        List<int> input = new List<int>() { 1, 2, 3, 4, 5, 6 };
        string expectedResult = $"Odd numbers: 1, 3, 5{Environment.NewLine}"+"Even numbers: 2, 4, 6";
        // Act
        string result = Grouping.GroupNumbers(input);
        // Assert
        Assert.That(result, Is.EqualTo(expectedResult));

    }

    [Test]
    public void Test_GroupNumbers_WithOnlyEvenNumbers_ShouldReturnGroupedString()
    {
        List<int> input = new List<int>() { 2, 4, 6 };
        string expectedResult = "Even numbers: 2, 4, 6";
        // Act
        string result = Grouping.GroupNumbers(input);
        // Assert
        Assert.That(result, Is.EqualTo(expectedResult));

    }

    [Test]
    public void Test_GroupNumbers_WithOnlyOddNumbers_ShouldReturnGroupedString()
    {
        List<int> input = new List<int>() { 1, 3, 5 };
        string expectedResult = "Odd numbers: 1, 3, 5";
        // Act
        string result = Grouping.GroupNumbers(input);
        // Assert
        Assert.That(result, Is.EqualTo(expectedResult));

    }

    [Test]
    public void Test_GroupNumbers_WithNegativeNumbers_ShouldReturnGroupedString()
    {
        List<int> input = new List<int>() { -1, -2, -3, -4, -5, -6 };
        string expectedResult = $"Odd numbers: -1, -3, -5{Environment.NewLine}" + "Even numbers: -2, -4, -6";
        // Act
        string result = Grouping.GroupNumbers(input);
        // Assert
        Assert.That(result, Is.EqualTo(expectedResult));
    }
}

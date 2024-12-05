using NUnit.Framework;
using System;
using System.Security.Cryptography;

namespace TestApp.Tests;

[TestFixture]
public class CsvParserTests
{
    [Test]
    public void Test_ParseCsv_EmptyInput_ReturnsEmptyArray()
    {
        //Arrange
        string input = string.Empty;
        string[] expected = Array.Empty<string>();

        //Act
        string[] result = CsvParser.ParseCsv(input);

        //Assert
        Assert.That(expected, Is.EqualTo(result));

    }

    [Test]
    public void Test_ParseCsv_SingleField_ReturnsArrayWithOneElement()
    {
        //Arrange
        string input = "one";
        string[] expected = {"one"};

        //Act
        string[] result = CsvParser.ParseCsv(input);

        //Assert
        Assert.That(expected, Is.EqualTo(result));
    }

    [Test]
    public void Test_ParseCsv_MultipleFields_ReturnsArrayWithMultipleElements()
    {
        //Arrange
        string input = "one, two, three, four, five";
        string[] expected = { "one", "two", "three", "four", "five" };

        //Act
        string[] result = CsvParser.ParseCsv(input);

        //Assert
        Assert.That(expected, Is.EqualTo(result));
    }

    [Test]
    public void Test_ParseCsv_TrimsWhiteSpace_ReturnsCleanArray()
    {
        //Arrange
        string input = "one two three four five";
        string[] expected = { "one two three four five" };

        //Act
        string[] result = CsvParser.ParseCsv(input);

        //Assert
        Assert.That(expected, Is.EqualTo(result));
    }
}

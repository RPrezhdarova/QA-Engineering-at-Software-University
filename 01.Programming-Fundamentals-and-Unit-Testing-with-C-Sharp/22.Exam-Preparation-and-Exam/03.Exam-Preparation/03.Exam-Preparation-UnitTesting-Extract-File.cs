using NUnit.Framework;
using System;
using System.Security.Cryptography;

namespace TestApp.Tests;

public class ExtractFileTests
{
    [Test]
    public void Test_GetFile_NullPath_ThrowsArgumentNullException()
    {
        string input = null;

        //Act & Assert
        Assert.Throws<ArgumentNullException>(() => ExtractFile.GetFile(input));
    }

    [Test]
    public void Test_GetFile_EmptyPath_ThrowsArgumentNullException()
    {
        string input = "";

        //Act & Assert
        Assert.Throws<ArgumentNullException>(() => ExtractFile.GetFile(input));
    }

    [Test]
    public void Test_GetFile_ValidPath_ReturnsFileNameAndExtension()
    {
        string input = "C:\\Users\\John\\Documents\\example.txt";
        string expectedResult = "File name: example\nFile extension: txt";

        //Act
        string actualResult = ExtractFile.GetFile(input);
        //Assert
        Assert.That(expectedResult, Is.EqualTo(actualResult));
    }

    [Test]
    public void Test_GetFile_PathWithNoExtension_ReturnsFileNameOnly()
    {
        string input = "C:\\Users\\John\\Documents\\example";
        string expectedResult = "File name: example";

        //Act
        string actualResult = ExtractFile.GetFile(input);
        //Assert
        Assert.That(expectedResult, Is.EqualTo(actualResult));
    }

    [Test]
    public void Test_GetFile_PathWithSpecialCharacters_ReturnsFileNameAndExtension()
    {
        string input = "C:\\Users\\John\\Documents?\\example.txt";
        string expectedResult = "File name: example\nFile extension: txt";

        //Act
        string actualResult = ExtractFile.GetFile(input);
        //Assert
        Assert.That(expectedResult, Is.EqualTo(actualResult));
    }
}

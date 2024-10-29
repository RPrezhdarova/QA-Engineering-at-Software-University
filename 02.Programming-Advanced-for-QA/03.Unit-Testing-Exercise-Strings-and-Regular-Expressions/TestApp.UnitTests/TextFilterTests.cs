using NUnit.Framework;

using System;

namespace TestApp.UnitTests;

public class TextFilterTests
{
    [Test]
    public void Test_Filter_WhenNoBannedWords_ShouldReturnOriginalText()
    {
        // Arrange
        string[] bannedWords = {};
        string input = "This is the original text.";
        string expectedResult= "This is the original text.";

        // Act
        string actualResult=TextFilter.Filter(bannedWords, input);

        // Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Test_Filter_WhenBannedWordExists_ShouldReplaceBannedWordWithAsterisks()
    {
        //Arrange
        string[] bannedWords = { "Rositsa", "Prezhdarova" };
        string input = "This is Rositsa Prezhdarova.";
        string expectedResult = "This is ******* ***********.";

        // Act
        string actualResult = TextFilter.Filter(bannedWords, input);

        // Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Test_Filter_WhenBannedWordsAreEmpty_ShouldReturnOriginalText()
    {
        //Arrange
        string[] bannedWords = Array.Empty<string>();
        string input = "This is Rositsa Prezhdarova.";
        string expectedResult = "This is Rositsa Prezhdarova.";

        // Act
        string actualResult = TextFilter.Filter(bannedWords, input);

        // Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Test_Filter_WhenBannedWordsContainWhitespace_ShouldReplaceBannedWord()
    {
        //Arrange
        string[] bannedWords = { " " };
        string input = "This is Rositsa Prezhdarova.";
        string expectedResult = "This*is*Rositsa*Prezhdarova.";

        // Act
        string actualResult = TextFilter.Filter(bannedWords, input);

        // Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }
}

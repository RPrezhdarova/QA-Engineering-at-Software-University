using NUnit.Framework;
using System;

namespace TestApp.UnitTests;

public class PatternTests
{

    [TestCase("abcdef", 4, "aBcDeFaBcDeFaBcDeFaBcDeF")]
    [TestCase("123", 3, "123123123")]
    [TestCase("abc def", 2, "aBc dEfaBc dEf")]
    [TestCase("Rositsa", 3, "rOsItSarOsItSarOsItSa")]
    public void Test_GeneratePatternedString_ValidInput_ReturnsExpectedResult(string input, 
        int repetitionFactor, string expected)
    {
        // Arrange

        // Act
        string result = Pattern.GeneratePatternedString(input, repetitionFactor);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_GeneratePatternedString_EmptyInput_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => Pattern.GeneratePatternedString(string.Empty, 3));
    }

    [Test]
    public void Test_GeneratePatternedString_NegativeRepetitionFactor_ThrowsArgumentException()
    {
        string input = "abc";
        Assert.Throws<ArgumentException>(() => Pattern.GeneratePatternedString(input, -3));
    }

    [Test]
    public void Test_GeneratePatternedString_ZeroRepetitionFactor_ThrowsArgumentException()
    {       
          string input = "abc";
          Assert.Throws<ArgumentException>(() => Pattern.GeneratePatternedString(input, 0));        
    }
}

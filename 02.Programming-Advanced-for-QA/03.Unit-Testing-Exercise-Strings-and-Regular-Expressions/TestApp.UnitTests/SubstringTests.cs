using NUnit.Framework;

namespace TestApp.UnitTests;

public class SubstringTests
{

    [Test]
    public void Test_RemoveOccurrences_RemovesSubstringFromMiddle()
    {
        // Arrange
        string toRemove = "fox";
        string input = "The quick brown fox jumps over the lazy dog";
        string expectedResult = "The quick brown jumps over the lazy dog";

        // Act
        string actualResult = Substring.RemoveOccurrences(toRemove, input);

        // Assert
        Assert.That(expectedResult, Is.EqualTo(actualResult));

    }

    [Test]
    public void Test_RemoveOccurrences_RemovesSubstringFromStart()
    {
        // Arrange
        string toRemove = "This";
        string input = "This is sample text";
        string expectedResult = "is sample text";

        // Act
        string actualResult = Substring.RemoveOccurrences(toRemove, input);

        // Assert
        Assert.That(expectedResult, Is.EqualTo(actualResult));
    }

    [Test]
    public void Test_RemoveOccurrences_RemovesSubstringFromEnd()
    {
        // Arrange
        string toRemove = "dog";
        string input = "The quick brown fox jumps over the lazy dog";
        string expectedResult = "The quick brown fox jumps over the lazy";

        // Act
        string actualResult = Substring.RemoveOccurrences(toRemove, input);

        // Assert
        Assert.That(expectedResult, Is.EqualTo(actualResult));
    }

    [Test]
    public void Test_RemoveOccurrences_RemovesAllOccurrences()
    {
        // Arrange
        string toRemove = "the";
        string input = "The quick the brown the fox jumps over the lazy the dog";
        string expectedResult = "quick brown fox jumps over lazy dog";

        // Act
        string actualResult = Substring.RemoveOccurrences(toRemove, input);

        // Assert
        Assert.That(expectedResult, Is.EqualTo(actualResult));
    }
}
 
using System.Collections.Generic;

using NUnit.Framework;

namespace TestApp.Tests;

[TestFixture]
public class DictionaryIntersectionTests
{
    [Test]
    public void Test_Intersect_TwoEmptyDictionaries_ReturnsEmptyDictionary()
    {
        //Arrange
        Dictionary<string, int> dict1 = new();
        Dictionary<string, int> dict2 = new();
        Dictionary<string, int> expected = new();

        //Act
        Dictionary<string, int> result = DictionaryIntersection.Intersect(dict1, dict2);

        //Assert
        Assert.That(result, Is.EquivalentTo(expected));
    }

    [Test]
    public void Test_Intersect_OneEmptyDictionaryAndOneNonEmptyDictionary_ReturnsEmptyDictionary()
    {
        //Arrange
        Dictionary<string, int> dict1 = new()
        {
            {"first", 1},
            { "second", 2 },
            { "third", 3 }
        };
        Dictionary<string, int> dict2 = new();
        Dictionary<string, int> expected = new();

        //Act
        Dictionary<string, int> result = DictionaryIntersection.Intersect(dict1, dict2);

        //Assert
        Assert.That(result, Is.EquivalentTo(expected));
    }

    [Test]
    public void Test_Intersect_TwoNonEmptyDictionariesWithNoCommonKeys_ReturnsEmptyDictionary()
    {
        //Arrange
        Dictionary<string, int> dict1 = new()
        {
            {"first", 1},
            { "second", 2 },
            { "third", 3 }
        };
        Dictionary<string, int> dict2 = new()
        {
            { "fourth", 4 },
            { "fifth", 5 },
            { "sixth", 6 }
        };
        Dictionary<string, int> expected = new();

        //Act
        Dictionary<string, int> result = DictionaryIntersection.Intersect(dict1, dict2);

        //Assert
        Assert.That(result, Is.EquivalentTo(expected));
    }

    [Test]
    public void Test_Intersect_TwoNonEmptyDictionariesWithCommonKeysAndValues_ReturnsIntersectionDictionary()
    {
        //Arrange
        Dictionary<string, int> dict1 = new()
        {
            {"first", 1},
            { "second", 2 },
            { "third", 3 }
        };
        Dictionary<string, int> dict2 = new()
        {
            { "second", 2 },
            { "third", 3 },
            { "fourth", 3 }
        };
        Dictionary<string, int> expected = new()
        {
            { "second", 2 },
            { "third",3 }
        };

        //Act
        Dictionary<string, int> result = DictionaryIntersection.Intersect(dict1, dict2);

        //Assert
        Assert.That(result, Is.EquivalentTo(expected));
    }

    [Test]
    public void Test_Intersect_TwoNonEmptyDictionariesWithCommonKeysAndDifferentValues_ReturnsEmptyDictionary()
    {
        //Arrange
        Dictionary<string, int> dict1 = new()
        {
            {"first", 1},
            { "second", 2 },
            { "third", 3 }
        };
        Dictionary<string, int> dict2 = new()
        {
            { "second", 4 },
            { "third", 5 },
            { "fourth", 6 }
        };
        Dictionary<string, int> expected = new();

        //Act
        Dictionary<string, int> result = DictionaryIntersection.Intersect(dict1, dict2);

        //Assert
        Assert.That(result, Is.EquivalentTo(expected));
    }
}

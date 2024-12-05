using System.Collections.Generic;

using NUnit.Framework;

namespace TestApp.Tests;

[TestFixture]
public class FruitsTests
{
    [Test]
    public void Test_GetFruitQuantity_FruitExists_ReturnsQuantity()
    {
        //Arrange
        Dictionary<string, int> input = new()
        {
            ["apple"] = 1,
            ["banana"] = 2,
            ["kiwi"] = 3
        };
        string fruitName = "kiwi";
        int expected = 3;

        //Act
        int result=Fruits.GetFruitQuantity(input, fruitName);

        //Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_GetFruitQuantity_FruitDoesNotExist_ReturnsZero()
    {
        //Arrange
        Dictionary<string, int> input = new()
        {
            ["apple"] = 1,
            ["banana"] = 2,
            ["kiwi"] = 3
        };
        string fruitName = "cherry";
        int expected = 0;

        //Act
        int result = Fruits.GetFruitQuantity(input, fruitName);

        //Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_GetFruitQuantity_EmptyDictionary_ReturnsZero()
    {
        //Arrange
        Dictionary<string, int> input = new();
        string fruitName = "kiwi";
        int expected = 0;

        //Act
        int result = Fruits.GetFruitQuantity(input, fruitName);

        //Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_GetFruitQuantity_NullDictionary_ReturnsZero()
    {
        //Arrange
        Dictionary<string, int> input = null;
        string fruitName = "kiwi";
        int expected = 0;

        //Act
        int result = Fruits.GetFruitQuantity(input, fruitName);

        //Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_GetFruitQuantity_NullFruitName_ReturnsZero()
    {
        //Arrange
        Dictionary<string, int> input = new()
        {
            ["apple"] = 1,
            ["banana"] = 2,
            ["kiwi"] = 3
        };
        string fruitName = null;
        int expected = 0;

        //Act
        int result = Fruits.GetFruitQuantity(input, fruitName);

        //Assert
        Assert.That(result, Is.EqualTo(expected));
    }
}

using NUnit.Framework;

using System;

namespace TestApp.Tests;

public class PlantsTests
{
    [Test]
    public void Test_GetFastestGrowing_WithEmptyArray_ShouldReturnEmptyString()
    {
        string[] input = Array.Empty<string>();
        string result = Plants.GetFastestGrowing(input);
        Assert.That(result, Is.Empty);
    }

    // TODO: finish test
    [Test]
    public void Test_GetFastestGrowing_WithSinglePlant_ShouldReturnPlant()
    {
        // Arrange
        string[] plants = new string[] { "Rose" };
        string expected = $"Plants with 4 letters:{Environment.NewLine}Rose";
        // Act
        string result = Plants.GetFastestGrowing(plants);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_GetFastestGrowing_WithMultiplePlants_ShouldReturnGroupedPlants()
    {
        // Arrange
        string[] plants = new string[] { "Dahlia", "Rose", "Mint", "Tulip" };
        string expected = $"Plants with 4 letters:{Environment.NewLine}" +
                           $"Rose{Environment.NewLine}" +
                           $"Mint{Environment.NewLine}" +
                           $"Plants with 5 letters:{Environment.NewLine}" +
                           $"Tulip{Environment.NewLine}" +
                           $"Plants with 6 letters:{Environment.NewLine}" +
                           $"Dahlia";
        // Act
        string result = Plants.GetFastestGrowing(plants);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_GetFastestGrowing_WithMixedCasePlants_ShouldBeCaseInsensitive()
    {
        string[] plants = new string[] { "DaHlia", "ROse", "MInt", "TulIp", "mInt" };
        string expected = $"Plants with 4 letters:{Environment.NewLine}" +
                           $"ROse{Environment.NewLine}" +
                           $"MInt{Environment.NewLine}" +
                           $"mInt{Environment.NewLine}" +
                           $"Plants with 5 letters:{Environment.NewLine}" +
                           $"TulIp{Environment.NewLine}" +
                           $"Plants with 6 letters:{Environment.NewLine}" +
                           $"DaHlia";
        // Act
        string result = Plants.GetFastestGrowing(plants);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
}

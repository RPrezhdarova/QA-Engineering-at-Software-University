using NUnit.Framework;
using System;

using System.Collections.Generic;
namespace TestApp.Tests;

public class DrumSetTests
{
    [Test]
    public void Test_Drum_TerminateCommandNotGiven_ThrowsArgumentException()
    {
        decimal initialMoney = 50m;
        List<int> initialQuality = new List<int> { 5, 10, 15 };
        List<string> commands = new List<string> { "5" };

        // Act & Assert
        var ex = Assert.Throws<ArgumentException>(() => DrumSet.Drum(initialMoney, initialQuality, commands));
        Assert.AreEqual("Terminate command not given!", ex.Message);
    }

    [Test]
    public void Test_Drum_StringGivenAsCommand_ThrowsArgumentException()
    {
        decimal initialMoney = 50m;
        List<int> initialQuality = new List<int> { 5, 10, 15 };
        List<string> commands = new List<string> { "" };

        // Act & Assert
        var ex = Assert.Throws<ArgumentException>(() => DrumSet.Drum(initialMoney, initialQuality, commands));
        Assert.AreEqual("Number did not parse correctly!", ex.Message);        
    }

    [Test]
    public void Test_Drum_ReturnsCorrectQualityAndAmount()
    {
        decimal money = 30m;
        List<int> drums = new List<int> { 5, 10, 15 };
        List<string> commands = new List<string>() { "4", "5", "Hit it again, Gabsy!" };
        string actualResult = DrumSet.Drum(money, drums, commands);

        string expectedResult = "5 1 6\nGabsy has 15.00lv.";
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Test_Drum_BalanceZero_WithOneDrumLeftOver_ReturnsCorrectQualityAndAmount()
    {
        decimal money = 0m;
        List<int> drums = new List<int> { 5, 6, 4 };
        List<string> commands = new List<string>() { "3", "2", "Hit it again, Gabsy!" };
        string actualResult = DrumSet.Drum(money, drums, commands);

        string expectedResult = "1\nGabsy has 0.00lv.";
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Test_Drum_NotEnoughBalance_RemovesAllDrums_ReturnsCorrectQualityAndAmount()
    {
        decimal money = 10m;
        List<int> initialQuality = new List<int> { 5, 8, 12 };
        List<string> commands = new List<string> { "5", "4", "3", "Hit it again, Gabsy!" };
        string actualResult = DrumSet.Drum(money, initialQuality, commands);

        string expectedResult = "\nGabsy has 10.00lv.";
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }
}

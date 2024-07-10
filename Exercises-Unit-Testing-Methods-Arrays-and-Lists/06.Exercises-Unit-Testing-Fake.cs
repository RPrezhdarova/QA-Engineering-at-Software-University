using NUnit.Framework;
using System;
namespace TestApp.UnitTests;

public class FakeTests
{
    [Test]
    public void Test_RemoveStringNumbers_RemovesDigitsFromCharArray()
    {
        char[] input = new char[] {'R', '9'};
        char[] result = Fake.RemoveStringNumbers(input);
        char[] expectedResult = { 'R' };
        Assert.That(expectedResult, Is.EqualTo(result));
    }

    [Test]
    public void Test_RemoveStringNumbers_NoDigitsInInput_ReturnsSameArray()
    {
        char[] input = new char[] { 'R', 'o', 's', 'i' };
        char[] result = Fake.RemoveStringNumbers(input);
        char[] expectedResult = { 'R', 'o', 's', 'i' };
        Assert.That(expectedResult, Is.EqualTo(result));
    }

    [Test]
    public void Test_RemoveStringNumbers_EmptyArray_ReturnsEmptyArray()
    {
        char[] input = new char[] {  };
        char[] result = Fake.RemoveStringNumbers(input);
        char[] expectedResult = {  };
        Assert.That(expectedResult, Is.EqualTo(result));
    }
}

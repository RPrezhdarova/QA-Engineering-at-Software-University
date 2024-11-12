using NUnit.Framework;

using System;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using System.Security.Cryptography;

namespace TestApp.UnitTests;

public class ExceptionTests
{
    private Exceptions _exceptions = null!;

    [SetUp]
    public void SetUp()
    {
        this._exceptions = new();
    }

    [Test]
    public void Test_Reverse_ValidString_ReturnsReversedString()
    {
        // Arrange
        string input = "Hallo";
        string expected = "ollaH";

        // Act
        string result = _exceptions.ArgumentNullReverse(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_Reverse_NullString_ThrowsArgumentNullException()
    {
        // Arrange
        string input = null;

        // Act & Assert
        Assert.That(() => this._exceptions.ArgumentNullReverse(input), Throws.ArgumentNullException);
    }

    [Test]
    public void Test_CalculateDiscount_ValidInput_ReturnsDiscountedPrice()
    {
        // Arrange
        decimal totalPrice = 100.0m;
        decimal discount = 50.0m;
        decimal expectedResult = 50.0m;

        // Acat
        decimal actualResult = this._exceptions.ArgumentCalculateDiscount(totalPrice, discount);

        // Act & Assert
        Assert.That(expectedResult, Is.EqualTo(actualResult));

    }

    [Test]
    public void Test_CalculateDiscount_NegativeDiscount_ThrowsArgumentException()
    {
        // Arrange
        decimal totalPrice = 100.0m;
        decimal discount = -50.0m;

        // Act & Assert
        Assert.That(() => this._exceptions.ArgumentCalculateDiscount(totalPrice, discount), Throws.ArgumentException);
    }

    [Test]
    public void Test_CalculateDiscount_DiscountOver100_ThrowsArgumentException()
    {
        // Arrange
        decimal totalPrice = 100.0m;
        decimal discount = 110.0m;

        // Act & Assert
        Assert.That(() => this._exceptions.ArgumentCalculateDiscount(totalPrice, discount), Throws.ArgumentException);
    }

    [Test]
    public void Test_GetElement_ValidIndex_ReturnsElement()
    {
        int[] array = { 1, 2, 3 };
        int index = 2;
        int expectedResult = 3;

        int result = this._exceptions.IndexOutOfRangeGetElement(array, index);

        Assert.That(result, Is.EqualTo(expectedResult));

    }

    [Test]
    public void Test_GetElement_IndexLessThanZero_ThrowsIndexOutOfRangeException()
    {
        // Arrange
        int[] array = { 1, 2, 3 };
        int index = -2;

        // Act & Assert
        Assert.That(() => this._exceptions.IndexOutOfRangeGetElement(array, index), Throws.InstanceOf<IndexOutOfRangeException>());
    }

    [Test]
    public void Test_GetElement_IndexEqualToArrayLength_ThrowsIndexOutOfRangeException()
    {
        // Arrange
        int[] array = { 10, 20, 30, 40, 50 };
        int index = array.Length;

        // Act & Assert
        Assert.That(() => this._exceptions.IndexOutOfRangeGetElement(array, index), Throws.InstanceOf<IndexOutOfRangeException>());
    }

    [Test]
    public void Test_GetElement_IndexGreaterThanArrayLength_ThrowsIndexOutOfRangeException()
    {
        // Arrange
        int[] array = { 10, 20, 30, 40, 50 };
        int index = array.Length + 20;

        // Act & Assert
        Assert.That(() => this._exceptions.IndexOutOfRangeGetElement(array, index), Throws.InstanceOf<IndexOutOfRangeException>());
    }

    [Test]
    public void Test_PerformSecureOperation_UserLoggedIn_ReturnsUserLoggedInMessage()
    {
        bool isLoggedIn = true;
        string expected = "User logged in.";

        string result = this._exceptions.InvalidOperationPerformSecureOperation(isLoggedIn);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_PerformSecureOperation_UserNotLoggedIn_ThrowsInvalidOperationException()
    {
        bool isLoggedIn = false;

        Assert.That(() => _exceptions.InvalidOperationPerformSecureOperation(isLoggedIn), Throws.Exception.InstanceOf<InvalidOperationException>());
    }

    [Test]
    public void Test_ParseInt_ValidInput_ReturnsParsedInteger()
    {
        string input = "3";
        int expected = 3;

        int result = this._exceptions.FormatExceptionParseInt(input);
        Assert.That(result, Is.EqualTo(expected));

    }

    [Test]
    public void Test_ParseInt_InvalidInput_ThrowsFormatException()
    {
        string input = "abc";

        Assert.That(() => this._exceptions.FormatExceptionParseInt(input), Throws.InstanceOf<FormatException>());
    }

    [Test]
    public void Test_FindValueByKey_KeyExistsInDictionary_ReturnsValue()
    {
        Dictionary<string, int> dictionary = new()
        {
            ["first"] = 10,
            ["second"] = 15,
            ["third"] = 20
        };
        string key = "second";
        int expected =15;
        int result=this._exceptions.KeyNotFoundFindValueByKey(dictionary, key);

        Assert.That(result,Is.EqualTo(expected));
    }

    [Test]
    public void Test_FindValueByKey_KeyDoesNotExistInDictionary_ThrowsKeyNotFoundException()
    {
        Dictionary<string, int> dictionary = new()
        {
            ["first"] = 10,
            ["second"] = 15,
            ["third"] = 20
        };
        string key = "zero";

        Assert.That(()=> this._exceptions.KeyNotFoundFindValueByKey(dictionary, key), Throws.InstanceOf<KeyNotFoundException>());
    }

    [Test]
    public void Test_AddNumbers_NoOverflow_ReturnsSum()
    {
        int a = 100;
        int b = 200;
        int expected = 300;
        int result=this._exceptions.OverflowAddNumbers(a, b);
        Assert.That(result,Is.EqualTo(expected));
    }

    [Test]
    public void Test_AddNumbers_PositiveOverflow_ThrowsOverflowException()
    {
        int a = int.MaxValue;
        int b = 200;

        Assert.That(()=>this._exceptions.OverflowAddNumbers(a, b), Throws.InstanceOf<OverflowException>());
    }

    [Test]
    public void Test_AddNumbers_NegativeOverflow_ThrowsOverflowException()
    {
        int a = int.MinValue;
        int b = -200;

        Assert.That(() => this._exceptions.OverflowAddNumbers(a, b), Throws.InstanceOf<OverflowException>());
    }

    [Test]
    public void Test_DivideNumbers_ValidDivision_ReturnsQuotient()
    {
        int dividend = 200;
        int divisor = 50;

        int expected = 4;
        int result=this._exceptions.DivideByZeroDivideNumbers(dividend, divisor);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_DivideNumbers_DivideByZero_ThrowsDivideByZeroException()
    {
        int dividend = 200;
        int divisor = 0;

        Assert.That(()=> this._exceptions.DivideByZeroDivideNumbers(dividend, divisor), Throws.InstanceOf<DivideByZeroException>());
    }

    [Test]
    public void Test_SumCollectionElements_ValidCollectionAndIndex_ReturnsSum()
    {
        int[] collection = new[] { 1, 2, 3 };
        int index = 2;
        int expected = 6;

        int result=this._exceptions.SumCollectionElements(collection, index);

        Assert.That(result, Is.EqualTo(expected));

    }

    [Test]
    public void Test_SumCollectionElements_NullCollection_ThrowsArgumentNullException()
    {
        int[] collection = null;
        int index = 2;

        Assert.That(()=>this._exceptions.SumCollectionElements(collection, index), Throws.InstanceOf<ArgumentNullException>());
    }

    [Test]
    public void Test_SumCollectionElements_IndexOutOfRange_ThrowsIndexOutOfRangeException()
    {
        int[] collection = new[] { 1, 2, 3 };
        int index = 6;

        Assert.That(() => this._exceptions.SumCollectionElements(collection, index), Throws.InstanceOf<IndexOutOfRangeException>());
    }

    [Test]
    public void Test_GetElementAsNumber_ValidKey_ReturnsParsedNumber()
    {
        Dictionary<string, string> collection = new()
        {
            ["first"] = "1",
            ["second"] = "2",
            ["third"] = "3"
        };
        string key = "first";
        int expected = 1;
        int result= this._exceptions.GetElementAsNumber(collection, key);
        Assert.That(result, Is.EqualTo(expected));

    }

    [Test]
    public void Test_GetElementAsNumber_KeyNotFound_ThrowsKeyNotFoundException()
    {
        Dictionary<string, string> collection = new()
        {
            ["first"] = "1",
            ["second"] = "2",
            ["third"] = "3"
        };
        string key = "zero";

        Assert.That(()=> this._exceptions.GetElementAsNumber(collection, key), Throws.InstanceOf<KeyNotFoundException>());
    }

    [Test]
    public void Test_GetElementAsNumber_InvalidFormat_ThrowsFormatException()
    {
        Dictionary<string, string> collection = new()
        {
            ["first"] = "fi",
            ["second"] = "2",
            ["third"] = "3"
        };
        string key = "first";

        Assert.That(()=> this._exceptions.GetElementAsNumber(collection, key), Throws.InstanceOf<FormatException>());
    }
}

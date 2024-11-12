using System;
using NUnit.Framework;
using static NUnit.Framework.Constraints.Tolerance;

namespace TestApp.Tests;

public class OrdersTests
{
    [Test]
    public void Test_Order_WithEmptyInput_ShouldReturnEmptyString()
    {
        string[] input = Array.Empty<string>();
        String result = Orders.Order(input);
        Assert.That(result, Is.Empty);
    }

    // TODO: finish test
    [Test]
    public void Test_Order_WithMultipleOrders_ShouldReturnTotalPrice()
    {
        // Arrange
        string[] input = new[] { "apple 1.5 1", "apple 1.2 1", "banana 3.75 1", "apple 1.99 1", "orange 1.98 1" };
        // Act
        string result = Orders.Order(input);

        // Assert
        Assert.That(result, Is.EqualTo($"apple -> 5.97{Environment.NewLine}banana -> 3.75{Environment.NewLine}orange -> 1.98"));
    }

    [Test]
    public void Test_Order_WithRoundedPrices_ShouldReturnTotalPrice()
    {
        // Arrange
        string[] input = new[] { "apple 1.00 3", "banana 10.00 10", "orange 3.00 3" };
        // Act
        string result = Orders.Order(input);

        // Assert
        Assert.That(result, Is.EqualTo($"apple -> 3.00{Environment.NewLine}banana -> 100.00{Environment.NewLine}orange -> 9.00"));
    }

    [Test]
    public void Test_Order_WithDecimalQuantities_ShouldReturnTotalPrice()
    {
        // Arrange
        string[] input = new[] { "apple 1.5 1.5", "apple 1.2 1.5", "banana 3.75 1.7", "apple 1.99 4.6", "orange 1.98 2.9" };
        // Act
        string result = Orders.Order(input);

        // Assert
        Assert.That(result, Is.EqualTo($"apple -> 15.12{Environment.NewLine}banana -> 6.38{Environment.NewLine}orange -> 5.74"));
    }
}

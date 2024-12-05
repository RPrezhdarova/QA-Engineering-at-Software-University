using NUnit.Framework;
using System;
using TestApp.Product;

namespace TestApp.Tests;

[TestFixture]
public class ProductInventoryTests
{
    private ProductInventory _inventory = null!;
    
    [SetUp]
    public void SetUp()
    {
        this._inventory = new();
    }
    
    [Test]
    public void Test_AddProduct_ProductAddedToInventory()
    {
        //Arrange
        string name = "Apple";
        double price = 12.00;
        int quantity = 15;
        string expected = $"Product Inventory:{Environment.NewLine}" + $"Apple - Price: $12.00 - Quantity: 15";

        //Act
        _inventory.AddProduct(name, price, quantity);
        string resul = _inventory.DisplayInventory();

        //Assert
        Assert.That(resul, Is.EqualTo(expected));

    }

    [Test]
    public void Test_DisplayInventory_NoProducts_ReturnsEmptyString()
    {
        //Arrange        
        string expected = "Product Inventory:";

        //Act        
        string resul = _inventory.DisplayInventory();

        //Assert
        Assert.That(resul, Is.EqualTo(expected));
    }

    [Test]
    public void Test_DisplayInventory_WithProducts_ReturnsFormattedInventory()
    {
        //Arrange
        string name = "Apple";
        double price = 12.00;
        int quantity = 15;
        string name2 = "Orange";
        double price2 = 20.00;
        int quantity2 = 2;
        string expected = $"Product Inventory:{Environment.NewLine}" + 
            $"Apple - Price: $12.00 - Quantity: 15{Environment.NewLine}" +
            $"Orange - Price: $20.00 - Quantity: 2";

        //Act
        _inventory.AddProduct(name, price, quantity);
        _inventory.AddProduct(name2, price2, quantity2);
        string resul = _inventory.DisplayInventory();

        //Assert
        Assert.That(resul, Is.EqualTo(expected));
    }

    [Test]
    public void Test_CalculateTotalValue_NoProducts_ReturnsZero()
    {
        //Arrange        
        double expected = 0;

        //Act        
        double resul = _inventory.CalculateTotalValue();

        //Assert
        Assert.That(resul, Is.EqualTo(expected));
    }

    [Test]
    public void Test_CalculateTotalValue_WithProducts_ReturnsTotalValue()
    {
        //Arrange
        string name = "Apple";
        double price = 12.00;
        int quantity = 15;
        string name2 = "Orange";
        double price2 = 20.00;
        int quantity2 = 2;
        double expected = 220;

        //Act
        _inventory.AddProduct(name, price, quantity);
        _inventory.AddProduct(name2, price2, quantity2);
        double resul = _inventory.CalculateTotalValue();

        //Assert
        Assert.That(resul, Is.EqualTo(expected));
    }
}

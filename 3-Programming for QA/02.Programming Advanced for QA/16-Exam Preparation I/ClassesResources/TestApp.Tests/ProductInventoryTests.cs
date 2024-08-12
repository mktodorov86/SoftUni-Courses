using NUnit.Framework;
using System;
using TestApp.Product;

namespace TestApp.Tests
{
    [TestFixture]
    public class ProductInventoryTests
    {
        private ProductInventory _inventory = null!;

        [SetUp]
        public void SetUp()
        {
            this._inventory = new ProductInventory();
        }

        [Test]
        public void Test_AddMultipleProducts_DisplaysAllProducts()
        {
            // Arrange
            this._inventory.AddProduct("Product A", 5.99, 10);
            this._inventory.AddProduct("Product B", 12.49, 4);

            // Act
            string result = this._inventory.DisplayInventory();

            // Assert
            string expected = $"Product Inventory:{Environment.NewLine}" +
                $"Product A - Price: $5.99 - Quantity: 10{Environment.NewLine}" +
                $"Product B - Price: $12.49 - Quantity: 4";




            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Test_DisplayInventory_FormatsPriceCorrectly()
        {
            // Arrange
            this._inventory.AddProduct("Product C", 1.255, 2); // Price with more than 2 decimal places

            // Act
            string result = this._inventory.DisplayInventory();

            // Assert
            string expected = $"Product Inventory:{Environment.NewLine}" +
                $"Product C - Price: $1.25 - Quantity: 2"; // Price should be rounded to two decimal places
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Test_AddProduct_UpdatesInventoryCorrectly()
        {
            // Arrange
            this._inventory.AddProduct("Product D", 20.00, 1);
            this._inventory.AddProduct("Product E", 30.00, 2);

            // Act
            string result = this._inventory.DisplayInventory();

            // Assert
            string expected = $"Product Inventory:{Environment.NewLine}" +
                $"Product D - Price: $20.00 - Quantity: 1{Environment.NewLine}" +
                $"Product E - Price: $30.00 - Quantity: 2";




            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Test_CalculateTotalValue_MultipleProducts()
        {
            // Arrange
            this._inventory.AddProduct("Product F", 7.50, 3); // 7.50 * 3 = 22.50
            this._inventory.AddProduct("Product G", 14.75, 2); // 14.75 * 2 = 29.50

            // Act
            double result = this._inventory.CalculateTotalValue();

            // Assert
            Assert.AreEqual(52.00, result); // Total is 22.50 + 29.50
        }

        [Test]
        public void Test_DisplayInventory_EmptyInventoryShowsHeaderOnly()
        {
            // Act
            string result = this._inventory.DisplayInventory();

            // Assert
            string expected = "Product Inventory:";
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Test_CalculateTotalValue_EmptyInventory_ReturnsZero()
        {
            // Act
            double result = this._inventory.CalculateTotalValue();

            // Assert
            Assert.AreEqual(0.0, result);
        }
    }
}

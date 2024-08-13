using System.Collections.Generic;
using NUnit.Framework;

namespace TestApp.Tests
{
    [TestFixture]
    public class FruitsTests
    {
        [Test]
        public void Test_GetFruitQuantity_FruitExists_ReturnsQuantity()
        {
            // Arrange
            var fruitDictionary = new Dictionary<string, int>
            {
                { "Apple", 10 },
                { "Banana", 5 }
            };
            string fruitName = "Apple";

            // Act
            int result = Fruits.GetFruitQuantity(fruitDictionary, fruitName);

            // Assert
            Assert.AreEqual(10, result);
        }

        [Test]
        public void Test_GetFruitQuantity_FruitDoesNotExist_ReturnsZero()
        {
            // Arrange
            var fruitDictionary = new Dictionary<string, int>
            {
                { "Apple", 10 },
                { "Banana", 5 }
            };
            string fruitName = "Orange";

            // Act
            int result = Fruits.GetFruitQuantity(fruitDictionary, fruitName);

            // Assert
            Assert.AreEqual(0, result);
        }

        [Test]
        public void Test_GetFruitQuantity_EmptyDictionary_ReturnsZero()
        {
            // Arrange
            var fruitDictionary = new Dictionary<string, int>();
            string fruitName = "Apple";

            // Act
            int result = Fruits.GetFruitQuantity(fruitDictionary, fruitName);

            // Assert
            Assert.AreEqual(0, result);
        }

        [Test]
        public void Test_GetFruitQuantity_NullDictionary_ReturnsZero()
        {
            // Arrange
            Dictionary<string, int>? fruitDictionary = null;
            string fruitName = "Apple";

            // Act
            int result = Fruits.GetFruitQuantity(fruitDictionary, fruitName);

            // Assert
            Assert.AreEqual(0, result);
        }

        [Test]
        public void Test_GetFruitQuantity_NullFruitName_ReturnsZero()
        {
            // Arrange
            var fruitDictionary = new Dictionary<string, int>
            {
                { "Apple", 10 },
                { "Banana", 5 }
            };
            string? fruitName = null;

            // Act
            int result = Fruits.GetFruitQuantity(fruitDictionary, fruitName);

            // Assert
            Assert.AreEqual(0, result);
        }
    }
}

using NUnit.Framework;
using System.Linq;
using TestApp; // Assuming Reverser class is in the TestApp namespace

namespace TestApp.UnitTests
{
    [TestFixture]
    public class ReverserTests
    {
        [Test]
        public void Test_ReverseStrings_WithEmptyArray_ReturnsEmptyArray()
        {
            // Arrange
            string[] input = { };
            string[] expected = { };

            // Act
            string[] result = Reverser.ReverseStrings(input);

            // Assert
            CollectionAssert.AreEqual(expected, result);
        }

        [Test]
        public void Test_ReverseStrings_WithSingleString_ReturnsReversedString()
        {
            // Arrange
            string[] inputArray = { "hello" };
            string expected = "olleh";

            // Act
            string[] resultArray = Reverser.ReverseStrings(inputArray);

            // Assert
            Assert.AreEqual(expected, resultArray[0]); // Directly check the first element
        }

        [Test]
        public void Test_ReverseStrings_WithMultipleStrings_ReturnsReversedStrings()
        {
            // Arrange
            string[] inputArray = { "hello", "world", "dotnet" };
            string[] expectedArray = { "olleh", "dlrow", "tentod" };

            // Act
            string[] resultArray = Reverser.ReverseStrings(inputArray);

            // Assert
            CollectionAssert.AreEqual(expectedArray, resultArray);
        }

        [Test]
        public void Test_ReverseStrings_WithSpecialCharacters_ReturnsReversedSpecialCharacters()
        {
            // Arrange
            string[] inputArray = { "Hello! World?", "Dot.net, Example!" };
            string[] expectedArray = { "?dlroW !olleH", "!elpmaxE ,ten.toD" };

            // Act
            string[] resultArray = Reverser.ReverseStrings(inputArray);

            // Assert
            CollectionAssert.AreEqual(expectedArray, resultArray);
        }
    }
}

using NUnit.Framework;
using System.Linq;
using System;

namespace TestApp.UnitTests
{
    public class ReverseConcatenateTests
    {
        [Test]
        public void Test_ReverseAndConcatenateStrings_EmptyInput_ReturnsEmptyString()
        {
            // Arrange
            string[] input = Array.Empty<string>();

            // Act
            string result = ReverseConcatenate.ReverseAndConcatenateStrings(input);

            // Assert
            Assert.That(result, Is.EqualTo(string.Empty));
        }

        [Test]
        public void Test_ReverseAndConcatenateStrings_SingleString_ReturnsSameString()
        {
            // Arrange
            string[] input = { "single" };

            // Act
            string result = ReverseConcatenate.ReverseAndConcatenateStrings(input);

            // Assert
            Assert.That(result, Is.EqualTo("single"));
        }

        [Test]
        public void Test_ReverseAndConcatenateStrings_MultipleStrings_ReturnsReversedConcatenatedString()
        {
            // Arrange
            string[] input = { "first", "second", "third" };

            // Act
            string result = ReverseConcatenate.ReverseAndConcatenateStrings(input);

            // Assert
            Assert.That(result, Is.EqualTo("thirdsecondfirst"));
        }

        [Test]
        public void Test_ReverseAndConcatenateStrings_NullInput_ReturnsEmptyString()
        {
            // Arrange
            string[]? input = null;

            // Act
            string result = ReverseConcatenate.ReverseAndConcatenateStrings(input);

            // Assert
            Assert.That(result, Is.EqualTo(string.Empty));
        }

        [Test]
        public void Test_ReverseAndConcatenateStrings_WhitespaceInput_ReturnsConcatenatedString()
        {
            // Arrange
            string[] input = { "  ", " ", "word" };

            // Act
            string result = ReverseConcatenate.ReverseAndConcatenateStrings(input);

            // Assert
            Assert.That(result, Is.EqualTo("word   "));
        }

        [Test]
        public void Test_ReverseAndConcatenateStrings_LargeInput_ReturnsReversedConcatenatedString()
        {
            // Arrange
            string[] input = Enumerable.Range(0, 1000).Select(i => i.ToString()).ToArray();

            // Act
            string result = ReverseConcatenate.ReverseAndConcatenateStrings(input);

            // Assert
            string expected = string.Concat(Enumerable.Range(0, 1000).Select(i => (999 - i).ToString()));
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
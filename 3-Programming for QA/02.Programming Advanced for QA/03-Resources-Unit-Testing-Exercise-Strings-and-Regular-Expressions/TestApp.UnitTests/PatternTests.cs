using System;
using System.Text;
using NUnit.Framework;

namespace TestApp.UnitTests
{
    public class PatternTests
    {
      [TestCase("abc", 3, "aBcaBcaBc")]
       [TestCase("xyz", 2, "xYzxYz")]
      [TestCase("hello", 1, "hElLo")]
        public void Test_GeneratePatternedString_ValidInput_ReturnsExpectedResult(string input, int repetitionFactor, string expected)
        {
            // Arrange - input provided by TestCase attribute

            // Act
            string result = Pattern.GeneratePatternedString(input, repetitionFactor);

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void Test_GeneratePatternedString_EmptyInput_ThrowsArgumentException()
        {
            // Arrange
            string input = "";
            int repetitionFactor = 2;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => Pattern.GeneratePatternedString(input, repetitionFactor));
        }

        [Test]
        public void Test_GeneratePatternedString_NegativeRepetitionFactor_ThrowsArgumentException()
        {
            // Arrange
            string input = "abc";
            int repetitionFactor = -1;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => Pattern.GeneratePatternedString(input, repetitionFactor));
        }

        [Test]
        public void Test_GeneratePatternedString_ZeroRepetitionFactor_ThrowsArgumentException()
        {
            // Arrange
            string input = "xyz";
            int repetitionFactor = 0;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => Pattern.GeneratePatternedString(input, repetitionFactor));
        }
    }
}

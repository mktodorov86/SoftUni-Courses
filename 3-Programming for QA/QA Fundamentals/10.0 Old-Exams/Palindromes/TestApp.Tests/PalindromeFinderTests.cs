using System.Collections.Generic;
using NUnit.Framework;

namespace TestApp.Tests
{
    public class PalindromeFinderTests
    {
        [Test]
        public void Test_GetPalindromes_NullWordsList_ReturnsEmptyString()
        {
            // Arrange
            List<string> words = null;

            // Act
            string result = PalindromeFinder.GetPalindromes(words);

            // Assert
            Assert.That(result, Is.EqualTo(""));
        }

        [Test]
        public void Test_GetPalindromes_EmptyWordsList_ReturnsEmptyString()
        {
            // Arrange
            List<string> words = new List<string>();

            // Act
            string result = PalindromeFinder.GetPalindromes(words);

            // Assert
            Assert.That(result, Is.EqualTo(""));
        }

        [Test]
        public void Test_GetPalindromes_ListWithWords_ReturnsOnlyPalindromeWords()
        {
            // Arrange
            List<string> words = new List<string> { "level", "hello", "noon", "radar", "civic" };

            // Act
            string result = PalindromeFinder.GetPalindromes(words);

            // Assert
            Assert.That(result, Is.EqualTo("level noon radar civic"));
        }

        [Test]
        public void Test_GetPalindromes_ListWithoutPalindromeWords_ReturnsEmptyString()
        {
            // Arrange
            List<string> words = new List<string> { "hello", "world", "apple", "orange" };

            // Act
            string result = PalindromeFinder.GetPalindromes(words);

            // Assert
            Assert.That(result, Is.EqualTo(""));
        }

        [Test]
        public void Test_GetPalindromes_ListOnlyWithPalindromeWords_ReturnsStringWithAllWords()
        {
            // Arrange
            List<string> words = new List<string> { "madam", "racecar", "deified" };

            // Act
            string result = PalindromeFinder.GetPalindromes(words);

            // Assert
            Assert.That(result, Is.EqualTo("madam racecar deified"));
        }
    }
}

using NUnit.Framework;
using System;

namespace TestApp.UnitTests
{
    public class TextFilterTests
    {
        [Test]
        public void Test_Filter_WhenNoBannedWords_ShouldReturnOriginalText()
        {
            // Arrange
            string[] bannedWords = { "bad", "word" };
            string text = "This is a clean text.";

            // Act
            string result = TextFilter.Filter(bannedWords, text);

            // Assert
            Assert.That(result, Is.EqualTo(text));
        }

        [Test]
        public void Test_Filter_WhenBannedWordExists_ShouldReplaceBannedWordWithAsterisks()
        {
            // Arrange
            string[] bannedWords = { "bad", "word" };
            string text = "This is a bad text.";

            // Act
            string result = TextFilter.Filter(bannedWords, text);

            // Assert
            Assert.That(result, Is.EqualTo("This is a *** text."));
        }

        [Test]
        public void Test_Filter_WhenBannedWordsAreEmpty_ShouldReturnOriginalText()
        {
            // Arrange
            string[] bannedWords = Array.Empty<string>();
            string text = "This is a clean text.";

            // Act
            string result = TextFilter.Filter(bannedWords, text);

            // Assert
            Assert.That(result, Is.EqualTo(text));
        }

        [Test]
        public void Test_Filter_WhenBannedWordsContainWhitespace_ShouldReplaceBannedWord()
        {
            // Arrange
            string[] bannedWords = { "bad word" };
            string text = "This is a bad word example.";

            // Act
            string result = TextFilter.Filter(bannedWords, text);

            // Assert
            Assert.That(result, Is.EqualTo("This is a ******** example."));
        }
    }
}
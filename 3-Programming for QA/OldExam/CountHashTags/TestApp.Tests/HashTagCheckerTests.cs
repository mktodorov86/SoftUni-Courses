using NUnit.Framework;

namespace TestApp.Tests
{
    public class HashTagCheckerTests
    {
        [Test]
        public void Test_GetHashTags_ValidTextWithOneHashTag_ReturnMessageForOneHashTags()
        {
            // Arrange
            string inputText = "This is a valid #hashtag";
            string expectedMessage = "Only one! You know exactly what you #tag.";

            // Act
            string result = HashTagChecker.GetHashTags(inputText);

            // Assert
            Assert.AreEqual(expectedMessage, result);
        }

        [Test]
        public void Test_GetHashTags_ValidText_ReturnMessageForEvenHashTags()
        {
            // Arrange
            string inputText = "This text has an even number of #tags #like #this";
            string expectedMessage = "The text contains an odd number of #tags (3 in total).";

            // Act
            string result = HashTagChecker.GetHashTags(inputText);

            // Assert
            Assert.AreEqual(expectedMessage, result);
        }

        [Test]
        public void Test_GetHashTags_ValidText_ReturnMessageForOddHashTags()
        {
            // Arrange
            string inputText = "This text has an odd number of #tags #like #this #one";
            string expectedMessage = "The text contains an even number of #tags (4 in total).";

            // Act
            string result = HashTagChecker.GetHashTags(inputText);

            // Assert
            Assert.AreEqual(expectedMessage, result);
        }

        [Test]
        public void Test_GetHashTags_NullOrEmptyText_ReturnsErrorMessage()
        {
            // Arrange
            string nullText = null;
            string emptyText = string.Empty;
            string expectedErrorMessage = "No content...";

            // Act
            string resultForNull = HashTagChecker.GetHashTags(nullText);
            string resultForEmpty = HashTagChecker.GetHashTags(emptyText);

            // Assert
            Assert.AreEqual(expectedErrorMessage, resultForNull);
            Assert.AreEqual(expectedErrorMessage, resultForEmpty);
        }

        [Test]
        public void Test_GetHashTags_TestWithoutHashTags_ReturnsErrorMessage()
        {
            // Arrange
            string inputText = "This text does not contain any hashtags.";
            string expectedErrorMessage = "The text does not contain #tags.";

            // Act
            string result = HashTagChecker.GetHashTags(inputText);

            // Assert
            Assert.AreEqual(expectedErrorMessage, result);
        }
    }
}


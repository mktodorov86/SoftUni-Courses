using System;
using NUnit.Framework;

namespace TestApp.Tests
{
    [TestFixture]
    public class SubstringExtractorTests
    {
        [Test]
        public void Test_ExtractSubstringBetweenMarkers_SubstringFound_ReturnsExtractedSubstring()
        {
            // Arrange
            string input = "Hello [world]!";
            string startMarker = "[";
            string endMarker = "]";
            string expected = "world";

            // Act
            string result = SubstringExtractor.ExtractSubstringBetweenMarkers(input, startMarker, endMarker);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Test_ExtractSubstringBetweenMarkers_StartMarkerNotFound_ReturnsNotFoundMessage()
        {
            // Arrange
            string input = "Hello world!";
            string startMarker = "[";
            string endMarker = "]";
            string expected = "Substring not found";

            // Act
            string result = SubstringExtractor.ExtractSubstringBetweenMarkers(input, startMarker, endMarker);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Test_ExtractSubstringBetweenMarkers_EndMarkerNotFound_ReturnsNotFoundMessage()
        {
            // Arrange
            string input = "Hello [world!";
            string startMarker = "[";
            string endMarker = "]";
            string expected = "Substring not found";

            // Act
            string result = SubstringExtractor.ExtractSubstringBetweenMarkers(input, startMarker, endMarker);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Test_ExtractSubstringBetweenMarkers_StartAndEndMarkersNotFound_ReturnsNotFoundMessage()
        {
            // Arrange
            string input = "Hello world!";
            string startMarker = "[";
            string endMarker = "]";
            string expected = "Substring not found";

            // Act
            string result = SubstringExtractor.ExtractSubstringBetweenMarkers(input, startMarker, endMarker);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Test_ExtractSubstringBetweenMarkers_EmptyInput_ReturnsNotFoundMessage()
        {
            // Arrange
            string input = "";
            string startMarker = "[";
            string endMarker = "]";
            string expected = "Substring not found";

            // Act
            string result = SubstringExtractor.ExtractSubstringBetweenMarkers(input, startMarker, endMarker);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Test_ExtractSubstringBetweenMarkers_StartAndEndMarkersOverlapping_ReturnsNotFoundMessage()
        {
            // Arrange
            string input = "Hello [world[!]!";
            string startMarker = "[";
            string endMarker = "]";
            string expected = "world[!";

            // Act
            string result = SubstringExtractor.ExtractSubstringBetweenMarkers(input, startMarker, endMarker);

            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}

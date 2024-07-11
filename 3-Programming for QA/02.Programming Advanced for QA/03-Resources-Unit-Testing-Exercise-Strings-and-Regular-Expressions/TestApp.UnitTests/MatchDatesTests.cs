using System;
using System.Text.RegularExpressions;
using NUnit.Framework;

namespace TestApp.UnitTests
{
    public class MatchDatesTests
    {
        [Test]
        public void Test_Match_ValidDate_ReturnsExpectedResult()
        {
            // Arrange
            string dates = "31-Dec-2022";
            string expected = "Day: 31, Month: Dec, Year: 2022";

            // Act
            string result = MatchDates.Match(dates);

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void Test_Match_NoMatch_ReturnsEmptyString()
        {
            // Arrange
            string dates = "Invalid date format";
            string expected = string.Empty;

            // Act
            string result = MatchDates.Match(dates);

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void Test_Match_MultipleMatches_ReturnsFirstMatch()
        {
            // Arrange
            string dates = "31-Dec-2022 and 15-Oct-2023";
            string expected = "Day: 31, Month: Dec, Year: 2022";

            // Act
            string result = MatchDates.Match(dates);

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void Test_Match_EmptyString_ReturnsEmptyString()
        {
            // Arrange
            string dates = "";

            // Act
            string result = MatchDates.Match(dates);

            // Assert
            Assert.That(result, Is.EqualTo(string.Empty));
        }

        [Test]
        public void Test_Match_NullInput_ThrowsArgumentException()
        {
            // Arrange
            string dates = null;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => MatchDates.Match(dates));
        }
    }
}

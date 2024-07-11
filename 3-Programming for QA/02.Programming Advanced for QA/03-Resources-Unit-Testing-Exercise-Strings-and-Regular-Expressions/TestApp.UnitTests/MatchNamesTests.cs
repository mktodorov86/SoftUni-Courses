using System.Text.RegularExpressions;
using NUnit.Framework;

namespace TestApp.UnitTests
{
    public class MatchNamesTests
    {
        [Test]
        public void Test_Match_ValidNames_ReturnsMatchedNames()
        {
            // Arrange
            string names = "John Smith and Alice Johnson";
            string expected = "John Smith Alice Johnson";

            // Act
            string result = MatchNames.Match(names);

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void Test_Match_NoValidNames_ReturnsEmptyString()
        {
            // Arrange
            string names = "No valid names here";

            // Act
            string result = MatchNames.Match(names);

            // Assert
            Assert.That(result, Is.EqualTo(string.Empty));
        }

        [Test]
        public void Test_Match_EmptyInput_ReturnsEmptyString()
        {
            // Arrange
            string names = "";

            // Act
            string result = MatchNames.Match(names);

            // Assert
            Assert.That(result, Is.EqualTo(string.Empty));
        }

        [Test]
        public void Test_Match_SingleValidName_ReturnsName()
        {
            // Arrange
            string names = "Emily Johnson";
            string expected = "Emily Johnson";

            // Act
            string result = MatchNames.Match(names);

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void Test_Match_MultipleMatches_ReturnsAllMatches()
        {
            // Arrange
            string names = "John Smith and Alice Johnson and Mark Thompson";
            string expected = "John Smith Alice Johnson Mark Thompson";

            // Act
            string result = MatchNames.Match(names);

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}

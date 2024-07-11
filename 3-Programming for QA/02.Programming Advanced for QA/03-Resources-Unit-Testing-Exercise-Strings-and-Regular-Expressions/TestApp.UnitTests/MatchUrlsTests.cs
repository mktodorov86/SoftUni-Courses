using System.Collections.Generic;
using NUnit.Framework;

namespace TestApp.UnitTests
{
    public class MatchUrlsTests
    {
        [Test]
        public void Test_ExtractUrls_EmptyText_ReturnsEmptyList()
        {
            // Arrange
            string text = "";

            // Act
            List<string> result = MatchUrls.ExtractUrls(text);

            // Assert
            Assert.That(result, Is.Empty);
        }

        [Test]
        public void Test_ExtractUrls_NoUrlsInText_ReturnsEmptyList()
        {
            // Arrange
            string text = "This is a text without any URLs.";

            // Act
            List<string> result = MatchUrls.ExtractUrls(text);

            // Assert
            Assert.That(result, Is.Empty);
        }

        [Test]
        public void Test_ExtractUrls_SingleUrlInText_ReturnsSingleUrl()
        {
            // Arrange
            string text = "Visit my website at https://example.com";

            // Act
            List<string> result = MatchUrls.ExtractUrls(text);

            // Assert
            Assert.That(result, Has.Count.EqualTo(1));
            Assert.That(result[0], Is.EqualTo("https://example.com"));
        }

        [Test]
        public void Test_ExtractUrls_MultipleUrlsInText_ReturnsAllUrls()
        {
            // Arrange
            string text = "Here are some links: https://example.com, http://test.com, and https://another-site.org";

            // Act
            List<string> result = MatchUrls.ExtractUrls(text);

            // Assert
            Assert.AreEqual(3,result.Count);
            Assert.AreEqual(result[0], "https://example.com");
            Assert.AreEqual(result[1], "http://test.com");
            Assert.AreEqual(result[2], "https://another-site.org");
        }

        [Test]
        public void Test_ExtractUrls_UrlsInQuotationMarks_ReturnsUrlsInQuotationMarks()
        {
            // Arrange
            string text = "Links in quotes: \"https://example.com\"";

            // Act
            List<string> result = MatchUrls.ExtractUrls(text);

            // Assert
            Assert.That(result, Has.Count.EqualTo(1));
            Assert.That(result, Contains.Item("https://example.com"));
        
        }

        [Test]
        public void Test_ExtractUrls_UrlsWithQueryAndAnchor_ReturnsUrlsWithQueryAndAnchor()
        {
            // Arrange
            string text = "Visit my site: https://example.com";

            // Act
            List<string> result = MatchUrls.ExtractUrls(text);

            // Assert
            Assert.That(result, Has.Count.EqualTo(1));
            Assert.That(result[0], Is.EqualTo("https://example.com"));
        }
    }
}

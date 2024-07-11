using System.Text.RegularExpressions;
using NUnit.Framework;

namespace TestApp.UnitTests
{
    public class EmailValidatorTests
    {
        // Test cases for valid emails
        [TestCase("john.doe@example.com")]
        [TestCase("jane.smith123@gmail.com")]
        [TestCase("info@company.co.uk")]
        [TestCase("first.last@subdomain.example.org")]
        public void Test_ValidEmails_ReturnsTrue(string email)
        {
            // Act
            bool result = EmailValidator.IsValidEmail(email);

            // Assert
            Assert.That(result, Is.True);
        }

        // Test cases for invalid emails
        [TestCase("john.doe@example")] // Missing top-level domain
        [TestCase("jane.smith@.com")] // Invalid domain part
        [TestCase("info@company")] // Missing domain extension
        [TestCase("invalid-email.com")] // Missing "@" symbol
        public void Test_InvalidEmails_ReturnsFalse(string email)
        {
            // Act
            bool result = EmailValidator.IsValidEmail(email);

            // Assert
            Assert.That(result, Is.False);
        }
    }
}

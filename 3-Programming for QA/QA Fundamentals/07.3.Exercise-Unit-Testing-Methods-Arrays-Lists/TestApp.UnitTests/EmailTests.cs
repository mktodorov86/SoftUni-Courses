using NUnit.Framework;
using TestApp;

namespace TestApp.UnitTests
{
    public class EmailTests
    {
        [Test]
        public void Test_IsValidEmail_ValidEmail()
        {
            // Arrange
            string validEmail = "test@example.com";

            // Act
            bool isValid = Email.IsValidEmail(validEmail);

            // Assert
            Assert.IsTrue(isValid, "Valid email should return true.");
        }

        [Test]
        public void Test_IsValidEmail_InvalidEmail_Null()
        {
            // Arrange
            string invalidEmail = null;

            // Act
            bool isValid = Email.IsValidEmail(invalidEmail);

            // Assert
            Assert.IsFalse(isValid, "Null email should return false.");
        }

        [Test]
        public void Test_IsValidEmail_NullInput()
        {
            // Act
            bool isValid = Email.IsValidEmail(null);

            // Assert
            Assert.IsFalse(isValid, "Null input should return false.");
        }

        [Test]
        public void Test_IsValidEmail_EmptyInput()
        {
            // Act
            bool isValid = Email.IsValidEmail("");

            // Assert
            Assert.IsFalse(isValid, "Empty string should return false.");
        }

        [Test]
        public void Test_IsValidEmail_WhitespaceInput()
        {
            // Act
            bool isValid = Email.IsValidEmail("   ");

            // Assert
            Assert.IsFalse(isValid, "Whitespace input should return false.");
        }
        [Test]
        public void Test_IsValidEmail_MissingDomain()
        {
            // Act
            bool isValid = Email.IsValidEmail("test@");

            // Assert
            Assert.IsFalse(isValid, "Email missing domain should return false.");
        }

        // Add more test cases as needed to cover edge cases and specific scenarios
    }
}

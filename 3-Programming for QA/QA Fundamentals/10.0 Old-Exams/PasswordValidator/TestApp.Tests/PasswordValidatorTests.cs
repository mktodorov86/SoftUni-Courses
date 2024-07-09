using NUnit.Framework;

namespace TestApp.Tests
{
    public class PasswordValidatorTests
    {
        [Test]
        public void Test_CheckPassword_ValidPassword_ReturnsValidMessage()
        {
            // Arrange
            string password = "Abc123";

            // Act
            string result = PasswordValidator.CheckPassword(password);

            // Assert
            Assert.That(result, Is.EqualTo("Password is valid"));
        }

        [Test]
        public void Test_CheckPassword_PasswordTooShort_ReturnsErrorMessage()
        {
            // Arrange
            string password = "Abc12"; // Less than 6 characters

            // Act
            string result = PasswordValidator.CheckPassword(password);

            // Assert
            Assert.That(result, Is.EqualTo("Password must be between 6 and 10 characters"));
        }

        [Test]
        public void Test_CheckPassword_ContainsSpecialCharacters_ReturnsErrorMessage()
        {
            // Arrange
            string password = "Abc123!"; // Contains special character '!'

            // Act
            string result = PasswordValidator.CheckPassword(password);

            // Assert
            Assert.That(result, Is.EqualTo("Password must consist only of letters and digits"));
        }

        [Test]
        public void Test_CheckPassword_InsufficientDigits_ReturnsErrorMessage()
        {
            // Arrange
            string password = "Abcdef"; // No digits

            // Act
            string result = PasswordValidator.CheckPassword(password);

            // Assert
            Assert.That(result, Is.EqualTo("Password must have at least 2 digits"));
        }

        [Test]
        public void Test_CheckPassword_ValidPasswordWithMaximumLength_ReturnsValidMessage()
        {
            // Arrange
            string password = "Abc34fghif"; // Maximum length (10 characters)

            // Act
            string result = PasswordValidator.CheckPassword(password);

            // Assert
            Assert.That(result, Is.EqualTo("Password is valid"));
        }
    }
}

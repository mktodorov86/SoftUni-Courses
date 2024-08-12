using NUnit.Framework;

namespace TestApp.Tests
{
    [TestFixture]
    public class StringRotatorTests
    {
        [Test]
        public void Test_RotateRight_EmptyString_ReturnsEmptyString()
        {
            // Arrange
            string input = string.Empty;
            int positions = 3;

            // Act
            string result = StringRotator.RotateRight(input, positions);

            // Assert
            Assert.AreEqual(string.Empty, result);
        }

        [Test]
        public void Test_RotateRight_RotateByZeroPositions_ReturnsOriginalString()
        {
            // Arrange
            string input = "hello";
            int positions = 0;

            // Act
            string result = StringRotator.RotateRight(input, positions);

            // Assert
            Assert.AreEqual("hello", result);
        }

        [Test]
        public void Test_RotateRight_RotateByPositivePositions_ReturnsRotatedString()
        {
            // Arrange
            string input = "hello";
            int positions = 2;

            // Act
            string result = StringRotator.RotateRight(input, positions);

            // Assert
            Assert.AreEqual("lohel", result);
        }

        [Test]
        public void Test_RotateRight_RotateByNegativePositions_ReturnsRotatedString()
        {
            // Arrange
            string input = "hello";
            int positions = -2;

            // Act
            string result = StringRotator.RotateRight(input, positions);

            // Assert
            Assert.AreEqual("lohel", result);
        }

        [Test]
        public void Test_RotateRight_RotateByMorePositionsThanStringLength_ReturnsRotatedString()
        {
            // Arrange
            string input = "hello";
            int positions = 7; // 7 % 5 = 2

            // Act
            string result = StringRotator.RotateRight(input, positions);

            // Assert
            Assert.AreEqual("lohel", result);
        }
    }
}

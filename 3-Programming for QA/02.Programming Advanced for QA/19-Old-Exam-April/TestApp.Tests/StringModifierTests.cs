using NUnit.Framework;
using TestApp;

namespace TestApp.Tests
{
    [TestFixture]
    public class StringModifierTests
    {
        [Test]
        public void Test_Modify_EmptyString_ReturnsEmptyString()
        {
            // Arrange
            string input = "";
            string expected = "";

            // Act
            string result = StringModifier.Modify(input);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Test_Modify_SingleWordWithEvenLength_ReturnsUpperCaseWord()
        {
            // Arrange
            string input = "Test";
            string expected = "TEST";

            // Act
            string result = StringModifier.Modify(input);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Test_Modify_SingleWordWithOddLength_ReturnsLowerCaseWord()
        {
            // Arrange
            string input = "hello";
            string expected = "hello";

            // Act
            string result = StringModifier.Modify(input);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Test_Modify_MultipleWords_ReturnsModifiedString()
        {
            // Arrange
            string input = "Hello World Test this Is a Example";
            string expected = "hello world TEST THIS IS a example";

            // Act
            string result = StringModifier.Modify(input);

            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}

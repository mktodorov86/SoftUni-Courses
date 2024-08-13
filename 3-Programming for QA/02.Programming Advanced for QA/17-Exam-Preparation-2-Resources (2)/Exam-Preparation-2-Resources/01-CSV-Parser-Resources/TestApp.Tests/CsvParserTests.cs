using System;
using NUnit.Framework;

namespace TestApp.Tests
{
    [TestFixture]
    public class CsvParserTests
    {
        [Test]
        public void Test_ParseCsv_EmptyInput_ReturnsEmptyArray()
        {
            // Act
            var result = CsvParser.ParseCsv(string.Empty);

            // Assert
            Assert.IsEmpty(result);
        }

        [Test]
        public void Test_ParseCsv_SingleField_ReturnsArrayWithOneElement()
        {
            // Arrange
            string csvData = "test";

            // Act
            var result = CsvParser.ParseCsv(csvData);

            // Assert
            Assert.AreEqual(1, result.Length);
            Assert.AreEqual("test", result[0]);
        }

        [Test]
        public void Test_ParseCsv_MultipleFields_ReturnsArrayWithMultipleElements()
        {
            // Arrange
            string csvData = "test1,test2,test3";

            // Act
            var result = CsvParser.ParseCsv(csvData);

            // Assert
            Assert.AreEqual(3, result.Length);
            Assert.AreEqual("test1", result[0]);
            Assert.AreEqual("test2", result[1]);
            Assert.AreEqual("test3", result[2]);
        }

        [Test]
        public void Test_ParseCsv_TrimsWhiteSpace_ReturnsCleanArray()
        {
            // Arrange
            string csvData = "  test1  ,  test2 ,  test3  ";

            // Act
            var result = CsvParser.ParseCsv(csvData);

            // Assert
            Assert.AreEqual(3, result.Length);
            Assert.AreEqual("test1", result[0]);
            Assert.AreEqual("test2", result[1]);
            Assert.AreEqual("test3", result[2]);
        }
    }
}

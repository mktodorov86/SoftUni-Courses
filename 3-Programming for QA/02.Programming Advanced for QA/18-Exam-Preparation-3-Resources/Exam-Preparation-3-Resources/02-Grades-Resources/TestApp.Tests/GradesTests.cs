using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace TestApp.Tests
{
    [TestFixture]
    public class GradesTests
    {
        [Test]
        public void Test_GetBestStudents_ReturnsBestThreeStudents()
        {
            // Arrange
            var grades = new Dictionary<string, int>
            {
                {"Alice", 90},
                {"Bob", 85},
                {"Charlie", 95},
                {"David", 80},
                {"Eve", 88}
            };
            string expected = $"Charlie with average grade 95.00{Environment.NewLine}" +
                $"Alice with average grade 90.00{Environment.NewLine}" +
                $"Eve with average grade 88.00";


            // Act
            string result = Grades.GetBestStudents(grades);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Test_GetBestStudents_EmptyGrades_ReturnsEmptyString()
        {
            // Arrange
            var grades = new Dictionary<string, int>();
            string expected = string.Empty;

            // Act
            string result = Grades.GetBestStudents(grades);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Test_GetBestStudents_LessThanThreeStudents_ReturnsAllStudents()
        {
            // Arrange
            var grades = new Dictionary<string, int>
            {
                {"Alice", 90},
                {"Bob", 85},
            };
            string expected = $"Alice with average grade 90.00{Environment.NewLine}" +
                $"Bob with average grade 85.00";

            // Act
            string result = Grades.GetBestStudents(grades);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Test_GetBestStudents_SameGrade_ReturnsInAlphabeticalOrder()
        {
            // Arrange
            var grades = new Dictionary<string, int>
            {
                {"Bob", 90},
                {"Alice", 90},
                {"Charlie", 90},
                {"David", 85}
            };
            string expected = $"Alice with average grade 90.00{Environment.NewLine}" +
                $"Bob with average grade 90.00{Environment.NewLine}" +
                $"Charlie with average grade 90.00";

            // Act
            string result = Grades.GetBestStudents(grades);

            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}

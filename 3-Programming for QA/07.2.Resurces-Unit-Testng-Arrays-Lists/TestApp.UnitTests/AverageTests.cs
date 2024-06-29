using NUnit.Framework;

using System;

namespace TestApp.UnitTests;

public class AverageTests
{
    // TODO: finish the test
    [Test]
    public void Test_CalculateAverage_InputHasOneElement_ShouldReturnSameElement()
    {
        // Arrange
        int[] numbers = new int[] { 5 };
        double expected = 5.0;

        // Act
        double actual = Average.CalculateAverage(numbers);

        // Assert
        Assert.AreEqual(expected, actual, "Average of a single element array should return the element itself.");
    }

    [Test]
    public void Test_CalculateAverage_InputHasPositiveIntegers_ShouldReturnCorrectAverage()
    {
        // Arrange
        int[] numbers = new int[] { 1, 2, 3, 4, 5 };
        double expected = 3.0;

        // Act
        double actual = Average.CalculateAverage(numbers);

        // Assert
        Assert.AreEqual(expected, actual, "Average of positive integers should be calculated correctly.");
    }

    [Test]
    public void Test_CalculateAverage_InputHasNegativeIntegers_ShouldReturnCorrectAverage()
    {
        // Arrange
        int[] numbers = new int[] { -1, -2, -3, -4, -5 };
        double expected = -3.0;

        // Act
        double actual = Average.CalculateAverage(numbers);

        // Assert
        Assert.AreEqual(expected, actual, "Average of negative integers should be calculated correctly.");
    }

    [Test]
    public void Test_CalculateAverage_InputHasMixedIntegers_ShouldReturnCorrectAverage()
    {
        // Arrange
        int[] numbers = new int[] { -1, 2, 0, 4, -3 };
        double expected = 0.4; // Average calculated manually as (-1 + 2 + 0 + 4 - 3) / 5 = 2.0 / 5 = 0.4

        // Act
        double actual = Average.CalculateAverage(numbers);

        // Assert
        Assert.AreEqual(expected, actual, 0.0001, "Average of mixed integers should be calculated correctly.");
    }
}

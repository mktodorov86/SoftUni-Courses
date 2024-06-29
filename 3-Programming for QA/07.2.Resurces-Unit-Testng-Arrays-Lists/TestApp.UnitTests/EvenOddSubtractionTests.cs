using NUnit.Framework;

using System;

namespace TestApp.UnitTests;

public class EvenOddSubtractionTests
{
    [Test]
    public void Test_FindDifference_InputIsEmpty_ShouldReturnZero()
    {
        // Arrange
        int[] emptyArray = Array.Empty<int>();

        // Act
        int result = EvenOddSubtraction.FindDifference(emptyArray);

        // Assert
        Assert.That(result, Is.EqualTo(0));
    }

    // TODO: finish the test
    [Test]
    public void Test_FindDifference_InputHasOnlyEvenNumbers_ShouldReturnEvenSum()
    {
        // Arrange
        int[] arr = new int[] { 2, 4, 6, 8 };
        int expected = 20; // Sum of { 2, 4, 6, 8 } = 20

        // Act
        int result = EvenOddSubtraction.FindDifference(arr);

        // Assert
        Assert.That(result, Is.EqualTo(expected), $"Expected sum of even numbers {expected}, but got {result}.");
    }

    [Test]
    public void Test_FindDifference_InputHasOnlyOddNumbers_ShouldReturnNegativeOddSum()
    {
        // Arrange
        int[] arr = new int[] { 1, 3, 5, 7 };
        int expected = -16; // Sum of { 1, 3, 5, 7 } = 16 (odd numbers)

        // Act
        int result = EvenOddSubtraction.FindDifference(arr);

        // Assert
        Assert.That(result, Is.EqualTo(expected), $"Expected difference of {expected}, but got {result}.");
    }

    [Test]
    public void Test_FindDifference_InputHasMixedNumbers_ShouldReturnDifference()
    {
        // Arrange
        int[] arr = new int[] { 1, 2, 3, 4, 5 };
        int expected = -3; // (2 + 4) - (1 + 3 + 5) = 6 - 9 = -3

        // Act
        int result = EvenOddSubtraction.FindDifference(arr);

        // Assert
        Assert.That(result, Is.EqualTo(expected), $"Expected difference of {expected}, but got {result}.");
    }
}

using NUnit.Framework;

using System.Collections.Generic;

namespace TestApp.UnitTests;

public class MaxNumberTests
{

    [Test]
    public void Test_FindMax_InputHasOneElement_ShouldReturnTheElement()
    {
        // Arrange
        List<int> numbers = new List<int> { 42 };

        // Act
        int max = MaxNumber.FindMax(numbers);

        // Assert
        Assert.AreEqual(42, max, "Failed to return the single element as maximum.");
    }

    [Test]
    public void Test_FindMax_InputHasPositiveIntegers_ShouldReturnMaximum()
    {
        // Arrange
        List<int> numbers = new List<int> { 3, 7, 1, 9, 5 };

        // Act
        int max = MaxNumber.FindMax(numbers);

        // Assert
        Assert.AreEqual(9, max, "Failed to find maximum number in list of positive integers.");
    }

    [Test]
    public void Test_FindMax_InputHasNegativeIntegers_ShouldReturnMaximum()
    {
        // Arrange
        List<int> numbers = new List<int> { -3, -7, -1, -9, -5 };

        // Act
        int max = MaxNumber.FindMax(numbers);

        // Assert
        Assert.AreEqual(-1, max, "Failed to find maximum number in list of negative integers.");
    }

    [Test]
    public void Test_FindMax_InputHasMixedIntegers_ShouldReturnMaximum()
    {
        // Arrange
        List<int> numbers = new List<int> { -3, 7, -1, 9, -5 };

        // Act
        int max = MaxNumber.FindMax(numbers);

        // Assert
        Assert.AreEqual(9, max, "Failed to find maximum number in list of mixed integers.");
    }

    [Test]
    public void Test_FindMax_InputHasDuplicateMaxValue_ShouldReturnMaximum()
    {
        // Arrange
        List<int> numbers = new List<int> { 3, 7, 9, 7, 5, 9 };

        // Act
        int max = MaxNumber.FindMax(numbers);

        // Assert
        Assert.AreEqual(9, max, "Failed to find maximum number in list with duplicate maximum values.");
    }
}

using NUnit.Framework;

using System.Collections.Generic;

namespace TestApp.UnitTests;

public class AdjacentEqualTests
{
    // TODO: finish test
    [Test]
    public void Test_Sum_InputIsEmptyList_ShouldReturnEmptyString()
    {
        // Arrange
        List<int> emptyList = new();

        // Act
        string actual = AdjacentEqual.Sum(emptyList);

        // Assert
        Assert.AreEqual(string.Empty, actual, "Sum of an empty list should return an empty string.");
    }

    // TODO: finish test
    [Test]
    public void Test_Sum_NoAdjacentEqualNumbers_ShouldReturnOriginalList()
    {
        // Arrange
        List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };
        string expected = "1 2 3 4 5";

        // Act
        string actual = AdjacentEqual.Sum(numbers);

        // Assert
        Assert.AreEqual(expected, actual, "Sum of list with no adjacent equal numbers should return the original list.");
    }

    [Test]
    public void Test_Sum_AdjacentEqualNumbersExist_ShouldReturnSummedList()
    {
        // Arrange
        List<int> numbers = new List<int> { 1, 2, 2, 3, 3, 3, 4 };
        string expected = "1 4 9 4";

        // Act
        string actual = AdjacentEqual.Sum(numbers);

        // Assert
        Assert.AreEqual(expected, actual, "Sum of list with adjacent equal numbers should return the summed list.");
    }

    [Test]
    public void Test_Sum_AllNumbersAreAdjacentEqual_ShouldReturnSingleSummedNumber()
    {
        // Arrange
        List<int> numbers = new List<int> { 5, 5, 5, 5, 5 };
        string expected = "25";

        // Act
        string actual = AdjacentEqual.Sum(numbers);

        // Assert
        Assert.AreEqual(expected, actual, "Sum of list with all adjacent equal numbers should return a single summed number.");
    }

    [Test]
    public void Test_Sum_AdjacentEqualNumbersAtBeginning_ShouldReturnSummedList()
    {
        // Arrange
        List<int> numbers = new List<int> { 2, 2, 3, 4, 5 };
        string expected = "4 3 4 5";

        // Act
        string actual = AdjacentEqual.Sum(numbers);

        // Assert
        Assert.AreEqual(expected, actual, "Sum of list with adjacent equal numbers at the beginning should return the summed list.");
    }

    [Test]
    public void Test_Sum_AdjacentEqualNumbersAtEnd_ShouldReturnSummedList()
    {
        // Arrange
        List<int> numbers = new List<int> { 1, 2, 3, 4, 4 };
        string expected = "1 2 3 8";

        // Act
        string actual = AdjacentEqual.Sum(numbers);

        // Assert
        Assert.AreEqual(expected, actual, "Sum of list with adjacent equal numbers at the end should return the summed list.");
    }
    // TODO: finish test
}



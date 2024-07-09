using NUnit.Framework;

using System;

namespace TestApp.UnitTests;

public class PatternTests
{
    [Test]
    public void Test_SortInPattern_SortsIntArrayInPattern_SortsCorrectly()
    {
        // Arrange
        int[] arr = { 5, 3, 8, 1, 4, 2 };
        int[] expected = { 1, 8, 2, 5, 3, 4 }; // Expected pattern: smallest, largest, second smallest, second largest, ...

        // Act
        int[] result = Pattern.SortInPattern(arr);

        // Assert
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Test_SortInPattern_EmptyArray_ReturnsEmptyArray()
    {
        // Arrange
        int[] arr = Array.Empty<int>();

        // Act
        int[] result = Pattern.SortInPattern(arr);

        // Assert
        Assert.IsEmpty(result);
    }

    [Test]
    public void Test_SortInPattern_SingleElementArray_ReturnsSameArray()
    {
        // Arrange
        int[] arr = { 5 }; // Single-element array

        // Act
        int[] result = Pattern.SortInPattern(arr);

        // Assert
        Assert.AreEqual(arr.Length, result.Length);
        Assert.AreEqual(arr[0], result[0]);
    }
}

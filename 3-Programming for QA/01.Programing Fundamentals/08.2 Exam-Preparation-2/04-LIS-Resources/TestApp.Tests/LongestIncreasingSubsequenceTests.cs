using NUnit.Framework;
using System;

namespace TestApp.Tests;

public class LongestIncreasingSubsequenceTests
{
    [Test]
    public void Test_GetLis_NullArray_ThrowsArgumentNullException()
    {
        // Arrange
        int[] arr = null;

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => LongestIncreasingSubsequence.GetLis(arr));
    }

    [Test]
    public void Test_GetLis_EmptyArray_ReturnsEmptyString()
    {
        // Arrange
        int[] arr = new int[] { };

        // Act
        string result = LongestIncreasingSubsequence.GetLis(arr);

        // Assert
        Assert.AreEqual(string.Empty, result);
    }

    [Test]
    public void Test_GetLis_SingleElementArray_ReturnsElement()
    {
        // Arrange
        int[] arr = new int[] { 5 };

        // Act
        string result = LongestIncreasingSubsequence.GetLis(arr);

        // Assert
        Assert.AreEqual("5", result);
    }

    [Test]
    public void Test_GetLis_UnsortedArray_ReturnsLongestIncreasingSubsequence()
    {
        // Arrange
        int[] arr = new int[] { 3, 10, 2, 1, 20 };
        string expected = "3 10 20";

        // Act
        string result = LongestIncreasingSubsequence.GetLis(arr);

        // Assert
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Test_GetLis_SortedArray_ReturnsItself()
    {
        // Arrange
        int[] arr = new int[] { 1, 2, 3, 4, 5 };
        string expected = "1 2 3 4 5";

        // Act
        string result = LongestIncreasingSubsequence.GetLis(arr);

        // Assert
        Assert.AreEqual(expected, result);
    }
}

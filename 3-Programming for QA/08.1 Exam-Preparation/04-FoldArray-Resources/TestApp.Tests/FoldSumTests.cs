using System;
using NUnit.Framework;

namespace TestApp.Tests;

public class FoldSumTests
{
    [TestCase(new[] { 1, 2, 3, 4, 5, 6 }, "3 9")]
    [TestCase(new[] { 1, 2, 3, 4, 5, 6, 7, 8 }, "5 5 13 13")]
    [TestCase(new[] { 1, 2, 3, 4 }, "3 7")]
    [TestCase(new[] { 1, 2, 3 }, "")]
    [TestCase(new[] { 1 }, "")]
    public void Test_FoldArray_ReturnsCorrectString(int[] arr, string expected)
    {
        // Arrange - No additional arrangement needed for this test

        // Act
        string result = FoldSum.FoldArray(arr);

        // Assert
        Assert.AreEqual(expected, result);
    }
}

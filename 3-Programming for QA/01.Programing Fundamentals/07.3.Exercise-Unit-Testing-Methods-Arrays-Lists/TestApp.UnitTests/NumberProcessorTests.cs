using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace TestApp.UnitTests;

public class NumberProcessorTests
{
    [Test]
    public void Test_ProcessNumbers_SquareEvenNumbers()
    {
        // Arrange
        List<int> input = new List<int> { 2, 4, 6 };
        List<double> expected = new List<double> { 4, 16, 36 };

        // Act
        List<double> actual = NumberProcessor.ProcessNumbers(input);

        // Assert
        CollectionAssert.AreEqual(expected, actual);
    }

    // TODO: finish test
    [Test]
    public void Test_ProcessNumbers_SquareRootOddNumbers()
    {
        // Arrange
        List<int> input = new List<int> { 1, 3, 5 };
        List<double> expected = new List<double> { 1, Math.Sqrt(3), Math.Sqrt(5) };

        // Act
        List<double> actual = NumberProcessor.ProcessNumbers(input);

        // Assert
        Assert.AreEqual(expected.Count, actual.Count, "Number of elements should match.");

        for (int i = 0; i < expected.Count; i++)
        {
            Assert.AreEqual(expected[i], actual[i], $"Element at index {i} should match.");
        }
    }
    // TODO: finish test
    [Test]
    public void Test_ProcessNumbers_HandleZero()
    {
        // Arrange
        List<int> input = new List<int> { 0 };
        List<double> expected = new List<double> { 0 };

        // Act
        List<double> actual = NumberProcessor.ProcessNumbers(input);

        // Assert
        Assert.AreEqual(expected.Count, actual.Count, "Number of elements should match.");
        Assert.AreEqual(expected[0], actual[0], "Element should match.");
    }

    [Test]
    public void Test_ProcessNumbers_EmptyInput()
    {
        // Arrange
        List<int> input = new List<int>();

        // Act
        List<double> actual = NumberProcessor.ProcessNumbers(input);

        // Assert
        Assert.IsEmpty(actual, "Result should be empty for an empty input list.");
    }
}

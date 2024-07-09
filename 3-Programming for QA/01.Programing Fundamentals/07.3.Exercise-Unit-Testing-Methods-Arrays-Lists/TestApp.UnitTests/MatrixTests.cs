using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace TestApp.UnitTests;

public class MatrixTests
{
    // TODO: finish test
    [Test]
    public void Test_MatrixAddition_ValidInput_ReturnsCorrectResult()
    {
        // Arrange
        List<List<int>> matrixA = new List<List<int>> {
            new List<int> { 1, 2 },
            new List<int> { 3, 4 }
        };

        List<List<int>> matrixB = new List<List<int>> {
            new List<int> { 5, 6 },
            new List<int> { 7, 8 }
        };

        List<List<int>> expected = new List<List<int>> {
            new List<int> { 6, 8 },
            new List<int> { 10, 12 }
        };

        // Act
        List<List<int>> result = Matrix.MatrixAddition(matrixA, matrixB);

        // Assert
        Assert.AreEqual(expected.Count, result.Count, "Number of rows should match.");

        for (int i = 0; i < expected.Count; i++)
        {
            CollectionAssert.AreEqual(expected[i], result[i], $"Row {i} should match.");
        }
    }

    [Test]
    public void Test_MatrixAddition_EmptyMatrices_ReturnsEmptyMatrix()
    {
        // Arrange
        List<List<int>> matrixA = new List<List<int>>();
        List<List<int>> matrixB = new List<List<int>>();
        List<List<int>> expected = new List<List<int>>();

        // Act
        List<List<int>> result = Matrix.MatrixAddition(matrixA, matrixB);

        // Assert
        Assert.AreEqual(expected.Count, result.Count, "Number of rows should match.");

        for (int i = 0; i < expected.Count; i++)
        {
            CollectionAssert.AreEqual(expected[i], result[i], $"Row {i} should match.");
        }
    }

    [Test]
    public void Test_MatrixAddition_DifferentDimensions_ThrowsArgumentException()
    {
        // Arrange
        List<List<int>> matrixA = new List<List<int>> {
            new List<int> { 1, 2 },
            new List<int> { 3, 4 }
        };

        List<List<int>> matrixB = new List<List<int>> {
            new List<int> { 5, 6, 7 }, // Different dimension here
            new List<int> { 8, 9, 10 }
        };

        // Act and Assert
        Assert.Throws<ArgumentException>(() => Matrix.MatrixAddition(matrixA, matrixB));
    }

    [Test]
    public void Test_MatrixAddition_NegativeNumbers_ReturnsCorrectResult()
    {
        // Arrange
        List<List<int>> matrixA = new List<List<int>> {
                    new List<int> { 1, -2 },
                    new List<int> { -3, 4 }
                };

        List<List<int>> matrixB = new List<List<int>> {
                    new List<int> { -5, 6 },
                    new List<int> { 7, -8 }
                };

        List<List<int>> expected = new List<List<int>> {
                    new List<int> { -4, 4 },
                    new List<int> { 4, -4 }
                };

        // Act
        List<List<int>> result = Matrix.MatrixAddition(matrixA, matrixB);

        // Assert
        Assert.AreEqual(expected.Count, result.Count, "Number of rows should match.");

        for (int i = 0; i < expected.Count; i++)
        {
            CollectionAssert.AreEqual(expected[i], result[i], $"Row {i} should match.");
        }
    }

    // TODO: finish test
    [Test]
    public void Test_MatrixAddition_ZeroMatrix_ReturnsOriginalMatrix()
    {
        // Arrange
        List<List<int>> matrixA = new List<List<int>> {
                    new List<int> { 1, 2 },
                    new List<int> { 3, 4 }
                };

        List<List<int>> matrixB = new List<List<int>> {
                    new List<int> { 0, 0 },
                    new List<int> { 0, 0 }
                };

        List<List<int>> expected = new List<List<int>> {
                    new List<int> { 1, 2 },
                    new List<int> { 3, 4 }
                };

        // Act
        List<List<int>> result = Matrix.MatrixAddition(matrixA, matrixB);

        // Assert
        Assert.AreEqual(expected.Count, result.Count, "Number of rows should match.");

        for (int i = 0; i < expected.Count; i++)
        {
            CollectionAssert.AreEqual(expected[i], result[i], $"Row {i} should match.");
        }
    }
}

using NUnit.Framework;
using System;
namespace TestApp.UnitTests;

public class FibonacciTests
{
    [Test]
    public void Test_CalculateFibonacci_ZeroInput()
    {
        // Arrange
        int n = 0;
        int expected = 0;

        // Act
        int result = Fibonacci.CalculateFibonacci(n);

        // Assert
        Assert.AreEqual(expected, result, $"Fibonacci of {n} should be {expected}.");
    }

    [Test]
    public void Test_CalculateFibonacci_PositiveInput()
    {
        // Arrange
        int[][] testCases = new int[][]
        {
        new int[] { 1, 1 },
        new int[] { 2, 1 },
        new int[] { 3, 2 },
        new int[] { 4, 3 },
        new int[] { 5, 5 },
        new int[] { 6, 8 },
        new int[] { 7, 13 },
        new int[] { 8, 21 },
        new int[] { 9, 34 },
        new int[] { 10, 55 }
        // Add more test cases as needed
        };

        foreach (var testCase in testCases)
        {
            int n = testCase[0];
            int expected = testCase[1];

            // Act
            int result = Fibonacci.CalculateFibonacci(n);

            // Assert
            Assert.AreEqual(expected, result, $"Fibonacci of {n} should be {expected}.");
        }
    }
}
using System;
using NUnit.Framework;

namespace TestApp.Tests;
public class PrimeNumbersTests
{
    [Test]
    public void Test_GetPrimeNumbersInRange_StartNumberBiggerThanEndNumber_ReturnsErrorMessage()
    {
        int start = 10;
        int end = 5;

        string result = PrimeNumbers.GetPrimeNumbersInRange(start, end);

        Assert.That(result, Is.EqualTo("Start number should be bigger than end number."));
    }

    [Test]
    public void Test_GetPrimeNumbersInRange_StartAndEndNumberAreEqual_ReturnsEmptyString()
    {
        // Arrange
        int startNum = 25;
        int endNum = 25;

        // Act
        string result = PrimeNumbers.GetPrimeNumbersInRange(startNum, endNum);

        // Assert
        Assert.That(result, Is.EqualTo(""));
    }

    [Test]
    public void Test_GetPrimeNumbersInRange_NoPrimeNumbers_ReturnsEmptyString()
    {
        // Arrange
        int startNum = 0;
        int endNum = 1;

        // Act
        string result = PrimeNumbers.GetPrimeNumbersInRange(startNum, endNum);

        // Assert
        Assert.That(result, Is.EqualTo(""));
    }

    [Test]
    public void Test_GetPrimeNumbersInRange_WithPrimeAndNonPrimeNumbers_ReturnsOnlyPrimeNumbers()
    {
        int start = 11;
        int end = 20;

        string result = PrimeNumbers.GetPrimeNumbersInRange(start, end);

        // Assert that result only contains prime numbers in the specified range
        Assert.That(result, Is.EqualTo("11 13 17 19")); // Adjust expected prime numbers as per your implementation
    }

    [Test]
    public void Test_GetPrimeNumbersInRange_OnlyPrimeNumbers_ReturnsAllNumbers()
    {
        // Arrange
        int startNum = 10;
        int endNum = 20;

        // Act
        string result = PrimeNumbers.GetPrimeNumbersInRange(startNum, endNum);

        // Assert
        Assert.That(result, Is.EqualTo("11 13 17 19"));
    }
}


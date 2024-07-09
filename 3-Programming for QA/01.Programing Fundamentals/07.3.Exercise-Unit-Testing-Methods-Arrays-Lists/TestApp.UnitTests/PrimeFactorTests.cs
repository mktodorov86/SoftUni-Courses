using NUnit.Framework;

namespace TestApp.UnitTests;

public class PrimeFactorTests
{
    [Test]
    public void Test_FindLargestPrimeFactor_PrimeNumber()

    {
        // Arrange
        long number = 17; // Example prime number
        long expected = 17; // Largest prime factor of 17 is 17

        // Act
        long result = PrimeFactor.FindLargestPrimeFactor(number);

        // Assert
        Assert.AreEqual(expected, result, $"Largest prime factor of {number} should be {expected}");
    }

    [Test]
    public void Test_FindLargestPrimeFactor_LargeNumber()
    {
        // Arrange
        long number = 600851475143; // Example large number
        long expected = 6857; // Largest prime factor of 600851475143 is 6857

        // Act
        long result = PrimeFactor.FindLargestPrimeFactor(number);

        // Assert
        Assert.AreEqual(expected, result, $"Largest prime factor of {number} should be {expected}");
    }
}

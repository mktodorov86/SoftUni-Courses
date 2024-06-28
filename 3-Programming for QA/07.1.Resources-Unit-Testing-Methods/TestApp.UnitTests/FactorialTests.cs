using NUnit.Framework;

namespace TestApp.UnitTests;

public class FactorialTests
{
    [Test]
    public void Test_CalculateFactorial_InputZero_ReturnsOne()
    {
        // Act
        int actual = Factorial.CalculateFactorial(0);

        // Assert
        Assert.AreEqual(1, actual, "Factorial of 0 should be 1.");
    }


    [Test]
    public void Test_CalculateFactorial_InputPositiveNumber_ReturnsCorrectFactorial()
    {
        // Act
        int actual = Factorial.CalculateFactorial(1);

        // Assert
        Assert.AreEqual(1, actual, "Factorial of 1 should be 1.");
    }

}

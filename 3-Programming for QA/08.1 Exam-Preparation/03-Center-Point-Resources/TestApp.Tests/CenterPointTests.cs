using System;
using NUnit.Framework;

namespace TestApp.Tests;

public class CenterPointTests
{
    [Test]
    public void Test_GetClosest_WhenFirstPointIsCloser_ShouldReturnFirstPoint()
    {
        // Arrange
        double x1 = 2.0;
        double y1 = 3.0;
        double x2 = 4.0;
        double y2 = 5.0;

        string expected = "(2, 3)";

        // Act
        string result = CenterPoint.GetClosest(x1, y1, x2, y2);

        // Assert
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Test_GetClosest_WhenSecondPointIsCloser_ShouldReturnSecondPoint()
    {
        // Arrange
        double x1 = 2.0;
        double y1 = 3.0;
        double x2 = -1.0;
        double y2 = -2.0;

        string expected = "(-1, -2)";

        // Act
        string result = CenterPoint.GetClosest(x1, y1, x2, y2);

        // Assert
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Test_GetClosest_WhenBothPointsHaveEqualDistance_ShouldReturnFirstPoint()
    {
        // Arrange
        double x1 = 1.0;
        double y1 = 2.0;
        double x2 = -1.0;
        double y2 = -2.0;

        string expected = "(-1, -2)";

        // Act
        string result = CenterPoint.GetClosest(x1, y1, x2, y2);

        // Assert
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Test_GetClosest_WhenFirstPointIsNegative_ShouldReturnFirstPoint()
    {
        // Arrange
        double x1 = -1.0;
        double y1 = -2.0;
        double x2 = 2.0;
        double y2 = 3.0;

        string expected = "(-1, -2)";

        // Act
        string result = CenterPoint.GetClosest(x1, y1, x2, y2);

        // Assert
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Test_GetClosest_WhenSecondPointIsNegative_ShouldReturnSecondPoint()
    {
        // Arrange
        double x1 = 1.0;
        double y1 = 2.0;
        double x2 = -2.0;
        double y2 = -3.0;

        string expected = "(1, 2)";

        // Act
        string result = CenterPoint.GetClosest(x1, y1, x2, y2);

        // Assert
        Assert.AreEqual(expected, result);
    }
}

using NUnit.Framework;

namespace TestApp.UnitTests;

public class TriangleTests
{
    [Test]
    public void Test_Triangle_OutputMatchesExpected_Size0()
    {
        // Arrange
        int size = 0;
        string expected = "";

        // Act
        string actual = Triangle.PrintTriangle(size);

        // Assert
        Assert.AreEqual(expected, actual, $"Triangle of size {size} did not match expected output.");
    }

    [Test]
    public void Test_Triangle_OutputMatchesExpected_Size3()
  
    {
        // Arrange
        int size = 3;
        string expected = "1" + System.Environment.NewLine +
                          "1 2" + System.Environment.NewLine +
                          "1 2 3" + System.Environment.NewLine +
                          "1 2" + System.Environment.NewLine +
                          "1";

        // Act
        string actual = Triangle.PrintTriangle(size);

        // Assert
        Assert.AreEqual(expected, actual, $"Triangle of size {size} did not match expected output.");
    }

    [Test]
    public void Test_Triangle_OutputMatchesExpected_Size5()
    {
        // Arrange
        int size = 5;
        string expected = "1" + System.Environment.NewLine +
                          "1 2" + System.Environment.NewLine +
                          "1 2 3" + System.Environment.NewLine +
                          "1 2 3 4" + System.Environment.NewLine +
                          "1 2 3 4 5" + System.Environment.NewLine +
                          "1 2 3 4" + System.Environment.NewLine +
                          "1 2 3" + System.Environment.NewLine +
                          "1 2" + System.Environment.NewLine +
                          "1";

        // Act
        string actual = Triangle.PrintTriangle(size);

        // Assert
        Assert.AreEqual(expected, actual, $"Triangle of size {size} did not match expected output.");
    }
}

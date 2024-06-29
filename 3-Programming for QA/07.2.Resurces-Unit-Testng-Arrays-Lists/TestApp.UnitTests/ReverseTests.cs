using NUnit.Framework;

using System;

namespace TestApp.UnitTests;

public class ReverseTests
{
    [Test]
    public void Test_ReverseArray_InputIsEmpty_ShouldReturnEmptyString()
    {
        // Arrange
        int[] emptyArray = Array.Empty<int>();

        // Act
        string result = Reverse.ReverseArray(emptyArray);

        // Assert
        Assert.That(result, Is.EqualTo(string.Empty));
    }

    // TODO: finish the test
    [Test]
    public void Test_ReverseArray_InputHasOneElement_ShouldReturnTheSameElement()
    {
        // Arrange
        int[] arr = new int[] { 42 };

        // Act
        string result = Reverse.ReverseArray(arr);

        // Assert
        Assert.That(result, Is.EqualTo("42"), "Reversed array of single element should be the element itself.");
    }

    [Test]
    public void Test_ReverseArray_InputHasMultipleElements_ShouldReturnReversedString()
    {
        // Arrange
        int[] arr = new int[] { 1, 2, 3, 4, 5 };

        // Act
        string result = Reverse.ReverseArray(arr);

        // Assert
        Assert.That(result, Is.EqualTo("5 4 3 2 1"), "Reversed array should match expected reversed string.");
    }
}

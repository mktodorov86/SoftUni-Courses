using NUnit.Framework;

using System;

namespace TestApp.UnitTests;

public class FakeTests
{
    [Test]
    public void Test_RemoveStringNumbers_RemovesDigitsFromCharArray()
    {
        // Arrange
        char[] input = "Abc123Def456Ghi".ToCharArray();
        char[] expected = "AbcDefGhi".ToCharArray();

        // Act
        char[] result = Fake.RemoveStringNumbers(input);

        // Assert
        Assert.AreEqual(expected, result, "Digits should be removed from the input array.");
    }

    [Test]
    public void Test_RemoveStringNumbers_NoDigitsInInput_ReturnsSameArray()
    {
        // Arrange
        char[] input = "OnlyLetters".ToCharArray();
        char[] expected = "OnlyLetters".ToCharArray();

        // Act
        char[] result = Fake.RemoveStringNumbers(input);

        // Assert
        Assert.AreEqual(expected, result, "Method should return the same array when no digits are present.");
    }

    [Test]
    public void Test_RemoveStringNumbers_EmptyArray_ReturnsEmptyArray()
    {
        // Arrange
        char[] input = new char[] { };
        char[] expected = new char[] { };

        // Act
        char[] result = Fake.RemoveStringNumbers(input);

        // Assert
        Assert.AreEqual(expected, result, "Method should return an empty array when input is empty.");
    }
}

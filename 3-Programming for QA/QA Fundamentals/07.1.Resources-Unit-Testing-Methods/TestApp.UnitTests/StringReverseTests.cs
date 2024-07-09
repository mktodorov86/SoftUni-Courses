using NUnit.Framework;
using System;

namespace TestApp.UnitTests;

public class StringReverseTests
{
    // TODO: finish test
    [Test]
    public void Test_Reverse_WhenGivenEmptyString_ReturnsEmptyString()
    {
        {
            // Act
            string actual = StringReverse.Reverse("");

            // Assert
            Assert.AreEqual("", actual, "The reverse of an empty string should be an empty string.");
        }
    }

    [Test]
    public void Test_Reverse_WhenGivenSingleCharacterString_ReturnsSameCharacter()
    {
        // Act
        string actual = StringReverse.Reverse("a");

        // Assert
        Assert.AreEqual("a", actual, "The reverse of a single character 'a' should be 'a'.");
    }

    [Test]
    public void Test_Reverse_WhenGivenNormalString_ReturnsReversedString()
    {
        // Arrange
        string input = "hello";
        string expected = "olleh";

        // Act
        string actual = StringReverse.Reverse(input);

        // Assert
        Assert.AreEqual(expected, actual, $"The reverse of '{input}' should be '{expected}'.");
    }
}

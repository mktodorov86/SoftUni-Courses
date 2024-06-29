using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace TestApp.UnitTests;

public class PalindromeTests
{
    // TODO: finish test
    [Test]
    public void Test_IsPalindrome_ValidPalindrome_ReturnsTrue()
    { 
        // Arrange
            List<string> words = new List<string> { "radar", "level", "madam" };

    // Act
    bool result = Palindrome.IsPalindrome(words);

    // Assert
    Assert.IsTrue(result, "Expected true for valid palindromes.");
        }

// TODO: finish test
[Test]
    public void Test_IsPalindrome_EmptyList_ReturnsTrue()
    {
        // Arrange
        List<string> words = new List<string>();

        // Act
        bool result = Palindrome.IsPalindrome(words);

        // Assert
        Assert.IsTrue(result, "Expected true for empty list.");
    }

    [Test]
    public void Test_IsPalindrome_SingleWord_ReturnsTrue()
    {
        // Arrange
        List<string> words = new List<string> { "level" };

        // Act
        bool result = Palindrome.IsPalindrome(words);

        // Assert
        Assert.IsTrue(result, "Expected true for single palindrome word.");
    }

    [Test]
    public void Test_IsPalindrome_NonPalindrome_ReturnsFalse()
    {
        // Arrange
        List<string> words = new List<string> { "hello" };

        // Act
        bool result = Palindrome.IsPalindrome(words);

        // Assert
        Assert.IsFalse(result, "Expected false for non-palindrome word.");
    }

    [Test]
    public void Test_IsPalindrome_MixedCasePalindrome_ReturnsTrue()
    {
        // Arrange
        List<string> words = new List<string> { "Racecar" }; // "Racecar" is a palindrome

        // Act
        bool result = Palindrome.IsPalindrome(words);

        // Assert
        Assert.IsTrue(result, "Expected true for mixed-case palindrome.");
    }

}

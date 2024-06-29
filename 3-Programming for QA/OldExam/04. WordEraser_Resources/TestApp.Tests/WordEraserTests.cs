using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace TestApp.Tests;

public class WordEraserTests
{
    [Test]
    public void Test_Erase_EmptyWordsList_ShouldReturnEmptyString()
    {
        // Arrange
        WordEraser wordEraser = new WordEraser();
        List<string> emptyList = new List<string>();

        // Act
        string result = wordEraser.Erase(emptyList, "erase");

        // Assert
        Assert.AreEqual(string.Empty, result);
    }

    [Test]
       public void Test_Erase_NullWordsList_ShouldReturnEmptyString()
    {
        // Arrange
        WordEraser wordEraser = new WordEraser();
        List<string> nullList = null;

        // Act
        string result = wordEraser.Erase(nullList, "erase");

        // Assert
        Assert.AreEqual(string.Empty, result);
    }

    [Test]
    public void Test_Erase_NullOrEmptyWordToErase_ShouldReturnStringOfGivenWordsList()
    {
        // Arrange
        WordEraser wordEraser = new WordEraser();
        List<string> wordsList = new List<string> { "apple", "banana", "cherry", "date" };

        // Act
        string resultEmpty = wordEraser.Erase(wordsList, null);
        string resultEmptyString = wordEraser.Erase(wordsList, "");

        // Assert
        Assert.AreEqual("apple banana cherry date", resultEmpty);
        Assert.AreEqual("apple banana cherry date", resultEmptyString);
    }

    [Test]
    public void Test_Erase_ValidInput_ShouldReturnEmptyString_WhenAllWordsMatchedTheWordToErase()
    {
        // Arrange
        WordEraser wordEraser = new WordEraser();
        List<string> wordsList = new List<string> { "apple", "apple", "apple", "apple" };
        string wordToErase = "apple";

        // Act
        string result = wordEraser.Erase(wordsList, wordToErase);

        // Assert
        Assert.AreEqual(string.Empty, result);
    }

    [Test]
    public void Test_Erase_ValidInput_ShouldReturnStringWithoutErasedWords_WhenFewOfWordsMatchedWordToArese()
    {
        // Arrange
        WordEraser wordEraser = new WordEraser();
        List<string> wordsList = new List<string> { "apple", "banana", "cherry", "apple", "date", "apple" };
        string wordToErase = "apple";

        // Act
        string result = wordEraser.Erase(wordsList, wordToErase);

        // Assert
        Assert.AreEqual("banana cherry date", result);
    }
}


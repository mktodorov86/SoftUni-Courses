using System;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace TestApp.Tests;

[TestFixture]
public class YellingCheckerTests
{
    [Test]
    public void Test_AnalyzeSentence_EmptyString_ReturnsEmptyDictionary()
    {
        // Arrange
        string sentence = string.Empty;

        // Act
        var result = YellingChecker.AnalyzeSentence(sentence);

        // Assert
        Assert.IsNotNull(result);
        Assert.IsEmpty(result);
    }

    [Test]
    public void Test_AnalyzeSentence_OnlyUpperCaseWords_ReturnsDictionaryWithYellingEntriesOnly()
    {
        // Arrange
        string sentence = "HELLO WORLD";

        // Act
        var result = YellingChecker.AnalyzeSentence(sentence);

        // Assert
        Assert.IsTrue(result.ContainsKey("yelling"));
        Assert.AreEqual(2, result["yelling"]);
        Assert.IsFalse(result.ContainsKey("speaking lower"));
        Assert.IsFalse(result.ContainsKey("speaking normal"));
    }

    [Test]
    public void Test_AnalyzeSentence_OnlyLowerCaseWords_ReturnsDictionaryWithSpeakingLowerEntriesOnly()
    {
        // Arrange
        string sentence = "hello world";

        // Act
        var result = YellingChecker.AnalyzeSentence(sentence);

        // Assert
        Assert.IsTrue(result.ContainsKey("speaking lower"));
        Assert.AreEqual(2, result["speaking lower"]);
        Assert.IsFalse(result.ContainsKey("yelling"));
        Assert.IsFalse(result.ContainsKey("speaking normal"));
    }

    [Test]
    public void Test_AnalyzeSentence_OnlyMixedCaseWords_ReturnsDictionaryWithASpeakingNormalEntriesOnly()
    {
        // Arrange
        string sentence = "Hello World";

        // Act
        var result = YellingChecker.AnalyzeSentence(sentence);

        // Assert
        Assert.IsTrue(result.ContainsKey("speaking normal"));
        Assert.AreEqual(2, result["speaking normal"]);
        Assert.IsFalse(result.ContainsKey("yelling"));
        Assert.IsFalse(result.ContainsKey("speaking lower"));
    }

    [Test]
    public void Test_AnalyzeSentence_LowerUpperMixedCasesWords_ReturnsDictionaryWithAllTypeOfEntries()
    {
        // Arrange
        string sentence = "HELLO world Hello";

        // Act
        var result = YellingChecker.AnalyzeSentence(sentence);

        // Assert
        Assert.IsTrue(result.ContainsKey("yelling"));
        Assert.AreEqual(1, result["yelling"]);

        Assert.IsTrue(result.ContainsKey("speaking lower"));
        Assert.AreEqual(1, result["speaking lower"]);

        Assert.IsTrue(result.ContainsKey("speaking normal"));
        Assert.AreEqual(1, result["speaking normal"]);
    }
}
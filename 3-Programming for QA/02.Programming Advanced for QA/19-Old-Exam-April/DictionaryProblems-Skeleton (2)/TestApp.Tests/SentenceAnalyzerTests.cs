using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;

namespace TestApp.Tests;

[TestFixture]
public class SentenceAnalyzerTests
{
    [Test]
    public void Test_Analyze_EmptyString_ReturnsEmptyDictionary()
    {
        // Arrange
        string input = string.Empty;
        var expected = new Dictionary<string, int>();

        // Act
        var result = SentenceAnalyzer.Analyze(input);

        // Assert
        CollectionAssert.AreEquivalent(expected, result);
    }


    [Test]
    public void Test_Analyze_SingleLetter_ReturnsDictionaryWithSingleLetterEntry()
    {
        // Arrange
        string input = "A";
        var expected = new Dictionary<string, int>
    {
        { "letters", 1 }
    };

        // Act
        var result = SentenceAnalyzer.Analyze(input);

        // Assert
        CollectionAssert.AreEquivalent(expected, result);
    }


    [Test]
    public void Test_Analyze_SingleDigit_ReturnsDictionaryWithSingleDigitEntry()
    {
        // Arrange
        string input = "1";
        var expected = new Dictionary<string, int>
    {
        { "digits", 1 }
    };

        // Act
        var result = SentenceAnalyzer.Analyze(input);

        // Assert
        CollectionAssert.AreEquivalent(expected, result);
    }

    [Test]
    public void Test_Analyze_WholeSentence_ReturnsDictionaryWithAllSymbolTypesCount()
    {
        // Arrange
        string input = "Hello World! 123 @#";
        var expected = new Dictionary<string, int>
    {
        { "letters", 10 },                // H, e, l, l, o, W, o, r, l, d
        { "digits", 3 },                  // 1, 2, 3
        { "special characters", 3 }       // !, @, #
    };

        // Act
        var result = SentenceAnalyzer.Analyze(input);

        // Assert
        CollectionAssert.AreEquivalent(expected, result);
    }

}


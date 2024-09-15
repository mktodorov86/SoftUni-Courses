using System;
using System.Text;
using System.Linq;
using NUnit.Framework;
using System.Collections.Generic;

namespace TestApp.Tests;

[TestFixture]
public class StringLengthCalculatorTests
{
    [Test]
    public void Test_Calculate_EmptyString_ReturnsZero()
    {
       
        string input = string.Empty;

        int result = StringLengthCalculator.Calculate(input);

        Assert.AreEqual(0, result);
    }

    [Test]
    public void Test_Calculate_SingleEvenLengthWord_ReturnsCorrectInteger()
    {
      
        string input = "hello"; 

       
        int result = StringLengthCalculator.Calculate(input);

       
        Assert.AreEqual(266, result); 
    }

    [Test]
    public void Test_Calculate_SingleOddLengthWord_ReturnsCorrectInteger()
    {
       
        string input = "world"; 

       
        int result = StringLengthCalculator.Calculate(input);

       
        Assert.AreEqual(276, result); 
    }

    [Test]
    public void Test_Calculate_WholeSentenceString_ReturnsCorrectInteger()
    {
       
        string input = "Hello, world!"; 

       
        int result = StringLengthCalculator.Calculate(input);

      
        Assert.AreEqual(541, result); 
    }
}
using NUnit.Framework;
using System.Collections.Generic;

namespace TestApp.Tests
{
    public class VowelsCounterTests
    {
        [Test]
        public void Test_CountTotalVowels_GetEmptyList_ReturnsZero()
        {
            int result = VowelsCounter.CountTotalVowels(new List<string>());
            Assert.AreEqual(0, result);
        }

        [Test]
        public void Test_CountTotalVowels_GetListWithEmptyStringValues_ReturnsZero()
        {
            int result = VowelsCounter.CountTotalVowels(new List<string> { "", "", "" });
            Assert.AreEqual(0, result);
        }

        [Test]
        public void Test_CountTotalVowels_MultipleLowerCaseStrings_ReturnsVowelsCount()
        {
            int result = VowelsCounter.CountTotalVowels(new List<string> { "apple", "banana", "cherry" });
            Assert.AreEqual(6, result);
        }

        [Test]
        public void Test_CountTotalVowels_GetStringsWithNoVowels_ReturnsZero()
        {
            int result = VowelsCounter.CountTotalVowels(new List<string> { "bcdfg", "hjklm", "npqrst" });
            Assert.AreEqual(0, result);
        }

        [Test]
        public void Test_CountTotalVowels_StringsWithMixedCaseVowels_ReturnsVowelsCount()
        {
            int result = VowelsCounter.CountTotalVowels(new List<string> { "AppLe", "BaNana", "ChErry" });
            Assert.AreEqual(6, result); 
        }
    }
}

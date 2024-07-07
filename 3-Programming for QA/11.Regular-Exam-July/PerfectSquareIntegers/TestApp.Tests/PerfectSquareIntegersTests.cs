using NUnit.Framework;

namespace TestApp.Tests
{
    public class PerfectSquareIntegersTests
    {
        [Test]
        public void Test_FindPerfectSquares_StartNumberGreaterThanEndNumber_ReturnsErrorMessage()
        {
            string result = PerfectSquareIntegers.FindPerfectSquares(10, 5);
            Assert.AreEqual("Start number should be less than end number.", result);
        }

        [Test]
        public void Test_FindPerfectSquares_GetSameSquareIntegerForStartAndEnd_ReturnsSameSquareInteger()
        {
            string result = PerfectSquareIntegers.FindPerfectSquares(4, 4);
            Assert.AreEqual("4", result);
        }

        [Test]
        public void Test_FindPerfectSquares_GetZeroAsSingleInteger_ReturnsZero()
        {
            string result = PerfectSquareIntegers.FindPerfectSquares(0, 0);
            Assert.AreEqual("0", result);
        }

        [Test]
        public void Test_FindPerfectSquares_RangeIncludesMultiplePerfectSquares_ReturnsOnlySquareIntegers()
        {
            string result = PerfectSquareIntegers.FindPerfectSquares(1, 16);
            Assert.AreEqual("1 4 9 16", result);
        }

        [Test]
        public void Test_FindPerfectSquares_NoPerfectSquaresInRange_ReturnsEmptyString()
        {
            string result = PerfectSquareIntegers.FindPerfectSquares(2, 3);
            Assert.AreEqual(string.Empty, result);
        }
    }
}

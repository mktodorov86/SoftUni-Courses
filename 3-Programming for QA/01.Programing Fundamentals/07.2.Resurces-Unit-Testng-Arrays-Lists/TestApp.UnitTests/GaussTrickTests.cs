using NUnit.Framework;
using System.Collections.Generic;

namespace TestApp.UnitTests
{
    public class GaussTrickTests
    {
        [Test]
        public void Test_SumPairs_InputIsEmptyList_ShouldReturnEmptyList()
        {
            // Arrange
            List<int> emptyList = new List<int>();

            // Act
            List<int> result = GaussTrick.SumPairs(emptyList);

            // Assert
            CollectionAssert.AreEqual(emptyList, result);
        }

        [Test]
        public void Test_SumPairs_InputHasSingleElement_ShouldReturnSameElement()
        {
            // Arrange
            List<int> list = new List<int> { 5 };
            List<int> expected = new List<int> { 5 };

            // Act
            List<int> result = GaussTrick.SumPairs(list);

            // Assert
            CollectionAssert.AreEqual(expected, result, "Single element should remain unchanged.");
        }

        [Test]
        public void Test_SumPairs_InputHasEvenCountElements_ShouldReturnSumPairs()
        {
            // Arrange
            List<int> list = new List<int> { 1, 2, 3, 4 };
            List<int> expected = new List<int> { 5, 5 };

            // Act
            List<int> result = GaussTrick.SumPairs(list);

            // Assert
            CollectionAssert.AreEqual(expected, result, "Pairs should be summed correctly for even count elements.");
        }

        [Test]
        public void Test_SumPairs_InputHasOddCountElements_ShouldReturnWithMiddleElement()
        {
            // Arrange
            List<int> list = new List<int> { 1, 2, 3, 4, 5 };
            List<int> expected = new List<int> { 6, 6, 3 };

            // Act
            List<int> result = GaussTrick.SumPairs(list);

            // Assert
            CollectionAssert.AreEqual(expected, result, "Pairs should be summed correctly for odd count elements.");
        }

        [Test]
        public void Test_SumPairs_InputHasLargeEvenCountElements_ShouldReturnSumPairs()
        {
            // Arrange
            List<int> list = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };
            List<int> expected = new List<int> { 21, 21, 21, 21, 21, 21, 21, 21, 21, 21 };

            // Act
            List<int> result = GaussTrick.SumPairs(list);

            // Assert
            CollectionAssert.AreEqual(expected, result, "Pairs should be summed correctly for large even count elements.");
        }

        [Test]
        public void Test_SumPairs_InputHasLargeOddCountElements_ShouldReturnWithMiddleElement()
        {
            // Arrange
            List<int> list = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19 };
            List<int> expected = new List<int> { 20, 20, 20, 20, 20, 20, 20, 20, 20, 10 };

            // Act
            List<int> result = GaussTrick.SumPairs(list);

            // Assert
            CollectionAssert.AreEqual(expected, result, "Pairs should be summed correctly for large odd count elements.");
        }
    }
}

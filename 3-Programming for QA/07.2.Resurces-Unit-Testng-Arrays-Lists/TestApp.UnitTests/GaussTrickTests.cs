using NUnit.Framework;

using System.Collections.Generic;

namespace TestApp.UnitTests;

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

    // TODO: finish the test
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

    // TODO: finish the test
    [Test]
    public void Test_SumPairs_InputHasEvenCountElements_ShouldReturnSumPairs()
    {
        // Test with 2 elements
        List<int> list2 = new List<int> { 1, 2 };
        List<int> expected2 = new List<int> { 3 };

        List<int> result2 = GaussTrick.SumPairs(list2);
        CollectionAssert.AreEqual(expected2, result2, "Pairs should be summed correctly for 2 elements.");
    }

    [Test]
    public void Test_SumPairs_InputHasOddCountElements_ShouldReturnWithMiddleElement()
    {
        List<int> list3 = new List<int> { 1, 2, 3 };
        List<int> expected3 = new List<int> { 4, 2 };

        List<int> result3 = GaussTrick.SumPairs(list3);
        CollectionAssert.AreEqual(expected3, result3, "Pairs should be summed correctly for 3 elements.");

    }

    [Test]
    public void Test_SumPairs_InputHasLargeEvenCountElements_ShouldReturnSumPairs()
    {
        {
            // Arrange
            List<int> list = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
            int expected = 16; // Sum of the first and last element

            // Act
            List<int> result = GaussTrick.SumPairs(list);

            // Assert
            Assert.AreEqual(expected, result[0], "Sum of the first and last element should be 16.");
        }

    }

    [Test]
    public void Test_SumPairs_InputHasLargeOddCountElements_ShouldReturnWithMiddleElement()
    {
        // Arrange
        List<int> list19 = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19 };
        List<int> expected19 = new List<int> { 20, 20, 20, 20, 20, 20, 20, 20, 20, 10 }; // (1+19), (2+18), (3+17), (4+16), (5+15), (6+14), (7+13), (8+12), (9+11), middle element: 10

        // Act
        List<int> result19 = GaussTrick.SumPairs(list19);

        // Assert
        CollectionAssert.AreEqual(expected19, result19, "Pairs should be summed correctly for a list with 19 elements.");
    }

}

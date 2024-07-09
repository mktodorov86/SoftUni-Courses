using NUnit.Framework;
using System.Collections.Generic;

namespace TestApp.Tests
{
    public class MessagingTests
    {
        [Test]
        public void Test_GetMessage_WithValidInput_ReturnsExpectedMessage()
        {
            var nums = new List<int> { 123, 456, 789 };
            var s = "abcdefghi";
            var result = Messaging.GetMessage(nums, s);
            Assert.AreEqual("gid", result); // Adjust this assertion based on the actual expected output
        }

        [Test]
        public void Test_GetMessage_EmptyList_ReturnsEmptyString()
        {
            var nums = new List<int>();
            var s = "abcdef";
            var result = Messaging.GetMessage(nums, s);
            Assert.AreEqual(string.Empty, result);
        }

        [Test]
        public void Test_GetMessage_EmptyString_ReturnsEmptyString()
        {
            var nums = new List<int> { 1, 2, 3 };
            var s = string.Empty;
            var result = Messaging.GetMessage(nums, s);
            Assert.AreEqual(string.Empty, result);
        }

        [Test]
        public void Test_GetMessage_NullList_ReturnsEmptyString()
        {
            List<int>? nums = null;
            var s = "abcdef";
            var result = Messaging.GetMessage(nums, s);
            Assert.AreEqual(string.Empty, result);
        }

        [Test]
        public void Test_GetMessage_NullString_ReturnsEmptyString()
        {
            var nums = new List<int> { 1, 2, 3 };
            string? s = null;
            var result = Messaging.GetMessage(nums, s);
            Assert.AreEqual(string.Empty, result);
        }
    }
}

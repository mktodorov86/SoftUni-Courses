using System;
using NUnit.Framework;
using TestApp.Chat;

namespace TestApp.Tests
{
    [TestFixture]
    public class ChatRoomTests
    {
        private ChatRoom _chatRoom = null!;

        [SetUp]
        public void Setup()
        {
            this._chatRoom = new();
        }

        [Test]
        public void Test_SendMessage_MessageSentToChatRoom()
        {
            // Arrange
            string sender = "Alice";
            string message = "Hello, world!";

            // Act
            this._chatRoom.SendMessage(sender, message);

            // Assert
            string chatDisplay = this._chatRoom.DisplayChat();
            Assert.IsTrue(chatDisplay.Contains("Alice: Hello, world!"));
        }

        [Test]
        public void Test_DisplayChat_NoMessages_ReturnsEmptyString()
        {
            // Act
            string chatDisplay = this._chatRoom.DisplayChat();

            // Assert
            Assert.AreEqual(string.Empty, chatDisplay);
        }

        [Test]
        public void Test_DisplayChat_WithMessages_ReturnsFormattedChat()
        {
            // Arrange
            string sender1 = "Alice";
            string message1 = "Hello, world!";
            string sender2 = "Bob";
            string message2 = "Hi, Alice!";

            this._chatRoom.SendMessage(sender1, message1);
            this._chatRoom.SendMessage(sender2, message2);

            // Act
            string chatDisplay = this._chatRoom.DisplayChat();

            // Assert
            string expected = $"Chat Room Messages:{Environment.NewLine}" +
                              $"Alice: Hello, world! - Sent at {DateTime.Now.Date:d}{Environment.NewLine}" +
                              $"Bob: Hi, Alice! - Sent at {DateTime.Now.Date:d}";
            Assert.AreEqual(expected, chatDisplay);
        }
    }
}

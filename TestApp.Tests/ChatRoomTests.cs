using System;

using NUnit.Framework;

using TestApp.Chat;

namespace TestApp.Tests;

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
        string sender = "Dimityr";
        string message = "Make exam nunit test now";

        // Act
        _chatRoom.SendMessage(sender, message);
        string chatDisplay = _chatRoom.DisplayChat();

        // Assert
        StringAssert.Contains(sender, chatDisplay);
        StringAssert.Contains(message, chatDisplay);
    }

    [Test]
    public void Test_DisplayChat_NoMessages_ReturnsEmptyString()
    {
        // Arrange
       

        // Act
        string chatDisplay = _chatRoom.DisplayChat();

        // Assert
        Assert.AreEqual(string.Empty, chatDisplay);
    }

    [Test]
    public void Test_DisplayChat_WithMessages_ReturnsFormattedChat()
    {
        // Arrange
        string sender1 = "Dimityr";
        string message1 = "Zdravei, kak si";
        _chatRoom.SendMessage(sender1, message1);

        string sender2 = "Ivan";
        string message2 = "Idvash li?";
        _chatRoom.SendMessage(sender2, message2);

        // Act
        string chatDisplay = _chatRoom.DisplayChat();

        // Assert
        StringAssert.Contains($"{sender1}: {message1}", chatDisplay);
        StringAssert.Contains($"{sender2}: {message2}", chatDisplay);
    }
}

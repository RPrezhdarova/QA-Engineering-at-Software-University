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
        //Arrange
        string sender = "Rositsa Prezhdarova";
        string message = "First Message";

        string expected = $"Rositsa Prezhdarova: First Message - Sent at ";

        //Act
        this._chatRoom.SendMessage(sender, message);
        string result = this._chatRoom.DisplayChat();

        //Assert
        Assert.That(result.Contains(expected), Is.True);

    }

    [Test]
    public void Test_DisplayChat_NoMessages_ReturnsEmptyString()
    {
        //Arrange
        string sender = String.Empty;
        string message = String.Empty;
        string expected = String.Empty;

        //Act        
        string result = this._chatRoom.DisplayChat();

        //Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_DisplayChat_WithMessages_ReturnsFormattedChat()
    {
        //Arrange
        string sender = "Rositsa Prezhdarova";
        string message = "First Message";
        string sender2 = "Vasil Prezhdarov";
        string message2 = "Second Message";

        string expected = "Rositsa Prezhdarova: First Message - Sent at ";
        string expected2= "Vasil Prezhdarov: Second Message - Sent at ";

        //Act
        this._chatRoom.SendMessage(sender, message);
        this._chatRoom.SendMessage(sender2, message2);
        string result = this._chatRoom.DisplayChat();

        //Assert

        bool isContained = result.Contains(expected) && result.Contains(expected2);
        Assert.That(isContained, Is.True);
    }
}

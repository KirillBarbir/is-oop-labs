using Itmo.ObjectOrientedProgramming.Lab3;
using Itmo.ObjectOrientedProgramming.Lab3.Destinations;
using Itmo.ObjectOrientedProgramming.Lab3.Logger;
using Itmo.ObjectOrientedProgramming.Lab3.MessageFinalPoint;
using Itmo.ObjectOrientedProgramming.Lab3.MessageFinalPoint.Displays;
using Itmo.ObjectOrientedProgramming.Lab3.MessageFinalPoint.Displays.DisplayDrivers;
using Itmo.ObjectOrientedProgramming.Lab3.MessageFinalPoint.Messages;
using Moq;
using Xunit;

namespace Lab3.Tests;

public class Lab3Tests
{
    [Fact]
    public void Test1()
    {
        // arrange
        var builder = new DestinationBuilder();
        var user1 = new User("1");
        var message1 = new Message("title", "body", Importance.VeryImportant);
        UserDestination userDestination = builder.BuildUser(user1);

        // act
        userDestination.SendMessage(message1);

        // assert
        Assert.False(user1.CheckReadStatus(message1));
    }

    [Fact]
    public void Test2()
    {
        // arrange
        var builder = new DestinationBuilder();
        var user1 = new User("1");
        var message1 = new Message("title", "body", Importance.VeryImportant);
        UserDestination userDestination = builder.BuildUser(user1);

        // act
        userDestination.SendMessage(message1);
        user1.MarkMessageAsRead(message1);

        // assert
        Assert.True(user1.CheckReadStatus(message1));
    }

    [Fact]
    public void Test3()
    {
        // arrange
        var builder = new DestinationBuilder();
        var user1 = new User("1");
        var message1 = new Message("title", "body", Importance.VeryImportant);
        UserDestination userDestination = builder.BuildUser(user1);

        // act
        userDestination.SendMessage(message1);
        user1.MarkMessageAsRead(message1);
        bool done = user1.MarkMessageAsRead(message1);

        // assert
        Assert.False(done);
    }

    [Fact]
    public void Test4()
    {
        // arrange
        var builder = new DestinationBuilder();
        var mock = new Mock<IDisplayDriver>();
        var display = new Display(mock.Object);
        DisplayDestination destination = builder.WithImportanceFilter(Importance.Important)
            .BuildDisplay(display);
        var message1 = new Message("title", "body", Importance.NotImportant);

        // act
        destination.SendMessage(message1);

        // assert
        mock.Verify(t => t.Print(message1.ToString()), Times.Never());
    }

    [Fact]
    public void Test5()
    {
        // arrange
        var builder = new DestinationBuilder();
        var mock = new Mock<IBasicLoggerLogWrapper>();
        var basicLogger = new BasicLogger("lab-3logs", mock.Object);
        var messenger = new Messenger(new MessengerPrintWrapper());
        MessengerDestination destination = builder.WithLogger(basicLogger)
            .BuildMessenger(messenger);
        var message1 = new Message("title", "body", Importance.NotImportant);

        // act
        destination.SendMessage(message1);

        // assert
        mock.Verify(t => t.Log("lab-3logs", message1 + "is sent to " + messenger), Times.Once());
    }

    [Fact]
    public void Test6()
    {
        // arrange
        var builder = new DestinationBuilder();
        var mock = new Mock<IMessengerPrintWrapper>();
        var messenger = new Messenger(mock.Object);
        MessengerDestination destination = builder.WithImportanceFilter(Importance.Important)
            .BuildMessenger(messenger);
        var message1 = new Message("title", "body", Importance.Important);

        // act
        destination.SendMessage(message1);

        // assert
        mock.Verify(t => t.Print($"Messenger: {message1}"), Times.Once());
    }

    [Fact]
    public void Test7()
    {
        // arrange
        var builder = new DestinationBuilder();
        var user1 = new User("1");
        var message1 = new Message("title", "body", Importance.Important);
        UserDestination userDestination1 = builder.WithImportanceFilter(Importance.NotImportant).BuildUser(user1);
        UserDestination userDestination2 = builder.WithImportanceFilter(Importance.VeryImportant).BuildUser(user1);
        var destinations = new List<BaseDestination>();
        destinations.Add(userDestination1);
        destinations.Add(userDestination2);
        var topic = new Topic("topic", destinations);

        // act
        topic.SendMessage(new Message("title", "body", Importance.Important));

        // assert
        Assert.Equal(1, user1.GetMessageCount());
    }
}
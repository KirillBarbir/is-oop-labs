using Itmo.ObjectOrientedProgramming.Lab3;
using Itmo.ObjectOrientedProgramming.Lab3.Destinations;
using Itmo.ObjectOrientedProgramming.Lab3.Destinations.Factories;
using Itmo.ObjectOrientedProgramming.Lab3.Logger;
using Itmo.ObjectOrientedProgramming.Lab3.MessageFinalPoint;
using Itmo.ObjectOrientedProgramming.Lab3.MessageFinalPoint.Displays;
using Itmo.ObjectOrientedProgramming.Lab3.MessageFinalPoint.Displays.DisplayDrivers;
using Itmo.ObjectOrientedProgramming.Lab3.MessageFinalPoint.Messengers;
using NSubstitute;
using Xunit;

namespace Lab3.Tests;

public class Lab3Tests
{
    [Fact]
    public void UserReceiveMessageAsUnreadTest()
    {
        // arrange
        var factory = new StandartDestinationFactory();
        var user = new User("user");
        var importance = new Importance(5);
        var message = new Message("title", "body", importance);
        IDestination userDestination = factory.CreateUserDestination(user);

        // act
        userDestination.SendMessage(message);

        // assert
        Assert.False(user.IsMessageRead(message));
    }

    [Fact]
    public void UserReceiveMessageAndReadTest()
    {
        // arrange
        var factory = new StandartDestinationFactory();
        var user = new User("user");
        var importance = new Importance(5);
        var message = new Message("title", "body", importance);
        IDestination userDestination = factory.CreateUserDestination(user);

        // act
        userDestination.SendMessage(message);
        user.ReadMessage(message);

        // assert
        Assert.True(user.IsMessageRead(message));
    }

    [Fact]
    public void UserReadMessageTwiceTest()
    {
        // arrange
        var factory = new StandartDestinationFactory();
        var user = new User("user");
        var importance = new Importance(5);
        var message = new Message("title", "body", importance);
        IDestination userDestination = factory.CreateUserDestination(user);

        // act
        userDestination.SendMessage(message);
        user.ReadMessage(message);
        ResultType result = user.ReadMessage(message);

        // assert
        Assert.Equal(ResultType.Failure, result);
    }

    [Fact]
    public void ImportanceFilterTest()
    {
        // arrange
        var importance1 = new Importance(5);
        var factory = new FilteredDestinationFactory(importance1);
        IDisplayDriver mock = Substitute.For<IDisplayDriver>();
        var display = new Display(mock);
        IDestination destination = factory.CreateDisplayDestination(display);
        var importance2 = new Importance(1);
        var message = new Message("title", "body", importance2);

        // act
        destination.SendMessage(message);

        // assert
        mock.DidNotReceive().Print(message.ToString());
    }

    [Fact]
    public void LoggingTest()
    {
        // arrange
        ILogger mock = Substitute.For<ILogger>();
        var factory = new LoggedDestinationFactory(mock);
        var messenger = new Messenger();
        var importance = new Importance(5);
        var message = new Message("title", "body", importance);
        IDestination messengerDestination = factory.CreateMessengerDestination(messenger);

        // act
        messengerDestination.SendMessage(message);

        // assert
        mock.Received().Log(message + "is sent");
    }

    [Fact]
    public void MessengerTest()
    {
        // arrange
        var factory = new StandartDestinationFactory();
        IMessengerPrintWrapper mock = Substitute.For<IMessengerPrintWrapper>();
        var messenger = new Messenger(mock);
        var importance = new Importance(5);
        var message = new Message("title", "body", importance);
        IDestination messengerDestination = factory.CreateMessengerDestination(messenger);

        // act
        messengerDestination.SendMessage(message);

        // assert
        mock.Received().Print($"Messenger: {message}");
    }

    [Fact]
    public void TwoDestinationsFilterTest()
    {
        // arrange
        var importance1 = new Importance(5);
        var factory = new FilteredDestinationFactory(importance1);
        var user = new User("user");
        var message = new Message("title", "body", importance1);
        IDestination userDestination1 = factory.CreateUserDestination(user);
        user.ReadMessage(message);
        var importance2 = new Importance(7);
        factory.SetImportanceFilter(importance2);
        IDestination userDestination2 = factory.CreateUserDestination(user);
        var destinations = new List<IDestination> { userDestination1, userDestination2 };
        var topic = new Topic("TOPIC", destinations);

        // act
        topic.SendMessage(message);

        // assert
        Assert.Equal(1, user.MessageReceived(message));
    }
}
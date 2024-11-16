using Itmo.ObjectOrientedProgramming.Lab3.Logger;
using Itmo.ObjectOrientedProgramming.Lab3.MessageFinalPoint;
using Itmo.ObjectOrientedProgramming.Lab3.MessageFinalPoint.Displays;
using Itmo.ObjectOrientedProgramming.Lab3.MessageFinalPoint.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Destinations;

public class DestinationBuilder : IDestinationBuilder
{
    public ILogger Logger { get; protected set; } = new EmptyLogger();

    public Importance Importance { get; protected set; }

    public IDestinationBuilder WithLogger(ILogger logger)
    {
        Logger = logger;
        return this;
    }

    public IDestinationBuilder WithImportanceFilter(Importance importance)
    {
        Importance = importance;
        return this;
    }

    public UserDestination BuildUser(User user)
    {
        return new UserDestination(Importance, Logger, user);
    }

    public MessengerDestination BuildMessenger(Messenger messenger)
    {
        return new MessengerDestination(Importance, Logger, messenger);
    }

    public DisplayDestination BuildDisplay(Display display)
    {
        return new DisplayDestination(Importance, Logger, display);
    }

    public GroupDestination BuildGroup(ICollection<BaseDestination> destinations)
    {
        return new GroupDestination(Importance, Logger, destinations);
    }
}
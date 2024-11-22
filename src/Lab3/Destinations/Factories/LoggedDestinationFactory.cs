using Itmo.ObjectOrientedProgramming.Lab3.Logger;
using Itmo.ObjectOrientedProgramming.Lab3.MessageFinalPoint;
using Itmo.ObjectOrientedProgramming.Lab3.MessageFinalPoint.Displays;
using Itmo.ObjectOrientedProgramming.Lab3.MessageFinalPoint.Messengers;

namespace Itmo.ObjectOrientedProgramming.Lab3.Destinations.Factories;

public class LoggedDestinationFactory : IDestinationFactory
{
    private readonly ILogger _logger;

    public LoggedDestinationFactory(ILogger logger)
    {
        _logger = logger;
    }

    public IDestination CreateUserDestination(User user)
    {
        return new DestinationLogger(new UserDestination(user), _logger);
    }

    public IDestination CreateMessengerDestination(Messenger messenger)
    {
        return new DestinationLogger(new MessengerDestination(messenger), _logger);
    }

    public IDestination CreateDisplayDestination(Display display)
    {
        return new DestinationLogger(new DisplayDestination(display), _logger);
    }

    public IDestination CreateGroupDestination(ICollection<IDestination> destinations)
    {
        return new DestinationLogger(new GroupDestination(destinations), _logger);
    }
}
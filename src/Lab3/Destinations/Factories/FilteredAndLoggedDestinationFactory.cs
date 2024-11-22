using Itmo.ObjectOrientedProgramming.Lab3.Logger;
using Itmo.ObjectOrientedProgramming.Lab3.MessageFinalPoint;
using Itmo.ObjectOrientedProgramming.Lab3.MessageFinalPoint.Displays;
using Itmo.ObjectOrientedProgramming.Lab3.MessageFinalPoint.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Destinations.Factories;

public class FilteredAndLoggedDestinationFactory : IDestinationFactory
{
    private readonly ILogger _logger;
    private Importance _importanceFilter;

    public FilteredAndLoggedDestinationFactory(Importance importanceFilter, ILogger logger)
    {
        _importanceFilter = importanceFilter;
        _logger = logger;
    }

    public void SetImportanceFilter(Importance importanceFilter)
    {
        _importanceFilter = importanceFilter;
    }

    public IDestination CreateUserDestination(User user)
    {
        return new DestinationLogger(new MessageFilter(new UserDestination(user), _importanceFilter), _logger);
    }

    public IDestination CreateMessengerDestination(Messenger messenger)
    {
        return new DestinationLogger(new MessageFilter(new MessengerDestination(messenger), _importanceFilter), _logger);
    }

    public IDestination CreateDisplayDestination(Display display)
    {
        return new DestinationLogger(new MessageFilter(new DisplayDestination(display), _importanceFilter), _logger);
    }

    public IDestination CreateGroupDestination(ICollection<IDestination> destinations)
    {
        return new DestinationLogger(new MessageFilter(new GroupDestination(destinations), _importanceFilter), _logger);
    }
}
using Itmo.ObjectOrientedProgramming.Lab3.MessageFinalPoint;
using Itmo.ObjectOrientedProgramming.Lab3.MessageFinalPoint.Displays;
using Itmo.ObjectOrientedProgramming.Lab3.MessageFinalPoint.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Destinations.Factories;

public class FilteredDestinationFactory : IDestinationFactory
{
    private Importance _importanceFilter;

    public FilteredDestinationFactory(Importance importanceFilter)
    {
        _importanceFilter = importanceFilter;
    }

    public void SetImportanceFilter(Importance importanceFilter)
    {
        _importanceFilter = importanceFilter;
    }

    public IDestination CreateUserDestination(User user)
    {
        return new MessageFilter(new UserDestination(user), _importanceFilter);
    }

    public IDestination CreateMessengerDestination(Messenger messenger)
    {
        return new MessageFilter(new MessengerDestination(messenger), _importanceFilter);
    }

    public IDestination CreateDisplayDestination(Display display)
    {
        return new MessageFilter(new DisplayDestination(display), _importanceFilter);
    }

    public IDestination CreateGroupDestination(ICollection<IDestination> destinations)
    {
        return new MessageFilter(new GroupDestination(destinations), _importanceFilter);
    }
}
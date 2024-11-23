using Itmo.ObjectOrientedProgramming.Lab3.MessageFinalPoint;
using Itmo.ObjectOrientedProgramming.Lab3.MessageFinalPoint.Displays;
using Itmo.ObjectOrientedProgramming.Lab3.MessageFinalPoint.Messengers;

namespace Itmo.ObjectOrientedProgramming.Lab3.Destinations.Factories;

public class StandartDestinationFactory
{
    public IDestination CreateUserDestination(User user)
    {
        return new UserDestination(user);
    }

    public IDestination CreateMessengerDestination(Messenger messenger)
    {
        return new MessengerDestination(messenger);
    }

    public IDestination CreateDisplayDestination(Display display)
    {
        return new DisplayDestination(display);
    }

    public IDestination CreateGroupDestination(ICollection<IDestination> destinations)
    {
        return new GroupDestination(destinations);
    }
}
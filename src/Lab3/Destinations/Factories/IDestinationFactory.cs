using Itmo.ObjectOrientedProgramming.Lab3.MessageFinalPoint;
using Itmo.ObjectOrientedProgramming.Lab3.MessageFinalPoint.Displays;
using Itmo.ObjectOrientedProgramming.Lab3.MessageFinalPoint.Messengers;

namespace Itmo.ObjectOrientedProgramming.Lab3.Destinations.Factories;

public interface IDestinationFactory
{
    IDestination CreateUserDestination(User user);

    IDestination CreateMessengerDestination(Messenger messenger);

    IDestination CreateDisplayDestination(Display display);

    IDestination CreateGroupDestination(ICollection<IDestination> destinations);
}
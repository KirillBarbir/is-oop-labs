using Itmo.ObjectOrientedProgramming.Lab3.Logger;
using Itmo.ObjectOrientedProgramming.Lab3.MessageFinalPoint;

namespace Itmo.ObjectOrientedProgramming.Lab3.Destinations;

public interface IDestinationBuilder
{
    IDestinationBuilder WithLogger(ILogger logger);

    IDestinationBuilder ImportanceFilter(Importance importance);

    UserDestination BuildUser(User user);

    MessengerDestination BuildMessenger(Messenger messenger);

    DisplayDestination BuildDisplay(Display display);

    GroupDestination BuildGroup(ICollection<BaseDestination> destinations);
}
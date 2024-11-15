using Itmo.ObjectOrientedProgramming.Lab3.Logger;

namespace Itmo.ObjectOrientedProgramming.Lab3.Destinations;

public class GroupDestination : BaseDestination
{
    public GroupDestination(Importance importance, ILogger logger, ICollection<BaseDestination> destinations)
        : base(importance, logger)
    {
        Destinations = destinations;
    }

    private ICollection<BaseDestination> Destinations { get; }

    public override void SendMessage(Message message)
    {
        foreach (BaseDestination destinations in Destinations)
        {
            destinations.SendMessage(message);
        }
    }
}
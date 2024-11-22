namespace Itmo.ObjectOrientedProgramming.Lab3.Destinations;

public class GroupDestination : IDestination
{
    private readonly ICollection<IDestination> _destinations;

    public GroupDestination(ICollection<IDestination> destinations)
    {
        _destinations = destinations;
    }

    public void SendMessage(Message message)
    {
        foreach (IDestination destinations in _destinations)
        {
            destinations.SendMessage(message);
        }
    }
}
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

    public IDestination Clone()
    {
        var clones = new List<IDestination>();
        foreach (IDestination destinations in _destinations)
        {
            clones.Add(destinations.Clone());
        }

        return new GroupDestination(clones);
    }
}
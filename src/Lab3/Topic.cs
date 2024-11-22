using Itmo.ObjectOrientedProgramming.Lab3.Destinations;

namespace Itmo.ObjectOrientedProgramming.Lab3;

public class Topic
{
    public Topic(string name, ICollection<IDestination> destinations)
    {
        Name = name;
        _destinations = destinations;
    }

    public string Name { get; }

    private readonly ICollection<IDestination> _destinations;

    public void SendMessage(Message message)
    {
        foreach (IDestination destination in _destinations)
        {
            destination.SendMessage(message);
        }
    }
}
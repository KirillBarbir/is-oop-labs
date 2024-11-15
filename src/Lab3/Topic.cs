using Itmo.ObjectOrientedProgramming.Lab3.Destinations;

namespace Itmo.ObjectOrientedProgramming.Lab3;

public class Topic
{
    public Topic(string name, ICollection<BaseDestination> destinations)
    {
        Name = name;
        Destinations = destinations;
    }

    public string Name { get; }

    private ICollection<BaseDestination> Destinations { get; }

    public void SendMessage(Message message)
    {
        foreach (BaseDestination destination in Destinations)
        {
            destination.SendMessage(message);
        }
    }
}
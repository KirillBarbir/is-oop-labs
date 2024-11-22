namespace Itmo.ObjectOrientedProgramming.Lab3.Destinations;

public class GroupDestination : IDestination
{
    public GroupDestination(ICollection<IDestination> destinations)
    {
        _destinations = destinations;
    }

    private readonly ICollection<IDestination> _destinations;

    public void SendMessage(Message message)
    {
        /*if (!CheckImportance(message.Importance))
        {
            Logger.Log(message + "is not sent to " + Destinations);
            return;
        }*/

        // Logger.Log(message + "is sent to " + Destinations);
        foreach (IDestination destinations in _destinations)
        {
            destinations.SendMessage(message);
        }
    }
}
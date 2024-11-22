namespace Itmo.ObjectOrientedProgramming.Lab3.Destinations;

public class MessageFilter : IDestination
{
    private readonly IDestination _destination;
    private readonly Importance _minimumImportance;

    public MessageFilter(IDestination destination, Importance minimumImportance)
    {
        _minimumImportance = minimumImportance;
        _destination = destination;
    }

    public void SendMessage(Message message)
    {
        if (message.Importance.ImportanceLevel >= _minimumImportance.ImportanceLevel)
        {
            _destination.SendMessage(message);
        }
    }
}
using Itmo.ObjectOrientedProgramming.Lab3.Logger;

namespace Itmo.ObjectOrientedProgramming.Lab3.Destinations;

public class DestinationLogger : IDestination
{
    private readonly IDestination _destination;
    private readonly ILogger _logger;

    public DestinationLogger(IDestination destination, ILogger logger)
    {
        _destination = destination;
        _logger = logger;
    }

    public void SendMessage(Message message)
    {
        _destination.SendMessage(message);
        _logger.Log(message + "is sent");
    }

    public IDestination Clone()
    {
        return new DestinationLogger(_destination.Clone(), _logger);
    }
}
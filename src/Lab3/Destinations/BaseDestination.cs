using Itmo.ObjectOrientedProgramming.Lab3.Logger;

namespace Itmo.ObjectOrientedProgramming.Lab3.Destinations;

public abstract class BaseDestination : IDestination
{
    protected BaseDestination(Importance importanceFilter, ILogger logger)
    {
        ImportanceFilter = importanceFilter;
        Logger = logger;
    }

    public ILogger Logger { get; }

    public Importance ImportanceFilter { get; }

    public abstract void SendMessage(Message message);

    protected bool CheckImportance(Importance importance)
    {
        return importance >= ImportanceFilter;
    }
}
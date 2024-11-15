using Itmo.ObjectOrientedProgramming.Lab3.Logger;
using Itmo.ObjectOrientedProgramming.Lab3.MessageFinalPoint;

namespace Itmo.ObjectOrientedProgramming.Lab3.Destinations;

public class DisplayDestination : BaseDestination
{
    public DisplayDestination(Importance importance, ILogger logger, Display display) : base(importance, logger)
    {
        Display = display;
    }

    public Display Display { get; }

    public override void SendMessage(Message message)
    {
        if (CheckImportance(message.Importance))
        {
            Logger.Log(message + "is not sent to " + ToString());
            return;
        }

        Display.ReceiveMessage(message);
    }
}
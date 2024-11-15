using Itmo.ObjectOrientedProgramming.Lab3.Logger;
using Itmo.ObjectOrientedProgramming.Lab3.MessageFinalPoint;

namespace Itmo.ObjectOrientedProgramming.Lab3.Destinations;

public class MessengerDestination : BaseDestination
{
    public MessengerDestination(Importance importance, ILogger logger, Messenger messenger) : base(importance, logger)
    {
        Messenger = messenger;
    }

    public Messenger Messenger { get; }

    public override void SendMessage(Message message)
    {
        if (CheckImportance(message.Importance))
        {
            Logger.Log(message + "is not sent to " + ToString());
            return;
        }

        Messenger.ReceiveMessage(message);
    }
}
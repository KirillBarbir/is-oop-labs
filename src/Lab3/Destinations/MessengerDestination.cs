using Itmo.ObjectOrientedProgramming.Lab3.MessageFinalPoint.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Destinations;

public class MessengerDestination : IDestination
{
    public MessengerDestination(Messenger messenger)
    {
        _messenger = messenger;
    }

    private readonly Messenger _messenger;

    public void SendMessage(Message message)
    {
        /*if (!CheckImportance(message.Importance))
        {
            Logger.Log(message + "is not sent to " + Messenger);
            return;
        }*/

        _messenger.ReceiveMessage(message.ToString());

        // Logger.Log(message + "is sent to " + Messenger);
    }
}
using Itmo.ObjectOrientedProgramming.Lab3.MessageFinalPoint.Messengers;

namespace Itmo.ObjectOrientedProgramming.Lab3.Destinations;

public class MessengerDestination : IDestination
{
    private readonly Messenger _messenger;

    public MessengerDestination(Messenger messenger)
    {
        _messenger = messenger;
    }

    public void SendMessage(Message message)
    {
        _messenger.ReceiveMessage(message.ToString());
    }

    public IDestination Clone()
    {
        return new MessengerDestination(_messenger);
    }
}
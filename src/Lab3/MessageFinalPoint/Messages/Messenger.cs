namespace Itmo.ObjectOrientedProgramming.Lab3.MessageFinalPoint.Messages;

public class Messenger
{
    private readonly IMessengerPrintWrapper _messengerPrintWrapper;

    public Messenger(IMessengerPrintWrapper messengerPrintWrapper)
    {
        _messengerPrintWrapper = messengerPrintWrapper;
    }

    public void ReceiveMessage(string text)
    {
        _messengerPrintWrapper.Print($"Messenger: {text}");
    }
}
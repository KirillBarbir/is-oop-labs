using Itmo.ObjectOrientedProgramming.Lab3.MessageFinalPoint.Displays;

namespace Itmo.ObjectOrientedProgramming.Lab3.Destinations;

public class DisplayDestination : IDestination
{
    private readonly Display _display;

    public DisplayDestination(Display display)
    {
        _display = display;
    }

    public void SendMessage(Message message)
    {
        _display.ReceiveMessage(message.ToString());
    }

    public IDestination Clone()
    {
        return new DisplayDestination(_display);
    }
}
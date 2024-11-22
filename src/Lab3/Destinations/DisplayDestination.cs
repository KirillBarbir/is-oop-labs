using Itmo.ObjectOrientedProgramming.Lab3.MessageFinalPoint.Displays;

namespace Itmo.ObjectOrientedProgramming.Lab3.Destinations;

public class DisplayDestination : IDestination
{
    public DisplayDestination(Display display)
    {
        _display = display;
    }

    private readonly Display _display;

    public void SendMessage(Message message)
    {
       /* if (!CheckImportance(message.Importance))
        {
            Logger.Log(message + "is not sent to " + Display);
            return;
        }*/

        _display.ReceiveMessage(message.ToString());

        // Logger.Log(message + "is sent to " + Display);
    }
}
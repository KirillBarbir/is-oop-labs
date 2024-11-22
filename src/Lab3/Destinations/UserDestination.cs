using Itmo.ObjectOrientedProgramming.Lab3.MessageFinalPoint;

namespace Itmo.ObjectOrientedProgramming.Lab3.Destinations;

public class UserDestination : IDestination
{
    public UserDestination(User user)
    {
        _user = user;
    }

    private readonly User _user;

    public void SendMessage(Message message)
    {
        /*if (!CheckImportance(message.Importance))
        {
            Logger.Log(message + "is not sent to " + User);
            return;
        }*/

        _user.ReceiveMessage(message);

        // Logger.Log(message + "is sent to " + User);
    }
}
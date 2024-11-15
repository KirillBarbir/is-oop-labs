using Itmo.ObjectOrientedProgramming.Lab3.Logger;
using Itmo.ObjectOrientedProgramming.Lab3.MessageFinalPoint;

namespace Itmo.ObjectOrientedProgramming.Lab3.Destinations;

public class UserDestination : BaseDestination
{
    public UserDestination(Importance importance, ILogger logger, User user) : base(importance, logger)
    {
        User = user;
    }

    public User User { get; }

    public override void SendMessage(Message message)
    {
        if (!CheckImportance(message.Importance))
        {
            Logger.Log(message + "is not sent to " + ToString());
            return;
        }

        User.ReceiveMessage(message);
    }
}
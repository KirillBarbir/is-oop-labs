using Itmo.ObjectOrientedProgramming.Lab3.MessageFinalPoint;

namespace Itmo.ObjectOrientedProgramming.Lab3.Destinations;

public class UserDestination : IDestination
{
    private readonly User _user;

    public UserDestination(User user)
    {
        _user = user;
    }

    public void SendMessage(Message message)
    {
        _user.ReceiveMessage(message);
    }

    public IDestination Clone()
    {
        return new UserDestination(_user);
    }
}
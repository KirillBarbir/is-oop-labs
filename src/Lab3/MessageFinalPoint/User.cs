namespace Itmo.ObjectOrientedProgramming.Lab3.MessageFinalPoint;

public class User
{
    private Dictionary<Message, bool> Messages { get; } = [];

    public User(string name)
    {
        Name = name;
    }

    public string Name { get; }

    public void ReceiveMessage(Message message)
    {
        Messages[message] = false;
    }

    public bool MarkMessageAsRead(Message message)
    {
        if (!Messages.TryGetValue(message, out bool read))
        {
            return false;
        }

        if (read)
        {
            return false;
        }

        Messages[message] = true;
        return true;
    }

    public bool CheckReadStatus(Message message)
    {
        Messages.TryGetValue(message, out bool read);
        return read;
    }

    public int GetMessageCount()
    {
        return Messages.Count;
    }
}
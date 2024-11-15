namespace Itmo.ObjectOrientedProgramming.Lab3.MessageFinalPoint;

public class User : IMessageFinalPoint
{
    public ICollection<UserMessage> Messages { get; } = [];

    public User(string name)
    {
        Name = name;
    }

    public string Name { get; }

    public void ReceiveMessage(Message message)
    {
        var userMessage = new UserMessage(message);
        Messages.Add(userMessage);
    }

    public void MarkMessageAsRead(Message message)
    {
        foreach (UserMessage currentMessage in Messages)
        {
            if (currentMessage.Message == message)
            {
                currentMessage.IsRead = true;
            }
        }
    }
}
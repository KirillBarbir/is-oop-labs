namespace Itmo.ObjectOrientedProgramming.Lab3;

public class UserMessage
{
    public UserMessage(Message message)
    {
        Message = message;
    }

    public Message Message { get; }

    public bool IsRead { get; internal set; }
}
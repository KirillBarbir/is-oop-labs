namespace Itmo.ObjectOrientedProgramming.Lab3.MessageFinalPoint;

public class User
{
    private readonly Dictionary<Message, MessageStatus> _messages = [];
    private readonly Dictionary<Message, int> _messageReceiveAmount = [];

    public User(string name)
    {
        Name = name;
    }

    public string Name { get; }

    public void ReceiveMessage(Message message)
    {
        _messages.TryAdd(message, MessageStatus.Unread);
        if (_messageReceiveAmount.ContainsKey(message))
        {
            _messageReceiveAmount[message]++;
            return;
        }

        _messageReceiveAmount.TryAdd(message, 1);
    }

    public ResultType ReadMessage(Message message)
    {
        if (!_messages.TryGetValue(message, out MessageStatus read))
        {
            return ResultType.Failure;
        }

        if (read == MessageStatus.Read)
        {
            return ResultType.Failure;
        }

        _messages[message] = MessageStatus.Read;
        return ResultType.Success;
    }

    public bool IsMessageRead(Message message)
    {
        _messages.TryGetValue(message, out MessageStatus read);
        return read == MessageStatus.Read;
    }

    public int MessageReceived(Message message)
    {
        _messageReceiveAmount.TryGetValue(message, out int amount);
        return amount;
    }
}
namespace Itmo.ObjectOrientedProgramming.Lab3.MessageFinalPoint;

public class Messenger : IMessageFinalPoint
{
    public void ReceiveMessage(Message message)
    {
        Console.WriteLine($"Messenger: {message}");
    }
}
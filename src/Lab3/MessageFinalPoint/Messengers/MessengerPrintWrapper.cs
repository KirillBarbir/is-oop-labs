namespace Itmo.ObjectOrientedProgramming.Lab3.MessageFinalPoint.Messages;

public class MessengerPrintWrapper : IMessengerPrintWrapper
{
    public void Print(string text)
    {
        Console.WriteLine(text);
    }
}
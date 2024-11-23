namespace Itmo.ObjectOrientedProgramming.Lab3.Destinations;

public interface IDestination
{
    public void SendMessage(Message message);

    public IDestination Clone();
}
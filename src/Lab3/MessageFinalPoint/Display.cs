using Itmo.ObjectOrientedProgramming.Lab3.MessageFinalPoint.DisplayDrivers;
using System.Drawing;

namespace Itmo.ObjectOrientedProgramming.Lab3.MessageFinalPoint;

public class Display : IMessageFinalPoint
{
    public Display(IDisplayDriver driver, Color color)
    {
        Driver = driver;
        Color = color;
        Driver.SetColor(Color);
    }

    public Color Color { get; }

    public IDisplayDriver Driver { get; }

    public void SetColor(Color color)
    {
        Driver.SetColor(color);
    }

    public void ReceiveMessage(Message message)
    {
        Driver.Clear();
        Driver.Print(message.ToString());
    }
}
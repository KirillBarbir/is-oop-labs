using Itmo.ObjectOrientedProgramming.Lab3.MessageFinalPoint.Displays.DisplayDrivers;
using System.Drawing;

namespace Itmo.ObjectOrientedProgramming.Lab3.MessageFinalPoint.Displays;

public class Display
{
    public Display(IDisplayDriver driver)
    {
        Driver = driver;
        Driver.SetColor(Color);
    }

    public Color Color { get; }

    public IDisplayDriver Driver { get; }

    public void SetColor(Color color)
    {
        Driver.SetColor(color);
    }

    public void ReceiveMessage(string text)
    {
        Driver.Clear();
        Driver.Print(text);
    }
}
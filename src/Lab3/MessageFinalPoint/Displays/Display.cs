using Itmo.ObjectOrientedProgramming.Lab3.MessageFinalPoint.Displays.DisplayDrivers;
using System.Drawing;

namespace Itmo.ObjectOrientedProgramming.Lab3.MessageFinalPoint.Displays;

public class Display
{
    private readonly IDisplayDriver _driver;

    public Display(IDisplayDriver driver)
    {
        _driver = driver;
    }

    public void SetColor(Color color)
    {
        _driver.SetColor(color);
    }

    public void ReceiveMessage(string text)
    {
        _driver.Clear();
        _driver.Print(text);
    }
}
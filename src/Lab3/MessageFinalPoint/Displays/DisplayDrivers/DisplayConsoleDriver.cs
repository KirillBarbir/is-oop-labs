using System.Drawing;

namespace Itmo.ObjectOrientedProgramming.Lab3.MessageFinalPoint.Displays.DisplayDrivers;

public class DisplayConsoleDriver : IDisplayDriver
{
    public Color Color { get; private set; }

    public void Clear()
    {
        Console.Clear();
    }

    public void SetColor(Color color)
    {
        Color = color;
    }

    public void Print(string? text)
    {
        if (text == null)
        {
            return;
        }

        Console.WriteLine(Crayon.Output.Rgb(Color.R, Color.G, Color.B).Text(text));
    }
}
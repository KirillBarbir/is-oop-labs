using System.Drawing;

namespace Itmo.ObjectOrientedProgramming.Lab3.MessageFinalPoint.DisplayDrivers;

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

    public void Print(string text)
    {
        Console.WriteLine(Crayon.Output.Rgb(Color.R, Color.G, Color.B).Text(text));
    }
}
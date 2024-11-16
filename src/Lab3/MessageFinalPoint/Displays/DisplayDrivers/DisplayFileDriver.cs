using System.Drawing;

namespace Itmo.ObjectOrientedProgramming.Lab3.MessageFinalPoint.Displays.DisplayDrivers;

public class DisplayFileDriver : IDisplayDriver
{
    public Color Color { get; private set; }

    public string FileName { get; }

    public DisplayFileDriver(string fileName)
    {
        FileName = fileName;
    }

    public void Clear()
    {
        File.Delete(FileName);
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

        File.AppendAllText(
                FileName,
                Crayon.Output.Rgb(Color.R, Color.G, Color.B).Text(text) + Environment.NewLine);
    }
}
using System.Drawing;

namespace Itmo.ObjectOrientedProgramming.Lab3.MessageFinalPoint.DisplayDrivers;

public interface IDisplayDriver
{
    void Clear();

    void SetColor(Color color);

    void Print(string text);
}
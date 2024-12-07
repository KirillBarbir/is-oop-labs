namespace Itmo.ObjectOrientedProgramming.Lab4;

public class ModeWrapper
{
    public string? Mode { get; private set; }

    public void SetMode(string? mode)
    {
        Mode = mode;
    }
}
namespace Itmo.ObjectOrientedProgramming.Lab1;

internal enum ExecutingResult
{
    Success,
    Failure,
}

public record SpeedResult
{
    internal double Speed { get; }

    internal ExecutingResult Result { get; }

    internal SpeedResult(double speed, ExecutingResult result)
    {
        Speed = speed;
        Result = result;
    }
}
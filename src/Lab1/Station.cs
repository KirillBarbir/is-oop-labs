namespace Itmo.ObjectOrientedProgramming.Lab1;

public class Station : Railway
{
    private double SpeedLimit { get; }

    public Station(double length, double speedLimit) : base(length)
    {
        SpeedLimit = speedLimit;
    }

    public override SpeedResult DriveThrough(double speed, double accuracy, double maxForce, double mass, double acceleration = 0)
    {
        ExecutingResult outputExecutingResult = ExecutingResult.Success;
        if (SpeedLimit < speed)
        {
            // Too high speed;
            outputExecutingResult = ExecutingResult.Failure;
        }

        SpeedResult newSpeedResult = Iterate(speed, accuracy);
        if (outputExecutingResult != ExecutingResult.Success)
        {
            var outputSpeedResult = new SpeedResult(newSpeedResult.Speed, ExecutingResult.Failure);
            return outputSpeedResult;
        }

        return newSpeedResult;
    }
}
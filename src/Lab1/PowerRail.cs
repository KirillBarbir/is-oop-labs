namespace Itmo.ObjectOrientedProgramming.Lab1;

public class PowerRail : Railway
{
    private double Force { get; }

    public PowerRail(double length, double force) : base(length)
    {
        Force = force;
    }

    public override SpeedResult DriveThrough(double speed, double accuracy, double maxForce, double mass, double acceleration)
    {
        ExecutingResult outputExecutingResult = ExecutingResult.Success;
        if (Force > maxForce)
        {
            // Applied force is too high;
            outputExecutingResult = ExecutingResult.Failure;
        }

        double newAcceleration = acceleration + (Force / mass);
        SpeedResult newSpeedResult = Iterate(speed, accuracy, newAcceleration);
        if (outputExecutingResult != ExecutingResult.Success)
        {
            var outputSpeedResult = new SpeedResult(newSpeedResult.Speed, ExecutingResult.Failure);
            return outputSpeedResult;
        }

        return newSpeedResult;
    }
}
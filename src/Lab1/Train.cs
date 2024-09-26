namespace Itmo.ObjectOrientedProgramming.Lab1;

public class Train
{
    internal double Speed { get; private set; }

    private double Mass { get; }

    private double Acceleration { get; set; }

    private double MaxForce { get; }

    public Train(double mass, double maxForce, double speed = 0.0,   double acceleration = 0.0)
    {
        if (mass < 0)
        {
            throw new ArgumentException("Mass cannot be negative");
        }

        if (maxForce < 0)
        {
            throw new ArgumentException("MaxForce cannot be negative");
        }

        Mass = mass;
        Speed = speed;
        Acceleration = acceleration;
        MaxForce = maxForce;
    }

    public bool GoThroughRailway(Railway railway, double accuracy)
    {
        SpeedResult newSpeedResult = railway.DriveThrough(Speed, accuracy, MaxForce, Mass, Acceleration);
        Speed = newSpeedResult.Speed;
        if (newSpeedResult.Result != ExecutingResult.Success)
        {
            return false;
        }

        return true;
    }
}
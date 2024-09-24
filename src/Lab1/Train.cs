namespace Itmo.ObjectOrientedProgramming.Lab1;

public class Train
{
    internal double Speed { get; private set; }

    private double Mass { get; }

    private double Acceleration { get; set; }

    private double MaxForce { get; }

    public Train(double mass, double maxForce, double speed = 0.0,   double acceleration = 0.0)
    {
        Mass = mass;
        Speed = speed;
        Acceleration = acceleration;
        MaxForce = maxForce;
    }

    public bool GoThroughRailway(Railway railway, double accuracy)
    {
        double newSpeed = railway.DriveThrough(Speed, accuracy, MaxForce, Mass, Acceleration);
        if (newSpeed < 0)
        {
            return false;
        }

        Speed = newSpeed;
        return true;
    }
}
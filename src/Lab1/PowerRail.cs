namespace Itmo.ObjectOrientedProgramming.Lab1;

public class PowerRail : Railway
{
    private double Force { get; }

    public PowerRail(double length, double force) : base(length)
    {
        Force = force;
    }

    public override double DriveThrough(double speed, double accuracy, double maxForce, double mass, double acceleration)
    {
        if (Force > maxForce)
        {
            return -1; // TODO: global constant?
        }

        double newAcceleration = acceleration + (Force / mass);
        double newSpeed = Iterate(speed, accuracy, newAcceleration);
        return newSpeed;
    }
}
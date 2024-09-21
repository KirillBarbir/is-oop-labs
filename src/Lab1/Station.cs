namespace Itmo.ObjectOrientedProgramming.Lab1;

public class Station : Railway
{
    private double SpeedLimit { get; }

    public Station(double length, double speedLimit) : base(length)
    {
        SpeedLimit = speedLimit;
    }

    public override double DriveThrough(double speed, double accuracy, double maxForce, double mass, double acceleration = 0)
    {
        if (SpeedLimit < speed)
        {
            Console.WriteLine("Too much speed");
            return -1;
        }

        if (Iterate(speed, accuracy, acceleration) < 0)
        {
            return -1;
        }

        return speed;
    }
}
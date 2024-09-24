namespace Itmo.ObjectOrientedProgramming.Lab1;

public class Railway
{
    private protected double Length { get; }

    public Railway(double length)
    {
        Length = length;
    }

    public virtual double DriveThrough(double speed, double accuracy, double maxForce, double mass, double acceleration = 0)
    {
        if (Iterate(speed, accuracy, acceleration) < 0)
        {
            return -1;
        }

        return speed;
    }

    private protected double Iterate(double speed, double accuracy, double acceleration = 0)
    {
        double resultSpeed = speed;
        double lengthLeft = Length;
        while (lengthLeft > 0)
        {
            resultSpeed += acceleration * accuracy;
            double moved = resultSpeed * accuracy;
            lengthLeft -= moved;

            if (moved <= 0)
            {
                return -1;
            }
        }

        return resultSpeed;
    }
}

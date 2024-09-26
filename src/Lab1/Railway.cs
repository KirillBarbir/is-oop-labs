namespace Itmo.ObjectOrientedProgramming.Lab1;

public class Railway
{
    private double Length { get; }

    public Railway(double length)
    {
        Length = length;
    }

    public virtual SpeedResult DriveThrough(double speed, double accuracy, double maxForce, double mass, double acceleration = 0)
    {
        return Iterate(speed, accuracy, acceleration);
    }

    private protected SpeedResult Iterate(double speed, double accuracy, double acceleration = 0)
    {
        ExecutingResult outputExecutingResult = ExecutingResult.Success;
        double resultSpeed = speed;
        double lengthLeft = Length;
        while (lengthLeft > 0)
        {
            resultSpeed += acceleration * accuracy;
            double moved = resultSpeed * accuracy;
            lengthLeft -= moved;

            if (moved <= 0)
            {
                // Unable to drive through railway;
                outputExecutingResult = ExecutingResult.Failure;
                var failureOutput = new SpeedResult(resultSpeed, outputExecutingResult);
                return failureOutput;
            }
        }

        var output = new SpeedResult(resultSpeed, outputExecutingResult);
        return output;
    }
}

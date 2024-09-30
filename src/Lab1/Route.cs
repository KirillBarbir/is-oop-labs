namespace Itmo.ObjectOrientedProgramming.Lab1;

public class Route
{
    private double MaxSpeed { get; }

    private Railway[] Railways { get; }

    public Route(double maxSpeed, Railway[] railways)
    {
        MaxSpeed = maxSpeed;
        Railways = railways;
    }

    public bool GoThroughRoute(Train train, double accuracy)
    {
        bool routeComplete = true;
        foreach (Railway t in Railways)
        {
            routeComplete = train.GoThroughRailway(t, accuracy);

            if (!routeComplete)
            {
                break;
            }
        }

        if (train.Speed > MaxSpeed)
        {
            Console.WriteLine("Route incomplete: too high speed");
            return false;
        }

        return routeComplete;
    }
}
namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.AbsolutePaths;

public class AbsolutePathDecider : IAbsolutePathDecider
{
    public IAbsolutePathExecutor? Decide(string? mode)
    {
        if (mode == "local")
        {
            return new LocalAbsolutePathExecutor();
        }

        return null;
    }
}
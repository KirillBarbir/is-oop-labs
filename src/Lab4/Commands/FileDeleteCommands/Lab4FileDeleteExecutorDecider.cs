namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.FileDeleteCommands;

public class Lab4FileDeleteExecutorDecider : IFileDeleteExecutorDecider
{
    public IFileDeleteExecutor? Decide(string mode)
    {
        if (mode == "local")
        {
            return new LocalFileDeleteExecutor();
        }

        return null;
    }
}
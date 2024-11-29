namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.FileShowCommands;

public class FileShowExecutorDecider : IFileShowExecutorDecider
{
    public IFileShowExecutor? Decide(string? mode)
    {
        if (mode == "local")
        {
            return new LocalFileShowExecutor();
        }

        return null;
    }
}
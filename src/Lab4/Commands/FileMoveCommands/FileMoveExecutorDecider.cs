namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.FileMoveCommands;

public class FileMoveExecutorDecider : IFileMoveExecutorDecider
{
    public IFileMoveExecutor? Decide(string? mode)
    {
        if (mode == "local")
        {
            return new LocalFileMoveExecutor();
        }

        return null;
    }
}
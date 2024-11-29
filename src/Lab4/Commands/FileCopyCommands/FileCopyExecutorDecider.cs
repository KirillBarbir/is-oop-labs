namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.FileCopyCommands;

public class FileCopyExecutorDecider : IFileCopyExecutorDecider
{
    public IFileCopyExecutor? Decide(string? mode)
    {
        if (mode == "local")
        {
            return new LocalFileCopyExecutor();
        }

        return null;
    }
}
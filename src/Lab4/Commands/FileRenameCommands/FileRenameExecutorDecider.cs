namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.FileRenameCommands;

public class FileRenameExecutorDecider : IFileRenameExecutorDecider
{
    public IFileRenameExecutor? Decide(string? mode)
    {
        if (mode == "local")
        {
            return new LocalFileRenameExecutor();
        }

        return null;
    }
}
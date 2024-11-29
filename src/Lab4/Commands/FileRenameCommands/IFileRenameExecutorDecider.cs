namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.FileRenameCommands;

public interface IFileRenameExecutorDecider
{
    IFileRenameExecutor? Decide(string? mode);
}
namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.FileDeleteCommands;

public interface IFileDeleteExecutorDecider
{
    IFileDeleteExecutor? Decide(string? mode);
}
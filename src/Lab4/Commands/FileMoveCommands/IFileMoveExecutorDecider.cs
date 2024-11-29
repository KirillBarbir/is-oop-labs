namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.FileMoveCommands;

public interface IFileMoveExecutorDecider
{
    IFileMoveExecutor? Decide(string? mode);
}
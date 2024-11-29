namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.FileShowCommands;

public interface IFileShowExecutorDecider
{
    IFileShowExecutor? Decide(string? mode);
}
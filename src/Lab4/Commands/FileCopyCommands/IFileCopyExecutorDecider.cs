namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.FileCopyCommands;

public interface IFileCopyExecutorDecider
{
    IFileCopyExecutor? Decide(string? mode);
}
namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeListCommands;

public interface ITreeListExecutorDecider
{
    ITreeListExecutor? Decide(string? mode);
}
namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeGotoCommands;

public interface ITreeGotoExecutorDecider
{
    ITreeGotoExecutor? Decide(string? mode);
}
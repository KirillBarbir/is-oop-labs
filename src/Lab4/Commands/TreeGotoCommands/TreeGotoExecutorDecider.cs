namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeGotoCommands;

public class TreeGotoExecutorDecider : ITreeGotoExecutorDecider
{
    public ITreeGotoExecutor? Decide(string? mode)
    {
        if (mode == "local")
        {
            return new LocalTreeGotoExecutor();
        }

        return null;
    }
}
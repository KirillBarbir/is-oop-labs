namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeListCommands;

public class TreeListExecutorDecider : ITreeListExecutorDecider
{
    public ITreeListExecutor? Decide(string? mode)
    {
        if (mode == "local")
        {
            return new LocalTreeListExecutor();
        }

        return null;
    }
}
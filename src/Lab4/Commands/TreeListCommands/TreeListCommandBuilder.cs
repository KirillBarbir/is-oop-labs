namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeListCommands;

public class TreeListCommandBuilder : BasicCommandBuilder
{
    private int _depth = 1;
    private ITreeListExecutorDecider? _treeListExecutorDecider;

    public override ICommand? Build()
    {
        if (AbsolutePath is null || _treeListExecutorDecider is null || Mode is null)
        {
            return null;
        }

        return new TreeListCommand(AbsolutePath, _depth, _treeListExecutorDecider.Decide(Mode.Mode));
    }

    public TreeListCommandBuilder WithDepth(int depth)
    {
        _depth = depth;
        return this;
    }

    public TreeListCommandBuilder WithDecider(ITreeListExecutorDecider decider)
    {
        _treeListExecutorDecider = decider;
        return this;
    }
}
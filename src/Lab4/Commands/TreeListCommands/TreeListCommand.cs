namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeListCommands;

public class TreeListCommand : ICommand
{
    private readonly AbsolutePath _absolutePath;
    private readonly int _depth;
    private readonly ITreeListExecutor? _treeListExecutor;

    public TreeListCommand(AbsolutePath path, int depth, ITreeListExecutor? treeListExecutor)
    {
        _absolutePath = path;
        _depth = depth;
        _treeListExecutor = treeListExecutor;
    }

    public void Execute()
    {
        _treeListExecutor?.Print(_absolutePath, _depth);
    }
}
using Itmo.ObjectOrientedProgramming.Lab4.Commands.AbsolutePaths;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeGotoCommands;

public class TreeGotoCommand : ICommand
{
    private readonly AbsolutePath _path;
    private readonly string? _newPath;
    private readonly ITreeGotoExecutor? _treeGotoExecutor;

    public TreeGotoCommand(AbsolutePath path, string? newPath, ITreeGotoExecutor? treeGotoExecutor)
    {
        _path = path;
        _newPath = newPath;
        _treeGotoExecutor = treeGotoExecutor;
    }

    public void Execute()
    {
        if (_newPath is null)
        {
            return;
        }

        _treeGotoExecutor?.TreeGoto(_path, _newPath);
    }
}
namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeGotoCommands;

public class TreeGotoCommandBuilder : BasicCommandBuilder
{
    private ITreeGotoExecutorDecider? _treeGotoExecutorDecider;
    private string? _newPath;

    public override ICommand? Build()
    {
        if (_treeGotoExecutorDecider is null || AbsolutePath is null || Mode is null)
        {
            return null;
        }

        return new TreeGotoCommand(AbsolutePath, AbsolutePath.CreateAbsolutePath(_newPath), _treeGotoExecutorDecider.Decide(Mode.Mode));
    }

    public TreeGotoCommandBuilder WithDecider(ITreeGotoExecutorDecider treeGotoExecutorDecider)
    {
        _treeGotoExecutorDecider = treeGotoExecutorDecider;
        return this;
    }

    public TreeGotoCommandBuilder WithPath(string path)
    {
        _newPath = path;
        return this;
    }
}
using Itmo.ObjectOrientedProgramming.Lab4.Filesystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeListCommands;

public class TreeListCommandBuilder : BasicCommandBuilder
{
    private int _depth = 1;
    private string _outputMode = "console";

    public override ICommand? Build()
    {
        if (Mode?.Mode is null || Filesystems is null ||
            !Filesystems.TryGetValue(Mode.Mode, out IFilesystem? filesystem))
        {
            return null;
        }

        return new TreeListCommand(_depth, filesystem, _outputMode);
    }

    public TreeListCommandBuilder WithDepth(int depth)
    {
        _depth = depth;
        return this;
    }

    public TreeListCommandBuilder WithOutputMode(string mode)
    {
        _outputMode = mode;
        return this;
    }
}
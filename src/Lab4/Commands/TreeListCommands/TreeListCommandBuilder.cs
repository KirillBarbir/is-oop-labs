using Itmo.ObjectOrientedProgramming.Lab4.Filesystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeListCommands;

public class TreeListCommandBuilder : BasicCommandBuilder
{
    private int _depth = 1;

    public override ICommand? Build()
    {
        if (Mode?.Mode is null || Filesystems is null ||
            !Filesystems.TryGetValue(Mode.Mode, out IFilesystem? filesystem))
        {
            return null;
        }

        return new TreeListCommand(_depth, filesystem);
    }

    public TreeListCommandBuilder WithDepth(int depth)
    {
        _depth = depth;
        return this;
    }
}
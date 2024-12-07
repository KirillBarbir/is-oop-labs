using Itmo.ObjectOrientedProgramming.Lab4.Filesystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeGotoCommands;

public class TreeGotoCommandBuilder : BasicCommandBuilder
{
    private string? _newPath;

    public override ICommand? Build()
    {
        if (Mode?.Mode is null || Filesystems is null ||
            !Filesystems.TryGetValue(Mode.Mode, out IFilesystem? filesystem))
        {
            return null;
        }

        return new TreeGotoCommand(_newPath, filesystem);
    }

    public TreeGotoCommandBuilder WithPath(string path)
    {
        _newPath = path;
        return this;
    }
}
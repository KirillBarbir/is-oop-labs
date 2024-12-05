using Itmo.ObjectOrientedProgramming.Lab4.Filesystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.FileDeleteCommands;

public class FileDeleteCommandBuilder : BasicCommandBuilder
{
    private string? _path;

    public override ICommand? Build()
    {
        if (Mode?.Mode is null || Filesystems is null ||
            !Filesystems.TryGetValue(Mode.Mode, out IFilesystem? filesystem))
        {
            return null;
        }

        return new FileDeleteCommand(_path, filesystem);
    }

    public FileDeleteCommandBuilder WithFilePath(string path)
    {
        _path = path;
        return this;
    }
}
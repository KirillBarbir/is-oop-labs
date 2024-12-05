using Itmo.ObjectOrientedProgramming.Lab4.Filesystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.FileShowCommands;

public class FileShowCommandBuilder : BasicCommandBuilder
{
    private string? _path;
    private string? _outputMode;

    public override ICommand? Build()
    {
        if (Mode?.Mode is null || Filesystems is null ||
            !Filesystems.TryGetValue(Mode.Mode, out IFilesystem? filesystem) || _outputMode is null)
        {
            return null;
        }

        return new FileShowCommand(_path, _outputMode, filesystem);
    }

    public FileShowCommandBuilder WithPath(string path)
    {
        _path = path;
        return this;
    }

    public FileShowCommandBuilder WithOutputMode(string outputMode)
    {
        _outputMode = outputMode;
        return this;
    }
}
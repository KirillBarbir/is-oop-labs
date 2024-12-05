using Itmo.ObjectOrientedProgramming.Lab4.Filesystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.FileMoveCommands;

public class FileMoveCommandBuilder : BasicCommandBuilder
{
    private string? _sourcePath;
    private string? _destinationPath;

    public override ICommand? Build()
    {
        if (Mode?.Mode is null || Filesystems is null ||
            !Filesystems.TryGetValue(Mode.Mode, out IFilesystem? filesystem))
        {
            return null;
        }

        return new FileMoveCommand(_sourcePath, _destinationPath, filesystem);
    }

    public FileMoveCommandBuilder WithSourcePath(string sourcePath)
    {
        _sourcePath = sourcePath;
        return this;
    }

    public FileMoveCommandBuilder WithDestinationPath(string destinationPath)
    {
        _destinationPath = destinationPath;
        return this;
    }
}
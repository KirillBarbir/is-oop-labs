using Itmo.ObjectOrientedProgramming.Lab4.Filesystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.FileMoveCommands;

public class FileMoveCommand : ICommand
{
    private readonly string? _sourcePath;
    private readonly string? _destinationPath;
    private readonly IFilesystem? _filesystem;

    public FileMoveCommand(string? sourcePath, string? destinationPath, IFilesystem? filesystem)
    {
        _sourcePath = sourcePath;
        _destinationPath = destinationPath;
        _filesystem = filesystem;
    }

    public void Execute()
    {
        if (_sourcePath is null || _destinationPath is null)
        {
            return;
        }

        _filesystem?.FileMove(_sourcePath, _destinationPath);
    }
}
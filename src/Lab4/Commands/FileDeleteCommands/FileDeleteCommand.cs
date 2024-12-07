using Itmo.ObjectOrientedProgramming.Lab4.Filesystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.FileDeleteCommands;

public record FileDeleteCommand : ICommand
{
    private readonly string? _path;

    private readonly IFilesystem? _filesystem;

    public FileDeleteCommand(string? path, IFilesystem? filesystem)
    {
        _path = path;
        _filesystem = filesystem;
    }

    public void Execute()
    {
        if (_filesystem is null || _path is null)
        {
            return;
        }

        _filesystem.DeleteFile(_path);
    }
}
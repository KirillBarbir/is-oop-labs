using Itmo.ObjectOrientedProgramming.Lab4.Filesystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.FileRenameCommands;

public class FileRenameCommand : ICommand
{
    private readonly string? _sourcePath;
    private readonly string _name;
    private readonly IFilesystem? _filesystem;

    public FileRenameCommand(string? sourcePath, string name, IFilesystem? filesystem)
    {
        _sourcePath = sourcePath;
        _name = name;
        _filesystem = filesystem;
    }

    public void Execute()
    {
        if (_sourcePath is null)
        {
            return;
        }

        _filesystem?.FileRename(_sourcePath, _name);
    }
}
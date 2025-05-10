using Itmo.ObjectOrientedProgramming.Lab4.Filesystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeGotoCommands;

public class TreeGotoCommand : ICommand
{
    private readonly string? _newPath;
    private readonly IFilesystem? _filesystem;

    public TreeGotoCommand(string? newPath, IFilesystem? filesystem)
    {
        _newPath = newPath;
        _filesystem = filesystem;
    }

    public void Execute()
    {
        if (_newPath is null)
        {
            return;
        }

        _filesystem?.TreeGoto(_newPath);
    }
}
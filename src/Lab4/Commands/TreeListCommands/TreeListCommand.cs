using Itmo.ObjectOrientedProgramming.Lab4.Filesystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeListCommands;

public class TreeListCommand : ICommand
{
    private readonly int _depth;
    private readonly IFilesystem? _filesystem;

    public TreeListCommand(int depth, IFilesystem? filesystem)
    {
        _depth = depth;
        _filesystem = filesystem;
    }

    public void Execute()
    {
        _filesystem?.TreeList(_depth);
    }
}
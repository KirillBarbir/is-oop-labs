using Itmo.ObjectOrientedProgramming.Lab4.Filesystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeListCommands;

public class TreeListCommand : ICommand
{
    private readonly int _depth;
    private readonly IFilesystem? _filesystem;
    private readonly string _outputMode;

    public TreeListCommand(int depth, IFilesystem? filesystem, string outputMode = "console")
    {
        _depth = depth;
        _filesystem = filesystem;
        _outputMode = outputMode;
    }

    public void Execute()
    {
        _filesystem?.TreeList(_depth, _outputMode);
    }
}
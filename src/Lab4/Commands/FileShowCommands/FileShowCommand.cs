using Itmo.ObjectOrientedProgramming.Lab4.Filesystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.FileShowCommands;

public record FileShowCommand : ICommand
{
    private readonly string? _path;
    private readonly string _outputMode;
    private readonly IFilesystem? _filesystem;

    public FileShowCommand(string? path, string outputMode, IFilesystem? filesystem)
    {
        _path = path;
        _outputMode = outputMode;
        _filesystem = filesystem;
    }

    public void Execute()
    {
        if (_path is null)
        {
            return;
        }

        _filesystem?.OutputFile(_path, _outputMode);
    }
}
namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.FileShowCommands;

public record FileShowCommand : ICommand
{
    private readonly string? _path;
    private readonly string _outputMode;
    private readonly IFileShowExecutor? _showExecutor;

    public FileShowCommand(string? path, string outputMode, IFileShowExecutor? showExecutor)
    {
        _path = path;
        _outputMode = outputMode;
        _showExecutor = showExecutor;
    }

    public void Execute()
    {
        if (_path is null)
        {
            return;
        }

        _showExecutor?.OutputFile(_path, _outputMode);
    }
}
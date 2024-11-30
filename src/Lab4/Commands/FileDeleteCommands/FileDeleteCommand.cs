namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.FileDeleteCommands;

public record FileDeleteCommand : ICommand
{
    private readonly string? _path;

    private readonly IFileDeleteExecutor? _executor;

    public FileDeleteCommand(string? path, IFileDeleteExecutor? executor)
    {
        _path = path;
        _executor = executor;
    }

    public void Execute()
    {
        if (_executor is null || _path is null)
        {
            return;
        }

        _executor.DeleteFile(_path);
    }
}
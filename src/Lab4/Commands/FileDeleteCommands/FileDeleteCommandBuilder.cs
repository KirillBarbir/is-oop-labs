namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.FileDeleteCommands;

public class FileDeleteCommandBuilder : BasicCommandBuilder
{
    private readonly IFileDeleteExecutorDecider _fileDeleteExecutorDecider;
    private string? _path;

    public FileDeleteCommandBuilder(IFileDeleteExecutorDecider fileDeleteExecutorDecider)
    {
        _fileDeleteExecutorDecider = fileDeleteExecutorDecider;
    }

    public override ICommand? Build()
    {
        if (_path is null || Mode is null)
        {
            return null;
        }

        return new FileDeleteCommand(_path, _fileDeleteExecutorDecider.Decide(Mode.Mode));
    }

    public FileDeleteCommandBuilder WithFilePath(string path)
    {
        _path = path;
        return this;
    }
}
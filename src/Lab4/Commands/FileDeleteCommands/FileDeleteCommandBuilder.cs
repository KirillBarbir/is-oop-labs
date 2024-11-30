namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.FileDeleteCommands;

public class FileDeleteCommandBuilder : BasicCommandBuilder
{
    private IFileDeleteExecutorDecider? _fileDeleteExecutorDecider;
    private string? _path;

    public override ICommand? Build()
    {
        if (Mode is null || _fileDeleteExecutorDecider is null || AbsolutePath is null)
        {
            return null;
        }

        return new FileDeleteCommand(AbsolutePath.CreateAbsolutePath(_path), _fileDeleteExecutorDecider.Decide(Mode.Mode));
    }

    public FileDeleteCommandBuilder WithFilePath(string path)
    {
        _path = path;
        return this;
    }

    public FileDeleteCommandBuilder WithDecider(IFileDeleteExecutorDecider decider)
    {
        _fileDeleteExecutorDecider = decider;
        return this;
    }
}
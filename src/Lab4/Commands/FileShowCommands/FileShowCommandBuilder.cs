namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.FileShowCommands;

public class FileShowCommandBuilder : BasicCommandBuilder
{
    private IFileShowExecutorDecider? _fileShowExecutorDecider;
    private string? _path;
    private string? _outputMode;

    public override ICommand? Build()
    {
        if (AbsolutePath is null || _outputMode is null || _fileShowExecutorDecider is null || Mode is null)
        {
            return null;
        }

        return new FileShowCommand(AbsolutePath.CreateAbsolutePath(_path), _outputMode, _fileShowExecutorDecider.Decide(Mode.Mode));
    }

    public FileShowCommandBuilder WithPath(string path)
    {
        _path = path;
        return this;
    }

    public FileShowCommandBuilder WithOutputMode(string outputMode)
    {
        _outputMode = outputMode;
        return this;
    }

    public FileShowCommandBuilder WithDecider(IFileShowExecutorDecider decider)
    {
        _fileShowExecutorDecider = decider;
        return this;
    }
}
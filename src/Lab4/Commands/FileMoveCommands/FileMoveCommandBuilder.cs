namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.FileMoveCommands;

public class FileMoveCommandBuilder : BasicCommandBuilder
{
    private IFileMoveExecutorDecider? _fileMoveExecutorDecider;
    private string? _sourcePath;
    private string? _destinationPath;

    public override ICommand? Build()
    {
        if (_sourcePath is null || _destinationPath is null || Mode is null || _fileMoveExecutorDecider is null)
        {
            return null;
        }

        return new FileMoveCommand(_sourcePath, _destinationPath, _fileMoveExecutorDecider.Decide(Mode.Mode));
    }

    public FileMoveCommandBuilder WithSourcePath(string sourcePath)
    {
        _sourcePath = sourcePath;
        return this;
    }

    public FileMoveCommandBuilder WithDestinationPath(string destinationPath)
    {
        _destinationPath = destinationPath;
        return this;
    }

    public FileMoveCommandBuilder WithDecider(IFileMoveExecutorDecider decider)
    {
        _fileMoveExecutorDecider = decider;
        return this;
    }
}
namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.FileCopyCommands;

public class FileCopyCommandBuilder : BasicCommandBuilder
{
    private IFileCopyExecutorDecider? _fileCopyExecutorDecider;
    private string? _sourcePath;
    private string? _destinationPath;

    public override ICommand? Build()
    {
        if (_sourcePath is null || _destinationPath is null || Mode is null || _fileCopyExecutorDecider is null)
        {
            return null;
        }

        return new FileCopyCommand(_sourcePath, _destinationPath, _fileCopyExecutorDecider.Decide(Mode.Mode));
    }

    public FileCopyCommandBuilder WithSourcePath(string sourcePath)
    {
        _sourcePath = sourcePath;
        return this;
    }

    public FileCopyCommandBuilder WithDestinationPath(string destinationPath)
    {
        _destinationPath = destinationPath;
        return this;
    }

    public FileCopyCommandBuilder WithDecider(IFileCopyExecutorDecider decider)
    {
        _fileCopyExecutorDecider = decider;
        return this;
    }
}
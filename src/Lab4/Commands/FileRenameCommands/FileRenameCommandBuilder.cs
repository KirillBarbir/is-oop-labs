namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.FileRenameCommands;

public class FileRenameCommandBuilder : BasicCommandBuilder
{
    private IFileRenameExecutorDecider? _fileRenameExecutorDecider;
    private string? _sourcePath;
    private string? _name;

    public override ICommand? Build()
    {
        if (AbsolutePath is null || _name is null || Mode is null || _fileRenameExecutorDecider is null)
        {
            return null;
        }

        return new FileRenameCommand(AbsolutePath.CreateAbsolutePath(_sourcePath), _name, _fileRenameExecutorDecider.Decide(Mode.Mode));
    }

    public FileRenameCommandBuilder WithSourcePath(string sourcePath)
    {
        _sourcePath = sourcePath;
        return this;
    }

    public FileRenameCommandBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public FileRenameCommandBuilder WithDecider(IFileRenameExecutorDecider decider)
    {
        _fileRenameExecutorDecider = decider;
        return this;
    }
}
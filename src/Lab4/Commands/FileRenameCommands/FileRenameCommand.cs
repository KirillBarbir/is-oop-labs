namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.FileRenameCommands;

public class FileRenameCommand : ICommand
{
    private readonly string _sourcePath;
    private readonly string _name;
    private readonly IFileRenameExecutor? _fileRenameExecutor;

    public FileRenameCommand(string sourcePath, string name, IFileRenameExecutor? fileRenameExecutor)
    {
        _sourcePath = sourcePath;
        _name = name;
        _fileRenameExecutor = fileRenameExecutor;
    }

    public void Execute()
    {
        _fileRenameExecutor?.FileRename(_sourcePath, _name);
    }
}
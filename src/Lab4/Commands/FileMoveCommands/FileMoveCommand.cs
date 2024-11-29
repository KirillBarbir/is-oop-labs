namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.FileMoveCommands;

public class FileMoveCommand : ICommand
{
    private readonly string _sourcePath;
    private readonly string _destinationPath;
    private readonly IFileMoveExecutor? _fileMoveExecutor;

    public FileMoveCommand(string sourcePath, string destinationPath, IFileMoveExecutor? fileMoveExecutor)
    {
        _sourcePath = sourcePath;
        _destinationPath = destinationPath;
        _fileMoveExecutor = fileMoveExecutor;
    }

    public void Execute()
    {
        _fileMoveExecutor?.FileMove(_sourcePath, _destinationPath);
    }
}
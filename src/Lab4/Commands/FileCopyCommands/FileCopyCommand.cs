namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.FileCopyCommands;

public class FileCopyCommand : ICommand
{
    private readonly string _sourcePath;
    private readonly string _destinationPath;
    private readonly IFileCopyExecutor _fileCopyExecutor;

    public FileCopyCommand(string sourcePath, string destinationPath, IFileCopyExecutor fileCopyExecutor)
    {
        _sourcePath = sourcePath;
        _destinationPath = destinationPath;
        _fileCopyExecutor = fileCopyExecutor;
    }

    public void Execute()
    {
        _fileCopyExecutor.FileCopy(_sourcePath, _destinationPath); // TODO: validate input or find smn to do it
    }
}
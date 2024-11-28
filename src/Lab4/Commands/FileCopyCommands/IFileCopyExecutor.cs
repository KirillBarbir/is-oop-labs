namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.FileCopyCommands;

public interface IFileCopyExecutor
{
    void FileCopy(string sourcePath, string destinationPath);
}
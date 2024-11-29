namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.FileMoveCommands;

public interface IFileMoveExecutor
{
    void FileMove(string sourcePath, string destinationPath);
}
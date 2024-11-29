namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.FileRenameCommands;

public interface IFileRenameExecutor
{
    void FileRename(string sourcePath, string name);
}
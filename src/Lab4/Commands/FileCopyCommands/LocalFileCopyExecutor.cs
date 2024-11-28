namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.FileCopyCommands;

public class LocalFileCopyExecutor : IFileCopyExecutor
{
    public void FileCopy(string sourcePath, string destinationPath)
    {
        File.Copy(sourcePath, destinationPath); // TODO: validate input or find smn to do it
    }
}
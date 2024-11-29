namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.FileCopyCommands;

public class LocalFileCopyExecutor : IFileCopyExecutor
{
    public void FileCopy(string sourcePath, string destinationPath)
    {
        if (File.Exists(destinationPath) && !File.Exists(sourcePath))
        {
            return;
        }

        File.Copy(sourcePath, destinationPath);
    }
}
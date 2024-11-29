namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.FileMoveCommands;

public class LocalFileMoveExecutor : IFileMoveExecutor
{
    public void FileMove(string sourcePath, string destinationPath)
    {
        if (File.Exists(destinationPath) && !File.Exists(sourcePath))
        {
            return;
        }

        File.Copy(sourcePath, destinationPath);
        File.Delete(sourcePath);
    }
}
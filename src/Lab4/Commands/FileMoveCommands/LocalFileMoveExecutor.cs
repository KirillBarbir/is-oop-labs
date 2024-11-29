namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.FileMoveCommands;

public class LocalFileMoveExecutor : IFileMoveExecutor
{
    public void FileMove(string sourcePath, string destinationPath)
    {
        if (!Directory.Exists(destinationPath) || !File.Exists(sourcePath))
        {
            return;
        }

        string[] splitSourcePath = sourcePath.Split('\\');
        if (File.Exists(destinationPath + "\\" + splitSourcePath[^1]))
        {
            return;
        }

        File.Copy(sourcePath, destinationPath + "\\" + splitSourcePath[^1]);
        File.Delete(sourcePath);
    }
}
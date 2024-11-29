namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.FileCopyCommands;

public class LocalFileCopyExecutor : IFileCopyExecutor
{
    public void FileCopy(string sourcePath, string destinationPath)
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
    }
}
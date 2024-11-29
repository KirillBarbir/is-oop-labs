namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.FileRenameCommands;

public class LocalFileRenameExecutor : IFileRenameExecutor
{
    public void FileRename(string sourcePath, string name)
    {
        if (!File.Exists(sourcePath))
        {
            return;
        }

        string[] splitSourcePath = sourcePath.Split('\\');
        splitSourcePath[^1] = name;
        string newPath = string.Join('\\', splitSourcePath);

        if (File.Exists(newPath))
        {
            return;
        }

        File.Copy(sourcePath, newPath);
        File.Delete(sourcePath);
    }
}
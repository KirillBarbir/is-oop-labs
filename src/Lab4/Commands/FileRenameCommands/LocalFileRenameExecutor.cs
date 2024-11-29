namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.FileRenameCommands;

public class LocalFileRenameExecutor : IFileRenameExecutor
{
    public void FileRename(string sourcePath, string name)
    {
        if (!File.Exists(sourcePath))
        {
            return;
        }

        string[] array = sourcePath.Split('\\');
        array[^1] = name;
        string newPath = string.Join('\\', array);

        if (File.Exists(newPath))
        {
            return;
        }

        File.Copy(sourcePath, newPath);
        File.Delete(sourcePath);
    }
}
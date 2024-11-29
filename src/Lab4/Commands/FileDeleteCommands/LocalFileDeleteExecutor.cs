namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.FileDeleteCommands;

public class LocalFileDeleteExecutor : IFileDeleteExecutor
{
    public void DeleteFile(string filePath)
    {
        if (!File.Exists(filePath))
        {
            return;
        }

        File.Delete(filePath);
    }
}
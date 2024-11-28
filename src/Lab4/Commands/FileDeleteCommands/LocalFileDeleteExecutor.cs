namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.FileDeleteCommands;

public class LocalFileDeleteExecutor : IFileDeleteExecutor
{
    public void DeleteFile(string filePath)
    {
        File.Delete(filePath); // TODO: validate input or find smn to do it
    }
}
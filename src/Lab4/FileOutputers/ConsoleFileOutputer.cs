namespace Itmo.ObjectOrientedProgramming.Lab4.FileOutputers;

public class ConsoleFileOutputer : IFileOutputer
{
    public void Output(string sourcePath)
    {
        using var fileStream = new FileStream(sourcePath, FileMode.Open);
        using Stream console = Console.OpenStandardOutput();
        fileStream.CopyTo(console);
    }
}
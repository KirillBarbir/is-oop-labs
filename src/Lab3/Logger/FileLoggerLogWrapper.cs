namespace Itmo.ObjectOrientedProgramming.Lab3.Logger;

public class FileLoggerLogWrapper : IFileLoggerLogWrapper
{
    public void Log(string outputFileName, string text)
    {
        File.AppendAllText(outputFileName, text + Environment.NewLine);
    }
}
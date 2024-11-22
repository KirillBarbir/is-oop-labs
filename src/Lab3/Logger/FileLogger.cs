namespace Itmo.ObjectOrientedProgramming.Lab3.Logger;

public class FileLogger : ILogger
{
    public FileLogger(string outputFileName)
    {
        _outputFileName = outputFileName;
    }

    private readonly string _outputFileName;

    public void Log(string text)
    {
        File.AppendAllText(_outputFileName, text + Environment.NewLine);
    }
}
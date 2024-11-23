namespace Itmo.ObjectOrientedProgramming.Lab3.Logger;

public class FileLogger : ILogger
{
    private readonly string _outputFileName;

    public FileLogger(string outputFileName)
    {
        _outputFileName = outputFileName;
    }

    public void Log(string text)
    {
        File.AppendAllText(_outputFileName, text + Environment.NewLine);
    }
}
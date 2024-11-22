namespace Itmo.ObjectOrientedProgramming.Lab3.Logger;

public class FileLogger : ILogger
{
    private readonly IFileLoggerLogWrapper _fileLoggerLogWrapper;

    public FileLogger(string outputFileName, IFileLoggerLogWrapper fileLoggerLogWrapper)
    {
        OutputFileName = outputFileName;
        _fileLoggerLogWrapper = fileLoggerLogWrapper;
    }

    public string OutputFileName { get; }

    public void Log(string text)
    {
        _fileLoggerLogWrapper.Log(OutputFileName, text);
    }
}
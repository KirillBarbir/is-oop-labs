namespace Itmo.ObjectOrientedProgramming.Lab3.Logger;

public class BasicLogger : ILogger
{
    private readonly IBasicLoggerLogWrapper _basicLoggerLogWrapper;

    public BasicLogger(string outputFileName, IBasicLoggerLogWrapper basicLoggerLogWrapper)
    {
        OutputFileName = outputFileName;
        _basicLoggerLogWrapper = basicLoggerLogWrapper;
    }

    public string OutputFileName { get; }

    public void Log(string text)
    {
        _basicLoggerLogWrapper.Log(OutputFileName, text);
    }
}
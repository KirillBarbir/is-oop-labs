namespace Itmo.ObjectOrientedProgramming.Lab3.Logger;

public class BasicLogger : ILogger
{
    public BasicLogger(string outputFileName)
    {
        OutputFileName = outputFileName;
    }

    public string OutputFileName { get; }

    public void Log(string text)
    {
        File.AppendAllText(OutputFileName, text + Environment.NewLine);
    }
}
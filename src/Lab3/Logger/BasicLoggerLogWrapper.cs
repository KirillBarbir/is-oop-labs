namespace Itmo.ObjectOrientedProgramming.Lab3.Logger;

public class BasicLoggerLogWrapper : IBasicLoggerLogWrapper
{
    public void Log(string outputFileName, string text)
    {
        File.AppendAllText(outputFileName, text + Environment.NewLine);
    }
}
namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.FileShowCommands;

public class LocalFileShowExecutor : IFileShowExecutor
{
    public void OutputFile(string path, string outputMode)
    {
        if (!File.Exists(path))
        {
            return;
        }

        if (outputMode == "console")
        {
            var fileStream = new FileStream(path, FileMode.Open);
            Stream console = Console.OpenStandardOutput();
            fileStream.CopyTo(console);
            fileStream.Close();
            console.Close();
        }
    }
}
namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeListCommands.Outputers;

public class ConsoleOutputer : IOutputer
{
    public void Output(string text)
    {
        Console.WriteLine(text);
    }
}
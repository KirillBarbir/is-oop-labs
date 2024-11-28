using Itmo.ObjectOrientedProgramming.Lab4.InputCommandsHandlers.FileInputCommands;

namespace Itmo.ObjectOrientedProgramming.Lab4;

public class Program
{
    public static void Main(string[] args)
    {
        var innerHandler = new FileDeleteInputCommandHandler();
        var fileHandler = new FileInputCommandsHandler(innerHandler);
        var runner = new Runner(fileHandler);
        runner.Run(args);
    }
}
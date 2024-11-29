using Itmo.ObjectOrientedProgramming.Lab4.Commands.FileDeleteCommands;
using Itmo.ObjectOrientedProgramming.Lab4.InputCommandsHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.InputCommandsHandlers.FileInputCommandHandlers;

namespace Itmo.ObjectOrientedProgramming.Lab4;

public class Program
{
    public static void Main(string[] args)
    {
        var innerHandler = new FileDeleteInputCommandHandler(new FileDeleteExecutorDecider());
        var fileHandler = new FileInputCommandsHandler(innerHandler);
        var connectHandler = new ConnectInputCommandHandler();
        var runner = new Runner(fileHandler.AddNext(connectHandler));
        runner.Run(args);
    }
}
using Itmo.ObjectOrientedProgramming.Lab4.Commands.AbsolutePaths;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.FileCopyCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.FileDeleteCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.FileMoveCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.FileRenameCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.FileShowCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeGotoCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeListCommands;
using Itmo.ObjectOrientedProgramming.Lab4.InputCommandsHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.InputCommandsHandlers.FileInputCommandHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.InputCommandsHandlers.TreeInputCommandHandlers;

namespace Itmo.ObjectOrientedProgramming.Lab4;

public class Program
{
    public static void Main(string[] args)
    {
        var fileInnerHandler = new FileDeleteInputCommandHandler(new FileDeleteExecutorDecider());
        fileInnerHandler.AddNext(new FileCopyInputCommandHandler(new FileCopyExecutorDecider()));
        fileInnerHandler.AddNext(new FileMoveInputCommandHandler(new FileMoveExecutorDecider()));
        fileInnerHandler.AddNext(new FileShowInputCommandHandler(new FileShowExecutorDecider()));
        fileInnerHandler.AddNext(new FileRenameInputCommandHandler(new FileRenameExecutorDecider()));
        var handler = new FileInputCommandsHandler(fileInnerHandler);
        var treeInnerHandler = new TreeGotoInputCommandHandler(new TreeGotoExecutorDecider());
        treeInnerHandler.AddNext(new TreeListInputCommandHandler(new TreeListExecutorDecider()));
        var connectHandler = new ConnectInputCommandHandler();
        handler.AddNext(connectHandler);
        handler.AddNext(new TreeInputCommandsHandler(treeInnerHandler));
        var runner = new Runner(handler, new AbsolutePathDecider());
        while (true)
        {
            runner.Run(Console.ReadLine()?.Split());
            Console.WriteLine("Reading...");
        }
    }
}
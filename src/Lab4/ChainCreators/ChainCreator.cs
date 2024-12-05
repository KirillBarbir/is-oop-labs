using Itmo.ObjectOrientedProgramming.Lab4.InputCommandsHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.InputCommandsHandlers.FileInputCommandHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.InputCommandsHandlers.TreeInputCommandHandlers;

namespace Itmo.ObjectOrientedProgramming.Lab4.ChainCreators;

public class ChainCreator : IChainCreator
{
    public IInputCommandHandler CreateChain()
    {
        var fileInnerHandler = new FileDeleteInputCommandHandler();
        fileInnerHandler.AddNext(new FileCopyInputCommandHandler());
        fileInnerHandler.AddNext(new FileMoveInputCommandHandler());
        fileInnerHandler.AddNext(new FileShowInputCommandHandler());
        fileInnerHandler.AddNext(new FileRenameInputCommandHandler());
        var handler = new FileInputCommandsHandler(fileInnerHandler);
        var treeInnerHandler = new TreeGotoInputCommandHandler();
        treeInnerHandler.AddNext(new TreeListInputCommandHandler());
        var connectHandler = new ConnectInputCommandHandler();
        handler.AddNext(connectHandler);
        var disconnectHandler = new DisconnectInputCommandHandler();
        handler.AddNext(disconnectHandler);
        handler.AddNext(new TreeInputCommandsHandler(treeInnerHandler));
        return handler;
    }
}
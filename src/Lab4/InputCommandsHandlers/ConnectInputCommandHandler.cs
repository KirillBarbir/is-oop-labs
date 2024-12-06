using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.ConnectCommands;
using Itmo.ObjectOrientedProgramming.Lab4.InputCommandsHandlers.FlagHandling;
using Itmo.ObjectOrientedProgramming.Lab4.InputCommandsHandlers.FlagHandling.FlagCommandBuilders;

namespace Itmo.ObjectOrientedProgramming.Lab4.InputCommandsHandlers;

public class ConnectInputCommandHandler : BaseInputCommandHandler
{
    public override ICommandBuilder? HandleCommand(IEnumerator<string> request)
    {
        if (request.Current is not "connect")
        {
            return Next?.HandleCommand(request);
        }

        if (request.MoveNext() is false)
        {
            return null;
        }

        string address = request.Current;

        if (request.MoveNext() is false)
        {
            return null;
        }

        var builder = new ConnectCommandFlaggedBuilder();
        var handler =
            new GenericFlagHandler<ConnectCommandBuilder, ConnectCommandFlaggedBuilder>("-m", builder, "local");
        return handler.Handle(request)?.WithNewPath(address);
    }
}
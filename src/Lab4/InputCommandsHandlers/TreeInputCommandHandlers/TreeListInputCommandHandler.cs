using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeListCommands;
using Itmo.ObjectOrientedProgramming.Lab4.InputCommandsHandlers.FlagHandling;
using Itmo.ObjectOrientedProgramming.Lab4.InputCommandsHandlers.FlagHandling.FlagCommandBuilders;

namespace Itmo.ObjectOrientedProgramming.Lab4.InputCommandsHandlers.TreeInputCommandHandlers;

public class TreeListInputCommandHandler : BaseInputCommandHandler
{
    public override ICommandBuilder? HandleCommand(IEnumerator<string> request)
    {
        if (request.Current is not "list")
        {
            return Next?.HandleCommand(request);
        }

        if (!request.MoveNext())
        {
            return null;
        }

        var builder = new TreeListCommandFlaggedBuilder();
        var handler =
            new GenericFlagHandler<TreeListCommandBuilder, TreeListCommandFlaggedBuilder>("-d", builder, "1");
        return handler.Handle(request);
    }
}
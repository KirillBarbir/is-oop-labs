using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.FileShowCommands;
using Itmo.ObjectOrientedProgramming.Lab4.InputCommandsHandlers.FlagHandling;
using Itmo.ObjectOrientedProgramming.Lab4.InputCommandsHandlers.FlagHandling.FlagCommandBuilders;

namespace Itmo.ObjectOrientedProgramming.Lab4.InputCommandsHandlers.FileInputCommandHandlers;

public class FileShowInputCommandHandler : BaseInputCommandHandler
{
    public override ICommandBuilder? HandleCommand(IEnumerator<string> request)
    {
        if (request.Current is not "show")
        {
            return Next?.HandleCommand(request);
        }

        if (request.MoveNext() is false)
        {
            return null;
        }

        string path = request.Current;

        if (request.MoveNext() is false)
        {
            return null;
        }

        var builder = new FileShowCommandFlaggedBuilder();
        var handler =
            new GenericFlagHandler<FileShowCommandBuilder, FileShowCommandFlaggedBuilder>("-m", builder, "console");
        return handler.Handle(request)?.WithPath(path);
    }
}
using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.DisconnectCommands;

namespace Itmo.ObjectOrientedProgramming.Lab4.InputCommandsHandlers;

public class DisconnectInputCommandHandler : BaseInputCommandHandler
{
    public override ICommandBuilder? HandleCommand(IEnumerator<string> request)
    {
        if (request.Current is not "disconnect")
        {
            return Next?.HandleCommand(request);
        }

        var builder = new DisconnectCommandBuilder();
        return builder;
    }
}
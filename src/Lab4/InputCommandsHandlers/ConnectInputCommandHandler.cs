using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.ConnectCommands;

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

        string mode = "local";
        if (request.Current is "-m" && request.MoveNext())
        {
            mode = request.Current;
        }

        var builder = new ConnectCommandBuilder();
        return builder.WithNewPath(address).WithNewMode(mode);
    }
}
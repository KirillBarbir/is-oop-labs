using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.FileDeleteCommands;

namespace Itmo.ObjectOrientedProgramming.Lab4.InputCommandsHandlers.FileInputCommands;

public class FileDeleteInputCommandHandler : BaseInputCommandHandler
{
    public override ICommandBuilder? HandleCommand(IEnumerator<string> request)
    {
        if (request.Current is not "delete")
        {
            return Next?.HandleCommand(request);
        }

        if (request.MoveNext() is false)
        {
            return null;
        }

        string path = request.Current;
        var builder = new FileDeleteCommandBuilder(new Lab4FileDeleteExecutorDecider()); // TODO: transfer
        return builder.WithFilePath(path);
    }
}
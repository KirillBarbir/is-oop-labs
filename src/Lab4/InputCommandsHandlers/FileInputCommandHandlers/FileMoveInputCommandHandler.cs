using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.FileMoveCommands;

namespace Itmo.ObjectOrientedProgramming.Lab4.InputCommandsHandlers.FileInputCommandHandlers;

public class FileMoveInputCommandHandler : BaseInputCommandHandler
{
    public override ICommandBuilder? HandleCommand(IEnumerator<string> request)
    {
        if (request.Current is not "move")
        {
            return Next?.HandleCommand(request);
        }

        if (request.MoveNext() is false)
        {
            return null;
        }

        string sourcePath = request.Current;

        if (request.MoveNext() is false)
        {
            return null;
        }

        string destinationPath = request.Current;
        var builder = new FileMoveCommandBuilder();
        return builder
            .WithSourcePath(sourcePath)
            .WithDestinationPath(destinationPath);
    }
}
using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.FileRenameCommands;

namespace Itmo.ObjectOrientedProgramming.Lab4.InputCommandsHandlers.FileInputCommandHandlers;

public class FileRenameInputCommandHandler : BaseInputCommandHandler
{
    public override ICommandBuilder? HandleCommand(IEnumerator<string> request)
    {
        if (request.Current is not "rename")
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

        string name = request.Current;
        var builder = new FileRenameCommandBuilder();
        return builder
            .WithSourcePath(sourcePath)
            .WithName(name);
    }
}
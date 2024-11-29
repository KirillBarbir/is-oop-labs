using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.FileCopyCommands;

namespace Itmo.ObjectOrientedProgramming.Lab4.InputCommandsHandlers.FileInputCommandHandlers;

public class FileCopyInputCommandHandler : BaseInputCommandHandler
{
    private readonly IFileCopyExecutorDecider _fileCopyExecutorDecider;

    public FileCopyInputCommandHandler(IFileCopyExecutorDecider fileCopyExecutorDecider)
    {
        _fileCopyExecutorDecider = fileCopyExecutorDecider;
    }

    public override ICommandBuilder? HandleCommand(IEnumerator<string> request)
    {
        if (request.Current is not "copy")
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
        var builder = new FileCopyCommandBuilder();
        return builder
            .WithSourcePath(sourcePath)
            .WithDestinationPath(destinationPath)
            .WithDecider(_fileCopyExecutorDecider);
    }
}
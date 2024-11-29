using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.FileDeleteCommands;

namespace Itmo.ObjectOrientedProgramming.Lab4.InputCommandsHandlers.FileInputCommandHandlers;

public class FileDeleteInputCommandHandler : BaseInputCommandHandler
{
    private readonly IFileDeleteExecutorDecider _fileDeleteExecutorDecider;

    public FileDeleteInputCommandHandler(IFileDeleteExecutorDecider fileDeleteExecutorDecider)
    {
        _fileDeleteExecutorDecider = fileDeleteExecutorDecider;
    }

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
        var builder = new FileDeleteCommandBuilder();
        return builder.WithFilePath(path).WithDecider(_fileDeleteExecutorDecider);
    }
}
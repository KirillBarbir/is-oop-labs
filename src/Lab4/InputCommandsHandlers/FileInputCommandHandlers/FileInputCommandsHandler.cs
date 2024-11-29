using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.InputCommandsHandlers.FileInputCommandHandlers;

public class FileInputCommandsHandler : BaseInputCommandHandler
{
    private readonly IInputCommandHandler _commandHandler;

    public FileInputCommandsHandler(IInputCommandHandler commandHandler)
    {
        _commandHandler = commandHandler;
    }

    public override ICommandBuilder? HandleCommand(IEnumerator<string> request)
    {
        if (request.Current is not "file")
        {
            return Next?.HandleCommand(request);
        }

        if (request.MoveNext() is false)
        {
            return null;
        }

        ICommandBuilder? commandBuilder = _commandHandler.HandleCommand(request);

        if (commandBuilder is not null)
        {
            return commandBuilder;
        }

        return null;
    }
}
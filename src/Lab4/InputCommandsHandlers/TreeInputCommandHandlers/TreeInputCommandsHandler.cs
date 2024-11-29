using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.InputCommandsHandlers.TreeInputCommandHandlers;

public class TreeInputCommandsHandler : BaseInputCommandHandler
{
    private readonly IInputCommandHandler _commandHandler;

    public TreeInputCommandsHandler(IInputCommandHandler commandHandler)
    {
        _commandHandler = commandHandler;
    }

    public override ICommandBuilder? HandleCommand(IEnumerator<string> request)
    {
        if (request.Current is not "tree")
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
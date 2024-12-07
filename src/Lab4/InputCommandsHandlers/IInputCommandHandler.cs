using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.InputCommandsHandlers;

public interface IInputCommandHandler
{
    IInputCommandHandler AddNext(IInputCommandHandler nextCommandHandler);

    ICommandBuilder? HandleCommand(IEnumerator<string> request);
}
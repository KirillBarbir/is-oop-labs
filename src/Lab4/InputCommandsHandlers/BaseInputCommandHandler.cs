using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.InputCommandsHandlers;

public abstract class BaseInputCommandHandler : IInputCommandHandler
{
    protected IInputCommandHandler? Next { get; private set; }

    public IInputCommandHandler AddNext(IInputCommandHandler nextCommandHandler)
    {
        if (Next is null)
        {
            Next = nextCommandHandler;
        }
        else
        {
            Next.AddNext(nextCommandHandler);
        }

        return this;
    }

    public abstract ICommandBuilder? HandleCommand(IEnumerator<string> request);
}
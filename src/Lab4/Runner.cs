using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.InputCommandsHandlers;

namespace Itmo.ObjectOrientedProgramming.Lab4;

public class Runner
{
    private readonly IInputCommandHandler _handler;

    private readonly ModeWrapper _mode = new ModeWrapper();

    private readonly AbsolutePath? _absolutePath = new AbsolutePath("C:\\gitprojects\\KirillBarbir\\src\\Lab4\\Lab4.csproj"); // TODO: fix

    public Runner(IInputCommandHandler handler)
    {
        _handler = handler;
    }

    public ReturnType Run(IEnumerable<string> args)
    {
        using IEnumerator<string> request = args.GetEnumerator();
        while (request.MoveNext())
        {
            ICommandBuilder? nextBuilder = _handler.HandleCommand(request);
            if (nextBuilder is not null && _mode is not null && _absolutePath is not null)
            {
                ICommand? command = nextBuilder.WithMode(_mode).WithConnectedPath(_absolutePath).Build();
                if (command is not null)
                {
                    command.Execute();
                }
                else
                {
                    Console.WriteLine("I give up");
                    return ReturnType.Failure;
                }
            }
            else
            {
                Console.WriteLine("I give up");
                return ReturnType.Failure;
            }
        }

        return ReturnType.Success;
    }
}
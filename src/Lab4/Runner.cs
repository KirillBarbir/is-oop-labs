using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Filesystems;
using Itmo.ObjectOrientedProgramming.Lab4.InputCommandsHandlers;

namespace Itmo.ObjectOrientedProgramming.Lab4;

public class Runner
{
    private readonly IInputCommandHandler _handler;

    private readonly ModeWrapper _mode = new ModeWrapper();
#pragma warning disable SK1500
    private readonly IDictionary<string, IFilesystem> _supportedFilesystems = new Dictionary<string, IFilesystem>();

// String is definitely IEquitable
#pragma warning restore SK1500
    public Runner(IInputCommandHandler handler)
    {
        _handler = handler;
    }

    public void AddSupportedFilesystemMode(string mode, IFilesystem filesystem)
    {
        _supportedFilesystems.TryAdd(mode, filesystem);
    }

    public ResultType Run(IEnumerable<string>? args)
    {
        if (args is null)
        {
            return ResultType.Failure;
        }

        using IEnumerator<string> request = args.GetEnumerator();
        while (request.MoveNext())
        {
            ICommandBuilder? nextBuilder = _handler.HandleCommand(request);
            if (nextBuilder is not null)
            {
                ICommand? command = nextBuilder.WithMode(_mode).WithFilesystemModes(_supportedFilesystems).Build();
                if (command is not null)
                {
                    command.Execute();
                }
                else
                {
                    Console.WriteLine("I give up");
                    return ResultType.Failure;
                }
            }
            else
            {
                break;
            }
        }

        return ResultType.Success;
    }
}
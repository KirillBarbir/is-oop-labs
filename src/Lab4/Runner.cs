using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Filesystems;
using Itmo.ObjectOrientedProgramming.Lab4.InputCommandsHandlers;

namespace Itmo.ObjectOrientedProgramming.Lab4;

public class Runner
{
    private readonly IInputCommandHandler _handler;

    private readonly ModeWrapper _mode = new ModeWrapper();
    private readonly IDictionary<string, IFilesystem> _supportedFilesystems = new Dictionary<string, IFilesystem>();

    public Runner(IInputCommandHandler handler)
    {
        _handler = handler;
    }

    public void AddSupportedFilesystemMode(string mode, IFilesystem filesystem)
    {
        _supportedFilesystems.TryAdd(mode, filesystem);
    }

    public RunnerResultEnum Run(IEnumerable<string>? args)
    {
        if (args is null)
        {
            return RunnerResultEnum.Failure;
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
                    return RunnerResultEnum.Failure;
                }
            }
            else
            {
                break;
            }
        }

        return RunnerResultEnum.Success;
    }
}
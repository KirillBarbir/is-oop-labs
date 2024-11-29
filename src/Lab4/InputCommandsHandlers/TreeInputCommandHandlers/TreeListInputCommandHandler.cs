using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeListCommands;

namespace Itmo.ObjectOrientedProgramming.Lab4.InputCommandsHandlers.TreeInputCommandHandlers;

public class TreeListInputCommandHandler : BaseInputCommandHandler
{
    private readonly ITreeListExecutorDecider _treeListExecutorDecider;

    public TreeListInputCommandHandler(ITreeListExecutorDecider treeListExecutorDecider)
    {
        _treeListExecutorDecider = treeListExecutorDecider;
    }

    public override ICommandBuilder? HandleCommand(IEnumerator<string> request)
    {
        if (request.Current is not "list")
        {
            return Next?.HandleCommand(request);
        }

        int depth = 1;
        if (request.MoveNext() && request.Current is "-d" && request.MoveNext())
        {
            depth = int.Parse(request.Current);
        }

        var builder = new TreeListCommandBuilder();
        return builder
            .WithDepth(depth)
            .WithDecider(_treeListExecutorDecider);
    }
}